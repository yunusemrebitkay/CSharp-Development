using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinalProject
{
    
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void BtnRegister_V2_Click(object sender, RoutedEventArgs e)
        {
            //I am calling a method that I have created from the other class and show the bool and message variables here.
            Tuple<bool, string> RegisterControlResult = SpecialControls.Registeroperation(this);
            
            //If the process fails, I show the error reason
            if (RegisterControlResult.Item1==false)
            {
                MessageBox.Show(RegisterControlResult.Item2);
            }
            else
            {
                //automatic forwarding message
                MessageBox.Show("You have successfully registered. You are logging in automatically now.");
            }
        }
        //I created a "BackToLogin" button to return to the login screen from the registration screen.
        private void BtnBackToLogin_Click(object sender, RoutedEventArgs e)
        {
            Login BackToLogin = new Login();
            BackToLogin.Show();
            this.Close();
        }
    }
}
