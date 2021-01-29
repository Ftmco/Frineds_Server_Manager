using FSM.WPF.Services.Generic.Control;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ServerManager.WPF.Pages
{
    /// <summary>
    /// Interaction logic for NewPing.xaml
    /// </summary>
    public partial class NewPing : Window
    {
        public Guid PingId = Guid.Empty;

        private readonly IControl<ServerPings> _control;

        public NewPing()
        {
            InitializeComponent();
            _control = new Control<ServerPings>();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidForm())
            {
                if (PingId == Guid.Empty)
                {
                    ServerPings newPing = new()
                    {
                        ServerName = txtServerName.Text,
                        Title = txtTitle.Text
                    };
                    if (await _control.Services.InsertAsync(newPing) && await _control.SaveAsync())
                        DialogResult = true;
                    else
                        MessageBox.Show("Sorry :( Exception", "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    ServerPings editPing = await _control.Services.FindAsync(PingId);
                    editPing.ServerName = txtServerName.Text;
                    editPing.Title = txtTitle.Text;
                    editPing.Status = editPing.Status;

                    if (await _control.Services.UpdateAsync(editPing) && await _control.SaveAsync())
                        DialogResult = true;
                    else
                        MessageBox.Show("Sorry :( Exception", "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
                MessageBox.Show("Please Enter The Requeird Filds (Titl) (Server Name)", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private bool IsValidForm() =>
       !string.IsNullOrEmpty(txtServerName.Text) && !string.IsNullOrEmpty(txtTitle.Text);

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (PingId != Guid.Empty)
            {
                ServerPings ping = await _control.Services.FindAsync(PingId);
                if (ping != null)
                {
                    txtServerName.Text = ping.ServerName;
                    txtTitle.Text = ping.Title;
                }
                else
                    MessageBox.Show("Not Found", "404 :)", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }
    }
}
