namespace WindowsBankingApplication
{
    partial class frmBatch
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
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radSelect = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.lnkProcess = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rtxtLog = new System.Windows.Forms.RichTextBox();
            this.institutionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.institutionComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.institutionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(415, 94);
            this.txtKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtKey.Name = "txtKey";
            this.txtKey.PasswordChar = '*';
            this.txtKey.Size = new System.Drawing.Size(132, 31);
            this.txtKey.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(444, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter Key:";
            // 
            // radSelect
            // 
            this.radSelect.AutoSize = true;
            this.radSelect.Location = new System.Drawing.Point(52, 53);
            this.radSelect.Margin = new System.Windows.Forms.Padding(4);
            this.radSelect.Name = "radSelect";
            this.radSelect.Size = new System.Drawing.Size(255, 29);
            this.radSelect.TabIndex = 1;
            this.radSelect.TabStop = true;
            this.radSelect.Text = "Select a Transmission";
            this.radSelect.UseVisualStyleBackColor = true;
            this.radSelect.CheckedChanged += new System.EventHandler(this.radSelect_CheckedChanged);
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Checked = true;
            this.radAll.Location = new System.Drawing.Point(52, 23);
            this.radAll.Margin = new System.Windows.Forms.Padding(4);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(257, 29);
            this.radAll.TabIndex = 0;
            this.radAll.TabStop = true;
            this.radAll.Text = "Run All Transmissions";
            this.radAll.UseVisualStyleBackColor = true;
            // 
            // lnkProcess
            // 
            this.lnkProcess.AutoSize = true;
            this.lnkProcess.Location = new System.Drawing.Point(48, 140);
            this.lnkProcess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkProcess.Name = "lnkProcess";
            this.lnkProcess.Size = new System.Drawing.Size(249, 25);
            this.lnkProcess.TabIndex = 3;
            this.lnkProcess.TabStop = true;
            this.lnkProcess.Text = "Process Transmission(s)";
            this.lnkProcess.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProcess_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.institutionComboBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtKey);
            this.groupBox2.Controls.Add(this.radSelect);
            this.groupBox2.Controls.Add(this.radAll);
            this.groupBox2.Controls.Add(this.lnkProcess);
            this.groupBox2.Location = new System.Drawing.Point(25, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(597, 185);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transmission Selection";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 213);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Transmission Log:";
            // 
            // rtxtLog
            // 
            this.rtxtLog.HideSelection = false;
            this.rtxtLog.Location = new System.Drawing.Point(21, 258);
            this.rtxtLog.Margin = new System.Windows.Forms.Padding(4);
            this.rtxtLog.Name = "rtxtLog";
            this.rtxtLog.Size = new System.Drawing.Size(600, 253);
            this.rtxtLog.TabIndex = 10;
            this.rtxtLog.Text = "";
            // 
            // institutionBindingSource
            // 
            this.institutionBindingSource.DataSource = typeof(BankOfBIT.Models.Institution);
            // 
            // institutionComboBox
            // 
            this.institutionComboBox.DataSource = this.institutionBindingSource;
            this.institutionComboBox.DisplayMember = "Description";
            this.institutionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.institutionComboBox.FormattingEnabled = true;
            this.institutionComboBox.Location = new System.Drawing.Point(52, 94);
            this.institutionComboBox.Name = "institutionComboBox";
            this.institutionComboBox.Size = new System.Drawing.Size(300, 33);
            this.institutionComboBox.TabIndex = 5;
            this.institutionComboBox.ValueMember = "InstituionNumber";
            // 
            // frmBatch
            // 
            this.ClientSize = new System.Drawing.Size(644, 540);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rtxtLog);
            this.Name = "frmBatch";
            this.Text = "Bank Transmission";
            this.Load += new System.EventHandler(this.frmBatch_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.institutionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radSelect;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.LinkLabel lnkProcess;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtxtLog;
        private System.Windows.Forms.ComboBox institutionComboBox;
        private System.Windows.Forms.BindingSource institutionBindingSource;
    }
}
