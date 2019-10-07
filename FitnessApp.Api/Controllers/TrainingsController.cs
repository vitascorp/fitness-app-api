using System.Collections.Generic;
using System.Linq;
using FitnessApp.Api.Models;
using FitnessApp.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Api.Controllers
{
    [Route("api/trainings")]
    [ApiController]
    public class TrainingsController : ControllerBase
    {
        private readonly ITrainingsService _trainingsService;

        public TrainingsController(ITrainingsService trainingsService)
        {
            _trainingsService = trainingsService;
        }

        [HttpGet, Route("")]
        public ActionResult<IEnumerable<Training>> GetTrainigs()
        {
            var task = _trainingsService.GetTrainigs();
            task.Wait();

            return task.Result.ToArray();
        }

        [HttpGet("{trainingId}")]
        public ActionResult<Training> GetTraining(int trainingId)
        {
            var task = _trainingsService.GetTraining(trainingId);
            task.Wait();

            return task.Result;
        }

        [HttpPost]
        public ActionResult<Training> SaveTraining([FromBody] Training training)
        {
            var saveTask = _trainingsService.SaveTraining(training);
            saveTask.Wait();

            var getTask = _trainingsService.GetTraining(saveTask.Result.Id.Value);
            getTask.Wait();

            return getTask.Result;
        }

        [HttpDelete("{trainingId}")]
        public void DeleteTraining(int trainingId)
        {
            var task = _trainingsService.DeleteTraining(trainingId);
            task.Wait();
        }

        [HttpPost("{trainingId}/cardio")]
        public ActionResult<TrainingCardio> SaveTrainingCardio(int trainingId, [FromBody] TrainingCardio trainingCardio)
        {
            var task = _trainingsService.SaveTrainingCardio(trainingId, trainingCardio);
            task.Wait();

            return task.Result;
        }

        [HttpDelete("cardio/{trainingCardioId}")]
        public void DeleteTrainingCardio(int trainingCardioId)
        {
            var task = _trainingsService.DeleteTrainingCardio(trainingCardioId);
            task.Wait();
        }

        [HttpPost("{trainingId}/exercises")]
        public ActionResult<TrainingExercise> SaveTrainingExercise(int trainingId, [FromBody] TrainingExercise trainingExercise)
        {
            var task = _trainingsService.SaveTrainingExercise(trainingId, trainingExercise);
            task.Wait();

            return task.Result;
        }

        [HttpDelete("exercises/{trainingExerciseId}")]
        public void DeleteTrainingExercise(int trainingExerciseId)
        {
            var task = _trainingsService.DeleteTrainingExercise(trainingExerciseId);
            task.Wait();
        }

        [HttpPost("exercises/{trainingExerciseId}/attempts")]
        public ActionResult<TrainingExerciseAttempt> SaveTrainingExerciseAttempt(int trainingExerciseId, [FromBody] TrainingExerciseAttempt trainingExerciseAttempt)
        {
            var task = _trainingsService.SaveTrainingExerciseAttempt(trainingExerciseId, trainingExerciseAttempt);
            task.Wait();

            return task.Result;
        }

        [HttpDelete("exercises/attempts/{trainingExerciseAttemptId}")]
        public void DeleteTrainingExerciseAttempt(int trainingExerciseAttemptId)
        {
            var task = _trainingsService.DeleteTrainingExerciseAttempt(trainingExerciseAttemptId);
            task.Wait();
        }
    }
}
