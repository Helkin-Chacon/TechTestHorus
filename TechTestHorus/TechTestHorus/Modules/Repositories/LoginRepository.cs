using Flurl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTestHorus.Core.Constants;
using TechTestHorus.Core.Services;
using TechTestHorus.Modules.Repositories.Interfaces;
using Flurl.Http;
using TechTestHorus.Core.Services.Interfaces;
using Xamarin.Essentials.Interfaces;
using TechTestHorus.Core.Models;
using TechTestHorus.Core.Models.WebApi.Login;

namespace TechTestHorus.Modules.Repositories
{
    public class LoginRepository : WebApiService, ILoginRepository
    {
        public LoginRepository(ISettingsService settingsService) : base(settingsService)
        {

          

        }

        public async Task<bool> Login(string email = null, string password = null)
        {
            Errors.Clear();
                 
            try
            {
                var url = ApiConstants.ApiBaseUrl.AppendPathSegment(ApiConstants.EndPointLogin);

                LoginApiResponseModel response = null;

                response = await url.PostJsonAsync(new
                {
                    Email = email,
                    Password = password
                }).ReceiveJson<LoginApiResponseModel>();                

                await SaveToken(response);

                return true;
                throw new NotImplementedException();
            }
            catch(Flurl.Http.FlurlHttpException ex)
            {
                switch (ex.StatusCode)
                {
                    case 401:
                        Errors.Add(new Error() { Message = ex.Message, Title = "Autentication Error"});
                        return false;
                        break;
                    case 500:
                        Errors.Add(new Error() { Message = ex.Message, Title = "Server Error" });
                        return false;

                        break;

                }
                return false;

            }
        }
    }
}
