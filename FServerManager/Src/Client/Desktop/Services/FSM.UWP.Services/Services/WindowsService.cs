using FSM.UWP.Services.Repository;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace FSM.UWP.Services.Services
{
    public class WindowsService : IWindowsServices
    {
        public async Task<bool> IsConnectNetWorkAsynx()
        {
            return await Task.Run(() => NetworkInterface.GetIsNetworkAvailable());
        }
    }
}
