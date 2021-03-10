using FSM.WPF.ViewModels.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM.WPF.Services.Repository
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Login User 
        /// use 'await'
        /// </summary>
        /// <returns></returns>
        Task<LoginResponse> LoginAsync(LoginViewModel login);

        /// <summary>
        /// Sign Up User 
        /// use 'await'
        /// </summary>
        /// <returns></returns>
        Task SignUpAsync();
    }
}
