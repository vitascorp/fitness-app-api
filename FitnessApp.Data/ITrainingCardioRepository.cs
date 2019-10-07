using FitnessApp.Data.Models;
using System.Threading.Tasks;

namespace FitnessApp.Data
{
    public interface ITrainingCardioRepository
    {
        Task<TrainingCardio> GetTrainingCardio(int trainingCardioId);

        Task<TrainingCardio> SaveTrainingCardio(TrainingCardio trainingCardio);

        Task DeleteTrainingCardio(int trainingCardioId);

    }
}
