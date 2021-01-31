using FSM.WPF.Services.Generic.Repository;
using System;
using System.Threading.Tasks;

namespace FSM.WPF.Services.Generic.Control
{
    public interface IControl<TModel> : IDisposable where TModel  : class 
    {
        public IGenericRepository<TModel> Services { get; }

        Task<bool> SaveAsync();
        bool Save();
    }
}
