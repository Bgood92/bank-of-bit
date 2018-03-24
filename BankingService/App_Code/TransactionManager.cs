using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BankOfBIT.Models;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TransactionManager" in code, svc and config file together.
public class TransactionManager : ITransactionManager
{
    BankOfBITContext db = new BankOfBIT.Models.BankOfBITContext();

    /// <summary>
    /// Modifies the balance of the bank account after a deposit has been made
    /// </summary>
    /// <param name="accountId">BankAccountId of the bank account being updated</param>
    /// <param name="amount">The amount being deposited into the bank account</param>
    /// <param name="notes">Transaction notes</param>
    /// <returns>The updated balance of the bank account</returns>
    public double? Deposit(int accountId, double amount, string notes)
    {
        createTransactionRecord(accountId, amount, notes, Utility.TransactionTypeValues.Deposit);
        return updateAccountBalance(accountId, amount, Utility.TransactionTypeValues.Deposit);
    }

    /// <summary>
    /// Modifies the balance of the bank account after a withdrawal has been made
    /// </summary>
    /// <param name="accountId">BankAccountId of the bank account being updated</param>
    /// <param name="amount">The amount being withdrawn from the bank account</param>
    /// <param name="notes">Transaction notes</param>
    /// <returns>The updated balance of the bank account</returns>
    public double? Withdrawal(int accountId, double amount, string notes)
    {
        createTransactionRecord(accountId, amount, notes, Utility.TransactionTypeValues.Withdrawal);
        return updateAccountBalance(accountId, amount, Utility.TransactionTypeValues.Withdrawal);
    }

    /// <summary>
    /// Modifies the balance of the bank account after a bill payment has been made
    /// </summary>
    /// <param name="accountId">BankAccountId of the bank account being updated</param>
    /// <param name="amount">The amount being withdrawn from the bank account for a bill payment</param>
    /// <param name="notes">Transaction notes</param>
    /// <returns>The updated balance of the bank account</returns>
    public double? BillPayment(int accountId, double amount, string notes)
    {
        createTransactionRecord(accountId, amount, notes, Utility.TransactionTypeValues.BillPayment);
        return updateAccountBalance(accountId, amount, Utility.TransactionTypeValues.BillPayment);
    }

    /// <summary>
    /// Modifies the balance of the two bank accounts involved in a transfer
    /// </summary>
    /// <param name="fromAccountId">BankAccountId of the bankAccount transferring out</param>
    /// <param name="toAccountId">BankAccountId of the bankAccount transferring in</param>
    /// <param name="amount">The amount being transferred</param>
    /// <param name="notes">Transaction notes</param>
    /// <returns>The updated balance of the bank account transferring out</returns>
    public double? Transfer(int fromAccountId, int toAccountId, double amount, string notes)
    {
        double? fromBalance = 0;

        try
        {
            fromBalance = updateAccountBalance(fromAccountId, amount, Utility.TransactionTypeValues.Withdrawal);

            updateAccountBalance(toAccountId, amount, Utility.TransactionTypeValues.Deposit);

            createTransactionRecord(fromAccountId, amount, notes, Utility.TransactionTypeValues.Transfer);

            createTransactionRecord(toAccountId, amount, notes, Utility.TransactionTypeValues.TransferRecipient);
        }
        catch (Exception)
        {
            fromBalance = null;
        }

        return fromBalance;
    }

    /// <summary>
    /// Determines the calculated interest and returns the new balance
    /// </summary>
    /// <param name="accountId">Account ID of the bank account being applied the interest</param>
    /// <param name="notes">Interest notes</param>
    /// <returns>The updated balance</returns>
    public double? CalculateInterest(int accountId, string notes)
    {
        BankAccount bankAccount = db.BankAccounts.Where(x => x.BankAccountId == accountId).SingleOrDefault();
        AccountState accountState = bankAccount.AccountState;
        double interestRate = accountState.RateAdjustment(bankAccount);

        double calculatedInterest = (interestRate * bankAccount.Balance * 1) / 12;

        if (calculatedInterest < 0)
        {
            Withdrawal(accountId, Math.Abs(Math.Round(calculatedInterest, 2)), "Withdrawn interest");
        }
        else if (calculatedInterest > 0)
        {
            Deposit(accountId, Math.Round(calculatedInterest, 2), "Deposited interest");
        }

        return bankAccount.Balance;
    }

    /// <summary>
    /// updateAccountBalance - Updates the BankAccount balance and returns the new balance
    /// </summary>
    /// <param name="accountId">BankAccountId of the bank account being updated</param>
    /// <param name="amount">The amount being withdrawn from the bank account for a bill payment</param>
    /// <param name="notes">Transaction notes</param>
    /// <param name="transactionType">The type of transaction</param>
    /// <returns>The updated balance of the corresponding bank account</returns>
    private double? updateAccountBalance(int accountId, double amount, Utility.TransactionTypeValues transactionType)
    {
        double? balance = 0;

        try
        {
            //Returns a record from the BankAccount table
            BankAccount account = (from results in db.BankAccounts where results.BankAccountId == accountId select results).SingleOrDefault();

            if (transactionType == Utility.TransactionTypeValues.Deposit)
            {
                account.Balance += amount;
            }
            else
            {
                //If the account type is anything other than depost, subtract that amount from the balance field
                account.Balance -= amount;
            }

            //Ensures the Bank Account's state corresponds to its new balance
            account.ChangeState();

            //Save changes made to the database
            db.SaveChanges();

            balance = account.Balance;

        }
        catch (Exception)
        {
            balance = null;
        }

        return balance;
    }

    /// <summary>
    /// createTransactionRecord - Creates a new transaction record and inserts it into the transactions table
    /// </summary>
    /// <param name="accountId">BankAccountId of the bank account being updated</param>
    /// <param name="amount">The amount being deposited or withdrawn from the bank account</param>
    /// <param name="notes">Transaction notes</param>
    /// <param name="transactionType">The type of transaction indicated</param>
    private void createTransactionRecord(int accountId, double amount, string notes, Utility.TransactionTypeValues transactionType)
    {
        //Create a new instance of Transaction
        Transaction transaction = new Transaction();

        if (transactionType == Utility.TransactionTypeValues.TransferRecipient || transactionType == Utility.TransactionTypeValues.Deposit)
        {
            transaction.Deposit = amount;
            transaction.Withdrawal = 0;
        }
        else
        {
            transaction.Deposit = 0;
            transaction.Withdrawal = amount;
        }

        //Update the fields of the newly created transaction inside the Transaction table
        transaction.SetNextTransactionNumber();
        transaction.BankAccountId = accountId;
        transaction.TransactionTypeId = (int)transactionType;
        transaction.DateCreated = DateTime.Now;
        transaction.Notes = notes;
        db.Transactions.Add(transaction);

        //Save changes made to the database
        db.SaveChanges();
    }
}
