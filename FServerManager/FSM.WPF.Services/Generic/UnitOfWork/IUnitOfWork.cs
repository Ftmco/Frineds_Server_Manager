using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FSM.WPF.Services.UnitOfWork
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {

        /// <summary>
        /// Return DbContext
        /// </summary>
        public DbContext GetDbContext { get; set; }

        /// <summary>
        /// Save All Changes Use 'await' befor Use This
        /// </summary>
        /// <returns>
        /// True ; False
        /// </returns>
        Task<bool> SaveAsync();

        /// <summary>
        /// Save All Changes
        /// </summary>
        /// <returns><
        /// True ; False
        /// /returns>
        bool Save();
    }
}
