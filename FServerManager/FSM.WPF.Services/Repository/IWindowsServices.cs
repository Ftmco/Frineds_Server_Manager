using System;
using System.Threading.Tasks;

namespace FSM.WPF.Services.Repository
{
    public interface IWindowsServices : IDisposable
    {
        Task<bool> IsConnectNetWorkAsync();
        string GetDate(DateTime date);
        string GetPersianDate(DateTime date);
    }
}
