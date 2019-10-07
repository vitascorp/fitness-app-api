using FitnessApp.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Data
{
    public interface ITrainingExerciseTitlesRepository
    {
        Task<IEnumerable<TrainingExerciseTitle>> GetTrainingExerciseTitles();

        Task<TrainingExerciseTitle> GetTrainingExerciseTitle(int trainingExerciseTitleId);

        Task<TrainingExerciseTitle> SaveTrainingExerciseTitle(TrainingExerciseTitle trainingExerciseTitle);

        Task DeleteTrainingExerciseTitle(int trainingExerciseTitleId);
    }
}
