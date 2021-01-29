using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FSM.WPF.Services.Generic.Repository
{
    public class GenericServicves<TModel> : IGenericRepository<TModel> where TModel : class
    {
        #region __Dependency__

        private readonly DbContext _db;

        private readonly DbSet<TModel> _dbSet;

        public GenericServicves(DbContext db)
        {
            _db = db;
            _dbSet = _db.Set<TModel>();
        }

        #endregion

        public Task<bool> DeleteAsync(TModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(IList<TModel> model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> FindAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> FirstOrDefaultAsync(Expression<Func<TModel, bool>> firstOrDefualt)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TModel, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(TModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(IList<TModel> model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(IList<TModel> model)
        {
            throw new NotImplementedException();
        }
    }
}
