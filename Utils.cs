using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LukieAnnLoansAndFinancialServicesApp
{
    internal class Utils
    {

       public static double MonthlyPayment(double principal, double intRate, double duration)
        {
            // Calculate Compound interest/Monthly payment
            var monthlyPayment = (principal * Math.Pow(1 + intRate / 100, duration / 12)) / duration;
            return monthlyPayment;
        }


        public static bool FormIsOpen(Form form)
        {
            // Check if a specific form (e.g., YouLikeHits_Settings) is open
            var openForm = Application.OpenForms.Cast<Form>();
            var isOpen = openForm.Any(x => x.Name == form.Name);
            return isOpen;
        }

        public static string HashedPassword(String password)
        {  
            SHA256 sha = SHA256.Create();
            //Converting string to byte array
            byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            
            //Create a now string to encode password
            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }

            //Assigning encoded password to a variable
            var hashed_password = sb.ToString();

            return hashed_password;
        }

        public static bool IsvalidEmail(string email)
        {
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
