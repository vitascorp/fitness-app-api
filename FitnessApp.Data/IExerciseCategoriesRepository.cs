using FitnessApp.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Data
{
    public interface IExerciseCategoriesRepository
    {
        Task<IEnumerable<Category>> GetExerciseCategories();

        Task<Category> GetExerciseCategory(int categoryId);

        Task<Category> SaveExerciseCategory(Category category);

        Task DeleteExerciseCategory(int categoryId);
    }
}
