using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITransactionManager" in both code and config file together.
[ServiceContract]
public interface ITransactionManager
{
    /// <summary>
    /// Modifies the balance of the bank account after a deposit has been made
    /// </summary>
    /// <param name="accountId">BankAccountId of the bank account being updated</param>
    /// <param name="amount">The amount being deposited into the bank account</param>
    /// <param name="notes">Transaction notes</param>
    /// <returns>The updated balance of the bank account</returns>
	[OperationContract]
	double? Deposit(int accountId, double amount, string notes);

    /// <summary>
    /// Modifies the balance of the bank account after a withdrawal has been made
    /// </summary>
    /// <param name="accountId">BankAccountId of the bank account being updated</param>
    /// <param name="amount">The amount being withdrawn from the bank account</param>
    /// <param name="notes">Transaction notes</param>
    /// <returns>The updated balance of the bank account</returns>
    [OperationContract]
    double? Withdrawal(int accountId, double amount, string notes);

    /// <summary>
    /// Modifies the balance of the bank account after a bill payment has been made
    /// </summary>
    /// <param name="accountId">BankAccountId of the bank account being updated</param>
    /// <param name="amount">The amount being withdrawn from the bank account for a bill payment</param>
    /// <param name="notes">Transaction notes</param>
    /// <returns>The updated balance of the bank account</returns>
    [OperationContract]
    double? BillPayment(int accountId, double amount, string notes);

    /// <summary>
    /// Modifies the balance of the two bank accounts involved in a transfer
    /// </summary>
    /// <param name="fromAccountId">BankAccountId of the bankAccount transferring out</param>
    /// <param name="toAccountId">BankAccountId of the bankAccount transferring in</param>
    /// <param name="amount">The amount being transferred</param>
    /// <param name="notes">Transaction notes</param>
    /// <returns>The updated balance of the bank account transferring out</returns>
    [OperationContract]
    double? Transfer(int fromAccountId, int toAccountId, double amount, string notes);

    [OperationContract]
    double? CalculateInterest(int accountId, string notes);
}
