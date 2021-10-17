using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NCalc;

namespace FinalProject
{
    
    public partial class Calculator : Window
    {
        //I have defined the logginedusername variable
        public static string LogginedUsername;

        //Here I defined the username information I got from my private class to the login username variable.
        public static void Loggined(string LogginedName)
        {
            LogginedUsername = LogginedName;
            
        }

        //I have defined the user file
        private static string SrFile()
        {
           string SrFileUser=@"UserLogs/"+LogginedUsername+".txt";
           return SrFileUser;
        }


        public Calculator()
        {
            InitializeComponent();
            //I have the cursor in the textbox at the window entry
            TxtBoxUserInput.Focus();
           
            //I created a label for the user to see the name entered in the window interface and defined it with the Content method below.
            LogUsername.Content = LogginedUsername;

            //I have defined my listbox with results items.
            LogsList.ItemsSource = Results;
            //I called method
            UsernameLogControl();
        }

        //I have transferred the previous transaction records of the user to my listbox.
        private void UsernameLogControl()
        {
            //With File.Exists, I prevent the program from failing by querying whether there is a file.
            if (File.Exists(SrFile()))
            {
                //To add the items in reverse, 
                //I first defined the array and then added it to the listbox via foreach and the Results variable.
                string[] ArrayUserLogs = File.ReadAllLines(SrFile()).ToArray();
                Array.Reverse(ArrayUserLogs);            
                Results.Clear();
                foreach (var VrPer in ArrayUserLogs)
                {
                    Results.Add(VrPer);
                }
            }
        }

        //We use the ObservableCollection method to update the listbox elements without any operation.
        private ObservableCollection<string> _Results = new ObservableCollection<string>();
        public ObservableCollection<string>Results
        {
            get { return _Results; }
            set
            {
                _Results = value;
            }
        }
        //I wrote the following method to keep the cursor at the end even while typing.
        private void TxtBoxFocus()
        {
            TxtBoxUserInput.Focus();          
            TxtBoxUserInput.SelectionStart = TxtBoxUserInput.Text.Length;
          
        }

        //I have provided code simplicity by connecting all buttons to a single method.
        private void TxtAddingBtnClick(object sender, RoutedEventArgs e)
        {
            Button CalculatorButtons = (Button)sender;
            //I have provided the expression defined in button content to be written to the textbox
            TxtBoxUserInput.Text += CalculatorButtons.Content.ToString();
            TxtBoxFocus();
        }

        //I added a logout button and made it return to the login screen when the button was pressed.
        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login Lg_CL = new Login();
            Lg_CL.Show();
            this.Close();
        }

        //I defined the letters A-Z with the Regex method.
        private static readonly Regex rg = new Regex("[a-zA-Z]+");
        
        //I check if the pasted item contains letters.
        private void TxtBoxUserInput_NumberAllow(object sender, TextCompositionEventArgs e)
        { 
            e.Handled = rg.IsMatch(e.Text);           
        }
        //I just make it enter numbers and special characters from the keyboard.
        private static bool IsTextOnlyNumberAllowed(string TxtInput)
        {
            return !rg.IsMatch(TxtInput);
        }

        //I'm customizing the paste command
        private void TxtBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
            //If it contains letters, I cancel pasting.
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String TxtInput = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextOnlyNumberAllowed(TxtInput))
                {
                    e.CancelCommand();
                }
            }
        }

        //Specifically, I make a button on the right to open and close the listbox. 
        //When I click this button, I change its function and send it to the 2nd click event.
        private void BtnForOpenCloseList_Click1(object sender, RoutedEventArgs e)
        {
            //I widen the window to the extent we specified
            this.Width = 678.5;
            BtnForOpenCloseList.Click -= BtnForOpenCloseList_Click1;
            BtnForOpenCloseList.Click += BtnForOpenCloseList_Click2;

        }
        private void BtnForOpenCloseList_Click2(object sender, RoutedEventArgs e)
        {
            //I shorten the window to the extent we set it
            this.Width = 375;
            BtnForOpenCloseList.Click -= BtnForOpenCloseList_Click2;
            BtnForOpenCloseList.Click += BtnForOpenCloseList_Click1;

        }

        //I define a method to delete the last character
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(TxtBoxUserInput.Text.Length>0)
            {
                TxtBoxUserInput.Text = TxtBoxUserInput.Text.Substring(0, TxtBoxUserInput.Text.Length - 1);
            }
            TxtBoxFocus();
        }

        //I define a button method that will delete the textbox content and result.
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TxtBoxUserInput.Text = "";
            LblResult.Content = "";
            TxtBoxFocus();

        }

        //I define a function to perform operations inside the equal button.
        private void BtnEqual_Click(object sender, RoutedEventArgs e)
        {
            //I declare variable decimal as zero
            decimal DecResult = Decimal.Zero;
            try
            {
                //I am sending information to the Evaluate method.
                DecResult = Evaluate(TxtBoxUserInput.Text);
            }
            catch(Exception E)
            {
                //If there are logical operations I return an error message
                MessageBox.Show("You entered an incorrect mathematical operation. Error message: " + E.Message);
                return;
            }
            //I send the result to the result label specially on the screen
            LblResult.Content = DecResult.ToString("N2");

            //I write the process and the result in the user record txt file.
            File.AppendAllText(SrFile(), TxtBoxUserInput.Text + "= " + DecResult.ToString("N2") + "\r\n");

            //I add both the textbox content and the result to the Results variable. 
            //Also I add reverse with insert.
            Results.Insert(0, TxtBoxUserInput.Text + "= " + DecResult.ToString("N2"));
            
        }

        //I am defining a special method to make a calculator operation.
        public static decimal Evaluate(string input)
        {
            //I'm calling the special plugin called ncal.
            NCalc.Expression e = new NCalc.Expression(input);
            
            //I take the information and define it in a variable named result.
            var result = e.Evaluate();

            //With Parse method, I convert the values of string type to number type values.
            decimal h2 = Decimal.Parse(result.ToString(), System.Globalization.NumberStyles.Any);

            return Convert.ToDecimal(h2);
        }

 
    }

}


