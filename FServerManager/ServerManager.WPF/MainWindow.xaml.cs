﻿using ServerManager.WPF.Pages;
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

        public MainWindow()
        {
            InitializeComponent();
            imgBtn.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + @"\Statics\Console.png"));
            GetDate();
            CheckConnection();
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

        void GetDate()
        {
            lblTime.Content = DateTime.Now.Year + "/" + DateTime.Now.Month.ToString("00") + "/" + DateTime.Now.DayOfWeek.ToString();
        }

        void CheckConnection()
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
            {
                lblConnect.Content = "Connect";
                lblConnect.Foreground = Brushes.Green;
            }
            else
            {
                lblConnect.Content = "Connecttion Faild";
                lblConnect.Foreground = Brushes.Red;
            }
        }

    }
}
