using System;
using System.Threading.Tasks;

namespace FSM.WPF.Services.Repository
{
    public interface IWindowsServices
    {
        bool IsConnectNetWork();
        string GetDate(DateTime date);
        string GetPersianDate(DateTime date);
    }
}
