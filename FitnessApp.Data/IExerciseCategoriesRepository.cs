using FitnessApp.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Data
{
    public interface IExerciseCategoriesRepository
    {
        Task<IEnumerable<ExerciseCategory>> GetExerciseCategories();
    }
}
