using FSM.Services.Shared.Repository;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace FSM.Services.Shared.Services
{
    public class WindowsService : IWindowsServices
    {
        public async Task<bool> IsConnectNetWorkAsynx()
        {
            return await Task.Run(() => NetworkInterface.GetIsNetworkAvailable());
        }
    }
}
