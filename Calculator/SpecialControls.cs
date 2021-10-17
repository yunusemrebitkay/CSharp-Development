using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FinalProject
{

    public static class SpecialControls
    {

        public static Tuple<bool, string> Registeroperation(Register mainWindowsInstance)
        {
            //We sent the Username and Email information to the methods 
            var VrResult = Controller.Username_controller(mainWindowsInstance.Register_username.Text, mainWindowsInstance.Register_email.Text);

            if (VrResult.BlControlResult == false)
            {
                return new Tuple<bool, string>(VrResult.BlControlResult, VrResult.SrResultMessage);

            }

            //We have sent a information to Methods for checking email format
            if (!mainWindowsInstance.Register_email.Text.Control_email())
            {
                VrResult.BlControlResult = false;
                VrResult.SrResultMessage = "The e-mail address you entered is not a valid e-mail address. Please enter your email in the format 'email@mail.com'.";
            }

            //We sent information to the methods for the required password rules.
            VrResult = Controller.Password_controller(mainWindowsInstance.Register_password.Password.ToString(), mainWindowsInstance.Register_againpassword.Password.ToString());
            if (VrResult.BlControlResult == false)
            {
                return new Tuple<bool, string>(VrResult.BlControlResult, VrResult.SrResultMessage);
            }

            //When all the checks are correct, we asked it to print to the file.
            if (VrResult.BlControlResult == true)
            {
                //If it is registered, we send the user name as register username to the calculator page.
                Calculator.Loggined(mainWindowsInstance.Register_username.Text);
                //We create a log txt file for the newly registered user
                FileStream Fs = File.Create(@"UserLogs/" + mainWindowsInstance.Register_username.Text + ".txt");
                //We close the file because if we do not close it, it will remain read-only, so we cannot do anything.
                Fs.Close();

                //If the registration is successful, we write the information in the txt file in the form we determined.
                File.AppendAllText(Controller.SrUsersFile, GenerateUserData(mainWindowsInstance.Register_username.Text,
                    mainWindowsInstance.Register_password.Password.ToString(), mainWindowsInstance.Register_email.Text));

                //If the process is successful, I direct the user to the automatic calculator page.
                Calculator CL_Register = new Calculator();
                CL_Register.Show();
                mainWindowsInstance.Close();

            }
            return new Tuple<bool, string>(VrResult.BlControlResult, VrResult.SrResultMessage);
        }

        //We specified the order in which to write in the file
        public static string GenerateUserData(string SrUsername, string SrPassword, string SrEmail)
        {
            //We both put the separator character in between and convert the password to 256bit and print it to the txt file.
            return SrUsername + Controller.CrSelectorCharacter + SrPassword.ComputeSha256Hash() + Controller.CrSelectorCharacter +
                SrEmail + Environment.NewLine;
        }


        public static void LoginOperation(Login mainWindowsInstance)
        {
            //I use ToLower method here to make it work regardless of the username big / small.
            string SrUsernameEntered = mainWindowsInstance.Login_username.Text.ToLower();
            //I convert the entered password to 256bit so that I can compare it with the saved password.
            string SrPasswordEntered = mainWindowsInstance.Login_password.Password.ToString().ComputeSha256Hash();
            //I created a list to collect the user names registered in the system in a list and compare them with the user name entered in the login section.
            List<string> LstUser = new List<string>();
            
            
            foreach (var PerLine in File.ReadLines(Controller.SrUsersFile))
            {
                //I separated and defined username, password and email by specifying the separator and using the split method.
                List<string> LstLine = PerLine.Split(Controller.CrSelectorCharacter).ToList();
                //I add usernames to the list we created above.
                LstUser.Add(LstLine[0]);

                //If the username and password match, login
                if (LstLine[0] == SrUsernameEntered && LstLine[1] == SrPasswordEntered)
                {
                    //Since it logs in, I send the username to the calculator page to the LogginedUsername variable.
                    Calculator.Loggined(SrUsernameEntered);
                    mainWindowsInstance.displayMessage("You have successfully logged-in ");
                    
                    //Switching between windows
                    Calculator CL = new Calculator();
                    mainWindowsInstance.Close();
                    CL.Show();
                    
                    //The reason I add return is if the operation is successful, I stop it from going to other commands.
                    return;
                }
            }

            //I compare the entered username with the usernames saved in the system. If not, I return an error message.
            if (LstUser.Contains(SrUsernameEntered) == false)
            {
                mainWindowsInstance.displayMessage("There is no such username in the system!");
                return;
            }

            //If the username exists in the system but the password is incorrect, I return the following error message.
            mainWindowsInstance.displayMessage("Error! username and password do not match please try again!");


        }
    }
}
