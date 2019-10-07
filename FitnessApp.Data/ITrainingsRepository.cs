using FitnessApp.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Data
{
    public interface ITrainingsRepository
    {
        Task<IEnumerable<Training>> GetTrainings();

        Task<Training> GetFullTraining(int trainingId);

        Task<Training> SaveTraining(Training training);

        Task DeleteTraining(int trainingId);
    }
}
