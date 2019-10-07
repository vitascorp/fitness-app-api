using FitnessApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Data
{
    public class TrainingExerciseTitlesRepository : ITrainingExerciseTitlesRepository
    {
        private readonly FitnessAppDbContext _context;

        public TrainingExerciseTitlesRepository(FitnessAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TrainingExerciseTitle>> GetTrainingExerciseTitles()
        {
            return await _context.TrainingExerciseTitles.ToArrayAsync();
        }

        public async Task<TrainingExerciseTitle> GetTrainingExerciseTitle(int trainingExerciseTitleId)
        {
            return await _context.TrainingExerciseTitles.FirstOrDefaultAsync(e => e.Id == trainingExerciseTitleId);
        }

        public async Task<TrainingExerciseTitle> SaveTrainingExerciseTitle(TrainingExerciseTitle trainingExerciseTitle)
        {
            if (!trainingExerciseTitle.Id.HasValue)
                _context.TrainingExerciseTitles.Add(trainingExerciseTitle);
            else
                _context.TrainingExerciseTitles.Update(trainingExerciseTitle);

            await _context.SaveChangesAsync();

            return trainingExerciseTitle;            
        }

        public async Task DeleteTrainingExerciseTitle(int trainingExerciseTitleId)
        {
            var trainingExerciseTitle = await _context.TrainingExerciseTitles.FirstOrDefaultAsync(e => e.Id == trainingExerciseTitleId);
            _context.Remove(trainingExerciseTitle);

            await _context.SaveChangesAsync();
        }
    }
}
