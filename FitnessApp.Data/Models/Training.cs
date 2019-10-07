using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.Data.Models
{
    public class Training
    {
        [Key]
        public int? Id { get; set; }

        public DateTime Date { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public decimal Weight { get; set; }

        public TrainingCardio Cardio { get; set; }

        public ICollection<TrainingExercise> Exercises { get; set; }
    }
}
