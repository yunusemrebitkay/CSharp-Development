﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace FinalProject
{
   
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void BtnGetStarted_Click(object sender, RoutedEventArgs e)
        {
            //To switch between windows
            Login LoginWindow = new Login();
            LoginWindow.Show();
            this.Close();
        }
    }
}
