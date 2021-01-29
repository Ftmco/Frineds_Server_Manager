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
using System.Windows.Shapes;

namespace ServerManager.WPF.Pages.Account
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            txtUserName.GotFocus += TxtUserName_GotFocus;
            txtUserName.LostFocus += TxtUserName_LostFocus;
        }

        private void TxtUserName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
                txtUserName.Text = "User Name or Email";
        }

        private void TxtUserName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtUserName.Text == "User Name or Email")
            {
                txtUserName.Text = "";
            }
        }

        private void LblRegister_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SingUp singUp = new();
            DialogResult = singUp.ShowDialog();
        }
               
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
