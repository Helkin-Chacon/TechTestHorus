using Flurl;
using DryIoc;
using Flurl.Http;
using System;

using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTestHorus.Core.Constants;
using TechTestHorus.Core.Models;
using TechTestHorus.Core.Models.WebApi.Dashboard;
using TechTestHorus.Core.Services;
using TechTestHorus.Modules.Repositories.Interfaces;
using Error = TechTestHorus.Core.Models.Error;
using TechTestHorus.Core.Models.WebApi.Login;
using Xamarin.Essentials;
using TechTestHorus.Core.Services.Interfaces;

namespace TechTestHorus.Modules.Repositories
{
    public class DashboardRepository : WebApiService, IDashboardRepository
    {
        public DashboardRepository(ISettingsService settingsService) : base(settingsService)
        {
        }

        public List<Error> GetErrors => throw new NotImplementedException();

        public async Task<List<ChallengeListApiResponse>> GetChallenges()
        {
            Errors.Clear();
            
            try
            {


                var token = await GetToken();
                var response = await ApiConstants.ApiBaseUrl
                     .AppendPathSegment(ApiConstants.EndPointChallenges)
                     .WithTimeout(30)
                     .WithHeader("Authorization", token)
                     .GetJsonAsync<List<ChallengeListApiResponse>>();

                return response;

            }
            catch (Exception e)
            {
                return null;               
            }
        }

    }
}
