using DryIoc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTestHorus.Core.Services.Interfaces;
using TechTestHorus.Core.Models.WebApi.Login;

namespace TechTestHorus.Core.Services
{
    public class WebApiService 
    {
        protected readonly ISettingsService _settingsService;
        public WebApiService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
            Errors = new List<TechTestHorus.Core.Models.Error>();
        }

        /// <summary>
        /// The errors.
        /// </summary>
        public List<TechTestHorus.Core.Models.Error> Errors;
        /// <summary>
        /// Gets the get errors.
        /// </summary>
        /// <value>The get errors.</value>
        public List<TechTestHorus.Core.Models.Error> GetErrors
        {
            get => Errors;
        }

     
        /// <summary>
        /// Save the token.
        /// </summary>
        /// <returns>The token.</returns>
        /// <param name="response">Response.</param>
        protected async Task SaveToken(LoginApiResponseModel response)
        {
            await Task.Run(() =>
            {
                _settingsService.SetString<string>("oauthToken", response.AuthorizationToken);              
            });
        }
        public async Task<string> GetToken()
        {
            return await Task.Run(() => _settingsService.GetString<string>("oauthToken"));
        }





    }
}
