using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LukieAnnLoansAndFinancialServicesApp
{
    public partial class MakePayment : Form
    {
        public PersonnelRoleTable getSignedIn;
        private readonly LukieAnnsLoans_dbEntities _DbEntities = new LukieAnnsLoans_dbEntities();
        public MakePayment()
        {
            InitializeComponent();
        }

        public MakePayment(PersonnelRoleTable getSignedIn)
        {
            InitializeComponent();
            this.getSignedIn = getSignedIn;
        }


        private void MakePayment_Load(object sender, EventArgs e)
        { 
            var CustomerRoles = _DbEntities.PersonnelRoleTables.FirstOrDefault(x => x.personnelRole == "Customer");
            if (CustomerRoles != null)
            {

                var CusNmae = _DbEntities.Personnel_Table.
                    Where(x => _DbEntities.Personnel_Login_LinkerTable.Any(r =>
                                        r.personnel_Role_ID == CustomerRoles.id &&
                                        x.id == r.Personnel_ID)).ToList();

                            Customer_comboBox.DisplayMember = "Fullname";
                            Customer_comboBox.ValueMember = "id";
                            Customer_comboBox.DataSource = CusNmae;
                            Customer_comboBox.SelectedItem = null;
            }
        }

        private void Customer_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var getSelectedItem = Convert.ToInt32(Customer_comboBox.SelectedValue);
            var selecetedItem = _DbEntities.Personnel_Table.FirstOrDefault(x => x.id == getSelectedItem);

            var loans = _DbEntities.LoanRequest_Linker.FirstOrDefault(x => x.Customer_Id == selecetedItem.id);
            if (loans != null)
            {
                var getLoan = _DbEntities.loanIssueances.FirstOrDefault(x => x.LoanRequest_Id == loans.Id);
                if (getLoan != null)
                {
                    BorrowedAmount_tb.Text = getLoan.LoanAmount.ToString();
                    TotalRepayment_tb.Text = getLoan.Total.ToString();
                    MonthlyPayment_Textbox.Text = getLoan.MonthlyPayment.ToString();

                    var paymentpayments = _DbEntities.Repayments.Where(x => x.loanIssuance_Id == getLoan.Id)
                                                                        .Sum(x => x.Amount);

                    TotalAmntRpayed_Lb.Text = paymentpayments.ToString();
                    
                    balance_Lb.Text = (Convert.ToDouble(getLoan.Total)
                                        - Convert.ToDouble(paymentpayments)).ToString();

                }
            }
        }

        private void Pay_button_Click(object sender, EventArgs e)
        {
            try
            {
                var getSelectedItem = Convert.ToInt32(Customer_comboBox.SelectedValue);
                var selecetedItem = _DbEntities.Personnel_Table.FirstOrDefault(x => x.id == getSelectedItem);
                if (selecetedItem != null)
                {
                    var loans = _DbEntities.LoanRequest_Linker.FirstOrDefault(x => x.Customer_Id == selecetedItem.id);
                    if(loans != null)
                    {
                        var getLoan = _DbEntities.loanIssueances.FirstOrDefault(x => x.LoanRequest_Id == loans.Id);

                        if (getLoan != null)
                        {
                            var payment = new Repayment();

                            payment.Amount = Convert.ToDecimal(MonthlyPayment_Textbox.Text);

                            payment.loanIssuance_Id = getLoan.Id;

                            payment.totalRepayment = _DbEntities.Repayments.Where(x => x.loanIssuance_Id == getLoan.Id)
                                                                              .Sum(x => x.Amount);

                            payment.balance = (getLoan.Total - payment.totalRepayment);

                            payment.PaymentDate = dateTimePicker.Value;



                            _DbEntities.Repayments.Add(payment);
                            _DbEntities.SaveChanges();

                            var tatMonthlyPayment = _DbEntities.Repayments.Where(x => _DbEntities.loanIssueances.Any(
                                                                                      l => l.Id == x.loanIssuance_Id));

                            var bal = getLoan.Total - tatMonthlyPayment.Sum(x => x.Amount);


                            TotalAmntRpayed_Lb.Text = tatMonthlyPayment.Sum(x => x.Amount).ToString();
                            balance_Lb.Text = bal.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Unable to make payment", "Failure");
                        }

                      
                    }
                    else
                    {
                        MessageBox.Show("Unable to make payment", "Failure");
                    }
              
                }
                else
                {
                    MessageBox.Show("No Customer was selected", "Failure");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to make payment", "Failure");
            }
          
             
      
        }
    }
}


