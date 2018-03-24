namespace WindowsBankingApplication
{
    partial class frmClients
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

                #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label clientNumberLabel;
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label fullAddressLabel;
            System.Windows.Forms.Label cityLabel;
            System.Windows.Forms.Label provinceLabel;
            System.Windows.Forms.Label postalCodeLabel;
            System.Windows.Forms.Label dateCreatedLabel;
            System.Windows.Forms.Label accountNumberLabel;
            System.Windows.Forms.Label balanceLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label descriptionLabel2;
            System.Windows.Forms.Label notesLabel;
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.notesLabel1 = new System.Windows.Forms.Label();
            this.bankAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.descriptionLabel3 = new System.Windows.Forms.Label();
            this.descriptionLabel1 = new System.Windows.Forms.Label();
            this.balanceLabel1 = new System.Windows.Forms.Label();
            this.accountNumberComboBox = new System.Windows.Forms.ComboBox();
            this.lnkTransaction = new System.Windows.Forms.LinkLabel();
            this.lnkDetails = new System.Windows.Forms.LinkLabel();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDateCreated = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.lblPostalCode = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.lblProvince = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtClientNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblRFID = new System.Windows.Forms.Label();
            clientNumberLabel = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            fullAddressLabel = new System.Windows.Forms.Label();
            cityLabel = new System.Windows.Forms.Label();
            provinceLabel = new System.Windows.Forms.Label();
            postalCodeLabel = new System.Windows.Forms.Label();
            dateCreatedLabel = new System.Windows.Forms.Label();
            accountNumberLabel = new System.Windows.Forms.Label();
            balanceLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            descriptionLabel2 = new System.Windows.Forms.Label();
            notesLabel = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientNumberLabel
            // 
            clientNumberLabel.AutoSize = true;
            clientNumberLabel.Location = new System.Drawing.Point(45, 54);
            clientNumberLabel.Name = "clientNumberLabel";
            clientNumberLabel.Size = new System.Drawing.Size(154, 25);
            clientNumberLabel.TabIndex = 30;
            clientNumberLabel.Text = "Client Number:";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(45, 85);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(115, 25);
            fullNameLabel.TabIndex = 31;
            fullNameLabel.Text = "Full Name:";
            // 
            // fullAddressLabel
            // 
            fullAddressLabel.AutoSize = true;
            fullAddressLabel.Location = new System.Drawing.Point(45, 119);
            fullAddressLabel.Name = "fullAddressLabel";
            fullAddressLabel.Size = new System.Drawing.Size(97, 25);
            fullAddressLabel.TabIndex = 32;
            fullAddressLabel.Text = "Address:";
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new System.Drawing.Point(45, 155);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new System.Drawing.Size(55, 25);
            cityLabel.TabIndex = 5;
            cityLabel.Text = "City:";
            // 
            // provinceLabel
            // 
            provinceLabel.AutoSize = true;
            provinceLabel.Location = new System.Drawing.Point(321, 155);
            provinceLabel.Name = "provinceLabel";
            provinceLabel.Size = new System.Drawing.Size(102, 25);
            provinceLabel.TabIndex = 33;
            provinceLabel.Text = "Province:";
            // 
            // postalCodeLabel
            // 
            postalCodeLabel.AutoSize = true;
            postalCodeLabel.Location = new System.Drawing.Point(486, 155);
            postalCodeLabel.Name = "postalCodeLabel";
            postalCodeLabel.Size = new System.Drawing.Size(135, 25);
            postalCodeLabel.TabIndex = 34;
            postalCodeLabel.Text = "Postal Code:";
            // 
            // dateCreatedLabel
            // 
            dateCreatedLabel.AutoSize = true;
            dateCreatedLabel.Location = new System.Drawing.Point(45, 191);
            dateCreatedLabel.Name = "dateCreatedLabel";
            dateCreatedLabel.Size = new System.Drawing.Size(145, 25);
            dateCreatedLabel.TabIndex = 35;
            dateCreatedLabel.Text = "Date Created:";
            // 
            // accountNumberLabel
            // 
            accountNumberLabel.AutoSize = true;
            accountNumberLabel.Location = new System.Drawing.Point(45, 56);
            accountNumberLabel.Name = "accountNumberLabel";
            accountNumberLabel.Size = new System.Drawing.Size(177, 25);
            accountNumberLabel.TabIndex = 5;
            accountNumberLabel.Text = "Account Number:";
            // 
            // balanceLabel
            // 
            balanceLabel.AutoSize = true;
            balanceLabel.Location = new System.Drawing.Point(493, 56);
            balanceLabel.Name = "balanceLabel";
            balanceLabel.Size = new System.Drawing.Size(96, 25);
            balanceLabel.TabIndex = 6;
            balanceLabel.Text = "Balance:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(45, 94);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(152, 25);
            descriptionLabel.TabIndex = 7;
            descriptionLabel.Text = "Account State:";
            // 
            // descriptionLabel2
            // 
            descriptionLabel2.AutoSize = true;
            descriptionLabel2.Location = new System.Drawing.Point(493, 95);
            descriptionLabel2.Name = "descriptionLabel2";
            descriptionLabel2.Size = new System.Drawing.Size(150, 25);
            descriptionLabel2.TabIndex = 8;
            descriptionLabel2.Text = "Account Type:";
            // 
            // notesLabel
            // 
            notesLabel.AutoSize = true;
            notesLabel.Location = new System.Drawing.Point(45, 133);
            notesLabel.Name = "notesLabel";
            notesLabel.Size = new System.Drawing.Size(74, 25);
            notesLabel.TabIndex = 10;
            notesLabel.Text = "Notes:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(notesLabel);
            this.groupBox2.Controls.Add(this.notesLabel1);
            this.groupBox2.Controls.Add(descriptionLabel2);
            this.groupBox2.Controls.Add(this.descriptionLabel3);
            this.groupBox2.Controls.Add(descriptionLabel);
            this.groupBox2.Controls.Add(this.descriptionLabel1);
            this.groupBox2.Controls.Add(balanceLabel);
            this.groupBox2.Controls.Add(this.balanceLabel1);
            this.groupBox2.Controls.Add(accountNumberLabel);
            this.groupBox2.Controls.Add(this.accountNumberComboBox);
            this.groupBox2.Controls.Add(this.lnkTransaction);
            this.groupBox2.Controls.Add(this.lnkDetails);
            this.groupBox2.Location = new System.Drawing.Point(13, 358);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(806, 306);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Account Data";
            // 
            // notesLabel1
            // 
            this.notesLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.notesLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Notes", true));
            this.notesLabel1.Location = new System.Drawing.Point(161, 132);
            this.notesLabel1.Name = "notesLabel1";
            this.notesLabel1.Size = new System.Drawing.Size(517, 81);
            this.notesLabel1.TabIndex = 11;
            // 
            // bankAccountBindingSource
            // 
            this.bankAccountBindingSource.DataSource = typeof(BankOfBIT.Models.BankAccount);
            // 
            // descriptionLabel3
            // 
            this.descriptionLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionLabel3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Description", true));
            this.descriptionLabel3.Location = new System.Drawing.Point(578, 95);
            this.descriptionLabel3.Name = "descriptionLabel3";
            this.descriptionLabel3.Size = new System.Drawing.Size(100, 23);
            this.descriptionLabel3.TabIndex = 9;
            // 
            // descriptionLabel1
            // 
            this.descriptionLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "AccountState.Description", true));
            this.descriptionLabel1.Location = new System.Drawing.Point(161, 94);
            this.descriptionLabel1.Name = "descriptionLabel1";
            this.descriptionLabel1.Size = new System.Drawing.Size(136, 23);
            this.descriptionLabel1.TabIndex = 8;
            // 
            // balanceLabel1
            // 
            this.balanceLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.balanceLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Balance", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.balanceLabel1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.balanceLabel1.Location = new System.Drawing.Point(578, 56);
            this.balanceLabel1.Name = "balanceLabel1";
            this.balanceLabel1.Size = new System.Drawing.Size(100, 23);
            this.balanceLabel1.TabIndex = 7;
            this.balanceLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // accountNumberComboBox
            // 
            this.accountNumberComboBox.DataSource = this.bankAccountBindingSource;
            this.accountNumberComboBox.DisplayMember = "AccountNumber";
            this.accountNumberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accountNumberComboBox.FormattingEnabled = true;
            this.accountNumberComboBox.Location = new System.Drawing.Point(161, 53);
            this.accountNumberComboBox.Name = "accountNumberComboBox";
            this.accountNumberComboBox.Size = new System.Drawing.Size(136, 33);
            this.accountNumberComboBox.TabIndex = 6;
            this.accountNumberComboBox.ValueMember = "BankAccountId";
            this.accountNumberComboBox.SelectionChangeCommitted += new System.EventHandler(this.accountNumberComboBox_SelectionChangeCommitted);
            // 
            // lnkTransaction
            // 
            this.lnkTransaction.AutoSize = true;
            this.lnkTransaction.Enabled = false;
            this.lnkTransaction.Location = new System.Drawing.Point(235, 261);
            this.lnkTransaction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkTransaction.Name = "lnkTransaction";
            this.lnkTransaction.Size = new System.Drawing.Size(206, 25);
            this.lnkTransaction.TabIndex = 4;
            this.lnkTransaction.TabStop = true;
            this.lnkTransaction.Text = "Perform Transaction";
            this.lnkTransaction.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTransaction_LinkClicked);
            // 
            // lnkDetails
            // 
            this.lnkDetails.AutoSize = true;
            this.lnkDetails.Enabled = false;
            this.lnkDetails.Location = new System.Drawing.Point(453, 261);
            this.lnkDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkDetails.Name = "lnkDetails";
            this.lnkDetails.Size = new System.Drawing.Size(130, 25);
            this.lnkDetails.TabIndex = 5;
            this.lnkDetails.TabStop = true;
            this.lnkDetails.Text = "View Details";
            this.lnkDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDetails_LinkClicked);
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataSource = typeof(BankOfBIT.Models.Client);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(dateCreatedLabel);
            this.groupBox1.Controls.Add(this.lblDateCreated);
            this.groupBox1.Controls.Add(postalCodeLabel);
            this.groupBox1.Controls.Add(this.lblPostalCode);
            this.groupBox1.Controls.Add(provinceLabel);
            this.groupBox1.Controls.Add(this.lblProvince);
            this.groupBox1.Controls.Add(cityLabel);
            this.groupBox1.Controls.Add(this.lblCity);
            this.groupBox1.Controls.Add(fullAddressLabel);
            this.groupBox1.Controls.Add(this.lblAddress);
            this.groupBox1.Controls.Add(fullNameLabel);
            this.groupBox1.Controls.Add(this.lblFullName);
            this.groupBox1.Controls.Add(clientNumberLabel);
            this.groupBox1.Controls.Add(this.txtClientNumber);
            this.groupBox1.Controls.Add(this.lblRFID);
            this.groupBox1.Location = new System.Drawing.Point(13, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(804, 291);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client Data";
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDateCreated.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "DateCreated", true));
            this.lblDateCreated.Location = new System.Drawing.Point(161, 190);
            this.lblDateCreated.Mask = "00/00/0000";
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(136, 23);
            this.lblDateCreated.TabIndex = 36;
            this.lblDateCreated.Text = "  -  -";
            // 
            // lblPostalCode
            // 
            this.lblPostalCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPostalCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "PostalCode", true));
            this.lblPostalCode.Location = new System.Drawing.Point(578, 154);
            this.lblPostalCode.Mask = "L0L 0L0";
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Size = new System.Drawing.Size(100, 23);
            this.lblPostalCode.TabIndex = 35;
            this.lblPostalCode.Text = "    ";
            // 
            // lblProvince
            // 
            this.lblProvince.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProvince.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "Province", true));
            this.lblProvince.Location = new System.Drawing.Point(390, 154);
            this.lblProvince.Mask = "LL";
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(67, 23);
            this.lblProvince.TabIndex = 34;
            // 
            // lblCity
            // 
            this.lblCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "City", true));
            this.lblCity.Location = new System.Drawing.Point(161, 154);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(136, 23);
            this.lblCity.TabIndex = 6;
            // 
            // lblAddress
            // 
            this.lblAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "FullAddress", true));
            this.lblAddress.Location = new System.Drawing.Point(161, 118);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(517, 23);
            this.lblAddress.TabIndex = 33;
            // 
            // lblFullName
            // 
            this.lblFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFullName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "FullName", true));
            this.lblFullName.Location = new System.Drawing.Point(161, 84);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(517, 23);
            this.lblFullName.TabIndex = 32;
            // 
            // txtClientNumber
            // 
            this.txtClientNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "ClientNumber", true));
            this.txtClientNumber.Location = new System.Drawing.Point(161, 51);
            this.txtClientNumber.Mask = "0000/0000";
            this.txtClientNumber.Name = "txtClientNumber";
            this.txtClientNumber.Size = new System.Drawing.Size(136, 31);
            this.txtClientNumber.TabIndex = 31;
            this.txtClientNumber.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtClientNumber.Leave += new System.EventHandler(this.txtClientNumber_Leave);
            // 
            // lblRFID
            // 
            this.lblRFID.ForeColor = System.Drawing.Color.Red;
            this.lblRFID.Location = new System.Drawing.Point(321, 49);
            this.lblRFID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRFID.Name = "lblRFID";
            this.lblRFID.Size = new System.Drawing.Size(285, 28);
            this.lblRFID.TabIndex = 30;
            this.lblRFID.Text = "RFID unavailable.  Enter Client ID manually.";
            this.lblRFID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmClients
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(829, 715);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmClients";
            this.Text = "Client Information";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClients_FormClosing);
            this.Load += new System.EventHandler(this.frmClients_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel lnkTransaction;
        private System.Windows.Forms.LinkLabel lnkDetails;
        private System.Windows.Forms.Label lblRFID;
        private System.Windows.Forms.MaskedTextBox txtClientNumber;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblCity;
        private EWSoftware.MaskedLabelControl.MaskedLabel lblProvince;
        private EWSoftware.MaskedLabelControl.MaskedLabel lblPostalCode;
        private EWSoftware.MaskedLabelControl.MaskedLabel lblDateCreated;
        private System.Windows.Forms.ComboBox accountNumberComboBox;
        private System.Windows.Forms.BindingSource bankAccountBindingSource;
        private System.Windows.Forms.Label notesLabel1;
        private System.Windows.Forms.Label descriptionLabel3;
        private System.Windows.Forms.Label descriptionLabel1;
        private System.Windows.Forms.Label balanceLabel1;
 
    }
}