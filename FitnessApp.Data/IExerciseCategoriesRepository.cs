using FitnessApp.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Data
{
    public interface IExerciseCategoriesRepository
    {
        Task<IEnumerable<ExerciseCategory>> GetExerciseCategories();

        Task<ExerciseCategory> GetExerciseCategory(int categoryId);

        Task<ExerciseCategory> SaveExerciseCategory(ExerciseCategory category);

        Task DeleteExerciseCategory(int categoryId);
    }
}
