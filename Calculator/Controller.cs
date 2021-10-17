using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Security.Cryptography;

namespace FinalProject
{
    public static class Controller
    {
        //We define the distinctive character
        public static Char CrSelectorCharacter = ':';
        //We define the users file
        public static String SrUsersFile = "Users.txt";

        //We have defined min and max variables for username
        private static readonly int irUsernameMinLenght = 3;
        private static readonly int irUsernameMaxLenght = 20;
        static Controller()
        {
            //Definitions
            List<char> LstAllowedCharacters = new List<char>();
            string SrAllowedCharactersForAccountName = "ABCÇDEFĞGHIİJKLMNOÖPQRSŞTÜUVWXYZ_";

            //We add the allowed characters to the list.
            foreach (var VrPerChar in SrAllowedCharactersForAccountName.ToCharArray())
            {
                LstAllowedCharacters.Add(VrPerChar);
            }

            //We reduce the allowed characters and add them to the list and we indicate Culture.
            foreach (var VrPerChar in SrAllowedCharactersForAccountName.ToLower(new System.Globalization.CultureInfo("tr-TR")))
            {
                LstAllowedCharacters.Add(VrPerChar);
            }

            //We enlarge the allowed characters and add them to the list and we indicate Culture.
            foreach (var VrPerChar in SrAllowedCharactersForAccountName.ToUpper(new System.Globalization.CultureInfo("tr-TR")))
            {
                LstAllowedCharacters.Add(VrPerChar);
            }

            //We remove duplicate items from the list.
            LstAllowedCharacters=LstAllowedCharacters.Distinct().ToList();
        }

 
        public class Control
        {
            //We have defined a controller and an error message
            public bool BlControlResult = true;
            public string SrResultMessage = "NA";
        }

        public static Control Username_controller(string SrUsername, string SrEmail)
        {
            //We connected to bool and message in control method.
            Control check = new Control();
          
            //We define forbidden characters for username
            List<char> forbiddencharacters = new List<char> { '%', '-', ':', '$', '/', '\\', '(', ')', '[', ']', '‘', '“', ',',
            '!', '?', '{', '}' , '=', '&' , '\"' ,'*','\"','<','>','|'};

            //I converted the username to a char directory.
            char[] UsernameArray = SrUsername.ToCharArray();

            //I have defined a string containing numbers 1-9
            char[] NumberArray = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            //Minimum character check
            if (irUsernameMinLenght>SrUsername.Length) 
            {
                check.BlControlResult = false;
                check.SrResultMessage = $"Your username can't be less than {irUsernameMinLenght} characters!";
            }
            //Maximum character check
            if(SrUsername.Length > irUsernameMaxLenght)
            {
                check.BlControlResult = false;
                check.SrResultMessage = $"Your username can't be bigger than {irUsernameMaxLenght} characters!";
            }

            //Forbidden character check
            foreach(var VrUsernameChar in SrUsername)
            {
                //With the contain method, I accessed and checked the forbidden words in the array.
                if (forbiddencharacters.Contains(VrUsernameChar)==true)
                {
                    check.BlControlResult = false;
                    check.SrResultMessage = $"You cannot use this {VrUsernameChar} character in your username!";

                }
            }

            //Digit check of the first index of the username
            for (int counter = 0; counter < NumberArray.Length; counter++)
            {
                //I prevented the first letter from being a number in the username
                if (SrUsername!="" && UsernameArray[0] == NumberArray[counter])
                {
                    check.BlControlResult = false;
                    check.SrResultMessage = $"You can't enter numbers in the first letter of your username";               
                }

            }

            //Comparison of entered values with log file
            if (File.Exists(SrUsersFile))
            {
                //We read line by line with foreach.
                foreach (var VrPerLine in File.ReadLines(SrUsersFile))
                {
                    //We transfer the lines in the file to the list
                    List<string> LstSplittedInformations = VrPerLine.Split(CrSelectorCharacter).ToList();

                    // We define it like Username : Password : Email 
                    string srRegisteredUsername = LstSplittedInformations[0];
                    string srRegisteredEmail = LstSplittedInformations[2];

                    //Username Control
                    if(SrUsername == srRegisteredUsername)
                    {
                        check.BlControlResult = false;
                        check.SrResultMessage = $"The username you chose is used, please try another username.";
                        break;
                    }
        
                    //Email Control
                    if (SrEmail==srRegisteredEmail)
                    {
                        check.BlControlResult = false;
                        check.SrResultMessage = $"The email you entered is in use. Please enter another email.";
                        break;
                    }

           
                }
            }

            return check;
        }

        //Email Format Check
        public static bool Control_email(this string Email)
        {
             
            try 
            {
                MailAddress mail = new MailAddress(Email);
                return true;
            }
            catch
            {
                return false;
            }
           
        }

        public static Control Password_controller(string password, string againpassword)
        {
            Control check = new Control();
            //We defined a minimum password length
            int irPasswordMinLenght = 8;

            //We check the password length and take the correctness of the two passwords entered once again.
            if (password.Length < irPasswordMinLenght)
            {
                check.BlControlResult = false;
                check.SrResultMessage = $"Your password must have at least 8 characters!";
            }
            //We compare two passwords entered during registration
            else if (password!=againpassword)
            {
                check.BlControlResult = false;
                check.SrResultMessage = $"The passwords you entered do not match. Please re-enter.";
            }

           

            //We have defined a special string for the password
            List<char> LstSpecialCharacters = new List<char> { '_', '-', '@', '#', '$', '%', '*', '?', ';', '&', '!' };

            bool BlContainsDigit = false; //Numbers
            bool BlContainsLetter = false; //Letter
            bool BlContainsUpperCase = false; // A upper letter
            bool BlContainsLowerCase = false; //A lower letter
            bool BlContainsSpecialCharacters = false; // Special char control


            foreach (char VrPerChar in password.ToCharArray())
            {
                //We check to see if it contains a number.
                if (char.IsDigit(VrPerChar))
                {
                    BlContainsDigit = true;
                }
                //We check to see if it contains a letter.
                if (char.IsLetter(VrPerChar)) 
                {
                    BlContainsLetter = true;
                }
                //We check to see if it contains a upper letter.
                if (char.IsUpper(VrPerChar))
                {
                    BlContainsUpperCase = true;
                }
                //We check to see if it contains a lower letter.
                if (char.IsLower(VrPerChar))
                {
                    BlContainsLowerCase = true;
                }
                //We inquire if it contains special characters
                if (LstSpecialCharacters.Contains(VrPerChar))
                {
                    BlContainsSpecialCharacters = true;
                }
            }


            if(!BlContainsDigit && check.BlControlResult==true)
            {
                check.BlControlResult = false;
                check.SrResultMessage = $"Your password must contain at least a number!";
            }
            if (!BlContainsLetter && check.BlControlResult == true)
            {
                check.BlControlResult = false;
                check.SrResultMessage = $"Your password must contain at least a letter!";
            }
            if (!BlContainsUpperCase && check.BlControlResult == true)
            {
                check.BlControlResult = false;
                check.SrResultMessage = $"Your password must contain at least an upper case character!";
            }
            if (!BlContainsLowerCase && check.BlControlResult == true)
            {
                check.BlControlResult = false;
                check.SrResultMessage = $"Your password must contain at least an lower case character!";
            }

            if(!BlContainsSpecialCharacters && check.BlControlResult == true)
            {
                check.BlControlResult = false;
                check.SrResultMessage = $"Your password must contain at least a special character.Use any of these characters at least 1 time {string.Join(" ", BlContainsSpecialCharacters)}";
            }

            return check;
        }

        //Password convert To Sha256 
        public static string ComputeSha256Hash(this string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }


    }
}
