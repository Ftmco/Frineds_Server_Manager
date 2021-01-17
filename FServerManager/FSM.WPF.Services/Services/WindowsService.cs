using FSM.WPF.Services.Repository;
using System;
using System.Globalization;
using System.Net.NetworkInformation;

namespace FSM.WPF.Services.Services
{
    public class WindowsService : IWindowsServices
    {
        public string GetDate(DateTime date)
        {
            PersianCalendar pc = new();
            return $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";
        }

        public string GetPersianDate(DateTime date) =>
            (date.Date.Year + "/" +
            date.Date.Month.ToString("00") + "/" +
            date.Date.DayOfYear.ToString("00"));


        public bool IsConnectNetWork() =>
       NetworkInterface.GetIsNetworkAvailable() == true;

    }
}
