namespace LukieAnnLoansAndFinancialServicesApp
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.CaculatorSelect_Btn = new System.Windows.Forms.ToolStripMenuItem();
            this.loanManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loanApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewLoanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managePersonnelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CaculatorSelect_Btn,
            this.loanManagementToolStripMenuItem,
            this.managePersonnelsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 27);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // CaculatorSelect_Btn
            // 
            this.CaculatorSelect_Btn.Name = "CaculatorSelect_Btn";
            this.CaculatorSelect_Btn.Size = new System.Drawing.Size(83, 23);
            this.CaculatorSelect_Btn.Text = "Calculator";
            this.CaculatorSelect_Btn.Click += new System.EventHandler(this.CalculatorSelect_Btn_Click);
            // 
            // loanManagementToolStripMenuItem
            // 
            this.loanManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loanApplicationToolStripMenuItem,
            this.addNewLoanToolStripMenuItem});
            this.loanManagementToolStripMenuItem.Name = "loanManagementToolStripMenuItem";
            this.loanManagementToolStripMenuItem.Size = new System.Drawing.Size(134, 23);
            this.loanManagementToolStripMenuItem.Text = "Loan Management";
            // 
            // loanApplicationToolStripMenuItem
            // 
            this.loanApplicationToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loanApplicationToolStripMenuItem.Name = "loanApplicationToolStripMenuItem";
            this.loanApplicationToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.loanApplicationToolStripMenuItem.Text = "Loan Application";
            this.loanApplicationToolStripMenuItem.Click += new System.EventHandler(this.loanApplicationToolStripMenuItem_Click);
            // 
            // addNewLoanToolStripMenuItem
            // 
            this.addNewLoanToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewLoanToolStripMenuItem.Name = "addNewLoanToolStripMenuItem";
            this.addNewLoanToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.addNewLoanToolStripMenuItem.Text = "Manage Loan Category";
            this.addNewLoanToolStripMenuItem.Click += new System.EventHandler(this.addNewLoanToolStripMenuItem_Click);
            // 
            // managePersonnelsToolStripMenuItem
            // 
            this.managePersonnelsToolStripMenuItem.Name = "managePersonnelsToolStripMenuItem";
            this.managePersonnelsToolStripMenuItem.Size = new System.Drawing.Size(139, 23);
            this.managePersonnelsToolStripMenuItem.Text = "Manage Personnels";
            this.managePersonnelsToolStripMenuItem.Click += new System.EventHandler(this.managePersonnelsToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lukie-Ann\'s Loans and Finaicial Services";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem CaculatorSelect_Btn;
        private System.Windows.Forms.ToolStripMenuItem loanManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewLoanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loanApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managePersonnelsToolStripMenuItem;
        public System.Windows.Forms.MenuStrip menuStrip;
    }
}