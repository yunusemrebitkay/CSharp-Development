using System.Windows;



namespace Login_Wpf
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SignUp.Main = this;
            Login.Main = this;
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp.trySignUp();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login.tryLogin();
        }
    }
}
