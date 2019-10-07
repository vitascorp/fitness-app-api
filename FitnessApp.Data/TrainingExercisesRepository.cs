
using FitnessApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Data
{
    public class TrainingExercisesRepository : ITrainingExercisesRepository
    {
        private readonly FitnessAppDbContext _context;

        public TrainingExercisesRepository(FitnessAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TrainingExercise>> GetTrainingExercises()
        {
            return await _context.TrainingExercises.ToArrayAsync();
        }

        public async Task<TrainingExercise> GetTrainingExercise(int trainingExerciseId)
        {
            return await _context.TrainingExercises.FirstOrDefaultAsync(e => e.Id == trainingExerciseId);
        }

        public async Task<TrainingExercise> AddTrainingExercise(TrainingExercise trainingExercise)
        {
           _context.TrainingExercises.Add(trainingExercise);
            await _context.SaveChangesAsync();

            return trainingExercise;
        }

        public async Task<TrainingExercise> UpdateTrainingExercise(TrainingExercise trainingExercise)
        {
            var updateTrainingExercise = await _context.TrainingExercises
                .Include(e => e.Titles)
                .Include(e => e.Attempts)
                .FirstOrDefaultAsync(e => e.Id == trainingExercise.Id);

            UpdateTitles(trainingExercise, updateTrainingExercise);
            UpdateAttempts(trainingExercise, updateTrainingExercise);

            _context.TrainingExercises.Update(updateTrainingExercise);
            await _context.SaveChangesAsync();

            return trainingExercise;            
        }

        public async Task DeleteTrainingExercise(int trainingExerciseId)
        {
            var trainingExercise = await _context.TrainingExercises.FirstOrDefaultAsync(e => e.Id == trainingExerciseId);
            _context.Remove(trainingExercise);

            await _context.SaveChangesAsync();
        }

        private void UpdateTitles(TrainingExercise trainingExercise, TrainingExercise updateTrainingExercise)
        {
            var addTitles = trainingExercise.Titles.Where(t => !t.Id.HasValue).ToArray();
            foreach (var addTitle in addTitles)
                updateTrainingExercise.Titles.Add(addTitle);

            var updateTitles = trainingExercise.Titles.Where(t => t.Id.HasValue).ToArray();
            foreach (var updateTitle in updateTitles)
            {
                var currUpdateTitle = trainingExercise.Titles.Single(t => t.Id == updateTitle.Id);
                currUpdateTitle.ExerciseId = updateTitle.ExerciseId;
                currUpdateTitle.MeasureId = updateTitle.MeasureId;
                currUpdateTitle.SupersetOrder = updateTitle.SupersetOrder;
            }

            var titleIds = trainingExercise.Titles.Select(t => t.Id).ToArray();
            var removeTitles = updateTrainingExercise.Titles.Where(t => !titleIds.Contains(t.Id)).ToArray();
            foreach (var removeTitle in removeTitles)
                updateTrainingExercise.Titles.Remove(removeTitle);
        }

        private void UpdateAttempts(TrainingExercise trainingExercise, TrainingExercise updateTrainingExercise)
        {
            var addAttempts = trainingExercise.Attempts.Where(t => !t.Id.HasValue).ToArray();
            foreach (var addAttempt in addAttempts)
                updateTrainingExercise.Attempts.Add(addAttempt);

            var updateAttempts = trainingExercise.Attempts.Where(t => t.Id.HasValue).ToArray();
            foreach (var updateTitle in updateAttempts)
            {
                var currUpdateAttempt = trainingExercise.Attempts.Single(t => t.Id == updateTitle.Id);
                currUpdateAttempt.Weight = updateTitle.Weight;
                currUpdateAttempt.Amount = updateTitle.Amount;
                currUpdateAttempt.Order = updateTitle.Order;
                currUpdateAttempt.SupersetOrder = updateTitle.SupersetOrder;
            }

            var attemptIds = trainingExercise.Attempts.Select(t => t.Id).ToArray();
            var removeAttempts = updateTrainingExercise.Attempts.Where(t => !attemptIds.Contains(t.Id)).ToArray();
            foreach (var removeAttempt in removeAttempts)
                updateTrainingExercise.Attempts.Remove(removeAttempt);
        }
    }
}
