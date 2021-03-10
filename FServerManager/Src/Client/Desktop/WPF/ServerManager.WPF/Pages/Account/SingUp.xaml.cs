using System.Windows;

namespace ServerManager.WPF.Pages.Account
{
    /// <summary>
    /// Interaction logic for SingUp.xaml
    /// </summary>
    public partial class SingUp : Window
    {
        public SingUp()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
