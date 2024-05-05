namespace LukieAnnLoansAndFinancialServicesApp
{
    partial class Calculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculator));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Print_Btn = new System.Windows.Forms.Button();
            this.Reset_Btn = new System.Windows.Forms.Button();
            this.Calculate_Btn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.receiptDisplay = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.MonthlyPayment_Label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loanType_comboBox1 = new System.Windows.Forms.ComboBox();
            this.LoanAmount = new System.Windows.Forms.TextBox();
            this.LoanTerm_comboBox2 = new System.Windows.Forms.ComboBox();
            this.Interest_Label = new System.Windows.Forms.Label();
            this.TotalRepayment_Label = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(20, 19);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 65);
            this.panel1.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(739, 61);
            this.label2.TabIndex = 0;
            this.label2.Text = "Calculator";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.Print_Btn);
            this.panel3.Controls.Add(this.Reset_Btn);
            this.panel3.Controls.Add(this.Calculate_Btn);
            this.panel3.Location = new System.Drawing.Point(20, 504);
            this.panel3.Margin = new System.Windows.Forms.Padding(6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(743, 52);
            this.panel3.TabIndex = 22;
            // 
            // Print_Btn
            // 
            this.Print_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Print_Btn.BackColor = System.Drawing.Color.Blue;
            this.Print_Btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Print_Btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Print_Btn.Location = new System.Drawing.Point(588, 6);
            this.Print_Btn.Margin = new System.Windows.Forms.Padding(6);
            this.Print_Btn.Name = "Print_Btn";
            this.Print_Btn.Size = new System.Drawing.Size(149, 38);
            this.Print_Btn.TabIndex = 19;
            this.Print_Btn.Text = "Print Receipt";
            this.Print_Btn.UseVisualStyleBackColor = false;
            this.Print_Btn.Click += new System.EventHandler(this.Print_Btn_Click);
            // 
            // Reset_Btn
            // 
            this.Reset_Btn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Reset_Btn.BackColor = System.Drawing.Color.Crimson;
            this.Reset_Btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reset_Btn.Location = new System.Drawing.Point(303, 6);
            this.Reset_Btn.Margin = new System.Windows.Forms.Padding(6);
            this.Reset_Btn.Name = "Reset_Btn";
            this.Reset_Btn.Size = new System.Drawing.Size(149, 38);
            this.Reset_Btn.TabIndex = 18;
            this.Reset_Btn.Text = "Reset";
            this.Reset_Btn.UseVisualStyleBackColor = false;
            this.Reset_Btn.Click += new System.EventHandler(this.Reset_Btn_Click);
            // 
            // Calculate_Btn
            // 
            this.Calculate_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Calculate_Btn.BackColor = System.Drawing.Color.Lime;
            this.Calculate_Btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Calculate_Btn.Location = new System.Drawing.Point(8, 8);
            this.Calculate_Btn.Margin = new System.Windows.Forms.Padding(6);
            this.Calculate_Btn.Name = "Calculate_Btn";
            this.Calculate_Btn.Size = new System.Drawing.Size(149, 38);
            this.Calculate_Btn.TabIndex = 17;
            this.Calculate_Btn.Text = "Calculate";
            this.Calculate_Btn.UseVisualStyleBackColor = false;
            this.Calculate_Btn.Click += new System.EventHandler(this.Calculate_Btn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.receiptDisplay, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 93);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(744, 402);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // receiptDisplay
            // 
            this.receiptDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.receiptDisplay.BackColor = System.Drawing.Color.White;
            this.receiptDisplay.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receiptDisplay.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.receiptDisplay.Location = new System.Drawing.Point(376, 2);
            this.receiptDisplay.Name = "receiptDisplay";
            this.receiptDisplay.Size = new System.Drawing.Size(363, 398);
            this.receiptDisplay.TabIndex = 27;
            this.receiptDisplay.Text = "Loan Details";
            this.receiptDisplay.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.MonthlyPayment_Label, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.loanType_comboBox1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.LoanAmount, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.LoanTerm_comboBox2, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.Interest_Label, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.TotalRepayment_Label, 0, 11);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 12;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(363, 392);
            this.tableLayoutPanel2.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 337);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 19);
            this.label10.TabIndex = 25;
            this.label10.Text = "Total Repayment:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 271);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 19);
            this.label9.TabIndex = 27;
            this.label9.Text = "Monthly Payment:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MonthlyPayment_Label
            // 
            this.MonthlyPayment_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MonthlyPayment_Label.BackColor = System.Drawing.Color.White;
            this.MonthlyPayment_Label.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonthlyPayment_Label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MonthlyPayment_Label.Location = new System.Drawing.Point(3, 300);
            this.MonthlyPayment_Label.Name = "MonthlyPayment_Label";
            this.MonthlyPayment_Label.Size = new System.Drawing.Size(357, 27);
            this.MonthlyPayment_Label.TabIndex = 25;
            this.MonthlyPayment_Label.Text = "Loan interest will appear here.";
            this.MonthlyPayment_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Loan Interest %:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Loan Term (in Months):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Loan Amount:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loan Type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // loanType_comboBox1
            // 
            this.loanType_comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.loanType_comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loanType_comboBox1.FormattingEnabled = true;
            this.loanType_comboBox1.Location = new System.Drawing.Point(3, 39);
            this.loanType_comboBox1.Name = "loanType_comboBox1";
            this.loanType_comboBox1.Size = new System.Drawing.Size(357, 27);
            this.loanType_comboBox1.TabIndex = 1;
            this.loanType_comboBox1.SelectionChangeCommitted += new System.EventHandler(this.loanType_comboBox1_SelectionChangeCommitted);
            // 
            // LoanAmount
            // 
            this.LoanAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LoanAmount.Location = new System.Drawing.Point(3, 103);
            this.LoanAmount.Multiline = true;
            this.LoanAmount.Name = "LoanAmount";
            this.LoanAmount.Size = new System.Drawing.Size(357, 25);
            this.LoanAmount.TabIndex = 2;
            this.LoanAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoanAmount_KeyPress);
            // 
            // LoanTerm_comboBox2
            // 
            this.LoanTerm_comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LoanTerm_comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LoanTerm_comboBox2.FormattingEnabled = true;
            this.LoanTerm_comboBox2.Location = new System.Drawing.Point(3, 171);
            this.LoanTerm_comboBox2.Name = "LoanTerm_comboBox2";
            this.LoanTerm_comboBox2.Size = new System.Drawing.Size(357, 27);
            this.LoanTerm_comboBox2.TabIndex = 4;
            // 
            // Interest_Label
            // 
            this.Interest_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Interest_Label.BackColor = System.Drawing.Color.White;
            this.Interest_Label.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Interest_Label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Interest_Label.Location = new System.Drawing.Point(3, 234);
            this.Interest_Label.Name = "Interest_Label";
            this.Interest_Label.Size = new System.Drawing.Size(357, 27);
            this.Interest_Label.TabIndex = 7;
            this.Interest_Label.Text = "Loan interest will appear here.";
            this.Interest_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TotalRepayment_Label
            // 
            this.TotalRepayment_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalRepayment_Label.BackColor = System.Drawing.Color.White;
            this.TotalRepayment_Label.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalRepayment_Label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TotalRepayment_Label.Location = new System.Drawing.Point(3, 364);
            this.TotalRepayment_Label.Name = "TotalRepayment_Label";
            this.TotalRepayment_Label.Size = new System.Drawing.Size(357, 27);
            this.TotalRepayment_Label.TabIndex = 26;
            this.TotalRepayment_Label.Text = "Loan interest will appear here.";
            this.TotalRepayment_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // Calculator
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Calculator";
            this.Text = "Calculator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Calculator_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button Reset_Btn;
        private System.Windows.Forms.Button Calculate_Btn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox loanType_comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LoanAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox LoanTerm_comboBox2;
        private System.Windows.Forms.Label Interest_Label;
        private System.Windows.Forms.Label MonthlyPayment_Label;
        private System.Windows.Forms.Label TotalRepayment_Label;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label receiptDisplay;
        private System.Windows.Forms.Button Print_Btn;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}