using FSM.WPF.Services.Generic.Control;
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

namespace ServerManager.WPF.Pages.Control
{
    /// <summary>
    /// Interaction logic for AddorEditServer.xaml
    /// </summary>
    public partial class AddorEditServer : Window
    {
        public Guid Id = Guid.Empty;

        private IControl<Server> _serverManager;

        public AddorEditServer()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) =>
            DialogResult = false;

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Id != Guid.Empty)
            {
                using (_serverManager = new Control<Server>())
                {
                    Server server = await _serverManager.Services.FindAsync(Id);
                    if (server != null)
                    {
                        txtServerIpAddress.Text = server.ServerIpAddress;
                        txtServerName.Text = server.ServerName;
                        txtToken.Text = server.Token;
                        prgDescription.Inlines.Add(new Run(server.Description));
                    }
                    else
                        MessageBox.Show("Not Found", "404 :)", MessageBoxButton.OK, MessageBoxImage.Hand);
                }
            }
        }
    }
}
