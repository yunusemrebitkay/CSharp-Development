using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Login_Wpf
{
    public class Login
    {

        public static MainWindow Main;
        public static void tryLogin()
        {
            string srLoginUser = Main.txbxLoginUser.Text;
            string srPassword = Main.passbxLoginPass.Password.ToString();
            bool blEmail = GeneralMethods.EmailControl(srLoginUser);

            if(srLoginUser == "")
            {
                MessageBox.Show("Username or Email fields can't be left blank!");
                return;
            }
            if (srPassword == "")
            {
                MessageBox.Show("Password field can't be left blank!");
                return;
            }

            using (UserContext context = new UserContext())
            {              
                if(blEmail == false)
                {
                    var vrUser = context.TblUsers.FirstOrDefault(pr => pr.Username == srLoginUser);
                    if(vrUser == null)
                    {
                        MessageBox.Show("The username you entered was not found in the system!");
                        return;
                    }
                    if (vrUser.Password != GeneralMethods.ComputeSha256Hash(srPassword))
                    {
                        MessageBox.Show("Your password does not match your username!");
                        return;
                    }
                }
                else
                {
                    var vrUser = context.TblUsers.FirstOrDefault(pr => pr.Email == srLoginUser);
                    if (vrUser == null)
                    {
                        MessageBox.Show("The Email you entered was not found in the system!");
                        return;
                    }
                    if (vrUser.Password != GeneralMethods.ComputeSha256Hash(srPassword))
                    {
                        MessageBox.Show("Your password does not match your email address!");
                        return;
                    }
                }
            }
            MessageBox.Show("You have successfully logged in.");
        }
    }
}
