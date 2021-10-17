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

    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            //I call the method named LoginOperation in the class I have created a custom.
            SpecialControls.LoginOperation(this);
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            //Switching between windows
            Register RegisterWindow = new Register();
            RegisterWindow.Show();
            this.Close();
        }

        //I have defined a special message variable for the login screen so that in case of any error, the user will be informed about the error.
        public void displayMessage(string SrResultMessage)
        {
            MessageBox.Show(SrResultMessage);          
        }
    }
}
