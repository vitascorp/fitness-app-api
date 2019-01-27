using FitnessApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FitnessApp.Api
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FitnessAppDbContext>
    {
        public FitnessAppDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<FitnessAppDbContext>();
            var connection = configuration.GetConnectionString("FitnessAppDb");

            builder.UseSqlServer(connection);

            return new FitnessAppDbContext(builder.Options);
        }
    }
}
