using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BankOfBIT.Models;
//note:  this needed to be done because during development
//ef released v. 6
//ef6 needed to add this
//using System.Data.Entity.Core;

namespace WindowsBankingApplication
{
    /// <summary>
    /// Transaction form - for use of creating an Account Transaction
    /// </summary>
    public partial class frmTransaction : Form
    {
        BankOfBITContext db = new BankOfBITContext();
        BankService.TransactionManagerClient transactionManager;

        ///given:  client and bankaccount data will be retrieved
        ///in this form and passed throughout application
        ///this object will be used to store the current
        ///client and selected bankaccount
        ConstructorData constructorData;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public frmTransaction()
        {
            InitializeComponent();
        }

        /// <summary>
        /// given:  This constructor will be used when returning to frmClient
        /// from another form.  This constructor will pass back
        /// specific information about the client and bank account
        /// based on activites taking place in another form
        /// </summary>
        /// <param name="client">specific client instance</param>
        /// <param name="account">specific bank account instance</param>
        public frmTransaction(ConstructorData constructorData)
        {
            InitializeComponent();
            this.constructorData = constructorData;

            clientNumberMaskedLabel.Text = this.constructorData.BankAccount.Client.ClientNumber.ToString();
            accountNumberMaskedLabel.Text = this.constructorData.BankAccount.AccountNumber.ToString();
            fullNameLabel1.Text = this.constructorData.BankAccount.Client.FullName;
            balanceLabel1.Text = this.constructorData.BankAccount.Balance.ToString("C");
        }

        /// <summary>
        /// given: this code will navigate back to frmClient with
        /// the specific client and account data that launched
        /// this form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //return to client with the data selected for this form
            frmClients frmClients = new frmClients(constructorData);
            frmClients.MdiParent = this.MdiParent;
            frmClients.Show();
            this.Close();

        }

        /// <summary>
        /// Handles the load event of the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTransaction_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            try
            {
                string accountNumberLabelMask = Utility.BusinessRules.AccountFormat(constructorData.BankAccount.Description);
                accountNumberMaskedLabel.Mask = accountNumberLabelMask;

                transactionTypeBindingSource.DataSource = db.TransactionTypes.Where(x => x.Description != "Transfer (Recipient)" &&
                                                            x.Description != "Interest").ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void descriptionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Selected value is Bill Payment
            if (descriptionComboBox.SelectedIndex == 2)
            {
                cboAccountPayee.DataSource = db.Payees.ToList();
                cboAccountPayee.DisplayMember = "Description";
                cboAccountPayee.ValueMember = "Description";
                cboAccountPayee.Visible = true;
                lblAcctPayee.Visible = true;
            }
                //Selected value is Transfer
            else if (descriptionComboBox.SelectedIndex == 3)
            {
                cboAccountPayee.DataSource = db.BankAccounts.Where(x => x.Client.ClientNumber ==
                                                constructorData.BankAccount.Client.ClientNumber && x.AccountNumber !=
                                                constructorData.BankAccount.AccountNumber).ToList();
                cboAccountPayee.DisplayMember = "AccountNumber";
                cboAccountPayee.ValueMember = "BankAccountId";
                
                if (cboAccountPayee.Items.Count == 0)
                {
                    lblNoAccounts.Visible = true;
                    cboAccountPayee.Visible = false;
                    lblAcctPayee.Visible = false;
                }
                else
                {
                    cboAccountPayee.Visible = true;
                    lblAcctPayee.Visible = true;
                }
            }
            else
            {
                lblNoAccounts.Visible = false;
                cboAccountPayee.Visible = false;
                lblAcctPayee.Visible = false;
            }
        }

        /// <summary>
        /// Handles the LinkClicked event of the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Create an instance of the local BankService
            transactionManager = new BankService.TransactionManagerClient();

            double? transaction;

            try
            {
                //Value is non-numeric or less than 0
                if (!Utility.Numeric.isNumeric(txtAmount.Text, System.Globalization.NumberStyles.AllowDecimalPoint))
                {
                    MessageBox.Show("Error - Amount entered must be a non-negative numeric value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //If the selected value of the combobox is Withdrawal, Bill Payment, or Transfer
                else if (descriptionComboBox.SelectedIndex >= 1 && descriptionComboBox.SelectedIndex <= 3)
                {
                    if (double.Parse(txtAmount.Text) > constructorData.BankAccount.Balance)
                    {
                        MessageBox.Show("Error - Insufficient funds.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //Selected value is Withdrawal
                    else if (descriptionComboBox.SelectedIndex == 1)
                    {
                        transaction = transactionManager.Withdrawal(constructorData.BankAccount.BankAccountId, double.Parse(txtAmount.Text),
                                                "Withdrawal from " + constructorData.BankAccount.AccountNumber);
                        evaluateTransaction(transaction);
                    }
                        //Selected value is Bill Payament
                    else if (descriptionComboBox.SelectedIndex == 2)
                    {
                        transaction = transactionManager.BillPayment(constructorData.BankAccount.BankAccountId, double.Parse(txtAmount.Text),
                                                "Bill Payment from " + constructorData.BankAccount.AccountNumber + " to " +
                                                cboAccountPayee.SelectedValue.ToString());
                        evaluateTransaction(transaction);
                    }
                        //Selected value is Transfer
                    else if (descriptionComboBox.SelectedIndex == 3)
                    {
                        int accountId = int.Parse(cboAccountPayee.SelectedValue.ToString());

                        string toAccountNumber = db.BankAccounts.Where(x => x.BankAccountId == accountId).Select(x => x.AccountNumber).SingleOrDefault().ToString();

                        transaction = transactionManager.Transfer(constructorData.BankAccount.BankAccountId, int.Parse(cboAccountPayee.SelectedValue.ToString()),
                                                double.Parse(txtAmount.Text), "Transfer from " + constructorData.BankAccount.AccountNumber +
                                                " to " + toAccountNumber);
                        evaluateTransaction(transaction);
                    }
                }
                else
                {
                    transaction = transactionManager.Deposit(constructorData.BankAccount.BankAccountId, double.Parse(txtAmount.Text),
                                                "Deposit to " + constructorData.BankAccount.AccountNumber);
                    evaluateTransaction(transaction);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error - Could not process your transaction.");
            }
        }

        /// <summary>
        /// Checks if transaction contains a value. If it does, populate the balance label with the new amount
        /// </summary>
        /// <param name="transaction">The new transaction</param>
        private void evaluateTransaction(double? transaction)
        {
            if (transaction == null)
            {
                MessageBox.Show("Error - Could not complete transaction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                balanceLabel1.Text = ((double)transaction).ToString("C");
            }
        }
    }
}
