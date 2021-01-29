using FSM.WPF.Services.Generic.Repository;
using FSM.WPF.Services.UnitOfWork;
using System.Threading.Tasks;

namespace FSM.WPF.Services.Generic.Control
{
    public class Control<TModel> : IControl<TModel> where TModel : class
    {
        #region __Dependency__

        private readonly IUnitOfWork<FsmWpfContext> _unitOfWork;

        public Control()
        {
            _unitOfWork = new UnitOfWork<FsmWpfContext>();
        }

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
        }

        public bool Save() => _unitOfWork.Save();

        public async Task<bool> SaveAsync() => await _unitOfWork.SaveAsync();

    }
}
