using FSM.WPF.Services.Repository;
using FSM.WPF.ViewModels.AccountViewModels;
using System.Windows;
using System.Windows.Input;

namespace ServerManager.WPF.Pages.Account
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        #region __Dependency__

        private IAccountRepository _account;

        #endregion

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

        private async void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

            switch (await _account.LoginAsync(new LoginViewModel
            {
                Email = txtUserName.Text,
                Password = txtPassword.Password,
                RememberMe = true
            }))
            {
                case LoginResponse.Success:
                    break;
                case LoginResponse.UserNotFount:
                    break;
                case LoginResponse.Exception:
                    break;
                default:
                    break;
            }
        }
    }
}
