using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Utility;
using BankOfBIT.Models;
//note:  this needed to be done because during development
//ef released v. 6
//ef6 needed to add this
//using System.Data.Entity.Core;

namespace WindowsBankingApplication
{
    /// <summary>
    /// History form - for use of displaying Account History
    /// </summary>
    public partial class frmHistory : Form
    {
        BankOfBITContext db = new BankOfBITContext();
        ///given:  client and bankaccount data will be retrieved
        ///in this form and passed throughout application
        ///this object will be used to store the current
        ///client and selected bankaccount
        ConstructorData constructorData;

        /// <summary>
        /// Default constructor
        /// </summary>
        public frmHistory()
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
        public frmHistory(ConstructorData constructorData)
        {
            InitializeComponent();
            this.constructorData = constructorData;

            /*
             * Populate the controls in the Client Data groupbox
             */
            clientNumberMaskedLabel.Text = this.constructorData.BankAccount.Client.ClientNumber.ToString();
            accountNumberMaskedLabel.Text = this.constructorData.BankAccount.AccountNumber.ToString();
            fullNameLabel1.Text = this.constructorData.BankAccount.Client.FullName;
            balanceLabel1.Text = this.constructorData.BankAccount.Balance.ToString("C");
        }

        /// <summary>
        /// given:  this code will navigate back to frmClient with
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
        private void frmHistory_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            try
            {
                //Call to the AccountFormat method of the BusinessRules class within the Utility project to set the label mask
                string accountNumberLabelMask = BusinessRules.AccountFormat(constructorData.BankAccount.Description);
                accountNumberMaskedLabel.Mask = accountNumberLabelMask;

                var query = from transResults in db.Transactions                           
                            join typeResults in db.TransactionTypes
                            on transResults.TransactionTypeId equals typeResults.TransactionTypeId
                            where transResults.BankAccountId == constructorData.BankAccount.BankAccountId
                            select new { 
                                transResults.DateCreated, 
                                typeResults.Description, 
                                transResults.Deposit, 
                                transResults.Withdrawal, 
                                transResults.Notes };

                transactionBindingSource.DataSource = query.ToList();
                transactionDataGridView.Columns[0].DefaultCellStyle.Format = "d";
                transactionDataGridView.Columns[2].DefaultCellStyle.Format = "c";
                transactionDataGridView.Columns[3].DefaultCellStyle.Format = "c";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
