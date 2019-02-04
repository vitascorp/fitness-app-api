using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessApp.Api.Models;

namespace FitnessApp.Api.Services
{
    public interface IExercisesService
    {
        Task<IEnumerable<Exercise>> GetExercises();

        Task<Exercise> GetExercise(int exerciseId);

        Task<Exercise> SaveExercise(Exercise exercise);

        Task DeleteExercise(int exerciseId);
    }
}
