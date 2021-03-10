using FSM.WPF.Services.Generic.Repository;
using FSM.WPF.Services.UnitOfWork;
using System.Threading.Tasks;

namespace FSM.WPF.Services.Generic.Control
{
    public class Control<TModel> : IControl<TModel>, System.IDisposable where TModel : class
    {
        #region __Dependency__

        private readonly IUnitOfWork<FsmWpfContext> _unitOfWork;

        private readonly IGenericRepository<TModel> _services;

        public Control()
        {
            _unitOfWork = new UnitOfWork<FsmWpfContext>();
            _services = new GenericServicves<TModel>(_unitOfWork.GetDbContext);
        }

        #endregion

        public IGenericRepository<TModel> Services
        {
            get => _services;
        }

        public bool Save() => _unitOfWork.Save();

        public async Task<bool> SaveAsync() => await _unitOfWork.SaveAsync();

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
