using System;
using System.Collections.Generic;
using System.Text;

namespace TechTestHorus.Core.Services.Interfaces
{
    public interface IValidationService
    {
        bool IsValidEmail(string email);
        bool IsValidPassword(string password);
    }
}
