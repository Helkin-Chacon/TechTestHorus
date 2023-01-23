using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTestHorus.Core.Models;
using TechTestHorus.Core.Models.WebApi.Dashboard;

namespace TechTestHorus.Modules.Repositories.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<ChallengeListApiResponse>> GetChallenges();
        List<Error> GetErrors { get; }

    }
}
