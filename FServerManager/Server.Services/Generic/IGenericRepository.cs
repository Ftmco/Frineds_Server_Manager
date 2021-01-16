using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Server.Services.Generic
{
    /// <summary>
    /// Crud an Entity Services
    /// </summary>
    /// <typeparam name="TModel">T Entity</typeparam>
    public interface IGenericRepository<TModel>
    {

        /// <summary>
        /// Get All T Entity
        /// </summary>
        /// <returns>All TModels</returns>
        Task<IEnumerable<TModel>> GetAllAsync();

        /// <summary>
        /// Get All T Entity With Expression
        /// </summary>
        /// <param name="where">Where TModel Expression</param>
        /// <returns>Filter and Get Al TModels</returns>
        Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TModel, bool>> where);

        /// <summary>
        /// Find one row With Id
        /// </summary>
        /// <param name="Id">Model Id</param>
        /// <returns>Model</returns>
        Task<TModel> FindByIdAsync(object Id);

        /// <summary>
        /// Insert New Model
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>
        /// True : Success
        /// False : Exception
        /// </returns>
        Task<bool> InsertAsync(TModel model);

        /// <summary>
        /// Update Exist Model
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>
        /// True : Success
        /// False : Exception
        /// </returns>
        Task<bool> UpdateAsync(TModel model);

        /// <summary>
        /// Delete Exist Model
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>
        /// True : Success
        /// False : Exception
        /// </returns>
        Task<bool> DeleteAsync(TModel model);

        /// <summary>
        /// Delete Exist Model With Id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>
        /// True : Success
        /// False : Exception
        /// </returns>
        Task<bool> DeleteAsync(object Id);
    }
}
