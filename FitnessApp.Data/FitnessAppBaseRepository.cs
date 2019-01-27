using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Data
{
    public abstract class FitnessAppBaseRepository
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        public FitnessAppBaseRepository(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        protected FitnessAppDbContext GetContext()
        {
            var connectionString = _connectionStringProvider.GetConnectionString();

            var options = new DbContextOptionsBuilder<FitnessAppDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new FitnessAppDbContext(options);
        }
    }
}
