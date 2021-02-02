using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ServerTasks.xaml
    /// </summary>
    public partial class ServerTasks : Page
    {
        public ServerTasks()
        {
            InitializeComponent();
        }

        private void BtnKillProcess_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BindGrid()
        {
          
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            BindGrid();
        }
    }

}
