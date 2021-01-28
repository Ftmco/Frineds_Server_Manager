using Microsoft.Win32;
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

namespace ServerManager.WPF.Pages
{
    /// <summary>
    /// Interaction logic for NewIISApp.xaml
    /// </summary>
    public partial class NewIISApp : Window
    {
        public NewIISApp()
        {
            InitializeComponent();
        }

        private void BtnSelectPath_Click(object sender, RoutedEventArgs e)
        {
            FileDialog fileDialog = new OpenFileDialog() { CheckFileExists = true, Multiselect = false, Title = "Select File" };
            if (fileDialog.ShowDialog() == true)
            {
                string exetion = System.IO.Path.GetExtension(fileDialog.FileName);
                if (exetion != ".zip" || exetion != ".rar")
                {
                    MessageBox.Show("File Is Not Supported", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void TxtPath_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BtnSelectPath_Click(sender, e);
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
