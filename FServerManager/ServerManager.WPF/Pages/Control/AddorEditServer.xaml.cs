using FSM.WPF.Services.Generic.Control;
using System;
using System.Windows;
using System.Windows.Documents;

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

        private async void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            TextRange txt = new TextRange(txtDescription.Document.ContentStart
                     , txtDescription.Document.ContentEnd);
            using (_serverManager = new Control<Server>())
            {
                Server newServer = new()
                {
                    InsertDate = DateTime.Now,
                    Token = txtToken.Text,
                    Description = txt.Text,
                    ServerIpAddress = txtServerIpAddress.Text,
                    ServerName = txtServerName.Text
                };
                if (await _serverManager.Services.InsertAsync(newServer) && await _serverManager.SaveAsync())
                    DialogResult = true;
                else
                    MessageBox.Show("Sorry :( Exception", "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) =>
            DialogResult = false;

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Id != Guid.Empty)
            {
                Title = "Edit";
                using (_serverManager = new Control<Server>())
                {
                    Server server = await _serverManager.Services.FindAsync(Id);
                    if (server != null)
                    {
                        Title += $" {server.ServerName}";
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
