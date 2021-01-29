﻿using FSM.WPF.Services.Generic.Control;
using System.Net.NetworkInformation;
using System.Threading;
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

        private readonly IControl<ServerPings> _control;

        public PingServerList()
        {
            InitializeComponent();
            _control = new Control<ServerPings>();
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
            dgvPings.ItemsSource = await _control.Services.GetAllAsync();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            BindGrid();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            StartPinging();
        }

        private void StartPinging()
        {
            ThreadStart threadStart = new(Pinging);
            Thread thread = new(threadStart);
            thread.Start();
        }

        private async void Pinging()
        {

            IControl<ServerPings> _service = new Control<ServerPings>();
            var lstPigns = await _service.Services.GetAllAsync();

            Ping ping = new();

            foreach (var item in lstPigns)
            {
                try
                {
                    PingReply res = ping.Send(item.ServerName);
                    item.RequestCount += 1;
                    IPStatus status = res.Status;

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
                catch
                {
                    item.Status = "Exception";
                }
                finally
                {
                    await _service.Services.UpdateAsync(item); await _service.SaveAsync();
                }
            }

            Pinging();
        }

    }
}
