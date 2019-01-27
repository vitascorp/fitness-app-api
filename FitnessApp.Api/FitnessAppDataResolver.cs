using FitnessApp.Data;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.Api
{
    public class FitnessAppDataResolver
    {
        public void Resolve(IServiceCollection services)
        {
            services.AddTransient<IConnectionStringProvider, ConnectionStringProvider>();
            services.AddTransient<IExerciseCategoriesRepository, ExerciseCategoriesRepository>();
        }
    }
}
