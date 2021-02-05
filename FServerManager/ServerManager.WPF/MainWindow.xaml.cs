using FSM.WPF.Services.Generic.Control;
using FSM.WPF.Services.Repository;
using FSM.WPF.Services.Services;
using ServerManager.WPF.Pages;
using ServerManager.WPF.Pages.Account;
using ServerManager.WPF.Pages.Control;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ServerManager.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly IWindowsServices _service;

        private IControl<Server> _serverManager;

        public MainWindow()
        {
            _service = new WindowsService();
            InitializeComponent();
            CallFuncs();
        }

        void CallFuncs()
        {
            GetDate();
            CheckConnection();
            NavigateFrames();
            BindGrid();
        }

        private void BtnFile_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }

        private void BtnPoweShell_Click(object sender, RoutedEventArgs e)
        {
            PoweShell ps1 = new();
            ps1.ShowDialog();
        }

        #region __Private Methodes__

        private void GetDate()
        {
            lblTime.Content = _service.GetDate(DateTime.Now);
        }

        private async Task CheckConnection() =>
            await Task.Run(async () =>
            {
                int result = 0;
                while (result != -2)
                {
                    result = await _service.IsConnectNetWorkAsync();
                    Thread.Sleep(50);
                    await Dispatcher.BeginInvoke(new Action(() =>
                     {
                         switch (result)
                         {
                             case 0:
                                 lblConnect.Content = "Local Internet Connect";
                                 lblConnect.Foreground = Brushes.Green;
                                 _service.ResetCount();
                                 break;
                             case -1:
                                 lblConnect.Content = "Local Internet Connecttion Faild";
                                 lblConnect.Foreground = Brushes.Red;
                                 break;
                             case -2:
                                 lblConnect.Content = "Trying to connect to the Internet more than allowed please check your connection and Restart Application";
                                 lblConnect.Foreground = Brushes.Red;
                                 break;
                             default:
                                 break;
                         }

                     }));
                }
                if (result == -2)
                    await Dispatcher.BeginInvoke(new Action(() =>
                    {
                        lblConnect.Content = "Trying to connect to the Internet more than allowed please check your connection and Restart Application";
                        lblConnect.Foreground = Brushes.Red;
                        Console.Beep(1000, 2560);
                    }));
            });


        private void NavigateFrames()
        {
            frmServerInfos.Navigate(new ServerTasks());
            frmListServers.Navigate(new PingServerList());
        }

        #endregion

        private void BtnSitest_Click(object sender, RoutedEventArgs e)
        {
            frmServerInfos.Navigate(new ServerSites());
        }

        private void BtnAccount_Click(object sender, RoutedEventArgs e)
        {
            Login login = new();
            if (login.ShowDialog() == true)
            {

            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnNewServer_Click(object sender, RoutedEventArgs e)
        {
            AddorEditServer addNewServer = new();
            if (addNewServer.ShowDialog() == true)
            {
                BindGrid();
            }
        }

        private async void BindGrid()
        {
            using (_serverManager = new Control<Server>())
            {
                IEnumerable<Server> data = await _serverManager.Services.GetAllAsync();
                dgServers.ItemsSource = data.OrderByDescending(s => s.InsertDate);
            }
        }
    }
}
