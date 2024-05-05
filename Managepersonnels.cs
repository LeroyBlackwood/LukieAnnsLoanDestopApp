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
    public partial class Managepersonnels : Form
    {

        private readonly LukieAnnsLoans_dbEntities _DbEntities = new LukieAnnsLoans_dbEntities();
        public PersonnelRoleTable getSignIn;
        public Managepersonnels()
        {
            InitializeComponent();
            _DbEntities = new LukieAnnsLoans_dbEntities();
        }

        public Managepersonnels(PersonnelRoleTable getRole)
        {
            this.getSignIn = getRole;
            InitializeComponent();
        }

        private void loadPersonnel_DB()
        {
            if (getSignIn.personnelRole != "Administrator")
            {
                var personnels = (from personnelLinker in _DbEntities.Personnel_Login_LinkerTable
                                  join personnel in _DbEntities.Personnel_Table
                                       on personnelLinker.Personnel_ID equals personnel.id
                                  join personnelRole in _DbEntities.PersonnelRoleTables
                                       on personnelLinker.personnel_Role_ID equals personnelRole.id
                               

                                  where personnelRole.personnelRole == "Customer"

                                  select new
                                  {
                                      personnel = personnel.FirstName + " " + personnel.MiddleName + " " + personnel.LastName,
                                      personnel.Address,
                                      personnel.emailAddress,
                                      personnel.Telephone,
                                      personnelRole.personnelRole,
                                      personnel.id,
                                      LinkerID = personnelLinker.id,
                                      Role_ID = personnelRole.id

                                     }).ToList();

                Personnel_dataGridView.DataSource = personnels;
                Personnel_dataGridView.Columns[5].Visible = false;
                Personnel_dataGridView.Columns[6].Visible = false;
                Personnel_dataGridView.Columns[7].Visible = false;


                Personnel_dataGridView.Columns[0].HeaderText = "Personnel Name";
                Personnel_dataGridView.Columns[1].HeaderText = "Address";
                Personnel_dataGridView.Columns[2].HeaderText = "Email Address";
                Personnel_dataGridView.Columns[3].HeaderText = "Phone No.";
                Personnel_dataGridView.Columns[4].HeaderText = "Role";
              //  Personnel_dataGridView.Columns[9].HeaderText = "Time Logged In";
              //  Personnel_dataGridView.Columns[10].HeaderText = "Time Logged Out";
            }

           else if(getSignIn.personnelRole == "Administrator")
                {
                var personnels = (from personnelLinker in _DbEntities.Personnel_Login_LinkerTable
                                  join personnel in _DbEntities.Personnel_Table
                                       on personnelLinker.Personnel_ID equals personnel.id
                                  join personnelRole in _DbEntities.PersonnelRoleTables
                                       on personnelLinker.personnel_Role_ID equals personnelRole.id
                          where personnelRole.id == personnelLinker.personnel_Role_ID

                                  where personnel.id == personnelLinker.Personnel_ID &&
                                        personnelRole.id == personnelLinker.personnel_Role_ID &&
                                        personnelRole.personnelRole != null

                                  select new
                                  {
                                      personnel = personnel.FirstName + " " + personnel.MiddleName + " " + personnel.LastName,
                                      personnel.Address,
                                      personnel.emailAddress,
                                      personnel.Telephone,
                                      personnelRole.personnelRole,
                                      personnel.id,
                                      LinkerID = personnelLinker.id,
                                      Role_ID = personnelRole.id

                                  }).ToList();
                Personnel_dataGridView.DataSource = personnels;

                Personnel_dataGridView.Columns[5].Visible = false;
                Personnel_dataGridView.Columns[6].Visible = false;
                Personnel_dataGridView.Columns[7].Visible = false;




                Personnel_dataGridView.Columns[0].HeaderText = "Personnel Name";
                Personnel_dataGridView.Columns[1].HeaderText = "Address";
                Personnel_dataGridView.Columns[2].HeaderText = "Email Address";
                Personnel_dataGridView.Columns[3].HeaderText = "Phone No.";
                Personnel_dataGridView.Columns[4].HeaderText = "Role";
         
            }
            else
            {
                MessageBox.Show("Unable to laod!", "Failure");
            }
        }

        private void loadrole_DB()
        {
           if (getSignIn.personnelRole!= "Administrator")
            {
                var role = (from personnelRole in _DbEntities.PersonnelRoleTables

                            where personnelRole.personnelRole == "Customer"
                            select new
                            {
                                personnelRole.personnelRole,
                                personnelRole.roleShortName,
                                personnelRole.id

                            }).ToList();

                roles_dataGridView.DataSource = role;
                roles_dataGridView.Columns[2].Visible = false;

                roles_dataGridView.Columns[1].HeaderText = "Role Short Name";
                roles_dataGridView.Columns[0].HeaderText = "Role";
            }

            else if (getSignIn.personnelRole == "Administrator")
            {
                var role = (from personnelRole in _DbEntities.PersonnelRoleTables

                            select new
                            {
                                personnelRole.personnelRole,
                                personnelRole.roleShortName,
                                personnelRole.id

                            }).ToList();

                roles_dataGridView.DataSource = role;
                roles_dataGridView.Columns[2].Visible = false;

                roles_dataGridView.Columns[1].HeaderText = "Role Short Name";
                roles_dataGridView.Columns[0].HeaderText = "Role";
            }

            else
            {
                MessageBox.Show("Unable to load", "Failure");
            }

        }

        private void Managepersonnels_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.getSignIn.personnelRole != "Administrator")
                {
                    var loadRole = _DbEntities.PersonnelRoleTables.Where(x => x.personnelRole == "Customer").ToList();

                    DisplayRole_comboBox.DisplayMember = "PersonnelRole";
                    DisplayRole_comboBox.ValueMember = "Id";
                    DisplayRole_comboBox.DataSource = loadRole;
                    DisplayRole_comboBox.SelectedItem = null;

                    ManageRoles.Visible = false;
                    DisplayRole_comboBox.Enabled = false;
                    ShortName_tb.Enabled = false;
                }

                else if (getSignIn.personnelRole == "Administrator")
                {
                    ManageRoles.Visible = true;
                    DisplayRole_comboBox.Enabled = true;

                    var loadRole = _DbEntities.PersonnelRoleTables.ToList();

                    DisplayRole_comboBox.DisplayMember = "PersonnelRole";
                    DisplayRole_comboBox.ValueMember = "Id";
                    DisplayRole_comboBox.DataSource = loadRole;
                    DisplayRole_comboBox.SelectedItem = null;

                    DisplayRole2_comboBox.DisplayMember = "PersonnelRole";
                    DisplayRole2_comboBox.ValueMember = "Id";
                    DisplayRole2_comboBox.DataSource = loadRole;
                    DisplayRole2_comboBox.SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("Unable to load!");
                }

                loadPersonnel_DB();
                loadrole_DB();

                InactivePersonnel_Btn.Select();
                ManagePersonnels_tab.TabPages.Remove(AddEditPersonnel_tabPage);
                ManagePersonnels_tab.TabPages.Remove(role_tabPage);
                ManagePersonnels_tab.SelectedTab = Personnels_tabPage;
                Del_Btn.Enabled = false;
                Save_Btn.Enabled = false;

            }
            catch (Exception)
            {

                MessageBox.Show("Unable to load");
            }
       
        }
        private void Save_Btn_Click(object sender, EventArgs e)
        {
            try
                // If Edit Mode
            {
                if (ManagePersonnels_tab.SelectedTab == AddEditPersonnel_tabPage)
                {
                    //Edit Customer
                    if (AddEditPersonnel_tabPage.Text == "Edit Personnel")
                    { //Get personnel selected ID and selected role ID
                        var personnel_ID = Convert.ToInt32(Personnel_dataGridView.SelectedRows[0].Cells["id"].Value);
                        var role_id = Convert.ToInt32(Personnel_dataGridView.SelectedRows[0].Cells["Role_ID"].Value);

                        //Use role selected ID to get role table from databae and seleceted ID to get personnel table from database
                        var role = _DbEntities.PersonnelRoleTables.FirstOrDefault(x => x.id == role_id);
                        var personnel = _DbEntities.Personnel_Table.FirstOrDefault(x => x.id == personnel_ID);

                        //Get the selected role from the Dsiplay role drop down box
                        var selectedRole = DisplayRole_comboBox.GetItemText(DisplayRole_comboBox.SelectedItem);
                        var selectedRole_ID = _DbEntities.PersonnelRoleTables.FirstOrDefault(x => x.personnelRole == selectedRole);


                        //Check if any input box is empty
                        if (fName_textBox.Text != "" || lName_textBox.Text != null || UserName_textBox.Text != "")
                        {

                            role.personnelRole = selectedRole_ID.personnelRole;
                            ShortName_tb.Text = selectedRole_ID.roleShortName;

                            personnel.FirstName = fName_textBox.Text;
                            personnel.LastName = lName_textBox.Text;
                            personnel.MiddleName = mName.Text;
                            personnel.Address = Address_textBox.Text;

                            var isEmail = email_textBox.Text.Trim();

                            if (Utils.IsvalidEmail(isEmail))
                            {
                                personnel.emailAddress = email_textBox.Text;
                            }
                            if (phone_textBox.Text != "")
                            {
                                var phoneNO = Convert.ToInt32(phone_textBox.Text.Trim());
                                personnel.Telephone = phoneNO;

                            }
                            else
                            {
                            }
                            var getLogIn = _DbEntities.personnel_LogIn.FirstOrDefault(x => x.Personel_ID == personnel.id);

                            if (getLogIn != null)
                            {
                                getLogIn.Password = "";
                                _DbEntities.SaveChanges();
                                getLogIn.UserName = UserName_textBox.Text;
                                var password = Utils.HashedPassword(Password_textBox.Text);

                                //Check if the password already exist in the database
                                var passwordCheck = _DbEntities.personnel_LogIn.Any(x =>
                                                    x.Password == password);
                                if (!passwordCheck)
                                {
                                    getLogIn.Password = Utils.HashedPassword(Password_textBox.Text);
                                }
                                else if (Password_textBox.Text == "")
                                {

                                }
                                else
                                {
                                    MessageBox.Show("Invalid password", "Password Failed");
                                }
                                if (ActivePersonnel_Btn.Checked)
                                {
                                    getLogIn.isActive = true;
                                }
                                else
                                {
                                    getLogIn.isActive = false;
                                }
                            }

                        }

                        //Saving the updates
                        _DbEntities.SaveChanges();
                        MessageBox.Show("Selected data has been updated.", "Sucess");


                        //Reloading the database
                        loadPersonnel_DB();

                        //setting all input box to empty
                        DisplayRole_comboBox.SelectedItem = null;
                        ShortName_tb.Text = "";
                        fName_textBox.Text = "";
                        lName_textBox.Text = "";
                        mName.Text = "";
                        UserName_textBox.Text = "";
                        email_textBox.Text = "";
                        phone_textBox.Text = "";
                        Address_textBox.Text = "";
                        Password_textBox.Text = "";
                        InactivePersonnel_Btn.Select();

                        //Closing addEdit tab;

                        ManagePersonnels_tab.TabPages.Remove(AddEditPersonnel_tabPage);
                        Save_Btn.Enabled = false;
                    }

                    //If Add Mode 
                    if (AddEditPersonnel_tabPage.Text == "Add Personnel")
                    {
                        
                        //Creating a new customer
                        if (fName_textBox.Text != "" && lName_textBox.Text != null && UserName_textBox.Text != "")
                        {
                            var personnelData = new Personnel_Table();
                                personnelData.FirstName = fName_textBox.Text.Trim();
                                personnelData.MiddleName = mName.Text.Trim();
                                personnelData.LastName = lName_textBox.Text.Trim();
                                personnelData.Address = Address_textBox.Text;
     


                            var isEmail = email_textBox.Text.Trim();

                            if (Utils.IsvalidEmail(isEmail))
                            {
                                personnelData.emailAddress = email_textBox.Text;
                            }
                            else
                            {
                            }
                            if (phone_textBox.Text != "")
                            {
                                var phoneNO = Convert.ToInt32(phone_textBox.Text.Trim());
                                personnelData.Telephone = phoneNO;
                               
                            }
                            else
                            {
                            }

                            _DbEntities.Personnel_Table.Add(personnelData);
                            _DbEntities.SaveChanges();

                            //Assign the existing role id to the new customer
                            // getting the linker table

                            var getLogIn = new personnel_LogIn();
                            getLogIn.Personel_ID = personnelData.id;
                            getLogIn.UserName = UserName_textBox.Text.Trim();
                            var password = Utils.HashedPassword(Password_textBox.Text);

                            //Check if the password already exist in the database
                            var passwordCheck = _DbEntities.personnel_LogIn.Any(x =>
                                                x.Password == password);
                            if(!passwordCheck)
                            {
                                getLogIn.Password = Utils.HashedPassword(Password_textBox.Text);
                            }
                            else if(Password_textBox.Text == "")
                            {

                            }
                            else
                            {
                                MessageBox.Show("Invalid password", "Password Failed");
                            }


                            if (ActivePersonnel_Btn.Checked)
                            {
                                getLogIn.isActive = true;
                            }
                            else if (InactivePersonnel_Btn.Checked)
                            {
                                getLogIn.isActive = false;
                            }

                            _DbEntities.personnel_LogIn.Add(getLogIn);
                            _DbEntities.SaveChanges();

                            //getting the selected role
                            var selectedRole = DisplayRole_comboBox.GetItemText(DisplayRole_comboBox.SelectedItem);
                            //checking the database if the selected role already exist
                            var Role = _DbEntities.PersonnelRoleTables.FirstOrDefault(x => x.personnelRole == selectedRole);

                            if (Role != null)
                            {
                                var roleLinker = new Personnel_Login_LinkerTable();
                                roleLinker.personnel_Role_ID = Role.id;
                                roleLinker.Personnel_ID = personnelData.id;
                                _DbEntities.Personnel_Login_LinkerTable.Add(roleLinker);
                                _DbEntities.SaveChanges();

                                getLogIn.Personel_ID = personnelData.id;

                                //Saving the database
                                _DbEntities.SaveChanges();
                                MessageBox.Show("Personnel added!");
                                //reloading the database
                                loadPersonnel_DB();

                                //Setting all input box to empty
                                DisplayRole_comboBox.SelectedItem = null;
                                ShortName_tb.Text = "";
                                fName_textBox.Text = "";
                                lName_textBox.Text = "";
                                mName.Text = "";
                                UserName_textBox.Text = "";
                                email_textBox.Text = "";
                                phone_textBox.Text = "";
                                Address_textBox.Text = "";
                                Password_textBox.Text = "";
                                InactivePersonnel_Btn.Select();

                                //Closing addEdit tab;

                                ManagePersonnels_tab.TabPages.Remove(AddEditPersonnel_tabPage);
                                Save_Btn.Enabled = false;

                            }
                            else
                            {
                                MessageBox.Show("Please select a role");
                            }

                        }

                        else
                        {
                            MessageBox.Show("Enter the appropriate information.");
                        }
                    }

                }

                else if (ManagePersonnels_tab.SelectedTab == role_tabPage)
                {
                    if (AddEditMode_LB.Text == "Edit Mode...")
                    {
                        if (DisplayRole2_comboBox.Text != null || DisplayRole2_comboBox.SelectedItem != null && Shortname2_textBox.Text != "")
                        {
                            var selecteditem_ID = Convert.ToInt32(roles_dataGridView.SelectedRows[0].Cells["id"].Value);

                            var selectedItem = _DbEntities.PersonnelRoleTables.FirstOrDefault(x => x.id == selecteditem_ID);

                            if(selectedItem != null)
                            {
                                if (selectedItem.personnelRole != "Administrator")
                                {
                                    selectedItem.personnelRole = DisplayRole2_comboBox.Text;
                                    selectedItem.roleShortName = Shortname2_textBox.Text;

                                    MessageBox.Show("Selected item was updated", "Success");
                                    _DbEntities.SaveChanges();
                                    loadrole_DB();


                                    AddEditMode_LB.Text = "Add Mode...";
                                    DisplayRole2_comboBox.Text = "";
                                    DisplayRole2_comboBox.SelectedItem = null;
                                    Shortname2_textBox.Text = "";

                                    Save_Btn.Enabled = false;
                                }
                                else
                                {
                                    MessageBox.Show("Administrator role connot be altered", "Note:");
                                }
                            }
                      
                        }
                        else
                        {
                            MessageBox.Show("Select a value to edit");
                        }
                    }

                    else if (AddEditMode_LB.Text == "Add Mode...")
                    {
                        if (DisplayRole2_comboBox.Text != null && Shortname2_textBox.Text != "")
                        {
                            var roleDB = new PersonnelRoleTable();
                            roleDB.personnelRole = DisplayRole2_comboBox.Text;
                            roleDB.roleShortName = Shortname2_textBox.Text;
                            _DbEntities.PersonnelRoleTables.Add(roleDB);

                            MessageBox.Show("New role was added", "Success");
                            _DbEntities.SaveChanges();

                            loadrole_DB();

                            var loadRole = _DbEntities.PersonnelRoleTables.ToList();

                            DisplayRole_comboBox.DisplayMember = "PersonnelRole";
                            DisplayRole_comboBox.ValueMember = "Id";
                            DisplayRole_comboBox.DataSource = loadRole;
                            DisplayRole_comboBox.SelectedItem = null;

                            DisplayRole2_comboBox.DisplayMember = "PersonnelRole";
                            DisplayRole2_comboBox.ValueMember = "Id";
                            DisplayRole2_comboBox.DataSource = loadRole;
                            DisplayRole2_comboBox.SelectedItem = null;

                            DisplayRole2_comboBox.Text = null;
                            Shortname2_textBox.Text = "";
                            Save_Btn.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Please enter values");
                        }

                    }

                    else
                    {
                        MessageBox.Show("Operation failed", "Failure");
                    }
                }
                else
                {
                    MessageBox.Show("Unable to Process.", "Failure");

                    //Closing addEdit tab;

                    ManagePersonnels_tab.TabPages.Remove(AddEditPersonnel_tabPage);
                }

            }

            catch (Exception)
            {
                //Error message
                MessageBox.Show("Something went wrong\nPlease try again");
            }

        }

        private void phone_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar)) {

                e.Handled = true;

            }
        }

        private void DisplayRole_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedItem = DisplayRole_comboBox.GetItemText(DisplayRole_comboBox.SelectedItem);

            var selecteditem_Id = _DbEntities.PersonnelRoleTables.FirstOrDefault(x => x.personnelRole == selectedItem);

            ShortName_tb.Text = selecteditem_Id.roleShortName;
        }

        private void Personnel_dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Save_Btn.Enabled = true;
            Del_Btn.Enabled= false;

            //Setting the header text to Edit personnel
            AddEditPersonnel_tabPage.Text = "Edit Personnel";

            //Checking if the requried tab page exit. if it does does, call it and selecting it
           if(!ManagePersonnels_tab.TabPages.Contains(AddEditPersonnel_tabPage))
            {
                ManagePersonnels_tab.TabPages.Insert(1, AddEditPersonnel_tabPage);
                ManagePersonnels_tab.SelectedTab = AddEditPersonnel_tabPage;
            }
            else
            {
                ManagePersonnels_tab.SelectedTab = AddEditPersonnel_tabPage;
            }

           //Checking if the required tab page is selected
            if (ManagePersonnels_tab.SelectedTab == AddEditPersonnel_tabPage)
             {
                //Get the personnel selected ID
                 var personnel_ID = Convert.ToInt32(Personnel_dataGridView.SelectedRows[0].Cells["id"].Value);
                //Get the role Seleceted ID
                 var role_id = Convert.ToInt32(Personnel_dataGridView.SelectedRows[0].Cells["Role_ID"].Value);


                //Using the role seleced ID to get the role table
                var role = _DbEntities.PersonnelRoleTables.FirstOrDefault(x => x.id == role_id);
                //Using the personnel seleced ID to get the personnel table
                var personnel = _DbEntities.Personnel_Table.FirstOrDefault(x => x.id == personnel_ID);


                //Setting all appropriate input box to the selected data
                 DisplayRole_comboBox.SelectedValue = role.id;
                ShortName_tb.Text = role.roleShortName;
                fName_textBox.Text = personnel.FirstName;
                lName_textBox.Text = personnel.LastName;
                mName.Text = personnel.MiddleName;
                Address_textBox.Text = personnel.Address;
                email_textBox.Text = personnel.emailAddress;
                phone_textBox.Text = Convert.ToString(personnel.Telephone);

                var logIn = _DbEntities.personnel_LogIn.FirstOrDefault(x => x.Personel_ID == personnel.id);
                if( logIn != null) 
                {
                    UserName_textBox.Text = logIn.UserName;
                }
                else
                {
                    UserName_textBox.Text = "";
                }
               


                if (logIn.isActive != true)
                {
                    InactivePersonnel_Btn.Select();
                }
                else
                {
                    ActivePersonnel_Btn.Select();
                }
             }
        }

        private void AddNew_Btn_Click(object sender, EventArgs e)
        {
            Save_Btn.Enabled = true;

            if (!ManagePersonnels_tab.TabPages.Contains(AddEditPersonnel_tabPage))
            {
                if(this.getSignIn.personnelRole == "Administrator")
                {
                    DisplayRole_comboBox.SelectedItem = null;
                    ShortName_tb.Text = "";
                }
                else
                {

                    var roleId = _DbEntities.PersonnelRoleTables.ToList();
                    var selectedItem = _DbEntities.PersonnelRoleTables.FirstOrDefault(x => x.personnelRole == "Customer");

                    DisplayRole_comboBox.SelectedValue = selectedItem.id;
                    ShortName_tb.Text = selectedItem.roleShortName;
                }
                AddEditPersonnel_tabPage.Text = "Add Personnel";
                ManagePersonnels_tab.TabPages.Insert(1, AddEditPersonnel_tabPage);
                fName_textBox.Text = "";
                lName_textBox.Text = "";
                mName.Text = "";
                UserName_textBox.Text = "";
                email_textBox.Text = "";
                phone_textBox.Text = "";
                Address_textBox.Text = "";
                Password_textBox.Text = "";
                InactivePersonnel_Btn.Select();

                ManagePersonnels_tab.SelectedTab = AddEditPersonnel_tabPage;

            }
            else if (ManagePersonnels_tab.TabPages.Contains(AddEditPersonnel_tabPage))
            {
                AddEditPersonnel_tabPage.Text = "Add Personnel";
                //Setting all input box to empty
                if (this.getSignIn.personnelRole == "Administrator")
                {
                    DisplayRole_comboBox.SelectedItem = null;
                    ShortName_tb.Text = "";
                }
                else
                {

                    var roleId = _DbEntities.PersonnelRoleTables.ToList();
                    var selectedItem = _DbEntities.PersonnelRoleTables.FirstOrDefault(x => x.personnelRole == "Customer");

                    DisplayRole_comboBox.SelectedValue = selectedItem.id;
                    ShortName_tb.Text = selectedItem.roleShortName;
                }
                ShortName_tb.Text = "";
                fName_textBox.Text = "";
                lName_textBox.Text = "";
                mName.Text = "";
                UserName_textBox.Text = "";
                email_textBox.Text = "";
                phone_textBox.Text = "";
                Address_textBox.Text = "";
                Password_textBox.Text = "";
                InactivePersonnel_Btn.Select();

                ManagePersonnels_tab.SelectedTab = AddEditPersonnel_tabPage;
            }
            else
            {
                MessageBox.Show("Operation Failed");
            }
        }

        private void ManageRoles_Click(object sender, EventArgs e)
        {
            Save_Btn.Enabled = true;
            Del_Btn.Enabled = false;

            if (!ManagePersonnels_tab.TabPages.Contains(role_tabPage))
            {
                ManagePersonnels_tab.TabPages.Insert(1, role_tabPage);
                ManagePersonnels_tab.SelectedTab = role_tabPage;
            }
            else if (ManagePersonnels_tab.TabPages.Contains(role_tabPage))
            {
                ManagePersonnels_tab.SelectedTab = role_tabPage;
            }
            else
            {
                MessageBox.Show("Opeation failed");
            }


        }

        private void DisplayRole2_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedItem = DisplayRole2_comboBox.GetItemText(DisplayRole2_comboBox.SelectedItem);

            var selecteditem_Id = _DbEntities.PersonnelRoleTables.FirstOrDefault(x => x.personnelRole == selectedItem);

            DisplayRole2_comboBox.SelectedItem = selecteditem_Id;
            Shortname2_textBox.Text = selecteditem_Id.roleShortName;

        }

        private void roles_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Save_Btn.Enabled = true;

            Del_Btn.Enabled = true;

            try
            {//Change table to edit mode
                AddEditMode_LB.Text = "Edit Mode...";

                //get id from selected row 
                var selectedRow = Convert.ToInt32(roles_dataGridView.SelectedRows[0].Cells["id"].Value);

                //get item from combobox using id for selected row
                DisplayRole2_comboBox.SelectedValue = selectedRow;

                //check database for id from selected row
                var selectItem = _DbEntities.PersonnelRoleTables.FirstOrDefault(x => x.id == selectedRow);

                //Get short name from selected row
                Shortname2_textBox.Text = selectItem.roleShortName;
            }
            catch (Exception)
            {

                MessageBox.Show("Something went wrong.\n Unable to process");
            }

        }

        private void Del_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ManagePersonnels_tab.SelectedTab == Personnels_tabPage)
                {
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            var selectedItem_ID = Convert.ToInt32(Personnel_dataGridView.SelectedRows[0].Cells["id"].Value);
                            var selecetedLinker_ID = Convert.ToInt32(Personnel_dataGridView.SelectedRows[0].Cells["LinkerID"].Value);
                            var selectedRole_ID = Convert.ToInt32(Personnel_dataGridView.SelectedRows[0].Cells["Role_ID"].Value);

                            var loggedIn = _DbEntities.personnel_LogIn.FirstOrDefault(x => x.Personel_ID == selectedItem_ID);


                            var loggedTimeList = _DbEntities.Login_DateTimeTable.Where(x => x.Login_ID == loggedIn.ID).ToList();
                            if(loggedTimeList.Count > 0)
                            {
                                var selectedLoggedTime = _DbEntities.Login_DateTimeTable.RemoveRange(loggedTimeList);
                            }
                            else
                            {

                            }
                            var logIn = _DbEntities.personnel_LogIn.Where(x => x.Personel_ID == selectedItem_ID).ToList();
                            if (logIn.Count > 0)
                            {
                                var selectedLoggedTime = _DbEntities.personnel_LogIn.RemoveRange(logIn);
                            }
                            else
                            {

                            }

                            var selectedPerson = _DbEntities.Personnel_Table.FirstOrDefault(x => x.id == selectedItem_ID);
                            var selectedLinker = _DbEntities.Personnel_Login_LinkerTable.FirstOrDefault(x => x.id == selecetedLinker_ID);

                            _DbEntities.Personnel_Table.Remove(selectedPerson);
                            _DbEntities.Personnel_Login_LinkerTable.Remove(selectedLinker);

                            _DbEntities.SaveChanges();
                            MessageBox.Show("Seleceted item has been deleted", "Success");
                            loadPersonnel_DB();

                            Del_Btn.Enabled = false;
                        }
                        else if (dialogResult == DialogResult.No)
                        { 
                        }                            

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Personnels assigned to a loan cannot be deleted");
                    }
                }

                else if(ManagePersonnels_tab.SelectedTab == role_tabPage)
                {
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            var selectedItem_ID = Convert.ToInt32(roles_dataGridView.SelectedRows[0].Cells["id"].Value);
                            //  var selecetedLinker_ID = Convert.ToInt32(roles_dataGridView.SelectedRows[0].Cells["LinkerID"].Value);

                            var selectedRole = _DbEntities.PersonnelRoleTables.FirstOrDefault(x => x.id == selectedItem_ID);

                            _DbEntities.PersonnelRoleTables.Remove(selectedRole);

                            _DbEntities.SaveChanges();

                            MessageBox.Show("Seleceted item has been deleted", "Success");
                            loadrole_DB();
                        }
                        Del_Btn.Enabled = false;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Roles assigned to a personnel cannot be delected");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Operation failed", "Failure");
            }
        }

        private void CloseTab_Btn_Click(object sender, EventArgs e)
        {   
            Save_Btn.Enabled = false;
            Del_Btn.Enabled = false;

            //Closing the selected tab
            if (ManagePersonnels_tab.SelectedTab != null)
            {
                ManagePersonnels_tab.TabPages.Remove(ManagePersonnels_tab.SelectedTab);
                if (ManagePersonnels_tab.SelectedTab == null)
                {
                    Close();
                }
            }
            else
            {
                MessageBox.Show("No tab exist.");
            }
            
        }

        private void Personnel_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Del_Btn.Enabled = true;
        }

        private void Personnels_tabPage_Click(object sender, EventArgs e)
        {
            Save_Btn.Enabled = false;
            Del_Btn .Enabled = false;
        }
    }
}
