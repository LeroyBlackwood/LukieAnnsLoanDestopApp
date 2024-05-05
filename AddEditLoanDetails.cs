using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LukieAnnLoansAndFinancialServicesApp
{
    public partial class AddEditLoanDetails : Form
    {   
        //Get database
        private readonly LukieAnnsLoans_dbEntities _DbEntities = new LukieAnnsLoans_dbEntities();
        
        //Checking if edit mode for loan type, interest type, and loan term 
        private bool isLoanTypeEditMode = false;
        private bool isLoanInterestEditMode = false;
        private bool isLoanTermEditMode = false;

        //Get user login role
        private PersonnelRoleTable getRole;

        public AddEditLoanDetails()
        {
            InitializeComponent();

        }

        public AddEditLoanDetails(PersonnelRoleTable getRole)
        {  //initializing the user login role
            this.getRole = getRole;
            InitializeComponent();
        }

        private void loadLoanTypeDatabase()
        {
            try
            {  
                //Display Loans type into dataGrid
                var loanData = (
                    from type in _DbEntities.LoanTypes
                    join intRate in _DbEntities.LoanInterests
                            on type.LoanInterest_Id equals intRate.Id 
               
                    select new
                    {
                        type.Type,
                        intRate.Rate,
                        type.Id

                    }).ToList();
                LoanType_Gridview.DataSource = loanData;
                LoanType_Gridview.Columns[2].Visible = false;

                LoanType_Gridview.Columns[0].HeaderText = "Loan Type";
                LoanType_Gridview.Columns[1].HeaderText = "Assigned Interest";

            }

            catch (Exception)
            {
                MessageBox.Show("Unable to load properly!\nPlease refresh tab!");
            }

        }
        private void loadLoanInterestDatabase()
        {

            //Display interest rate in grid view
            var loanInterestDisplay = (from intRate in _DbEntities.LoanInterests
                                       select new
                                       {
                                           intRate.Rate,
                                           intRate.Id
                                       }).ToList();
            IntRate_GridView.DataSource = loanInterestDisplay;
            IntRate_GridView.Columns[1].Visible = false;

            IntRate_GridView.Columns[0].HeaderText = "Interest Rate";
        }
        private void loadLoanTermDataBase()
        {
            try
            {
                //Disply loan term in grid view
                var loanTermDisplay
                    = (

                  from term in _DbEntities.LoanTerms

                  select new
                  {
                      term.Term,
                      term.Id
                  }).ToList();

                Duration_dataGridView.DataSource = loanTermDisplay;

                Duration_dataGridView.Columns[1].Visible = false;

                Duration_dataGridView.Columns[0].HeaderText = "Duration in Months";
            }
            catch (Exception)
            {

                throw;
            }
        }




        //Get and Display all the Interest Rates within the database
        private void AddEditLoanDetails_Load(object sender, EventArgs e)
        {
            try
            {
                var rate = _DbEntities.LoanInterests.ToList();
                InterestRate_comboBox1.DisplayMember = "Rate";
                InterestRate_comboBox1.ValueMember = "Id";
                InterestRate_comboBox1.DataSource = rate;
                InterestRate_comboBox1.SelectedItem = null;

            }
            catch (Exception)
            {

                MessageBox.Show("Unable to load correctly.");
            }

            loadLoanTypeDatabase();
            loadLoanTermDataBase();
            loadLoanInterestDatabase();

            LoanEdit_btn.Enabled = false;
            IntRateEdit_btn.Enabled = false;
            TermEdit_btn.Enabled = false;

            LoanTypeMode_tb.Text = "Add Mode";
            InterestMode_lb.Text = "Add Mode";
            TermMode_lb.Text = "Add Mode";

            LoanTypeDelete_Btn.Enabled = false;
            IntRateDelete_Btn.Enabled = false;
            DurationDelete_Btn.Enabled = false;

        }


        private void SaveLoan_Type_btn_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRate = Convert.ToDecimal(InterestRate_comboBox1.GetItemText(InterestRate_comboBox1.SelectedItem));
                var LoanInterestId = _DbEntities.LoanInterests.FirstOrDefault(x => x.Rate == selectedRate);

                if (isLoanTypeEditMode)
                {

                    if (LoanInterestId.ToString() != null)
                    {
                        var checkDb = _DbEntities.LoanTypes.FirstOrDefault(x => x.Type == LoanType_tb.Text);
                        if (checkDb == null)
                        {
                            if (InterestRate_comboBox1.SelectedText != null)
                            {
                                var selectedRowId = Convert.ToInt32(LoanType_Gridview.SelectedRows[0].Cells["Id"].Value);

                                var selectedType = _DbEntities.LoanTypes.FirstOrDefault(x => x.Id == selectedRowId);

                                if (selectedType != null)
                                {

                                    MessageBox.Show("Changes made.\n\n" + selectedType.Type + " was changed to "
                                                                        + LoanType_tb.Text + " and was assigned interest of "
                                                                        + LoanInterestId.Rate + "%", "Success");

                                    selectedType.Type = LoanType_tb.Text;
                                    selectedType.LoanInterest_Id = LoanInterestId.Id;

                                    LoanType_tb.Text = "";
                                    InterestRate_comboBox1.SelectedItem = null;
                                    InterestRate_comboBox1.Text = "";


                                    _DbEntities.SaveChanges();

                                    loadLoanTypeDatabase();

                                    isLoanTypeEditMode = false;
                                    LoanTypeMode_tb.Text = "Add Mode";
                                }

                                else
                                {

                                }

                            }

                        }

                        else
                        {
                            MessageBox.Show("This loan Type already exist!");
                        }
                    }

                    else
                    {
                        MessageBox.Show("Assign a interest rate to the loan.");
                    }
                }
                else if (!isLoanTypeEditMode)
                {
                    try
                    {
                        if (LoanInterestId != null)
                        {
                            if (LoanType_tb.Text != null)
                            {
                                if (InterestRate_comboBox1.SelectedText != null)
                                {
                                    var checkDb = _DbEntities.LoanTypes.FirstOrDefault(x => x.Type == LoanType_tb.Text);
                                    if (checkDb == null)
                                    {
                                        var loanType = new LoanType
                                        {

                                            Type = LoanType_tb.Text,
                                            LoanInterest_Id = LoanInterestId.Id
                                        };

                                        _DbEntities.LoanTypes.Add(loanType);
                                        MessageBox.Show("New Loan Type Added");
                                        _DbEntities.SaveChanges();

                                        loadLoanTypeDatabase();


                                        LoanType_tb.Text = "";
                                        InterestRate_comboBox1.SelectedItem = null;
                                    }

                                    else
                                    {
                                        MessageBox.Show("This loan type already exist!");
                                    }


                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Field is empty!");
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Field is empty!");
                    }


                }

            }
            catch (Exception)
            {

                MessageBox.Show("Something went wrong\nplease try again!");
            }

        }
        private void SaveInterest_Click(object sender, EventArgs e)
        {
            try
            {
                if (isLoanInterestEditMode)
                {
                    if (Interest_tb.Text != null)
                    {
                        var selectedRate = Interest_tb.Text;

                        var LoanInterestId = _DbEntities.LoanInterests.FirstOrDefault(x => x.Rate.ToString() == selectedRate);

                        if (LoanInterestId == null)
                        {
                            var selectedRow = Convert.ToInt32(IntRate_GridView.SelectedRows[0].Cells["Id"].Value);

                            var selectedInterest = _DbEntities.LoanInterests.FirstOrDefault(x => x.Id == selectedRow);

                            MessageBox.Show("Changes made\n\n Interest Rate: " + selectedInterest.Rate + "%"
                                          + " is now " + Interest_tb.Text + "%", "Success");

                            selectedInterest.Rate = Convert.ToInt32(Interest_tb.Text);

                            _DbEntities.SaveChanges();


                            var rate = _DbEntities.LoanInterests.ToList();
                            InterestRate_comboBox1.DisplayMember = "Rate";
                            InterestRate_comboBox1.ValueMember = "Id";
                            InterestRate_comboBox1.DataSource = rate;
                            InterestRate_comboBox1.SelectedItem = null;

                            loadLoanInterestDatabase();
                            loadLoanTypeDatabase();

                            isLoanInterestEditMode = false;
                            InterestMode_lb.Text = "Add Mode";
                            Interest_tb.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("This Interest Rate already exist!");
                        }
                        
                    }
           
                }

                else if (!isLoanInterestEditMode)
                {
                if (Interest_tb.Text != null)
                {
                    //Gettting the selected interest rate from the drop down box
                    var selectedRate = Interest_tb.Text;

                    //Getting the Id from the database for the interest rate got from the dropdown box
                    var LoanInterestId = _DbEntities.LoanInterests.FirstOrDefault(x => x.Rate.ToString() == selectedRate);
                    if (LoanInterestId == null)

                    {
                        var loanInterest = new LoanInterest
                        {
                            Rate = int.Parse(Interest_tb.Text),
                        };
                        _DbEntities.LoanInterests.Add(loanInterest);

                        MessageBox.Show("New Interest Rate Added.");
                        _DbEntities.SaveChanges();

                        var rate = _DbEntities.LoanInterests.ToList();
                        InterestRate_comboBox1.DisplayMember = "Rate";
                        InterestRate_comboBox1.ValueMember = "Id";
                        InterestRate_comboBox1.DataSource = rate;
                        InterestRate_comboBox1.SelectedItem = null;

                        loadLoanInterestDatabase();

                            Interest_tb.Text = "";

                            isLoanTermEditMode = false;
                            InterestMode_lb.Text = "Add Mode";
                    }
                    else
                    {
                        MessageBox.Show("This Interest Rate already exist!");
                    }

                }

                }

            }
            catch (Exception)
            {

                MessageBox.Show("Enter the correct value!");
            }

        }
        private void SaveDuration_button_Click(object sender, EventArgs e)
        {

            try
            {
                if (isLoanTermEditMode)
                {
                    if (Term_tb.Text != null)
                    {
                        var getTerm = _DbEntities.LoanTerms.FirstOrDefault(x => x.Term.ToString() == Term_tb.Text);

                        if (getTerm == null)
                        {
                            var selectedRow = Convert.ToInt32(Duration_dataGridView.SelectedRows[0].Cells["Id"].Value);

                            var selectedTerm = _DbEntities.LoanTerms.FirstOrDefault(x => x.Id == selectedRow);

                            MessageBox.Show("Changes made\n\n Loan Duration: " + selectedTerm.Term + " Months"
                                            + " is now " + Term_tb.Text + " Months", "Success");

                            selectedTerm.Term = Convert.ToDecimal(Term_tb.Text);


                            _DbEntities.SaveChanges();

                            loadLoanTermDataBase();

                            Term_tb.Text = "";

                            isLoanTermEditMode = false;
                            TermMode_lb.Text = "Add Mode";

                        }
                        else
                        {
                            MessageBox.Show("This Duration Rate already exist!");
                        }
                    }

                }
                else if(!isLoanTermEditMode)
                {
                    if (Term_tb.Text != null)
                    {
                        var getTerm = _DbEntities.LoanTerms.FirstOrDefault(x => x.Term.ToString() == Term_tb.Text);

                        if (getTerm == null)
                        {

                            var loanTerm = new LoanTerm
                            {
                                Term = Convert.ToDecimal(Term_tb.Text),
                            };

                            _DbEntities.LoanTerms.Add(loanTerm);
                            MessageBox.Show("New duration was entered");

                            _DbEntities.SaveChanges();

                            loadLoanTermDataBase();
                            Term_tb.Text = "";
                        }

                        else
                        {
                            MessageBox.Show("Duration already exist");
                        }



                    }

                }
                else
                {
                    MessageBox.Show("Enter the correct value.");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Enter the correct value.");
            } 
        

        }
        private void Duration_dataGridView_Click(object sender, EventArgs e)
        {
            TermEdit_btn.Enabled = true;
            DurationDelete_Btn.Enabled = true;
        }
        private void IntRate_GridView_Click(object sender, EventArgs e)
        {
            try
            {
            IntRateEdit_btn.Enabled = true;
            IntRateDelete_Btn.Enabled = true;


            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong\nPlease try again!");
            }
        }
        private void LoanType_Gridview_Click(object sender, EventArgs e)
        {
            try
            {
                LoanEdit_btn.Enabled = true;
                LoanTypeDelete_Btn.Enabled = true;  


            }
            catch (Exception)
            {

                MessageBox.Show("Something went wrong.\nPlease try again.");
            }
        }




        private void LoanEdit_btn_Click(object sender, EventArgs e)
        {
            try
            {
                isLoanTypeEditMode = true;
                LoanTypeMode_tb.Text = "Edit Mode";

                var selectedLoanType = LoanType_Gridview.CurrentRow.Cells[0].Value.ToString();
                LoanType_tb.Text = selectedLoanType;

                var selectedRow = _DbEntities.LoanTypes.FirstOrDefault(x => (x.Type).ToString() == selectedLoanType);
                var selectedIntRate = _DbEntities.LoanInterests.FirstOrDefault(x => (x.Id) == selectedRow.LoanInterest_Id);
                InterestRate_comboBox1.SelectedValue = selectedIntRate.Id;
            }
            catch (Exception)
            {

                MessageBox.Show("Something went wrong.\nPlease try again.");
            }
      
        }
        private void IntRateEdit_btn_Click(object sender, EventArgs e)
        {
            try
            {
              isLoanInterestEditMode = true;
                IntRateDelete_Btn.Enabled = true;

                InterestMode_lb.Text = "Edit Mode";
                var selectedRow = IntRate_GridView.CurrentRow.Cells[0].Value.ToString();
                        Interest_tb.Text = selectedRow;
            }
            catch (Exception)
            {

                MessageBox.Show("Something went wrong.\nPlease try again.");
            }

        }
        private void TermEdit_btn_Click(object sender, EventArgs e)
        {
            try
            {
                isLoanTermEditMode = true;
                DurationDelete_Btn.Enabled = true;
                TermMode_lb.Text = "Edit Mode";
                var selectedRow = Duration_dataGridView.CurrentRow.Cells[0].Value.ToString();
                Term_tb.Text = selectedRow;
            }
            catch (Exception)
            {

                MessageBox.Show("Something went wrong.\nPlease try again.");

            }
        }


        private void LoanType_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Interest_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Term_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        //Delete loan Type
        private void LoanTypeDelete_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the selected loan type?",
                                                "Delete Loan Type", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var selectedRow = Convert.ToInt32(LoanType_Gridview.SelectedRows[0].Cells["Id"].Value);

                    var selecteditems = _DbEntities.LoanTypes.FirstOrDefault(x => x.Id == selectedRow);

                    if (selecteditems != null)
                    { var checkLoanReqLinker = _DbEntities.LoanRequest_Linker.FirstOrDefault
                            (x => x.Customer_Id == selecteditems.Id);
                        if (checkLoanReqLinker != null)
                        {
                            MessageBox.Show("Durations assigned to a loan requested connot be deleted.");

                        }
                        else
                        {
                            _DbEntities.LoanTypes.Remove(selecteditems);

                            _DbEntities.SaveChanges();

                            MessageBox.Show(selecteditems.Type + " was selected and has been deleted.", "Delete Loan Type");


                            loadLoanTypeDatabase();
                            LoanEdit_btn.Enabled = false;
                            LoanTypeDelete_Btn.Enabled = false;
                        }
                     
                    }
                    else
                    {
                        MessageBox.Show("No loan type was selected.", "Delete Loan Type");
                    }

                }

                else
                {
                    MessageBox.Show("Selected loan type deletion has been canceled.", "Delete Loan Type");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong\nPlease try again!");
            }
        }

        private void DurationDelete_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the selected loan duration?",
                                                "Delete Loan Duration", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var selectedRow = Convert.ToInt32(Duration_dataGridView.SelectedRows[0].Cells["Id"].Value);

                    var selecteditems = _DbEntities.LoanTerms.FirstOrDefault(x => x.Id == selectedRow);

                    if (selecteditems != null)
                    {
                        var checkedCusReq_Linker = _DbEntities.LoanRequest_Linker.FirstOrDefault(x => x.LoanTerm_Id == selecteditems.Id);
                        if (checkedCusReq_Linker != null) 
                            {
                            MessageBox.Show("Durations assigned to a loan requested connot be deleted.");
                            }
                        else
                        {
                            _DbEntities.LoanTerms.Remove(selecteditems);

                            MessageBox.Show("The Duration of: " + selecteditems.Term + " Months was selected and has been deleted.", "Delete Duration");
                            _DbEntities.SaveChanges();

                            loadLoanTermDataBase();
                            TermEdit_btn.Enabled = false;
                            DurationDelete_Btn.Enabled = false;

                        }


                    }
                    else
                    {
                        MessageBox.Show("No Duration was selected.", "Delete Duration");
                    }

                }

                else
                {
                    MessageBox.Show("Selected Duration deletion has been canceled.", "Delete Duration");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.\n Please try again!");
            }

        }

        private void IntRateDelete_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the selected interest rate?",
                                                "Delete Interest Rate", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var selectedRow = Convert.ToInt32(IntRate_GridView.SelectedRows[0].Cells["Id"].Value);

                    var selecteditems = _DbEntities.LoanInterests.FirstOrDefault(x => x.Id == selectedRow);

                    if (selecteditems != null)
                    {
                        var intRateId = _DbEntities.LoanTypes.FirstOrDefault(x => x.LoanInterest_Id == selecteditems.Id);
                        if(intRateId == null)
                        {
                            _DbEntities.LoanInterests.Remove(selecteditems);

                            _DbEntities.SaveChanges();

                            MessageBox.Show("The Interest Rate: " + selecteditems.Rate + " was selected and has been deleted.", "Delete Interest Rate");

                            var rate = _DbEntities.LoanInterests.ToList();
                            InterestRate_comboBox1.DisplayMember = "Rate";
                            InterestRate_comboBox1.ValueMember = "Id";
                            InterestRate_comboBox1.DataSource = rate;
                            InterestRate_comboBox1.SelectedItem = null;

                            loadLoanInterestDatabase();
                            loadLoanTypeDatabase();
                            IntRateEdit_btn.Enabled = false;
                            IntRateDelete_Btn.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Interest rates assigned to a loan request connot be deleted.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("No interest rate was selected.", "Delete Interest Rate");
                    }

                }

                else
                {
                    MessageBox.Show("Selected interest rate deletion has been canceled.", "Delete Interest Rate");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.\nPlease try again");
            }

        }
    } 
}

        
