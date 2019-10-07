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
            services.AddTransient<IExercisesRepository, ExercisesRepository>();
            services.AddTransient<ITrainingsRepository, TrainingsRepository>();
            services.AddTransient<IMeasuresRepository, MeasuresRepository>();
            services.AddTransient<ITrainingCardioRepository, TrainingCardioRepository>();
            services.AddTransient<ITrainingExercisesRepository, TrainingExercisesRepository>();
            services.AddTransient<ITrainingExerciseAttemptsRepository, TrainingExerciseAttemptsRepository>();
        }
    }
}
