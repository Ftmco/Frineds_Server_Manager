using System;
using System.Threading.Tasks;

namespace FSM.Services.Shared.Repository
{
    public interface IWindowsServices
    {
        bool IsConnectNetWork();
        string GetDate(DateTime date);
        string GetPersianDate(DateTime date);
    }
}
