using System.Threading.Tasks;

namespace FSM.UWP.Services.Repository
{
    public interface IWindowsServices
    {
        Task<bool> IsConnectNetWorkAsynx();
    }
}
