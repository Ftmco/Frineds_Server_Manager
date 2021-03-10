using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM.WPF.ViewModels.ApiResult
{
    public record ApiResult
    {
        public int ErrorId { get; set; }
        public string Title { get; set; }
        public object Result { get; set; }
    }
}
