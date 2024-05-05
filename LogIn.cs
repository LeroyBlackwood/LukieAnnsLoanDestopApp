using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LukieAnnLoansAndFinancialServicesApp
{
    public partial class LogIn : Form
    {
       public readonly LukieAnnsLoans_dbEntities _DbEntities;
        public LogIn()
        {
            InitializeComponent();
            _DbEntities = new LukieAnnsLoans_dbEntities();
        }

        
        private void LogIn_button_Click(object sender, EventArgs e)
        {
            try
            { 
                    //get username and password from user
                    var username = UserName_textBox.Text.Trim();
                    var password = Password_textBox.Text.Trim();

                    //Encrypting password
                    var EncryptPassword = Utils.HashedPassword(password);

                    //checking the username and password retrieved against the stored user and and password
                    var _username = _DbEntities.personnel_LogIn.FirstOrDefault(x => x.UserName == username
                                            && x.Password == EncryptPassword && x.isActive == true);

                    var _getRole = _DbEntities.Personnel_Login_LinkerTable.FirstOrDefault(x => x.Personnel_ID == _username.Personel_ID);
                    var _roleName = _DbEntities.PersonnelRoleTables.FirstOrDefault(x => x.id == _getRole.personnel_Role_ID);
                
                //Get login time
                var getLogInTime = DateTime.Now;


                //Check if username is null and not equal to Customer
                if (_username != null && _roleName.personnelRole != "Customer")
                    {
                    //Hide login
                    this.Hide();
                    //Get login time table and and login id and login time to table
                    var timeLoggedIn = new Login_DateTimeTable();
                    timeLoggedIn.Login_ID = _username.ID;
                    timeLoggedIn.Login_DateTime = getLogInTime;
                   
                    //Create a new main window object
                    MainWindow main = new MainWindow(this, _roleName, timeLoggedIn,_username);
                    //Show main window
                    main.Show();

                    //_DbEntities.Login_DateTimeTable.Add(timeLoggedIn);
                    //_DbEntities.SaveChanges();

                    UserName_textBox.Text = "";
                    Password_textBox.Text = "";
                }
                    else
                    {
                    //Display if login fails
                        MessageBox.Show("Invalid log in", "Failure");
                    }
            }
            catch (Exception)
            {
                //Display if an error occurs
                MessageBox.Show("Unable to log in!", "Error");
            }
 
        }
    }
}
