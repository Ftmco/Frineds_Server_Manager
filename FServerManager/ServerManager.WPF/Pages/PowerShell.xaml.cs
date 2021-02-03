using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
                    pgGetResult.Visibility = Visibility.Visible;
                    brdPG.BorderBrush = Brushes.Blue;
                    RunCmd(txt.Text);
                }
            }
        }

        private async void RunCmd(string cmd)
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
                pragResult.Inlines.Add(new Run(await process.StandardOutput.ReadToEndAsync()));

                string errors = process.StandardError.ReadToEnd();
                if (!string.IsNullOrEmpty(errors))
                {
                    pragResult.Inlines.Add(new Run($"Errors : {errors}"));
                }
                brdPG.BorderBrush = Brushes.White;
                process.Close();
            }
            catch (Exception ex)
            {
                pragResult.Inlines.Add(new Run($"An error occurred \n Massage : {ex.Message} \n"));
                pgGetResult.IsIndeterminate = false;
                brdPG.BorderBrush = Brushes.Red;
            }
            finally
            {
                pgGetResult.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Insert in v2", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
