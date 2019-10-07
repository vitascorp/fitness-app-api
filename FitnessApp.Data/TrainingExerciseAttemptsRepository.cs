using FitnessApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Data
{
    public class TrainingExerciseAttemptsRepository : ITrainingExerciseAttemptsRepository
    {
        private readonly FitnessAppDbContext _context;

        public TrainingExerciseAttemptsRepository(FitnessAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TrainingExerciseAttempt>> GetTrainingExerciseAttempts()
        {
            return await _context.TrainingExerciseAttempts.ToArrayAsync();
        }

        public async Task<TrainingExerciseAttempt> GetTrainingExerciseAttempt(int trainingExerciseAttemptId)
        {
            return await _context.TrainingExerciseAttempts.FirstOrDefaultAsync(e => e.Id == trainingExerciseAttemptId);
        }

        public async Task<TrainingExerciseAttempt> SaveTrainingExerciseAttempt(TrainingExerciseAttempt trainingExerciseAttempt)
        {
            if (!trainingExerciseAttempt.Id.HasValue)
                _context.TrainingExerciseAttempts.Add(trainingExerciseAttempt);
            else
                _context.TrainingExerciseAttempts.Update(trainingExerciseAttempt);

            await _context.SaveChangesAsync();

            return trainingExerciseAttempt;            
        }

        public async Task DeleteTrainingExerciseAttempt(int trainingExerciseAttemptId)
        {
            var trainingExerciseAttempt = await _context.TrainingExerciseAttempts.FirstOrDefaultAsync(e => e.Id == trainingExerciseAttemptId);
            _context.Remove(trainingExerciseAttempt);

            await _context.SaveChangesAsync();
        }
    }
}
