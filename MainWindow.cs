using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LukieAnnLoansAndFinancialServicesApp
{
    public partial class MainWindow : Form
    {
        private readonly LukieAnnsLoans_dbEntities _DbEntities = new LukieAnnsLoans_dbEntities();
        private readonly LogIn logIn;
        private readonly PersonnelRoleTable getRole;
        private personnel_LogIn userName_check;
        private Login_DateTimeTable timeLoggedIn;

        public MainWindow()
        {
            InitializeComponent();
        }


        public MainWindow(LogIn logIn, PersonnelRoleTable getRole, Login_DateTimeTable timeLoggedIn, personnel_LogIn userName_check)
        {
            this.logIn = logIn;
            this.getRole = getRole;
            this.timeLoggedIn = timeLoggedIn;
            this.userName_check = userName_check;
            InitializeComponent();
        }

        private void CalculatorSelect_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                 Calculator calculator = new Calculator(getRole);  
                if(!Utils.FormIsOpen(calculator))
                {
                    calculator.MdiParent = this;
                    calculator.Show();
                }

                //Closing all the forms that are being used
                Application.OpenForms.Cast<Form>().
                    Where(x => !(x is LogIn || x is Calculator || x is MainWindow))
                    .ToList().
                    ForEach(x => x.Close());
            }
            catch (Exception)
            {

                MessageBox.Show("Unable to open!");

            }
 
     
        }

        private void addNewLoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Creating a new AddEditLoanDetails Form object
                AddEditLoanDetails addEditLoanDetails = new AddEditLoanDetails(getRole);
                //Checking if it it is already called and calling it if it is not called
                if (!Utils.FormIsOpen(addEditLoanDetails)) 
                {//Making the Main Windows the parent
                    addEditLoanDetails.MdiParent = this;
                    addEditLoanDetails.Show();
                }
                //Closing the forms not in use
                Application.OpenForms.Cast<Form>()
               .Where(x => !(x is MainWindow || x is AddEditLoanDetails || x is LogIn))
               .ToList()
               .ForEach(x => x.Close());
            }
            catch (Exception)
            {

                MessageBox.Show("Unable to open!");
            }
         
        }

        private void loanApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {// crating a new LoanApplication object
                LoanApplication loanApplication = new LoanApplication(getRole);

                //Checking the is LoanApplication is called and calling it if it was not
                if (!Utils.FormIsOpen(loanApplication))
                {//Makin the Main Window the parent
                    loanApplication.MdiParent = this;
                    loanApplication.Show();
                }
                //Closing the forms not in use
                Application.OpenForms.Cast<Form>()
               .Where(x => !(x is MainWindow || x is LoanApplication || x is LogIn))
               .ToList()
               .ForEach(x => x.Close());

            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open!");
            }
       
           
        }

        //Calling the Manage Personnel Form
        private void managePersonnelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Creating a new Manage personnel object
                Managepersonnels managepersonels = new Managepersonnels(getRole);
                //Checking if the Manage Personnel Form is already called and calling it if it is not
                
                if (!Utils.FormIsOpen(managepersonels))
                {//Making the Main Window the parent
                    managepersonels.MdiParent = this;
                    managepersonels.Show();
                               }
                //Closing the forms not in use
                Application.OpenForms.Cast<Form>()
               .Where(x => !(x is MainWindow || x is Managepersonnels || x is LogIn))
               .ToList()
               .ForEach(x => x.Close());
            }
            catch (Exception)
            {

                MessageBox.Show("Unable to open!");
            }

        }

        //Calling the make Payment Form
        private void makePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Creating a new object of the Make Payment Form
                MakePayment makePayment = new MakePayment(getRole);

                //Checking if the Make Payment Form is already called and calling it if it is not
                if (!Utils.FormIsOpen(makePayment))
                {//Making the Main Window the parent
                    makePayment.MdiParent = this;
                    makePayment.Show();
                }

                //Closing all the forms that are not in use
                Application.OpenForms.Cast<Form>()
                    .Where(x => !(x is MainWindow || x is MakePayment || x is LogIn)
                    ).ToList().
                     ForEach(x => x.Close()) ;
            }
            catch (Exception)
            {

                MessageBox.Show("Unable to open!");
            }

        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {var timeLoggedOut = DateTime.Now;
            timeLoggedIn.Logout_DateTime = timeLoggedOut;   
            _DbEntities.Login_DateTimeTable.Add(timeLoggedIn);
            _DbEntities.SaveChanges();
            //Closing th log in form
            Utils.FormIsOpen(logIn);
            logIn.Close();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (getRole.personnelRole == "Administrator")
            {
                addNewLoanToolStripMenuItem.Enabled = true;
            }
            else
            {
                addNewLoanToolStripMenuItem.Enabled = false;   
            }
        }
    }
}
