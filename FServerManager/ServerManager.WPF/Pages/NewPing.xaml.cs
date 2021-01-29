using FSM.WPF.Services.Generic.Control;
using System.Windows;
using System.Windows.Controls;

namespace ServerManager.WPF.Pages
{
    /// <summary>
    /// Interaction logic for NewPing.xaml
    /// </summary>
    public partial class NewPing : Window
    {
        private readonly IControl<ServerPings> _control;

        public NewPing()
        {
            InitializeComponent();
            _control = new Control<ServerPings>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ServerPings newPing = new()
            {
                ServerName = txtServerName.Text,
                Title = txtTitle.Text
            };
            if (_control.Services.InsertAsync(newPing).Result && _control.Save())
            {
                DialogResult = true;
            }
            MessageBox.Show("Exception");
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
