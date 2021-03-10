using FSM.WPF.Services.Generic.Control;
using FSM.WPF.Services.Repository;
using FSM.WPF.Services.Services;
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

namespace ServerManager.WPF.Pages.Ping_Servers
{
    /// <summary>
    /// Interaction logic for PingServers.xaml
    /// </summary>
    public partial class PingServers : Page
    {
        private IControl<ServerPings> _servcies;

        public PingServers()
        {
            InitializeComponent();
        }

        private  void Page_Loaded(object sender, RoutedEventArgs e)
        {
            BindList();
        }

        private async void BindList()
        {
            using (_servcies = new Control<ServerPings>())
            {
                IEnumerable<ServerPings> data = await _servcies.Services.GetAllAsync();
                List<ListBoxItem> listBoxItems = new();
                foreach (ServerPings dataItem in data)
                {
                    ListBoxItem item = new() { Height = 100 };
                    StackPanel itemStackPanel = new() { Width = 250 };
                    item.Content = itemStackPanel;
                    itemStackPanel.Children.Add(new Label { Content = dataItem.Title });
                    itemStackPanel.Children.Add(new Label { Content = dataItem.IpAddress });
                    itemStackPanel.Children.Add(new ProgressBar { Value = dataItem.Avrage, Height = 35 });
                    listBoxItems.Add(item);
                }
                lstPingList.ItemsSource = listBoxItems;
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            BindList();
        }
    }
}
