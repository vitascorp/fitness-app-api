using FitnessApp.Api.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.Api
{
    public class FitnessAppApiResolver
    {
        public void Resolve(IServiceCollection services)
        {
            services.AddTransient<IExerciseCategoriesService, ExerciseCategoriesService>();
        }
    }
}
