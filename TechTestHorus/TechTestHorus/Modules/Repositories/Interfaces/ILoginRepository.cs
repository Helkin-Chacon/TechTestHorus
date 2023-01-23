using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTestHorus.Core.Models;

namespace TechTestHorus.Modules.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        Task<bool> Login(string email = null, string password = null);
        List<Error> GetErrors { get; }

    }
}
