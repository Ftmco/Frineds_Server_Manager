using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> DeleteAsync(TModel model)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _dbSet.Remove(model);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> DeleteAsync(IList<TModel> model)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _dbSet.RemoveRange(model);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> DeleteAsync(object id)
        {
            return await Task.Run(async () => await DeleteAsync(await FindAsync(id)));
        }

        public async Task<TModel> FindAsync(object id)
        {
            return await Task.Run(async () => await _dbSet.FindAsync(id));
        }

        public async Task<TModel> FirstOrDefaultAsync(Expression<Func<TModel, bool>> firstOrDefualt)
        {
            return await Task.Run(async () => await _dbSet.FirstOrDefaultAsync(firstOrDefualt));
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return await Task.Run(async () => await _dbSet.ToListAsync());
        }

        public async Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TModel, bool>> where)
        {
            return await Task.Run(async () => await _dbSet.Where(where).ToListAsync());
        }

        public async Task<bool> InsertAsync(TModel model)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    await _dbSet.AddAsync(model);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> InsertAsync(IList<TModel> model)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    await _dbSet.AddRangeAsync(model);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> UpdateAsync(TModel model)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _dbSet.Update(model);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> UpdateAsync(IList<TModel> model)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _dbSet.UpdateRange(model);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }
    }
}
