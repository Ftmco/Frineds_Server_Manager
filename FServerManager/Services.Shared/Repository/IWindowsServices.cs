using System.Threading.Tasks;

namespace Services.Shared.Repository
{
    public interface IWindowsServices
    {
        Task<bool> IsConnectNetWork();
    }
}
