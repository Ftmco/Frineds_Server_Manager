using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FSM.WPF.Services.Generic.Repository
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TModel, bool>> where);
        Task<TModel> FindAsync(object id);
        Task<TModel> FirstOrDefaultAsync(Expression<Func<TModel, bool>> firstOrDefualt);
        Task<bool> InsertAsync(TModel model);
        Task<bool> InsertAsync(IList<TModel> model);
        Task<bool> UpdateAsync(TModel model);
        Task<bool> UpdateAsync(IList<TModel> model);
        Task<bool> DeleteAsync(TModel model);
        Task<bool> DeleteAsync(IList<TModel> model);
        Task<bool> DeleteAsync(object id);
    }
}
