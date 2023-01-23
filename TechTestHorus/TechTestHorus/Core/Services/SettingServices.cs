using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using TechTestHorus.Core.Services.Interfaces;

namespace TechTestHorus.Core.Services
{
    public class SettingServices : ISettingsService
    {
        private readonly ISettings _appSettings;
        public SettingServices()
        {
            _appSettings = CrossSettings.Current;
        }
        /// <summary>
        ///     Remove an item with a given id from local settings storage
        /// </summary>
        /// <param name="id">Id of the setting to be removed</param>
        public void DeleteItem(string id)
        {
            _appSettings.Remove(id);
        }
        /// <summary>
        /// Get a string with a given id from the local settings storage
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetString<T>(string id)
        {
            return _appSettings.GetValueOrDefault(id, string.Empty);
        }
        public void SetString<T>(string id, string data)
        {
            _appSettings.AddOrUpdateValue(id, data);
        }
        public bool GetBool<T>(string id)
        {
            return _appSettings.GetValueOrDefault(id, false);
        }

        /// <summary>
        ///     Store an item with a given id from the local storage
        /// </summary>
        /// <typeparam name="T">
        ///     Type of the item to be stored ( Int32, Int64)
        /// </typeparam>
        /// <param name="id">id of the setting to be stored</param>
        /// <param name="data">Value of the setting to be stored</param>
        public void SetBool<T>(string id, bool data)
        {
            _appSettings.AddOrUpdateValue(id, data);
        }
    }
}
