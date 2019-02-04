using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessApp.Api.Models;

namespace FitnessApp.Api.Services
{
    public interface IExerciseCategoriesService
    {
        Task<IEnumerable<ExerciseCategory>> GetExerciseCategories();

        Task<ExerciseCategory> GetExerciseCategory(int categoryId);

        Task<ExerciseCategory> SaveExerciseCategory(ExerciseCategory category);

        Task DeleteExerciseCategory(int categoryId);
    }
}
