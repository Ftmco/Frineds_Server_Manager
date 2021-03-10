using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM.WPF.ViewModels.AccountViewModels
{
    public enum LoginResponse
    {
        Success = 0,
        UserNotFount = -1,
        Exception = -2
    }
}
