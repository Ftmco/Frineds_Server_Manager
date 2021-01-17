using FSM.Services.Shared.Repository;
using System;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace FSM.Services.Shared.Services
{
    public class WindowsService : IWindowsServices
    {
        public async Task<string> GetDateAsync(DateTime date)
        {
            return await Task.Run(() =>
            {
                PersianCalendar pc = new();
                return $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";
            });
        }

        public async Task<string> GetPersianDateAsync(DateTime date)
        {
            return await Task.Run(() =>
            (date.Date.Year + "/" +
            date.Date.Month.ToString("00") + "/" +
            date.Date.DayOfYear.ToString("00")));
        }

        public async Task<bool> IsConnectNetWorkAsynx()
        {
            return await Task.Run(() => NetworkInterface.GetIsNetworkAvailable());
        }
    }
}
