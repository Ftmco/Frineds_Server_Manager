using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        #region __Dependency__

        private readonly DbContext _db;

        public UnitOfWork()
        {
            _db = new TContext();
        }

        #endregion

        #region --Save -- Dispose--

        public async void Dispose()
        {
            await _db.DisposeAsync();
        }

        public bool Save()
        {
            try
            {
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> SaveAsync()
        {
            return await Task.Run(async () =>
            {
                try
                {
                    await _db.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        #endregion
    }
}
