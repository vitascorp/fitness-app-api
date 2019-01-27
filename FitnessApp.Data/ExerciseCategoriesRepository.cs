using FitnessApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Data
{
    public class ExerciseCategoriesRepository : IExerciseCategoriesRepository
    {
        private readonly FitnessAppDbContext _context;

        public ExerciseCategoriesRepository(FitnessAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExerciseCategory>> GetExerciseCategories()
        {
            return await _context.ExerciseCategories.ToArrayAsync();
        }
    }
}
