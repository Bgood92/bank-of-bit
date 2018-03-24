namespace WindowsBankingApplication
{
    partial class frmTransaction
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
            System.Windows.Forms.Label balanceLabel;
            System.Windows.Forms.Label accountNumberLabel;
            System.Windows.Forms.Label clientNumberLabel;
            System.Windows.Forms.Label fullNameLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fullNameLabel1 = new System.Windows.Forms.Label();
            this.bankAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.balanceLabel1 = new System.Windows.Forms.Label();
            this.accountNumberMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.clientNumberMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.lblNoAccounts = new System.Windows.Forms.Label();
            this.lblAcctPayee = new System.Windows.Forms.Label();
            this.lnkProcess = new System.Windows.Forms.LinkLabel();
            this.lnkReturn = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.descriptionComboBox = new System.Windows.Forms.ComboBox();
            this.transactionTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cboAccountPayee = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            balanceLabel = new System.Windows.Forms.Label();
            accountNumberLabel = new System.Windows.Forms.Label();
            clientNumberLabel = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // balanceLabel
            // 
            balanceLabel.AutoSize = true;
            balanceLabel.Location = new System.Drawing.Point(376, 66);
            balanceLabel.Name = "balanceLabel";
            balanceLabel.Size = new System.Drawing.Size(173, 25);
            balanceLabel.TabIndex = 11;
            balanceLabel.Text = "Current Balance:";
            // 
            // accountNumberLabel
            // 
            accountNumberLabel.AutoSize = true;
            accountNumberLabel.Location = new System.Drawing.Point(12, 69);
            accountNumberLabel.Name = "accountNumberLabel";
            accountNumberLabel.Size = new System.Drawing.Size(177, 25);
            accountNumberLabel.TabIndex = 9;
            accountNumberLabel.Text = "Account Number:";
            // 
            // clientNumberLabel
            // 
            clientNumberLabel.AutoSize = true;
            clientNumberLabel.Location = new System.Drawing.Point(12, 30);
            clientNumberLabel.Name = "clientNumberLabel";
            clientNumberLabel.Size = new System.Drawing.Size(154, 25);
            clientNumberLabel.TabIndex = 7;
            clientNumberLabel.Text = "Client Number:";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(444, 27);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(74, 25);
            fullNameLabel.TabIndex = 13;
            fullNameLabel.Text = "Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(fullNameLabel);
            this.groupBox1.Controls.Add(this.fullNameLabel1);
            this.groupBox1.Controls.Add(balanceLabel);
            this.groupBox1.Controls.Add(this.balanceLabel1);
            this.groupBox1.Controls.Add(accountNumberLabel);
            this.groupBox1.Controls.Add(this.accountNumberMaskedLabel);
            this.groupBox1.Controls.Add(clientNumberLabel);
            this.groupBox1.Controls.Add(this.clientNumberMaskedLabel);
            this.groupBox1.Location = new System.Drawing.Point(34, 32);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(692, 123);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client Data";
            // 
            // fullNameLabel1
            // 
            this.fullNameLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fullNameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Client.FullName", true));
            this.fullNameLabel1.Location = new System.Drawing.Point(503, 26);
            this.fullNameLabel1.Name = "fullNameLabel1";
            this.fullNameLabel1.Size = new System.Drawing.Size(154, 23);
            this.fullNameLabel1.TabIndex = 14;
            // 
            // bankAccountBindingSource
            // 
            this.bankAccountBindingSource.DataSource = typeof(BankOfBIT.Models.BankAccount);
            // 
            // balanceLabel1
            // 
            this.balanceLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.balanceLabel1.Location = new System.Drawing.Point(503, 65);
            this.balanceLabel1.Name = "balanceLabel1";
            this.balanceLabel1.Size = new System.Drawing.Size(154, 23);
            this.balanceLabel1.TabIndex = 13;
            this.balanceLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // accountNumberMaskedLabel
            // 
            this.accountNumberMaskedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accountNumberMaskedLabel.Location = new System.Drawing.Point(116, 68);
            this.accountNumberMaskedLabel.Name = "accountNumberMaskedLabel";
            this.accountNumberMaskedLabel.Size = new System.Drawing.Size(160, 23);
            this.accountNumberMaskedLabel.TabIndex = 10;
            // 
            // clientNumberMaskedLabel
            // 
            this.clientNumberMaskedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clientNumberMaskedLabel.Location = new System.Drawing.Point(116, 29);
            this.clientNumberMaskedLabel.Mask = "0000-0000";
            this.clientNumberMaskedLabel.Name = "clientNumberMaskedLabel";
            this.clientNumberMaskedLabel.Size = new System.Drawing.Size(160, 23);
            this.clientNumberMaskedLabel.TabIndex = 8;
            this.clientNumberMaskedLabel.Text = "    -";
            // 
            // lblNoAccounts
            // 
            this.lblNoAccounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNoAccounts.Location = new System.Drawing.Point(8, 161);
            this.lblNoAccounts.Name = "lblNoAccounts";
            this.lblNoAccounts.Size = new System.Drawing.Size(355, 23);
            this.lblNoAccounts.TabIndex = 8;
            this.lblNoAccounts.Text = "No accounts exist to receive transferred funds";
            this.lblNoAccounts.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblNoAccounts.Visible = false;
            // 
            // lblAcctPayee
            // 
            this.lblAcctPayee.AutoSize = true;
            this.lblAcctPayee.Location = new System.Drawing.Point(30, 131);
            this.lblAcctPayee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAcctPayee.Name = "lblAcctPayee";
            this.lblAcctPayee.Size = new System.Drawing.Size(127, 25);
            this.lblAcctPayee.TabIndex = 4;
            this.lblAcctPayee.Text = "To Account:";
            this.lblAcctPayee.Visible = false;
            // 
            // lnkProcess
            // 
            this.lnkProcess.AutoSize = true;
            this.lnkProcess.Location = new System.Drawing.Point(83, 201);
            this.lnkProcess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkProcess.Name = "lnkProcess";
            this.lnkProcess.Size = new System.Drawing.Size(209, 25);
            this.lnkProcess.TabIndex = 6;
            this.lnkProcess.TabStop = true;
            this.lnkProcess.Text = "Process Transaction";
            this.lnkProcess.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProcess_LinkClicked);
            // 
            // lnkReturn
            // 
            this.lnkReturn.AutoSize = true;
            this.lnkReturn.Location = new System.Drawing.Point(218, 201);
            this.lnkReturn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkReturn.Name = "lnkReturn";
            this.lnkReturn.Size = new System.Drawing.Size(212, 25);
            this.lnkReturn.TabIndex = 7;
            this.lnkReturn.TabStop = true;
            this.lnkReturn.Text = "Return to Client Data";
            this.lnkReturn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReturn_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Amount:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.descriptionComboBox);
            this.groupBox2.Controls.Add(this.cboAccountPayee);
            this.groupBox2.Controls.Add(this.lblNoAccounts);
            this.groupBox2.Controls.Add(this.lblAcctPayee);
            this.groupBox2.Controls.Add(this.lnkProcess);
            this.groupBox2.Controls.Add(this.txtAmount);
            this.groupBox2.Controls.Add(this.lnkReturn);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(191, 203);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(504, 246);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transaction Data";
            // 
            // descriptionComboBox
            // 
            this.descriptionComboBox.DataSource = this.transactionTypeBindingSource;
            this.descriptionComboBox.DisplayMember = "Description";
            this.descriptionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.descriptionComboBox.FormattingEnabled = true;
            this.descriptionComboBox.Location = new System.Drawing.Point(164, 44);
            this.descriptionComboBox.Name = "descriptionComboBox";
            this.descriptionComboBox.Size = new System.Drawing.Size(160, 33);
            this.descriptionComboBox.TabIndex = 33;
            this.descriptionComboBox.ValueMember = "TransactionTypeId";
            this.descriptionComboBox.SelectedIndexChanged += new System.EventHandler(this.descriptionComboBox_SelectedIndexChanged);
            // 
            // transactionTypeBindingSource
            // 
            this.transactionTypeBindingSource.DataSource = typeof(BankOfBIT.Models.TransactionType);
            // 
            // cboAccountPayee
            // 
            this.cboAccountPayee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccountPayee.FormattingEnabled = true;
            this.cboAccountPayee.Location = new System.Drawing.Point(164, 128);
            this.cboAccountPayee.Name = "cboAccountPayee";
            this.cboAccountPayee.Size = new System.Drawing.Size(160, 33);
            this.cboAccountPayee.TabIndex = 32;
            this.cboAccountPayee.Visible = false;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(164, 90);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(160, 31);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Transaction Type:";
            // 
            // frmTransaction
            // 
            this.ClientSize = new System.Drawing.Size(751, 464);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTransaction";
            this.Text = "Account Transaction";
            this.Load += new System.EventHandler(this.frmTransaction_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionTypeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNoAccounts;
        private System.Windows.Forms.Label lblAcctPayee;
        private System.Windows.Forms.LinkLabel lnkProcess;
        private System.Windows.Forms.LinkLabel lnkReturn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox cboAccountPayee;
        private System.Windows.Forms.Label fullNameLabel1;
        private System.Windows.Forms.BindingSource bankAccountBindingSource;
        private System.Windows.Forms.Label balanceLabel1;
        private EWSoftware.MaskedLabelControl.MaskedLabel accountNumberMaskedLabel;
        private EWSoftware.MaskedLabelControl.MaskedLabel clientNumberMaskedLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox descriptionComboBox;
        private System.Windows.Forms.BindingSource transactionTypeBindingSource;
    }
}
