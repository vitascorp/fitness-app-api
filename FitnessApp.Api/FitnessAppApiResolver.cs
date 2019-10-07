using FitnessApp.Api.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.Api
{
    public class FitnessAppApiResolver
    {
        public void Resolve(IServiceCollection services)
        {
            services.AddTransient<IExerciseCategoriesService, ExerciseCategoriesService>();

            services.AddTransient<IMeasuresService, MeasuresService>();
            services.AddTransient<ITrainingsService, TrainingService>();
            services.AddTransient<IExercisesService, ExercisesService>();
        }
    }
}
