using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LukieAnnLoansAndFinancialServicesApp
{
    public partial class Calculator : Form
    {
        private readonly LukieAnnsLoans_dbEntities _DbEntities;

        public Calculator()
        {
            InitializeComponent();
            _DbEntities = new LukieAnnsLoans_dbEntities();
        }

        public Calculator(PersonnelRoleTable getRole)
        {
            this.getRole = getRole;
            InitializeComponent();
            _DbEntities = new LukieAnnsLoans_dbEntities();
        }

        private String receiptHeader = "\n\n                **************************************************\n" +
                                        "                **              Lukie-Ann's Loans and Financial Services               **\n" +
                                        "                **************************************************\n";
        private PersonnelRoleTable getRole;

        private void Calculator_Load(object sender, EventArgs e)
        {
            var loanTypeList = _DbEntities.LoanTypes.ToList();
            loanType_comboBox1.DisplayMember = "Type";
            loanType_comboBox1.ValueMember = "Id";
            loanType_comboBox1.DataSource = loanTypeList;
            loanType_comboBox1.SelectedItem = null;

            var loanTermList = _DbEntities.LoanTerms.ToList();
            LoanTerm_comboBox2.DisplayMember = "Term";
            LoanTerm_comboBox2.ValueMember = "Id";
            LoanTerm_comboBox2.DataSource = loanTermList;
            LoanTerm_comboBox2.SelectedItem = null;

            receiptDisplay.Text = receiptHeader;

            if (loanType_comboBox1.SelectedItem == null || LoanTerm_comboBox2.SelectedItem == null || LoanAmount.Text == null)
            {
                Print_Btn.Enabled = false;
            }
        }

        private void loanType_comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedItem = loanType_comboBox1.GetItemText(loanType_comboBox1.SelectedItem).ToString();
            var selectedInterest_Id = _DbEntities.LoanTypes.FirstOrDefault(x => x.Type == selectedItem).LoanInterest_Id;

            if (selectedItem != null)
            {
                if (selectedInterest_Id == null)
                {
                    MessageBox.Show("No Loan was Selected!");
                }

                else
                {
                    var selectedInterest = _DbEntities.LoanInterests.FirstOrDefault(x => x.Id == selectedInterest_Id).Rate;
                    if (selectedInterest == null)
                    {
                        MessageBox.Show("Please select a loan!");
                    }

                    else
                    {
                        Interest_Label.Text = selectedInterest.ToString();
                    }
                }



            }

        }

        private void LoanAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                  if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
                        {
                            e.Handled = true;
                        }
            }
            catch (Exception)
            {

                MessageBox.Show("Value should only be numbers");
            }
      
        }

        private void Calculate_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoanTerm_comboBox2.SelectedItem != null && LoanAmount.Text != null)
                {
                    var interestRate = (Convert.ToDouble(Interest_Label.Text));
                    var duration = Convert.ToDouble(LoanTerm_comboBox2.GetItemText(LoanTerm_comboBox2.SelectedItem));
                    var principle = Convert.ToDouble(LoanAmount.Text);

                    var monthlyPayment = Utils.MonthlyPayment(principle, interestRate, duration);

                    MonthlyPayment_Label.Text = String.Format("{0, 0:C}", Math.Round(monthlyPayment, 2));
                    TotalRepayment_Label.Text = String.Format("{0, 0:C}", Math.Round(monthlyPayment * duration, 2));

                    receiptDisplay.Text = null;

                    var result = "\n\n" +
                                       String.Format("{0, 60}  {1}", "Type of loan:   ", loanType_comboBox1.GetItemText(loanType_comboBox1.SelectedItem)) + "\n" +
                                "\n" + String.Format("{0, 53} {1, 0:C}", "Borrowed amount:   ", principle) + "\n" +
                                "\n" + String.Format("{0, 59} {1}", "Loan Term:   ", duration + " Months") + "\n" +
                                "\n" + String.Format("{0, 59} {1}", "Interest Rate:   ", Interest_Label.Text + " %") + "\n" +
                                "\n" + String.Format("{0, 53} {1}", "Monthly Payment:   ", MonthlyPayment_Label.Text) + "\n\n" +
                                       String.Format("{0, 57} {1}", "Total Payment:   ", TotalRepayment_Label.Text);

                    receiptDisplay.Text += receiptHeader + result;
                    Print_Btn.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Unable to Calculate!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong \n Please try again.");
            }

        }

        private void Reset_Btn_Click(object sender, EventArgs e)
        {
            LoanAmount.Text = null;
            loanType_comboBox1.SelectedItem = null;
            LoanTerm_comboBox2.SelectedItem = null;
            Interest_Label.Text = "Interest rate will display here";
            MonthlyPayment_Label.Text = "Monthly payment will display here";
            TotalRepayment_Label.Text = "Total payment will display here";
            receiptDisplay.Text = receiptHeader;
            Print_Btn.Enabled = false;
        }

        private void Print_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
                Print_Btn.Enabled = false;
            }
            catch (Exception)
            {

                throw;
            }
        
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString("******************************************************", new
                Font("TimesNewRomans", 24, FontStyle.Regular), Brushes.Black, new Point(80, 25));
            e.Graphics.DrawString("**   Lukie-Ann's Loans and Financial Services   **", new
                Font("TimesNewRomans", 24, FontStyle.Regular), Brushes.Black, new Point(80, 50));
            e.Graphics.DrawString("******************************************************", new
                Font("TimesNewRomans", 24, FontStyle.Regular), Brushes.Black, new Point(80, 85));
            e.Graphics.DrawString("Date: " + DateTime.Now.ToString(), new
                Font("TimesNewRomans", 16, FontStyle.Regular), Brushes.Black, new Point(80, 125));
            e.Graphics.DrawString("_________________________________________________________", new
                Font("TimesNewRomans", 16, FontStyle.Regular), Brushes.Black, new Point(80, 150));


            e.Graphics.DrawString("Loan Type: \t\t|\t\t" + loanType_comboBox1.GetItemText(loanType_comboBox1.SelectedItem), new
                Font("TimesNewRomans", 16, FontStyle.Regular), Brushes.Black, new Point(120, 200));
            e.Graphics.DrawString("Loan Amount: \t\t|\t\t$" + LoanAmount.Text, new
                Font("TimesNewRomans", 16, FontStyle.Regular), Brushes.Black, new Point(120, 240));
            e.Graphics.DrawString("Loan Term: \t\t|\t\t" + LoanTerm_comboBox2.GetItemText(LoanTerm_comboBox2.SelectedItem) + "Month/s", new
                Font("TimesNewRomans", 16, FontStyle.Regular), Brushes.Black, new Point(120, 280));
            e.Graphics.DrawString("Interest Rate: \t\t|\t\t" + Interest_Label.Text + "%", new
                Font("TimesNewRomans", 16, FontStyle.Regular), Brushes.Black, new Point(120, 320));
            e.Graphics.DrawString("Monthly Payment: \t|\t\t" + MonthlyPayment_Label.Text, new
                Font("TimesNewRomans", 16, FontStyle.Regular), Brushes.Black, new Point(120, 360));
            e.Graphics.DrawString("Total Payment: \t\t|\t\t" + TotalRepayment_Label.Text, new Font("TimesNewRomans", 16, FontStyle.Regular), Brushes.Black, new Point(120, 400));
            e.Graphics.DrawString("_________________________________________________________", new
                Font("TimesNewRomans", 16, FontStyle.Regular), Brushes.Black, new Point(80, 440));

        }
    }
}
