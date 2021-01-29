using FSM.WPF.Services.Generic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM.WPF.Services.Generic.Control
{
    public interface IControl<TModel> where TModel : class
    {
        public IGenericRepository<TModel> Services { get; set; }
    }
}
