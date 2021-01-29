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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ServerManager.WPF.Pages
{
    /// <summary>
    /// Interaction logic for PingServerList.xaml
    /// </summary>
    public partial class PingServerList : Page
    {
        #region __Dependency__

        private readonly IControl<ServerPings> _control;

        public PingServerList()
        {
            InitializeComponent();
            _control = new Control<ServerPings>();
            BindGrid();
        }

        #endregion



        private void BtnAddNewPingServer_Click(object sender, RoutedEventArgs e)
        {
            NewPing newPing = new();
            if (newPing.ShowDialog() == true)
            {

            }
        }

        private async void BindGrid()
        {
            dgvPings.AutoGenerateColumns = false;
            dgvPings.ItemsSource = await _control.Services.GetAllAsync();
        }
    }
}
