using FSM.WPF.Services.Generic.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ServerManager.WPF.Pages
{
    /// <summary>
    /// Interaction logic for PingServerList.xaml
    /// </summary>
    public partial class PingServerList : Page
    {
        #region __Dependency__

        private IControl<ServerPings> _control;

        public IControl<ServerPings> Control
        {
            get
            {
                if (_control == null)
                {
                    _control = new Control<ServerPings>();
                }
                return _control;
            }
        }

        public PingServerList()
        {
            InitializeComponent();
            BindGrid();
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
            dgvPings.AutoGenerateColumns = false;
            IEnumerable<ServerPings> data = await Control.Services.GetAllAsync();
            dgvPings.ItemsSource = data;
            _control = null;
            await GetPingingAsync();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            BindGrid();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            BindGrid();
        }

        private async Task GetPingingAsync()
        {
            await Task.Run(async () =>
            {
                IControl<ServerPings> _service = new Control<ServerPings>();
                while (true)
                {
                    IEnumerable<ServerPings> lstPigns = await _service.Services.GetAllAsync();
                    Ping ping = new();

                    foreach (var item in lstPigns)
                    {
                        try
                        {
                            if (item.RequestCount <= 1000)
                            {
                                PingReply res = ping.Send(item.ServerName);
                                item.RequestCount += 1;
                                IPStatus status = res.Status;
                                item.Ping = (int)res.RoundtripTime;
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
                                        item.Status = "HardwareError";
                                        break;
                                    case IPStatus.PacketTooBig:
                                        item.Status = "PacketTooBig";
                                        break;
                                    case IPStatus.TimedOut:
                                        item.Status = "TimedOut";
                                        break;
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
                            }
                        }
                        catch
                        {
                            item.Status = "Exception";
                        }
                        finally
                        {
                            await _service.Services.UpdateAsync(item);
                        }
                    }
                    await _service.SaveAsync();
                    await Dispatcher.BeginInvoke(new Action(() => BindGrid()));
                }
            });
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            ServerPings current = (ServerPings)dgvPings.CurrentItem;
            if (current != null)
            {
                if (await Control.Services.DeleteAsync(current) && await Control.SaveAsync())
                {
                    BindGrid();
                }
                else
                    MessageBox.Show("Sorry :( Exception", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Please Select One", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ServerPings current = (ServerPings)dgvPings.CurrentItem;
            if (current != null)
            {
                NewPing editPing = new();
                editPing.PingId = current.PingId;
                if (editPing.ShowDialog() == true)
                {
                    BindGrid();
                }
            }
            else
                MessageBox.Show("Please Select One", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
