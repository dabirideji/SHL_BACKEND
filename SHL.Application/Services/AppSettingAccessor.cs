using Microsoft.Extensions.Configuration;
using SHL.Application.Interfaces;

namespace SHL.Application.Services
{
    public class AppSettingAccessor : IAppSettingAccessor
    {
        private readonly IConfiguration _config;

        public AppSettingAccessor(IConfiguration config)
        {
            _config = config;
        }
        public IConfigurationSection GetSection(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("invalid key");
            return _config.GetSection(key);
        }

        public string GetValue(string key, string subkey)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("invalid key");
            var section = _config.GetSection(key);
            var valueToReturn = section.GetSection(subkey).Value;
            return valueToReturn;
        }
    }
}