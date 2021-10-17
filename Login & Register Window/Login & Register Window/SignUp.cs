using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Login_Wpf
{
    public class SignUp
    {
        public static MainWindow Main;
        public static void trySignUp()
        {
            string srUsername = Main.txtboxUsername.Text;
            string srEmail = Main.txtboxEmail.Text;
            string srPassword = Main.passboxPassword.Password.ToString();
            string srAgainPassword = Main.passboxAgainPassword.Password.ToString();

            var vrResult = UsernameController(srUsername);

            if (vrResult.generalStatus == false)
            {
                MessageBox.Show(vrResult.displayMessage);
                return;
            }

            vrResult = EmailController(srEmail);
            if (vrResult.generalStatus == false)
            {
                MessageBox.Show(vrResult.displayMessage);
                return;
            }

            vrResult = PasswordController(srPassword, srAgainPassword);

            if (vrResult.generalStatus == false)
            {
                MessageBox.Show(vrResult.displayMessage);
                return;
            }
            CompleteSignUp(srUsername, srEmail, srPassword);

        }

        public class statusResult
        {
            public string displayMessage = "";
            public bool generalStatus = true;
        }

        public static statusResult UsernameController(string srUsername)
        {
            statusResult status = new statusResult();

            List<char> forbiddenCharacters = new List<char> { '%', '-', ':', '$', '/', '\\', '(', ')', '[', ']', '‘', '“', ',', '!', '?', '{', '}', '=', '&', '\"', '*', '\"', '<', '>', '|' };
            int irUsernameMinLength = 8;
            int irUsernameMaxLength = 64;

            if (srUsername == "")
            {
                status.generalStatus = false;
                status.displayMessage = "Username field can't be left blank!";
                return status;
            }
            if (srUsername.Length < irUsernameMinLength)
            {
                status.generalStatus = false;
                status.displayMessage = "Username can't be more less 8 characters";
                return status;
            }
            if (srUsername.Length > irUsernameMaxLength)
            {
                status.generalStatus = false;
                status.displayMessage = "Username can't be more than 64 characters";
                return status;
            }

            foreach (var varUsernameChar in srUsername)
            {
                if (forbiddenCharacters.Contains(varUsernameChar) == true)
                {
                    status.generalStatus = false;
                    status.displayMessage = $"You cannot use this {varUsernameChar} character in your username!";
                    return status;
                }
            }


            using (UserContext context = new UserContext())
            {
                var vrUsername = context.TblUsers.FirstOrDefault(pr => pr.Username == srUsername);

                if (vrUsername != null)
                {
                    status.generalStatus = false;
                    status.displayMessage = "The username you entered is in use. Please enter another username.";
                    return status;
                }
            }

            return status;
        }


        public static statusResult EmailController(string srEmail)
        {
            statusResult status = new statusResult();

            if (srEmail == "")
            {
                status.generalStatus = false;
                status.displayMessage = "Email field can't be left blank!";
                return status;
            }
            if (GeneralMethods.EmailControl(srEmail) == false)
            {
                status.generalStatus = false;
                status.displayMessage = "Email you entered is in an invalid format. Please re-enter.";
                return status;
            }


            using (UserContext context = new UserContext())
            {
                var vrEmail = context.TblUsers.FirstOrDefault(pr => pr.Email == srEmail);

                if (vrEmail != null)
                {
                    status.generalStatus = false;
                    status.displayMessage = "The Email you entered is in use. Please enter another Email.";
                    return status;
                }
            }
            return status;
        }

        public static statusResult PasswordController(string srPassword, string srAgainPassword)
        {
            statusResult status = new statusResult();

            int irPasswordLength = 8;
            List<char> lstSpecialChars = new List<char> { '_', '-', '@', '#', '$', '%', '*', '?', ';', '&', '!' };

            if (srPassword == "")
            {
                status.generalStatus = false;
                status.displayMessage = "Password fields can't be left blank!";
                return status;
            }

            if (srPassword.Length < irPasswordLength)
            {
                status.generalStatus = false;
                status.displayMessage = "The Password you enter can't be less than 8 characters!";
                return status;
            }

            bool blContainSpecChar = false, blContainUpperCase = false, blContainLowerCase = false, blContainDigit = false, blContainLetter = false;

            foreach (char vrPerChar in srPassword.ToCharArray())
            {
                if (char.IsDigit(vrPerChar))
                {
                    blContainDigit = true;
                }
                if (char.IsLetter(vrPerChar))
                {
                    blContainLetter = true;
                }
                if (char.IsUpper(vrPerChar))
                {
                    blContainUpperCase = true;
                }
                if (char.IsLower(vrPerChar))
                {
                    blContainLowerCase = true;
                }
                if (lstSpecialChars.Contains(vrPerChar))
                {
                    blContainSpecChar = true;
                }
            }

            if (!blContainSpecChar)
            {
                status.generalStatus = false;
                status.displayMessage = "Your password must contain at least a special character.";
                return status;
            }
            if (!blContainDigit)
            {
                status.generalStatus = false;
                status.displayMessage = "Your password must contain at least a number!";
                return status;
            }
            if (!blContainLetter)
            {
                status.generalStatus = false;
                status.displayMessage = "Your password must contain at least a letter!";
                return status;
            }
            if (!blContainUpperCase)
            {
                status.generalStatus = false;
                status.displayMessage = "Your password must contain at least an upper case character!";
                return status;
            }
            if (!blContainLowerCase)
            {
                status.generalStatus = false;
                status.displayMessage = "Your password must contain at least an lower case character!";
                return status;
            }

            if (srPassword != srAgainPassword)
            {
                status.generalStatus = false;
                status.displayMessage = "The passwords you entered don't match! Please re-enter.";
                return status;
            }
            return status;
        }

        public static void CompleteSignUp(string srUsername, string srEmail, string srPassword)
        {
            Task.Factory.StartNew(() =>
            {
                using (UserContext context = new UserContext())
                {
                    TblUsers User = new TblUsers();

                    User.Username = srUsername;
                    User.Email = srEmail;
                    User.Password = GeneralMethods.ComputeSha256Hash(srPassword);

                    try
                    {
                        context.TblUsers.Add(User);
                        context.SaveChanges();
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show("An error has occured while registering. Error is: \n" + E.Message.ToString() + "\n\n" + E?.InnerException?.Message);
                        return;
                    }
                    MessageBox.Show("You have successfully registered. You are logging in automatically now.");
                }
            });
        }
    }
}
