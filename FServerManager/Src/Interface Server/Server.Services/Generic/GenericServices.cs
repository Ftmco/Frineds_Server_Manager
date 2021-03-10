using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Server.Services.Generic
{
    public class GenericServices<TModle> : IGenericRepository<TModle> where TModle : class
    {
        #region __Dependency__

        /// <summary>
        /// Data Base Context
        /// </summary>
        private readonly DbContext _db;

        /// <summary>
        /// Data Base Table
        /// </summary>
        private readonly DbSet<TModle> _dbSet;

        /// <summary>
        /// Generic Repository
        /// </summary>
        /// <param name="db">Data base Context</param>
        public GenericServices(DbContext db)
        {
            _db = db;
            _dbSet = _db.Set<TModle>();
        }

        #endregion

        public async Task<bool> DeleteAsync(TModle model)
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

        public async Task<bool> DeleteAsync(object Id)
        {
            return await Task.Run(async () => await DeleteAsync(await FindByIdAsync(Id)));
        }

        public async Task<TModle> FindByIdAsync(object Id)
        {
            return await Task.Run(async () => await _dbSet.FindAsync(Id));
        }

        public async Task<IEnumerable<TModle>> GetAllAsync()
        {
            return await Task.Run(async () => await _dbSet.ToListAsync());
        }

        public async Task<IEnumerable<TModle>> GetAllAsync(Expression<Func<TModle, bool>> where)
        {
            return await Task.Run(async () => await _dbSet.Where(where).ToListAsync());
        }

        public async Task<bool> InsertAsync(TModle model)
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

        public async Task<bool> UpdateAsync(TModle model)
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
    }
}
