using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BankOfBIT.Models;

namespace WindowsBankingApplication
{
    public partial class frmBatch : Form
    {

        BankOfBITContext db = new BankOfBIT.Models.BankOfBITContext();

        public frmBatch()
        {
            InitializeComponent();

            
        }

        /// <summary>
        /// given - further code required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBatch_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            //Set the datasource of the institution combobox to the records from the Institutions table
            institutionComboBox.DataSource = db.Institutions.ToList();

            institutionComboBox.Enabled = false;
        }

        /// <summary>
        /// given - further code required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Batch batch = new Batch();

            //given - for use in encryption assignment
            if (txtKey.Text.Trim().Length != 8)
            {
                MessageBox.Show("64 Bit Decryption Key must be entered", "Enter Key");
                txtKey.Focus();
            }

            //Calls batch.ProcessTransmission and passes in the appropriate parameters based on which
            //radio button is selected
            if (radSelect.Checked == true)
            {
                batch.ProcessTransmission(institutionComboBox.SelectedValue.ToString(), txtKey.Text);
                logInformation(batch);
            }
            else if (radAll.Checked == true)
            {
                foreach (Institution institution in db.Institutions)
                {
                    batch.ProcessTransmission(institution.InstituionNumber.ToString(), txtKey.Text);
                    logInformation(batch);
                }
            }
        }

        /// <summary>
        /// Logs data to a log file and outputs it's contents
        /// </summary>
        /// <param name="batch">The Batch object</param>
        private void logInformation(Batch batch)
        {
            string logData;

            logData = batch.WriteLogData();

            rtxtLog.Text += logData + "\n";
        }

        /// <summary>
        /// Handles the CheckChanged event
        /// </summary>
        private void radSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (radSelect.Checked == true)
            {
                institutionComboBox.Enabled = true;
            }
            else
            {
                institutionComboBox.Enabled = false;
            }          
        }
    }
}
