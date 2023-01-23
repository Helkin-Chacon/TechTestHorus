using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TechTestHorus.Core.Services.Interfaces;

namespace TechTestHorus.Core.Services
{
    public class ValidationService : IValidationService
    {
        public bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^([\w\.\-]{3,})@([\w\-]{3,})((\.(\w){2,7})+)$");

            return !string.IsNullOrWhiteSpace(email) && emailRegex.IsMatch(email);
        }

        public bool IsValidPassword(string password)
        {
            var score = password.Length;
            return score > 8;

        }
    }
}
