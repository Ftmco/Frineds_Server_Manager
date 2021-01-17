using System.Threading.Tasks;

namespace FSM.Services.Shared.Repository
{
    public interface IWindowsServices
    {
        Task<bool> IsConnectNetWorkAsynx();
    }
}
