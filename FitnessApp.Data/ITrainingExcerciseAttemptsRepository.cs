using FitnessApp.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Data
{
    public interface ITrainingExerciseAttemptsRepository
    {
        Task<IEnumerable<TrainingExerciseAttempt>> GetTrainingExerciseAttempts();

        Task<TrainingExerciseAttempt> GetTrainingExerciseAttempt(int trainingExerciseAttemptId);

        Task<TrainingExerciseAttempt> SaveTrainingExerciseAttempt(TrainingExerciseAttempt trainingExerciseAttempt);

        Task DeleteTrainingExerciseAttempt(int trainingExerciseAttemptId);
    }
}
