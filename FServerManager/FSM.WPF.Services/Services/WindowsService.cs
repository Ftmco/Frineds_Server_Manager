using Services.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Services.Shared.Services
{
    public class WindowsService : IWindowsServices
    {
        public async Task<bool> IsConnectNetWorkAsynx()
        {
            return await Task.Run(() => NetworkInterface.GetIsNetworkAvailable());
        }
    }
}
