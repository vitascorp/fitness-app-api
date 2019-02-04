using FitnessApp.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Data
{
    public interface IExercisesRepository
    {
        Task<IEnumerable<Exercise>> GetExercises();

        Task<Exercise> GetExercise(int exerciseId);

        Task<Exercise> SaveExercise(Exercise exercise);

        Task DeleteExercise(int exerciseId);
    }
}
