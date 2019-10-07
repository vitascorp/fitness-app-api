using System;
using System.Collections.Generic;

namespace FitnessApp.Api.Models
{
    public class Training
    {
        public int? Id { get; set; }

        public DateTime Date { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public decimal Weight { get; set; }

        public TrainingCardio Cardio {get;set;}

        public IEnumerable<TrainingExercise> Exercises { get; set; }
    }
}
