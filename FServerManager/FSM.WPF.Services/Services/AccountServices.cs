using FSM.WPF.Services.Repository;
using FSM.WPF.ViewModels.AccountViewModels;
using FSM.WPF.ViewModels.ApiResult;
using FSM.WPF.ViewModels.Consts;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FSM.WPF.Services.Services
{
    public class AccountServices : IAccountRepository
    {
        #region __Dependency__

        /// <summary>
        /// Http Client For Apis
        /// </summary>
        private HttpClient _client;

        #endregion

        public async Task<LoginResponse> LoginAsync(LoginViewModel login) => await Task.Run(async () =>
        {
            using (_client = new())
            {
                try
                {
                    string url = ApplicationConsts.ApiUrl + ApplicationConsts.LoginApi;
                    string json = JsonConvert.SerializeObject(login);
                    StringContent content = new(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage result = await _client.PostAsync(url, content);
                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        ApiResult objectResult = await result.Content.ReadFromJsonAsync<ApiResult>();
                        switch (objectResult.ErrorId)
                        {
                            case 0:
                                return LoginResponse.Success;

                            case -2:
                                return LoginResponse.Exception;

                            case -1:
                                return LoginResponse.UserNotFount;

                            default:
                                break;
                        }
                    }
                    return LoginResponse.Exception;
                }
                catch
                {
                    return LoginResponse.Exception;
                }
            }
        });

        public Task SignUpAsync()
        {
            throw new NotImplementedException();
        }
    }
}
