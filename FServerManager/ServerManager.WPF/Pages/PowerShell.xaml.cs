using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
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
    /// Interaction logic for PoweShell.xaml
    /// </summary>
    public partial class PoweShell : Window
    {
        public PoweShell()
        {
            InitializeComponent();
        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                if (pragCmd.Inlines.LastInline == null)
                    MessageBox.Show("Command Is Null", "Null Refrence", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    TextRange txt = new TextRange(pragCmd.Inlines.LastInline.ContentStart
                        , pragCmd.Inlines.LastInline.ContentEnd);
                    RunCmd(txt.Text);
                }
            }
        }

        private void RunCmd(string cmd)
        {
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.FileName = "powershell.exe";
                processInfo.Arguments = cmd;
                processInfo.RedirectStandardError = true;
                processInfo.RedirectStandardOutput = true;
                processInfo.UseShellExecute = false;
                processInfo.CreateNoWindow = true;

                Process process = new Process();
                process.StartInfo = processInfo;
                process.Start();
                pragResult.Inlines.Add(new Run(process.StandardOutput.ReadToEnd()));

                string errors = process.StandardError.ReadToEnd();
                if (!string.IsNullOrEmpty(errors))
                {
                    pragResult.Inlines.Add(new Run($"Errors : {errors}"));
                }
            }
            catch (Exception ex)
            {
                pragResult.Inlines.Add(new Run($"An error occurred \n Massage : {ex.Message} \n"));
            }
        }
    }
}
