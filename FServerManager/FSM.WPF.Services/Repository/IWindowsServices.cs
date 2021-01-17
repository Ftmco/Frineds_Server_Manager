using System;
using System.Threading.Tasks;

namespace FSM.Services.Shared.Repository
{
    public interface IWindowsServices
    {
        Task<bool> IsConnectNetWorkAsynx();
        Task<string> GetDateAsync(DateTime date);
        Task<string> GetPersianDateAsync(DateTime date);
    }
}
