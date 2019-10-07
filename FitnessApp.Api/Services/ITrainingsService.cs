using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessApp.Api.Models;

namespace FitnessApp.Api.Services
{
    public interface ITrainingsService
    {
        Task<IEnumerable<Training>> GetTrainigs();

        Task<Training> GetTraining(int trainingId);

        Task<Training> SaveTraining(Training training);

        Task DeleteTraining(int trainingId);

        Task<TrainingCardio> SaveTrainingCardio(int trainingId, TrainingCardio trainingCardio);

        Task DeleteTrainingCardio(int trainingCardioId);

        Task<TrainingExercise> SaveTrainingExercise(int trainingId, TrainingExercise trainingExercise);

        Task DeleteTrainingExercise(int trainingExcerciseId);

        Task<TrainingExerciseAttempt> SaveTrainingExerciseAttempt(int trainingExerciseId, TrainingExerciseAttempt trainingExerciseAttempt);

        Task DeleteTrainingExerciseAttempt(int trainingExerciseAttemptId);
    }
}
