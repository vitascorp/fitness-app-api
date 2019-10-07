using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.Api.Models;
using FitnessApp.Data;

namespace FitnessApp.Api.Services
{
    public class TrainingService : ITrainingsService
    {
        private readonly ITrainingsRepository _trainingsRepository;
        private readonly ITrainingCardioRepository _trainingCardioRepository;
        private readonly ITrainingExercisesRepository _trainingExercisesRepository;
        private readonly ITrainingExerciseAttemptsRepository _trainingExerciseAttemptsRepository;

        private readonly IMapper _mapper;

        public TrainingService(
            ITrainingsRepository trainingsRepository,
            ITrainingCardioRepository trainingCardioRepository,
            ITrainingExercisesRepository trainingExercisesRepository, 
            ITrainingExerciseAttemptsRepository trainingExerciseAttemptsRepository,
            IMapper mapper)
        {
            _trainingsRepository = trainingsRepository;
            _trainingCardioRepository = trainingCardioRepository;
            _trainingExercisesRepository = trainingExercisesRepository;
            _trainingExerciseAttemptsRepository = trainingExerciseAttemptsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Training>> GetTrainigs()
        {
            var entities = await _trainingsRepository.GetTrainings();

            return entities.Select(_mapper.Map<Training>).ToArray();
        }

        public async Task<Training> GetTraining(int trainingId)
        {
            var entity = await _trainingsRepository.GetFullTraining(trainingId);

            return _mapper.Map<Training>(entity);
        }

        public async Task<Training> SaveTraining(Training training)
        {
            var entity = _mapper.Map<Data.Models.Training>(training);
            entity = await _trainingsRepository.SaveTraining(entity);

            return _mapper.Map<Training>(entity);
        }

        public async Task DeleteTraining(int trainingId)
        {
            await _trainingsRepository.DeleteTraining(trainingId);
        }

        public async Task<TrainingCardio> SaveTrainingCardio(int trainingId, TrainingCardio trainingCardio)
        {
            var entity = _mapper.Map<TrainingCardio, Data.Models.TrainingCardio>(
                trainingCardio,
                o => o.AfterMap((s, d) => d.TrainingId = trainingId)
            );

            entity = await _trainingCardioRepository.SaveTrainingCardio(entity);

            return _mapper.Map<TrainingCardio>(entity);
        }

        public async Task DeleteTrainingCardio(int trainingCardioId)
        {
            await _trainingCardioRepository.DeleteTrainingCardio(trainingCardioId);
        }

        public async Task<TrainingExercise> SaveTrainingExercise(int trainingId, TrainingExercise trainingExercise)
        {
            var entity = _mapper.Map<TrainingExercise, Data.Models.TrainingExercise>(trainingExercise, 
                o => o.AfterMap((s, d) => {
                    d.TrainingId = trainingId;
                })                
            );

            entity = !entity.Id.HasValue 
                ? await _trainingExercisesRepository.AddTrainingExercise(entity)
                : await _trainingExercisesRepository.UpdateTrainingExercise(entity);            

            return _mapper.Map<TrainingExercise>(entity);
        }

        public async Task DeleteTrainingExercise(int trainingExcerciseId)
        {
            await _trainingExercisesRepository.DeleteTrainingExercise(trainingExcerciseId);
        }

        public async Task<TrainingExerciseAttempt> SaveTrainingExerciseAttempt(int trainingExerciseId, TrainingExerciseAttempt trainingExerciseAttempt)
        {
            var entity = _mapper.Map<Data.Models.TrainingExerciseAttempt>(trainingExerciseAttempt);
            entity.TrainingExerciseId = trainingExerciseId;

            entity = await _trainingExerciseAttemptsRepository.SaveTrainingExerciseAttempt(entity);

            return _mapper.Map<TrainingExerciseAttempt>(entity);
        }

        public async Task DeleteTrainingExerciseAttempt(int trainingExerciseAttemptId)
        {
            await _trainingExerciseAttemptsRepository.DeleteTrainingExerciseAttempt(trainingExerciseAttemptId);
        }
    }
}
