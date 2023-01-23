using System;
using System.Collections.Generic;
using System.Text;

namespace TechTestHorus.Core.Services.Interfaces
{
    public interface ISettingsService
    {
   
        string GetString<T>(string id);
        void SetString<T>(string id, string data);
        void DeleteItem(string id);
        bool GetBool<T>(string id);
        void SetBool<T>(string id, bool data);
    }
}
