using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services.UnitOfWork
{
    /// <summary>
    /// Unit Of Work Service
    /// </summary>
    /// <typeparam name="TContext">DbContext</typeparam>
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        /// <summary>
        /// Save All Changes
        /// </summary>
        /// <returns>
        /// True : Success
        /// False : Exception
        /// </returns>
        Task<bool> SaveAsync();

        /// <summary>
        /// Save All Changes
        /// </summary>
        /// <returns> 
        /// True : Success
        /// False : Exception
        /// </returns>
        bool Save();
    }
}
