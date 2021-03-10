using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM.WPF.ViewModels.Consts
{
    /// <summary>
    /// Application Constansts
    /// </summary>
    public record ApplicationConsts
    {
        /// <summary>
        /// Api Friends Account Services Url
        /// </summary>
        public static string ApiUrl { get => "https://account.api.ftmco.ir"; }

        /// <summary>
        /// Login Api Url 
        /// </summary>
        public static string LoginApi { get => "/Account/Login"; }

        /// <summary>
        /// Sign Up Api Url
        /// </summary>
        public static string SingUpApi { get => "/Account/SignUp"; }

        /// <summary>
        /// Application Api Key For Friends Identity Api Header
        /// </summary>
        public static string ApplicationApiKey { get => "93825A3A137F7BC6C5EC0813AD77AC74723DB6841B79D5146830606B771562D2"; }
    }
}
