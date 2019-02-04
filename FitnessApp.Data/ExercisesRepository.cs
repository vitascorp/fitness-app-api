using FitnessApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Data
{
    public class ExercisesRepository : IExercisesRepository
    {
        private readonly FitnessAppDbContext _context;

        public ExercisesRepository(FitnessAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Exercise>> GetExercises()
        {
            return await _context.Exercises.ToArrayAsync();
        }

        public async Task<Exercise> GetExercise(int exerciseId)
        {
            return await _context.Exercises.FirstOrDefaultAsync(e => e.Id == exerciseId);
        }

        public async Task<Exercise> SaveExercise(Exercise exercise)
        {
            if (!exercise.Id.HasValue)
                _context.Exercises.Add(exercise);
            else
                _context.Exercises.Update(exercise);

            await _context.SaveChangesAsync();

            return exercise;            
        }

        public async Task DeleteExercise(int exerciseId)
        {
            var exercise = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == exerciseId);
            _context.Remove(exercise);

            await _context.SaveChangesAsync();
        }
    }
}
