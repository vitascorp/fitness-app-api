using Microsoft.Extensions.Configuration;
using System.IO;

namespace FitnessApp.Data
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        public string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("FitnessAppDb");

            return connectionString;
        }
    }
}
