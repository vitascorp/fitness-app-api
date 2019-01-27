using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessApp.Api.Models;

namespace FitnessApp.Api.Services
{
    public interface IExerciseCategoriesService
    {
        Task<IEnumerable<ExerciseCategory>> GetExerciseCategories();
    }
}
