using FSM.WPF.Services.Generic.Repository;
using FSM.WPF.Services.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM.WPF.Services.Generic.Control
{
    class Control<TModel> : IControl<TModel> where TModel : class
    {
        #region __Dependency__

        private readonly IUnitOfWork<FsmWpfContext> _unitOfWork;

        #endregion

        private IGenericRepository<TModel> _services;

        public IGenericRepository<TModel> Services
        {
            get
            {
                if (_services == null)
                {
                    _services = new GenericServicves<TModel>(_unitOfWork.GetDbContext);
                }
                return _services;
            }
            set => throw new NotImplementedException();
        }
    }
}
