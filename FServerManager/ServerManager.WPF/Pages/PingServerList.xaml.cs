using FSM.WPF.Services.Generic.Control;
using FSM.WPF.Services.Repository;
using FSM.WPF.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ServerManager.WPF.Pages
{
    /// <summary>
    /// Interaction logic for PingServerList.xaml
    /// </summary>
    public partial class PingServerList : Page
    {
        bool IsInChange = false;

        #region __Dependency__

        private IControl<ServerPings> _control;

        private readonly IWindowsServices _windows;

        public PingServerList()
        {
            InitializeComponent();
            _windows = new WindowsService();
        }


        #endregion

        private void BtnAddNewPingServer_Click(object sender, RoutedEventArgs e)
        {
            NewPing newPing = new();
            if (newPing.ShowDialog() == true)
            {
                BindGrid();
            }
        }

        private async void BindGrid()
        {
            using (_control = new Control<ServerPings>())
            {
                dgvPings.AutoGenerateColumns = false;
                IEnumerable<ServerPings> data = await _control.Services.GetAllAsync();
                if (data.Count() != 0)
                {
                    float sum = data.Count() > 1 ? data.Sum(d => d.Avrage) : data.FirstOrDefault().Ping;
                    double pgAvrageValue = data.Count() > 1 ? sum / data.Count() : data.FirstOrDefault().Avrage;

                    if (double.IsNaN(pgAvrageValue))
                        pgAvrageValue = 0;

                    pgAvrage.Maximum = sum;
                    pgAvrage.Value = pgAvrageValue;

                    double switchValue = pgAvrage.Value * 100 / pgAvrage.Maximum;

                    lblAvrage.Content = $"'{Convert.ToInt32(pgAvrage.Value)}/{pgAvrage.Maximum}' | '{Convert.ToInt32((double.IsNaN(switchValue) ? 0 : switchValue))}%'";
                    pgAvrage.Foreground = switchValue switch
                    {
                        > 75 => new SolidColorBrush(Colors.Red),
                        > 65 => new SolidColorBrush(Colors.Orange),
                        > 55 => new SolidColorBrush(Colors.Yellow),
                        > 45 => new SolidColorBrush(Colors.YellowGreen),
                        > 25 => new SolidColorBrush(Colors.Gold),
                        _ => new SolidColorBrush(Colors.Green)
                    };

                    dgvPings.ItemsSource = data.OrderByDescending(sp => sp.Ping);
                }
                SetLstPings();
            }
            await GetPingingAsync();
        }

        private async void SetLstPings()
        {
            using (_control = new Control<ServerPings>())
            {
                IEnumerable<ServerPings> data = await _control.Services.GetAllAsync();
                List<ListBoxItem> lstItems = new List<ListBoxItem>();
                foreach (var item in data)
                {
                    float avrage = item.Ping;

                    ListBoxItem lstIrem = new();
                    StackPanel stackPanel = new();
                    stackPanel.Children.Add(new Label { Content = item.Title });
                    stackPanel.Children.Add(new Label { Content = $"ping : {avrage}" });
                    stackPanel.Children.Add(new ProgressBar
                    {
                        Maximum = 100,
                        Width = cd.Width.Value - 50,
                        HorizontalContentAlignment = HorizontalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Center,
                        Height = 25,
                        Value = avrage,
                        Foreground = avrage switch
                        {
                            > 75 => new SolidColorBrush(Colors.Red),
                            > 65 => new SolidColorBrush(Colors.Orange),
                            > 55 => new SolidColorBrush(Colors.Yellow),
                            > 45 => new SolidColorBrush(Colors.YellowGreen),
                            > 25 => new SolidColorBrush(Colors.Gold),
                            _ => new SolidColorBrush(Colors.Green)
                        }
                    });

                    lstIrem.Content = stackPanel;
                    lstItems.Add(lstIrem);

                    lstPings.ItemsSource = lstItems.Distinct();
                }
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            IsInChange = false;
            BindGrid();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            BindGrid();
        }

        int result = 0;
        private async Task GetPingingAsync()
        {
            await Task.Run(async () =>
            {
                using IWindowsServices windowsServices = new WindowsService();
                if (!IsInChange)
                {
                    if (result != -2)
                    {
                        result = await windowsServices.IsConnectNetWorkAsync();
                        if (result == 0)
                        {
                            using IControl<ServerPings> _service = new Control<ServerPings>();
                            IEnumerable<ServerPings> lstPigns = await _service.Services.GetAllAsync();
                            Ping ping = new();

                            foreach (var item in lstPigns)
                            {
                                try
                                {
                                    if (item.RequestCount <= 500)
                                    {
                                        PingReply res = ping.Send(item.ServerName);
                                        item.RequestCount += 1;
                                        IPStatus status = res.Status;
                                        item.Ping = (int)res.RoundtripTime;
                                        item.PingSum += item.Ping;
                                        item.Avrage = item.PingSum / item.RequestCount;
                                        item.IpAddress = res.Address.ToString();

                                        switch (status)
                                        {
                                            case IPStatus.Unknown:
                                                item.Status = "Unknown";
                                                break;
                                            case IPStatus.Success:
                                                item.Status = "Success";
                                                break;
                                            case IPStatus.DestinationNetworkUnreachable:
                                                item.Status = "DestinationNetworkUnreachable";
                                                break;
                                            case IPStatus.DestinationHostUnreachable:
                                                item.Status = "DestinationHostUnreachable";
                                                break;
                                            case IPStatus.DestinationProhibited:
                                                item.Status = "DestinationProhibited";
                                                break;
                                            case IPStatus.DestinationPortUnreachable:
                                                item.Status = "DestinationPortUnreachable";
                                                break;
                                            case IPStatus.NoResources:
                                                item.Status = "NoResources";
                                                break;
                                            case IPStatus.BadOption:
                                                item.Status = "BadOption";
                                                break;
                                            case IPStatus.HardwareError:
                                                {
                                                    item.PingSum += 200;
                                                    System.Console.Beep(2500, 200);
                                                    item.Status = "HardwareError";
                                                    break;
                                                }
                                            case IPStatus.PacketTooBig:
                                                item.Status = "PacketTooBig";
                                                break;
                                            case IPStatus.TimedOut:
                                                {
                                                    item.PingSum += 200;
                                                    System.Console.Beep(1500, 200);
                                                    item.Status = "TimedOut";
                                                    break;
                                                }
                                            case IPStatus.BadRoute:
                                                item.Status = "BadRoute";
                                                break;
                                            case IPStatus.TtlExpired:
                                                item.Status = "TtlExpired";
                                                break;
                                            case IPStatus.TtlReassemblyTimeExceeded:
                                                item.Status = "TtlReassemblyTimeExceeded";
                                                break;
                                            case IPStatus.ParameterProblem:
                                                item.Status = "ParameterProblem";
                                                break;
                                            case IPStatus.SourceQuench:
                                                item.Status = "SourceQuench";
                                                break;
                                            case IPStatus.BadDestination:
                                                item.Status = "BadDestination";
                                                break;
                                            case IPStatus.DestinationUnreachable:
                                                item.Status = "DestinationUnreachable";
                                                break;
                                            case IPStatus.TimeExceeded:
                                                item.Status = "TimeExceeded";
                                                break;
                                            case IPStatus.BadHeader:
                                                item.Status = "BadHeader";
                                                break;
                                            case IPStatus.UnrecognizedNextHeader:
                                                item.Status = "UnrecognizedNextHeader";
                                                break;
                                            case IPStatus.IcmpError:
                                                item.Status = "IcmpError";
                                                break;
                                            case IPStatus.DestinationScopeMismatch:
                                                item.Status = "DestinationScopeMismatch";
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        item.RequestCount = 0;
                                        item.Ping = 0;
                                        item.Avrage = 0;
                                        item.PingSum = 0;
                                    }
                                }
                                catch
                                {
                                    item.PingSum += 300;
                                    item.Status = "Exception";
                                    System.Console.Beep(5000, 50);
                                    item.ExceptionCount++;
                                    if (item.ExceptionCount >= 1000)
                                        if (MessageBox.Show($"We want to remove '{item.Title}' because more than '{item.ExceptionCount}' errors have been registered for this '{item.Title}'", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error) == MessageBoxResult.OK)
                                            await _service.Services.DeleteAsync(item); await _service.SaveAsync();
                                }
                                finally
                                {
                                    await _service.Services.UpdateAsync(item);
                                }
                            }
                            await _service.SaveAsync();
                        }
                        await Dispatcher.BeginInvoke(new Action(() => BindGrid()));
                    }
                }
            });
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            ServerPings current = (ServerPings)dgvPings.CurrentItem;
            if (current != null)
            {
                IsInChange = true;
                if (MessageBox.Show($"Are You Sure To Delete '{current.Title}'?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    using (_control = new Control<ServerPings>())
                    {
                        if (await _control.Services.DeleteAsync(current) && await _control.SaveAsync())
                        {
                            IsInChange = false;
                            BindGrid();
                        }
                        else
                            MessageBox.Show("Sorry :( Exception", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
                MessageBox.Show("Please Select One", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ServerPings current = (ServerPings)dgvPings.CurrentItem;
            if (current != null)
            {
                IsInChange = true;
                NewPing editPing = new();
                editPing.PingId = current.Id;
                if (editPing.ShowDialog() == true)
                {
                    IsInChange = false;
                    BindGrid();
                }
            }
            else
                MessageBox.Show("Please Select One", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

    }
}
