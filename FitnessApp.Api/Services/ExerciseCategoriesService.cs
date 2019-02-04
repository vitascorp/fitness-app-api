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

        public async Task<ExerciseCategory> GetExerciseCategory(int categoryId)
        {
            var category = await _exerciseCategoriesRepository.GetExerciseCategory(categoryId);
            return new ExerciseCategory { Id = category.Id, Name = category.Name };
        }

        public async Task<ExerciseCategory> SaveExerciseCategory(ExerciseCategory category)
        {
            var entity = new Data.Models.ExerciseCategory { Id = category.Id, Name = category.Name };
            entity = await _exerciseCategoriesRepository.SaveExerciseCategory(entity);

            return new ExerciseCategory { Id = category.Id, Name = category.Name };
        }

        public async Task DeleteExerciseCategory(int categoryId)
        {
            await _exerciseCategoriesRepository.DeleteExerciseCategory(categoryId);
        }
    }
}
