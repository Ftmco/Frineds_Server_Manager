using FSM.WPF.ViewModels.Consts;

namespace FSM.WPF.ViewModels.AccountViewModels
{
    /// <summary>
    /// Login App View Model
    /// for Call Fidentity Api 
    /// </summary>
    public record LoginViewModel
    {
        /// <summary>
        /// User Name Or Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Remember Me On this Device
        /// </summary>
        public bool RememberMe { get; set; }

        /// <summary>
        /// Application Key For Call Api Identity 
        /// Default Set To  ApplicationConsts.ApplicationApiKey
        /// </summary>
        public string ApplicationKey { get; set; } = ApplicationConsts.ApplicationApiKey;
    }
}
