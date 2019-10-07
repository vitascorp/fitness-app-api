using FitnessApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Data
{
    public class TrainingsRepository : ITrainingsRepository
    {
        private readonly FitnessAppDbContext _context;

        public TrainingsRepository(FitnessAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Training>> GetTrainings()
        {
            return await _context.Trainings.Include(e => e.Category).ToArrayAsync();
        }

        public async Task<Training> GetFullTraining(int trainingId)
        {
            return await _context.Trainings
                .Where(e => e.Id == trainingId)
                .Include(e => e.Cardio)
                .Include(e => e.Exercises)
                .ThenInclude(e => e.Titles)
                .Include(e => e.Exercises)
                .ThenInclude(e => e.Attempts)
                .FirstOrDefaultAsync();
        }

        public async Task<Training> SaveTraining(Training training)
        {
            if (!training.Id.HasValue)
                _context.Trainings.Add(training);
            else
                _context.Trainings.Update(training);

            await _context.SaveChangesAsync();

            return training;            
        }

        public async Task DeleteTraining(int trainingId)
        {
            var training = await _context.Trainings.FirstOrDefaultAsync(e => e.Id == trainingId);
            _context.Remove(training);

            await _context.SaveChangesAsync();
        }
    }
}
