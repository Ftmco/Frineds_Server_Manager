using FSM.Services.Shared.Repository;
using FSM.Services.Shared.Services;
using ServerManager.WPF.Pages;
using System;
using System.IO;
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

        public MainWindow()
        {
            _service = new WindowsService();
            InitializeComponent();
            CallFuncs();
        }

        void CallFuncs()
        {
            SetItemSource();
            GetDate();
            CheckConnection();
            SideBar();
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

        private void CheckConnection()
        {
            if (_service.IsConnectNetWork())
            {
                lblConnect.Content = "Local Internet Connect";
                lblConnect.Foreground = Brushes.Green;
            }
            else
            {
                lblConnect.Content = "Local Internet Connecttion Faild";
                lblConnect.Foreground = Brushes.Red;
            }
        }

        private void SideBar()
        {
            frmSideBar.Navigate(new SideBar());
        }

        private void SetItemSource()
        {
            string path = Directory.GetCurrentDirectory() + @"\Statics\";
            imgBtnConsle.Source = new BitmapImage(new Uri(path + "Console.png"));
            imgBtnSettings.Source = new BitmapImage(new Uri(path + "Settings.png"));
        }

        #endregion
    }
}
