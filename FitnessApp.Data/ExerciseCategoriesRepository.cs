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

        public async Task<IEnumerable<Category>> GetExerciseCategories()
        {
            return await _context.Categories.ToArrayAsync();
        }

        public async Task<Category> GetExerciseCategory(int categoryId)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
        }

        public async Task<Category> SaveExerciseCategory(Category category)
        {
            if (!category.Id.HasValue)
                _context.Categories.Add(category);
            else
                _context.Categories.Update(category);

            await _context.SaveChangesAsync();

            return category;            
        }

        public async Task DeleteExerciseCategory(int categoryId)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
            _context.Remove(category);

            await _context.SaveChangesAsync();
        }
    }
}
