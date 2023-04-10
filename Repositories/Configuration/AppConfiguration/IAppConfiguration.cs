using Microsoft.Extensions.Configuration;

namespace Repositories
{
    public interface IAppConfiguration
    {
        string ConnectionString { get; }
        string DBKey { get; }

        string GetConnectionString();

        IConfigurationSection GetConfigurationSection(string Key);
    }
}