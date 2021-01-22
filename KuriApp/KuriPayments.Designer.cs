namespace KuriApp
{
    partial class KuriPayments
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxDivision = new System.Windows.Forms.ComboBox();
            this.comboBoxKuri = new System.Windows.Forms.ComboBox();
            this.txtPaidAmount = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.buttonSaveData = new System.Windows.Forms.Button();
            this.dataGridViewPaymentHistory = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.labelTotalReceived = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelCurrentKuriAmount = new System.Windows.Forms.Label();
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.dateTimePickerPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxAgents = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.labeTotalDues = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPaymentHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Division";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Kuri";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(74, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "User";
            // 
            // comboBoxDivision
            // 
            this.comboBoxDivision.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDivision.FormattingEnabled = true;
            this.comboBoxDivision.Location = new System.Drawing.Point(279, 57);
            this.comboBoxDivision.Name = "comboBoxDivision";
            this.comboBoxDivision.Size = new System.Drawing.Size(198, 37);
            this.comboBoxDivision.TabIndex = 1;
            this.comboBoxDivision.SelectedIndexChanged += new System.EventHandler(this.comboBoxDivision_SelectedIndexChanged);
            // 
            // comboBoxKuri
            // 
            this.comboBoxKuri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxKuri.FormattingEnabled = true;
            this.comboBoxKuri.Location = new System.Drawing.Point(279, 111);
            this.comboBoxKuri.Name = "comboBoxKuri";
            this.comboBoxKuri.Size = new System.Drawing.Size(198, 37);
            this.comboBoxKuri.TabIndex = 1;
            this.comboBoxKuri.SelectedIndexChanged += new System.EventHandler(this.comboBoxKuri_SelectedIndexChanged);
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.Depth = 0;
            this.txtPaidAmount.Hint = "";
            this.txtPaidAmount.Location = new System.Drawing.Point(279, 387);
            this.txtPaidAmount.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.PasswordChar = '\0';
            this.txtPaidAmount.SelectedText = "";
            this.txtPaidAmount.SelectionLength = 0;
            this.txtPaidAmount.SelectionStart = 0;
            this.txtPaidAmount.Size = new System.Drawing.Size(198, 32);
            this.txtPaidAmount.TabIndex = 2;
            this.txtPaidAmount.UseSystemPasswordChar = false;
            // 
            // buttonSaveData
            // 
            this.buttonSaveData.BackColor = System.Drawing.Color.Teal;
            this.buttonSaveData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveData.ForeColor = System.Drawing.Color.White;
            this.buttonSaveData.Image = global::KuriApp.Properties.Resources.save_24;
            this.buttonSaveData.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSaveData.Location = new System.Drawing.Point(279, 449);
            this.buttonSaveData.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSaveData.Name = "buttonSaveData";
            this.buttonSaveData.Size = new System.Drawing.Size(198, 53);
            this.buttonSaveData.TabIndex = 4;
            this.buttonSaveData.Text = "Save";
            this.buttonSaveData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSaveData.UseVisualStyleBackColor = false;
            this.buttonSaveData.Click += new System.EventHandler(this.buttonSaveData_Click);
            // 
            // dataGridViewPaymentHistory
            // 
            this.dataGridViewPaymentHistory.AllowUserToAddRows = false;
            this.dataGridViewPaymentHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewPaymentHistory.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPaymentHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPaymentHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPaymentHistory.ColumnHeadersHeight = 40;
            this.dataGridViewPaymentHistory.Location = new System.Drawing.Point(592, 57);
            this.dataGridViewPaymentHistory.Name = "dataGridViewPaymentHistory";
            this.dataGridViewPaymentHistory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewPaymentHistory.RowHeadersVisible = false;
            this.dataGridViewPaymentHistory.RowTemplate.Height = 28;
            this.dataGridViewPaymentHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPaymentHistory.Size = new System.Drawing.Size(424, 656);
            this.dataGridViewPaymentHistory.TabIndex = 5;
            this.dataGridViewPaymentHistory.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewPaymentHistory_DataBindingComplete);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(71, 637);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(263, 29);
            this.label7.TabIndex = 0;
            this.label7.Text = "Total Amount Received";
            // 
            // labelTotalReceived
            // 
            this.labelTotalReceived.AutoSize = true;
            this.labelTotalReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalReceived.Location = new System.Drawing.Point(361, 635);
            this.labelTotalReceived.Name = "labelTotalReceived";
            this.labelTotalReceived.Size = new System.Drawing.Size(109, 29);
            this.labelTotalReceived.TabIndex = 0;
            this.labelTotalReceived.Text = "................";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(71, 387);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(202, 29);
            this.label9.TabIndex = 0;
            this.label9.Text = "Received Amount";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(70, 583);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(228, 29);
            this.label10.TabIndex = 0;
            this.label10.Text = "Current Kuri Amount";
            // 
            // labelCurrentKuriAmount
            // 
            this.labelCurrentKuriAmount.AutoSize = true;
            this.labelCurrentKuriAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentKuriAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelCurrentKuriAmount.Location = new System.Drawing.Point(361, 583);
            this.labelCurrentKuriAmount.Name = "labelCurrentKuriAmount";
            this.labelCurrentKuriAmount.Size = new System.Drawing.Size(118, 29);
            this.labelCurrentKuriAmount.TabIndex = 0;
            this.labelCurrentKuriAmount.Text = "...............";
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(279, 172);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(198, 37);
            this.comboBoxUsers.TabIndex = 1;
            this.comboBoxUsers.SelectedIndexChanged += new System.EventHandler(this.comboBoxUsers_SelectedIndexChanged);
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(75, 515);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(472, 10);
            this.materialDivider1.TabIndex = 6;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // dateTimePickerPaymentDate
            // 
            this.dateTimePickerPaymentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerPaymentDate.Location = new System.Drawing.Point(279, 259);
            this.dateTimePickerPaymentDate.Name = "dateTimePickerPaymentDate";
            this.dateTimePickerPaymentDate.Size = new System.Drawing.Size(198, 30);
            this.dateTimePickerPaymentDate.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 29);
            this.label1.TabIndex = 22;
            this.label1.Text = "Received date";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(74, 319);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 29);
            this.label12.TabIndex = 0;
            this.label12.Text = "Agent";
            // 
            // comboBoxAgents
            // 
            this.comboBoxAgents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAgents.FormattingEnabled = true;
            this.comboBoxAgents.Location = new System.Drawing.Point(279, 319);
            this.comboBoxAgents.Name = "comboBoxAgents";
            this.comboBoxAgents.Size = new System.Drawing.Size(198, 37);
            this.comboBoxAgents.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(74, 689);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 29);
            this.label13.TabIndex = 0;
            this.label13.Text = "Total Dues";
            // 
            // labeTotalDues
            // 
            this.labeTotalDues.AutoSize = true;
            this.labeTotalDues.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeTotalDues.Location = new System.Drawing.Point(361, 684);
            this.labeTotalDues.Name = "labeTotalDues";
            this.labeTotalDues.Size = new System.Drawing.Size(109, 29);
            this.labeTotalDues.TabIndex = 0;
            this.labeTotalDues.Text = "................";
            this.labeTotalDues.Click += new System.EventHandler(this.labeTotalDues_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.AutoSize = true;
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(274, 212);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(0, 29);
            this.txtUserName.TabIndex = 0;
            // 
            // KuriPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 814);
            this.Controls.Add(this.dateTimePickerPaymentDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.dataGridViewPaymentHistory);
            this.Controls.Add(this.buttonSaveData);
            this.Controls.Add(this.txtPaidAmount);
            this.Controls.Add(this.comboBoxAgents);
            this.Controls.Add(this.comboBoxUsers);
            this.Controls.Add(this.comboBoxKuri);
            this.Controls.Add(this.comboBoxDivision);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labeTotalDues);
            this.Controls.Add(this.labelTotalReceived);
            this.Controls.Add(this.labelCurrentKuriAmount);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Name = "KuriPayments";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Load += new System.EventHandler(this.KuriPayments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPaymentHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxDivision;
        private System.Windows.Forms.ComboBox comboBoxKuri;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPaidAmount;
        private System.Windows.Forms.Button buttonSaveData;
        private System.Windows.Forms.DataGridView dataGridViewPaymentHistory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelTotalReceived;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelCurrentKuriAmount;
        private System.Windows.Forms.ComboBox comboBoxUsers;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.DateTimePicker dateTimePickerPaymentDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxAgents;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labeTotalDues;
        private System.Windows.Forms.Label txtUserName;
    }
}