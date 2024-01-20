using System;
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

namespace InvoiceManagement
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        private string correctPw = "Testing123";
        public LoginView()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string inputPw = PasswordBox.Password;
            if(inputPw == correctPw)
            {
                MessageBox.Show("Logged In with Password: " + inputPw);
            }
            else
            {
                MessageBox.Show("Login failed. Wrong password.");
            }

        }
        private void OnChange(object sender, RoutedEventArgs e)
        {
            string inputPw = PasswordBox.Password;
            if (!string.IsNullOrEmpty(inputPw) )
            {
                LoginButton.IsEnabled = true;
            }
            else
            {
                LoginButton.IsEnabled = false;
            }
        }
    }
}
