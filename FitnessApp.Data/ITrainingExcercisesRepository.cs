using FitnessApp.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Data
{
    public interface ITrainingExercisesRepository
    {
        Task<IEnumerable<TrainingExercise>> GetTrainingExercises();

        Task<TrainingExercise> GetTrainingExercise(int trainingExerciseId);

        Task<TrainingExercise> AddTrainingExercise(TrainingExercise trainingExercise);

        Task<TrainingExercise> UpdateTrainingExercise(TrainingExercise trainingExercise);

        Task DeleteTrainingExercise(int trainingExerciseId);
    }
}
