﻿using FSM.WPF.Services.Generic.Control;
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidForm())
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
                MessageBox.Show("Please Enter The Requeird Filds (Titl) (Server Name)", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private bool IsValidForm() =>
       !string.IsNullOrEmpty(txtServerName.Text) && !string.IsNullOrEmpty(txtTitle.Text);

    }
}
