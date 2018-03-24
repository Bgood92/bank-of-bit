using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using BankOfBIT.Models;
//note:  this needed to be done because during development
//ef released v. 6
//ef6 needed to add this
//using System.Data.Entity.Core;

using System.IO.Ports;      //for rfid assignment

namespace WindowsBankingApplication
{

    /// <summary>
    /// Client Window Form - for use of displaying general client information
    /// </summary>
    public partial class frmClients : Form
    {
        BankOfBITContext db = new BankOfBITContext();

        ///given: client and bankaccount data will be retrieved
        ///in this form and passed throughout application
        ///these variables will be used to store the current
        ///client and selected bankaccount
        ConstructorData constructorData = new ConstructorData();

        /// <summary>
        /// Default constructor
        /// </summary>
        public frmClients()
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
        public frmClients(ConstructorData constructorData)
        {
            InitializeComponent();
            this.constructorData.Client = constructorData.BankAccount.Client;
            this.constructorData.BankAccount = constructorData.BankAccount;
            txtClientNumber.Text = this.constructorData.Client.ClientNumber.ToString();
            txtClientNumber_Leave(txtClientNumber, null);        
        }

        /// <summary>
        /// given: open history form passing data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            //instance of frmHistory passing constructor data
            frmHistory frmHistory = new frmHistory(constructorData);
            //open in frame
            frmHistory.MdiParent = this.MdiParent;
            //show form
            frmHistory.Show();
            this.Close();
        }

        /// <summary>
        /// given: open transaction form passing constructor data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkTransaction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //instance of frmTransaction passing constructor data
            frmTransaction frmTransaction = new frmTransaction(constructorData);
            //open in frame
            frmTransaction.MdiParent = this.MdiParent;
            //show form
            frmTransaction.Show();
            this.Close();
        }

       /// <summary>
       /// Handles the load event of the form
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void frmClients_Load(object sender, EventArgs e)
        {
            //keeps location of form static when opened and closed
            this.Location = new Point(0, 0);
        }

        /// <summary>
        /// Handles the Leave event of the form
        /// </summary>
        private void txtClientNumber_Leave(object sender, EventArgs e)
        {
            try
            {
                // Validate the ClientNumber textbox to assure 8 characters are entered
                if (txtClientNumber.Text.Length == 8)
                {
                    long clientNumber = long.Parse(txtClientNumber.Text);

                    Client client = db.Clients.Where(x => x.ClientNumber == clientNumber).SingleOrDefault();

                    if (client == null)
                    {
                        disableLinks();
                        clearAndFocus();
                        MessageBox.Show("The client number entered does not exist.");                      
                    }
                    else
                    {
                        clientBindingSource.DataSource = client;
                        int clientId = client.ClientId;
                        IQueryable<BankAccount> bankAccounts = db.BankAccounts.Where(x => x.ClientId == clientId);
                        bankAccountBindingSource.DataSource = bankAccounts.ToList();

                        //Used if the user navigates back to the client form from another form
                        if (constructorData.BankAccount != null)
                        {
                            accountNumberComboBox.Text = constructorData.BankAccount.AccountNumber.ToString();
                        }

                        if (bankAccountBindingSource.List.Count == 0)
                        {
                            disableLinks();
                            bankAccountBindingSource.Clear();
                        }
                        else
                        {
                            int bankAccountId = int.Parse(accountNumberComboBox.SelectedValue.ToString());
                            constructorData.BankAccount = db.BankAccounts.Where(x => x.BankAccountId == bankAccountId).SingleOrDefault();
                            
                            enablesLinks();
                        }
                    }

                    accountNumberComboBox.Focus();                    
                }
            }
            catch (Exception ex)
            {
                disableLinks();
                clearAndFocus();
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the FormClosing event
        /// </summary>
        private void frmClients_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.txtClientNumber.Leave -= new System.EventHandler(this.txtClientNumber_Leave);
        }

        /// <summary>
        /// Handles the SelectionChangeCommitted event
        /// </summary>
        private void accountNumberComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int bankAccountId = int.Parse(accountNumberComboBox.SelectedValue.ToString());

            constructorData.BankAccount = db.BankAccounts.Where(x => x.BankAccountId == bankAccountId).SingleOrDefault();
        }

        /// <summary>
        /// Clears the Binding Sources of the form and sets focus to the ClientNumber textbox
        /// </summary>
        private void clearAndFocus()
        {
            clientBindingSource.Clear();
            bankAccountBindingSource.Clear();
            txtClientNumber.Focus();
        }

        /// <summary>
        /// Enables Link controls on the form
        /// </summary>
        private void enablesLinks()
        {
            lnkDetails.Enabled = true;
            lnkTransaction.Enabled = true;
        }

        /// <summary>
        /// Disables Link controls on the form
        /// </summary>
        private void disableLinks()
        {
            lnkDetails.Enabled = false;
            lnkTransaction.Enabled = false;
        }
  }
}
