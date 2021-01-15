using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

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

        private void TxtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                TextRange txt = new TextRange(txtCMD.Document.ContentStart
                        , txtCMD.Document.ContentEnd);

                if (string.IsNullOrEmpty(txt.Text))
                    MessageBox.Show("Command Is Null", "Null Refrence", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    pragResult.Inlines.Add(new Run("Please Wait Runnig Command"));
                    RunCmd(txt.Text);
                }
            }
        }

        private void RunCmd(string cmd)
        {
            try
            {
                ProcessStartInfo processInfo = new()
                {
                    FileName = "powershell.exe",
                    Arguments = cmd,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                Process process = new()
                {
                    StartInfo = processInfo
                };
                process.Start();
                pragResult.Inlines.Clear();
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
