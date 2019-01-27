using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Api.Models;
using FitnessApp.Data;

namespace FitnessApp.Api.Services
{
    public class ExerciseCategoriesService : IExerciseCategoriesService
    {
        private readonly IExerciseCategoriesRepository _exerciseCategoriesRepository;

        public ExerciseCategoriesService(IExerciseCategoriesRepository exerciseCategoriesRepository)
        {
            _exerciseCategoriesRepository = exerciseCategoriesRepository;
        }

        public async Task<IEnumerable<ExerciseCategory>> GetExerciseCategories()
        {
            var categories = await _exerciseCategoriesRepository.GetExerciseCategories();
            return categories.Select(category => new ExerciseCategory { Id = category.Id, Name = category.Name });
        }
    }
}
