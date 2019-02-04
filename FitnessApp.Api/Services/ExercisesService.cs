using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Api.Models;
using FitnessApp.Data;

namespace FitnessApp.Api.Services
{
    public class ExercisesService : IExercisesService
    {
        private readonly IExercisesRepository _exercisesRepository;

        public ExercisesService(IExercisesRepository exercisesRepository)
        {
            _exercisesRepository = exercisesRepository;
        }

        public async Task<IEnumerable<Exercise>> GetExercises()
        {
            var exercises = await _exercisesRepository.GetExercises();
            return exercises.Select(e => new Exercise { Id = e.Id, CategoryId = e.CategoryId, Name = e.Name, Order = e.Order });
        }

        public async Task<Exercise> GetExercise(int exerciseId)
        {
            var exercise = await _exercisesRepository.GetExercise(exerciseId);
            return new Exercise { Id = exercise.Id, CategoryId = exercise.CategoryId, Name = exercise.Name, Order = exercise.Order };
        }

        public async Task<Exercise> SaveExercise(Exercise exercise)
        {
            var entity = new Data.Models.Exercise { Id = exercise.Id, CategoryId = exercise.CategoryId, Name = exercise.Name, Order = exercise.Order };
            entity = await _exercisesRepository.SaveExercise(entity);

            return new Exercise { Id = exercise.Id, CategoryId = exercise.CategoryId, Name = exercise.Name, Order= exercise.Order };
        }

        public async Task DeleteExercise(int exerciseId)
        {
            await _exercisesRepository.DeleteExercise(exerciseId);
        }
    }
}
