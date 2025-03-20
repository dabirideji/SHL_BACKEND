using Microsoft.Extensions.Configuration;

namespace SHL.Application.Interfaces
{
    public interface IAppSettingAccessor
    {
        string GetValue(string key, string subkey);
        IConfigurationSection GetSection(string key);
    }
}