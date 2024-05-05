using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LukieAnnLoansAndFinancialServicesApp
{
    public partial class LoanApplication : Form
    {
        private readonly LukieAnnsLoans_dbEntities _DbEntities;
        private readonly LogIn login;
        public readonly PersonnelRoleTable getSignedIn;
        private Login_DateTimeTable timeLoggedIn;
        private personnel_LogIn userName_check;

        public LoanApplication(PersonnelRoleTable getSignedIn)
        {
            InitializeComponent();
            _DbEntities = new LukieAnnsLoans_dbEntities();
            login = new LogIn();
            this.getSignedIn = getSignedIn;
        }

        //geting the appropriate fields form the database
        private void loadDatabase()
        {
            try
            {     //Display all Loans issueance into dataGrid
                var loaddata = (
                                from loanReq in _DbEntities.LoanRequest_Linker
                                join loanIssue in _DbEntities.loanIssueances
                                    on loanReq.Id equals loanIssue.LoanRequest_Id
                                join type in _DbEntities.LoanTypes
                                    on loanReq.LoanType_Id equals type.Id
                                join Terms in _DbEntities.LoanTerms
                                    on loanReq.LoanTerm_Id equals Terms.Id
                                join Cus in _DbEntities.Personnel_Table
                                    on loanReq.Customer_Id equals Cus.id
                                join intRate in _DbEntities.LoanInterests on type.LoanInterest_Id equals intRate.Id


                                where

                               loanIssue.LoanRequest_Id == loanReq.Id



                                select new
                                {

                                    Customers = Cus.FirstName + " " + Cus.MiddleName + " " + Cus.LastName,
                                    Loan_Type = type.Type,
                                    Loan_Amount = loanIssue.LoanAmount,
                                    Duration = Terms.Term,
                                    Interest = intRate.Rate,
                                    Monthly_Payment = loanIssue.MonthlyPayment,
                                    Total_Payment = loanIssue.Total,
                                    Issue_Date = loanIssue.StartDate,
                                    Due_Date = loanIssue.EndDate,
                                    Status = loanIssue.status,
                                    loanReq.Id
                                }).ToList();
                // loading the data to the data grid view
                Loan_dataGridView1.DataSource = loaddata;

                //Hiding the id row
                Loan_dataGridView1.Columns[10].Visible = false;

                Loan_dataGridView1.Columns[1].HeaderText = "Loan Type";
                Loan_dataGridView1.Columns[2].HeaderText = "Loan Amount";
                Loan_dataGridView1.Columns[5].HeaderText = "Monthly Payment";
                Loan_dataGridView1.Columns[6].HeaderText = "Total Repayment";
                Loan_dataGridView1.Columns[7].HeaderText = "Issue Date";
                Loan_dataGridView1.Columns[8].HeaderText = "Due Date";



            }
            catch (Exception)
            {

                MessageBox.Show("Unable to load properly!\nPlease refresh tab!");
            }

        }

        //loading the database into the program
        private void Loan_Management_Load(object sender, EventArgs e)
        {

            try
            {
                saveEditBtn.Enabled = false;
                del_btn.Enabled = false;
                aprv_button.Enabled = false;

                loadDatabase();


                //Displaying Loan Type in Loan Type Dropdown
                var loanType = _DbEntities.LoanTypes.ToList();
                LoanType_comboBox1.DisplayMember = "Type";
                LoanType_comboBox1.ValueMember = "Id";
                LoanType_comboBox1.DataSource = loanType;
                LoanType_comboBox1.SelectedItem = null;

                //Displaying Loan Terms in Duration Dropdown
                var loanTerm = _DbEntities.LoanTerms.ToList();
                LoanTerm_comboBox2.DisplayMember = "Term";
                LoanTerm_comboBox2.ValueMember = "Id";
                LoanTerm_comboBox2.DataSource = loanTerm;
                LoanTerm_comboBox2.SelectedItem = null;



                // Displaying Customer FullName in Customers dropdown
                var CustomerRole = _DbEntities.PersonnelRoleTables.FirstOrDefault(x => x.personnelRole == "Customer");
                var Customers = _DbEntities.Personnel_Table.Where(x =>
                                _DbEntities.Personnel_Login_LinkerTable.Any(l =>
                                l.personnel_Role_ID == CustomerRole.id && x.id == l.Personnel_ID)).ToList();

                Customer_comboBox1.DisplayMember = "Fullname";
                Customer_comboBox1.ValueMember = "id";
                Customer_comboBox1.DataSource = Customers;
                Customer_comboBox1.SelectedItem = null;

            }
            catch (Exception)
            {

                MessageBox.Show("Unable to Load!");
            }
        }

        //getting the interest form the database
       public void getloanInterest()
        {
            if (LoanType_comboBox1 != null)
            {


                var loan_selectedValue = Convert.ToInt32(LoanType_comboBox1.SelectedValue);

                var getIterestId = _DbEntities.LoanTypes.FirstOrDefault(x => x.Id == loan_selectedValue);
                var intRate = _DbEntities.LoanInterests.FirstOrDefault(x => x.Id == getIterestId.LoanInterest_Id);
                Interest_Tb.Text = (intRate.Rate).ToString();
            }

            else
            {
                MessageBox.Show("Populate the appropriate fields.");
            }

        }

        //Set all text box and all combo box to empty
        public void setNull()
        {
            Customer_comboBox1.SelectedItem = null;
            LoanType_comboBox1.SelectedItem = null;
            LoanTerm_comboBox2.SelectedItem = null;
            Interest_Tb.Text = "";
            LoanAmount_tb.Text = "";
        }

        //add new loan to the database
        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //Check to see if any of the input boxes are empty
                if (Customer_comboBox1 == null || LoanType_comboBox1 == null || LoanTerm_comboBox2 == null || LoanAmount_tb.Text == "")
                {
                    //Display appropriate message
                    MessageBox.Show("Populate all fields");
                }
                else
                {
                    //Get ID number for selected item in the appropriate comboboxes
                    var customer_selectedValue = Convert.ToInt32(Customer_comboBox1.SelectedValue);
                    var loan_selectedValue = Convert.ToInt32(LoanType_comboBox1.SelectedValue);
                    var term_selectedValue = Convert.ToInt32(LoanTerm_comboBox2.SelectedValue);



                    //check selected item ID number against item in appropriate table in batabases
                    var CustomerName = _DbEntities.Personnel_Table.FirstOrDefault
                                        (x => x.id == customer_selectedValue);

                    var loanType = _DbEntities.LoanTypes.FirstOrDefault
                                    (x => x.Id == loan_selectedValue);

                    var loanTerm = _DbEntities.LoanTerms.FirstOrDefault
                                    (x => x.Id == term_selectedValue);

                   

                   // Checking if a valu was returned from the database
                    if (loanType != null && CustomerName != null && loanTerm != null)

                    { 

                                //Creating a new LoanTermLinkTable object to push to appropriate information to the database
                                var setloanTerm = new LoanRequest_Linker();
                                setloanTerm.LoanTerm_Id = loanTerm.Id;
                                setloanTerm.LoanType_Id = loanType.Id;
                                setloanTerm.Customer_Id = CustomerName.id;
                                _DbEntities.LoanRequest_Linker.Add(setloanTerm);

                                    var intRate = Convert.ToDouble(Interest_Tb.Text);
                        var duration = Convert.ToDouble(loanTerm.Term);
                        var principal = Convert.ToDouble(LoanAmount_tb.Text);
                        var monthlyPayment = Utils.MonthlyPayment(principal, intRate, duration);

                                     //Get new loan record
                                var loanIssue = new loanIssueance();
                                    loanIssue.LoanAmount = Convert.ToDecimal(LoanAmount_tb.Text);
                                    loanIssue.MonthlyPayment = Convert.ToDecimal(monthlyPayment);
                                    loanIssue.Total = Convert.ToDecimal(monthlyPayment * duration);
                                    loanIssue.LoanRequest_Id = setloanTerm.Id;
                                    loanIssue.status = "Pending";
                                    loanIssue.StartDate = DateTime.Today;
                                  /* Assuming that every month has 28 days, multiply the current date of the application
                                     by 28 to get the due date*/

                                    loanIssue.EndDate = DateTime.Today.AddMonths(Convert.ToInt32(loanTerm.Term) / 12);
                                   //Add loan record to the database
                                      _DbEntities.loanIssueances.Add(loanIssue);

                                //Saving addition to the database
                                _DbEntities.SaveChanges();

                              loadDatabase();

                        setNull();

                    }

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.\n Please try again!");
            }
        }

        //Setting the loan amount textbox to only accept numbers
        private void LoanAmount_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // setting the interest rate text box to get the interest rate of the selected loan
        private void LoanType_comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                getloanInterest();
            }
            catch (Exception)
            {

                MessageBox.Show("Something went wrong.\nPlease try again.");
            }
        
        }

        //Double click to select the row you want to make changes to
        private void Loan_dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Enable delete and save edit button, disable add button
            del_btn.Enabled = true;
            saveEditBtn.Enabled = true;
            addBtn.Enabled = false;

            var statusindexValue = Loan_dataGridView1.CurrentRow.Cells[9].Value.ToString();

            if(statusindexValue == "Approved")
            {
                aprv_button.Enabled = false;
                del_btn.Enabled = false;
            }

            else if(statusindexValue == "Pending")
            {
                aprv_button.Enabled = true;
                del_btn.Enabled = true;
            }

            //Get the selected/Current row values
            var customerNameIndexValue = Loan_dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var loanTypeIndexValue = Loan_dataGridView1.CurrentRow.Cells[1].Value.ToString();
            var loanAmountIndexValue = Loan_dataGridView1.CurrentRow.Cells[2].Value.ToString();
            var loanTermindexValue = Convert.ToDecimal(Loan_dataGridView1.CurrentRow.Cells[3].Value);


            //check selected item ID number against item in appropriate table in batabases

            var CustomerName = _DbEntities.Personnel_Table.FirstOrDefault
                                (x => x.FirstName + " " + x.MiddleName + " " + x.LastName == customerNameIndexValue).id;

            var loanType = _DbEntities.LoanTypes.FirstOrDefault
                            (x => x.Type == loanTypeIndexValue).Id;

            var loanTerm = _DbEntities.LoanTerms.FirstOrDefault
                            (x => x.Term == loanTermindexValue);

            //getting the selected items in the appropriate boxes
            Customer_comboBox1.SelectedValue = CustomerName;
            LoanTerm_comboBox2.SelectedValue = loanTerm.Id;
            LoanType_comboBox1.SelectedValue = loanType;
            LoanAmount_tb.Text = loanAmountIndexValue;

            //setting the interest rate for the interest rate text box
            getloanInterest();

        }

        //update the changes of the selected loan to the same id selected in the database
        private void updateBtn_Click(object sender, EventArgs e)
        {  

            var selectedRowId = Convert.ToInt32(Loan_dataGridView1.SelectedRows[0].Cells["Id"].Value);

            var loan = _DbEntities.loanIssueances.FirstOrDefault(x => x.LoanRequest_Id == selectedRowId);

            var duration = Convert.ToDouble(LoanTerm_comboBox2.GetItemText(LoanTerm_comboBox2.SelectedItem).ToString());
            var amount = Convert.ToDouble(LoanAmount_tb.Text);
            var interest = Convert.ToDouble(Interest_Tb.Text);
       

            var monthlyPayment = Convert.ToDecimal(Utils.MonthlyPayment
                                               (amount, interest, duration));
            

            loan.StartDate = DateTime.Today;
            loan.EndDate = DateTime.Today.AddMonths(Convert.ToInt32(duration) / 12);
            loan.MonthlyPayment = monthlyPayment;
            loan.Total = monthlyPayment * Convert.ToDecimal(duration);
            loan.status = "Pending";
            loan.LoanAmount = Convert.ToDecimal(LoanAmount_tb.Text);

            var customerNameIndexValue = Customer_comboBox1.GetItemText(Customer_comboBox1.SelectedItem);
            var loanTypeIndexValue = LoanType_comboBox1.GetItemText(LoanType_comboBox1.SelectedItem);
            var loanTermindexValue = Convert.ToDecimal(LoanTerm_comboBox2.GetItemText(LoanTerm_comboBox2.SelectedItem));

            var loanLink = _DbEntities.LoanRequest_Linker.FirstOrDefault(x => x.Id == selectedRowId);

                var CustomerName = _DbEntities.Personnel_Table.FirstOrDefault
                                 (x => x.FirstName + " " + x.MiddleName + " " + x.LastName == customerNameIndexValue);
                var loanType = _DbEntities.LoanTypes.FirstOrDefault
                                (x => x.Type == loanTypeIndexValue).Id;
                var loanTerm = _DbEntities.LoanTerms.FirstOrDefault
                                (x => x.Term == loanTermindexValue).Id;

            loanLink.LoanTerm_Id = loanTerm;
            loanLink.LoanType_Id = loanType;
            loanLink.Customer_Id = CustomerName.id;
           
            _DbEntities.SaveChanges();
            
            del_btn.Enabled = false;    
            saveEditBtn.Enabled = false;
            addBtn.Enabled = true;


            getloanInterest();
            loadDatabase();

            setNull();

        }

        //Delete the seleceted row from the database
        private void del_btn_Click(object sender, EventArgs e)
        {
            try
            {
                
                //check if the user wants to delete to loan request selected

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the selected loan request?", "Delete Loan", MessageBoxButtons.YesNo);
                //If yes then do the following
                if (dialogResult == DialogResult.Yes)
                {
                    //get selected row id
                    var selectedRowId = Convert.ToInt32(Loan_dataGridView1.SelectedRows[0].Cells["Id"].Value);
                    //Check if the selected row is greater than "0"
                    if(selectedRowId > 0)
                    {
                        //check the database appropriate tables for the id
                        var loan = _DbEntities.loanIssueances.FirstOrDefault(x => x.LoanRequest_Id == selectedRowId);

                        if (loan != null)
                        {
                            var loanLink = _DbEntities.LoanRequest_Linker.FirstOrDefault(x => x.Id == selectedRowId);

                            //If the selected id is found in the database, remove/ delete it from the database
                            _DbEntities.LoanRequest_Linker.Remove(loanLink);
                            _DbEntities.loanIssueances.Remove(loan);
                            //Save the changes
                            _DbEntities.SaveChanges();
                            // Display deletion confirmation
                            dialogResult = MessageBox.Show("Loan Request has been deleted!", "Deletion Confirmation", MessageBoxButtons.OK);
                        }

                    }
               
                }
                //do nothing if the user selects no
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

                //Set the delete and edit button to disable and the add btn to enable
                del_btn.Enabled = false;
                saveEditBtn.Enabled = false;
                addBtn.Enabled = true;

                // Refresh the database
                loadDatabase();

                //Set all textbox and combobox to null
                setNull();
            }

            //Set failed if anything else happens while trying the edit a selected item
            catch (Exception)
            {

                DialogResult dialogResult = MessageBox.Show("Something went wrong\nPlease try again!", "Edit failed", MessageBoxButtons.OK);

            }


        }

        //Approve selected loan
        private void aprv_button_Click(object sender, EventArgs e)
        {
            try
            {
                //Get selected row id
                var selectedRowId = Convert.ToInt32(Loan_dataGridView1.SelectedRows[0].Cells["Id"].Value);

                //get if select row id is greater than "0"
                if (selectedRowId > 0)
                {
                    // checking if the selected ow id is in the database
                    var loan = _DbEntities.loanIssueances.FirstOrDefault(x => x.LoanRequest_Id == selectedRowId);
                    if (loan != null)
                    {
                        //equal status to "Approved"
                        loan.status = "Approved";

                        //Saving the changes
                        _DbEntities.SaveChanges();

                        aprv_button.Enabled = false;
                        del_btn.Enabled = false;



                        //Set all textbox and combobox to null
                        setNull();

                        //Display confirmation message
                        DialogResult dialogResult = MessageBox.Show("Selected loan has been approved!", "Approval Confirmation", MessageBoxButtons.OK);
                    }

                    else
                    {
                        //desplay failed message
                        DialogResult dialogResult = MessageBox.Show("No loan was selected!", "Approval Failed", MessageBoxButtons.OK);

                    }

                }
                //if fail
                else
                {
                    //desplay failed message
                    DialogResult dialogResult = MessageBox.Show("No loan was selected!", "Approval Failed", MessageBoxButtons.OK);

                }

                //refresh database
                loadDatabase();

            }//display failed message if the anything occur while trying to approve a loan
            catch (Exception)
            {

                DialogResult dialogResult = MessageBox.Show("Something went wrong\nPlease try again!", "Approval Failed", MessageBoxButtons.OK);
            }

        }

        private void MakePayment_Btn_Click(object sender, EventArgs e)
        {
            MakePayment makePayment = new MakePayment(getSignedIn);
            if(!Utils.FormIsOpen(makePayment))
            {
                MainWindow mainWindow = new MainWindow(login, getSignedIn, timeLoggedIn, userName_check);
                makePayment.MdiParent = mainWindow.MdiParent;
                makePayment.Show();
            }
            {
                MainWindow mainWindow = new MainWindow(login, getSignedIn, timeLoggedIn, userName_check);
                makePayment.MdiParent = mainWindow.MdiParent;
            }
           
        }
    }

}
