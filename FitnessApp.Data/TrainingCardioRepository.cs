using FitnessApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FitnessApp.Data
{
    public class TrainingCardioRepository: ITrainingCardioRepository
    {
        private readonly FitnessAppDbContext _context;

        public TrainingCardioRepository(FitnessAppDbContext context)
        {
            _context = context;
        }

        public async Task<TrainingCardio> GetTrainingCardio(int trainingCardioId)
        {
            return await _context.TrainingCardios.FirstOrDefaultAsync(e => e.Id == trainingCardioId);
        }

        public async Task<TrainingCardio> SaveTrainingCardio(TrainingCardio trainingCardio)
        {
            if (!trainingCardio.Id.HasValue)
                _context.TrainingCardios.Add(trainingCardio);
            else
                _context.TrainingCardios.Update(trainingCardio);

            await _context.SaveChangesAsync();

            return trainingCardio;
        }

        public async Task DeleteTrainingCardio(int trainingCardioId)
        {
            var trainingCardio = await _context.TrainingCardios.FirstOrDefaultAsync(e => e.Id == trainingCardioId);
            _context.Remove(trainingCardio);

            await _context.SaveChangesAsync();
        }
    }
}
