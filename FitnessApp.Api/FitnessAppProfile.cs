using AutoMapper;
using FitnessApp.Api.Models;

namespace FitnessApp.Api
{
    public class FitnessAppProfile : Profile
    {
        public FitnessAppProfile()
        {
            CreateMap<Training, Data.Models.Training>()
                .ReverseMap()
                .ForPath(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name));

            CreateMap<TrainingCardio, Data.Models.TrainingCardio>().ReverseMap();
            CreateMap<TrainingExercise, Data.Models.TrainingExercise>().ReverseMap();
            CreateMap<TrainingExerciseTitle, Data.Models.TrainingExerciseTitle>().ReverseMap();
            CreateMap<TrainingExerciseAttempt, Data.Models.TrainingExerciseAttempt>().ReverseMap();
        }
    }
}
