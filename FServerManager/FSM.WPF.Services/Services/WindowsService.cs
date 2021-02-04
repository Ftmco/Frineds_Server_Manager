using FSM.WPF.Services.Repository;
using System;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace FSM.WPF.Services.Services
{
    public class WindowsService : IWindowsServices
    {
        public void Dispose() { }

        public string GetDate(DateTime date)
        {
            PersianCalendar pc = new();
            return $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";
        }

        public string GetPersianDate(DateTime date) =>
            (date.Date.Year + "/" +
            date.Date.Month.ToString("00") + "/" +
            date.Date.DayOfYear.ToString("00"));

        int count = 0;

        public async Task<int> IsConnectNetWorkAsync() =>
            await Task.Run(() =>
            {               
                if (count <= 500)
                {
                    count++;
                    try
                    {
                        Ping ping = new();
                        PingReply res = ping.Send("google.com");
                        return (res.Status == IPStatus.Success) ? 0 : -1;
                    }
                    catch
                    {
                        return -1;
                    }
                }
                return -2;
            });

        public void ResetCount() => count = 0;

    }
}
