using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.Data.Models
{
    public class TrainingExerciseAttempt
    {
        [Key]
        public int? Id { get; set; }

        public int TrainingExerciseId { get; set; }

        [ForeignKey("TrainingExerciseId")]
        public TrainingExercise TrainingExercise { get; set; }

        [Range(0, 1000)]
        public decimal Weight { get; set; }

        [Range(0, 1000)]
        public ushort Amount { get; set; }

        [Range(0, 100)]
        public ushort Order { get; set; }

        [Range(0, 100)]
        public ushort SupersetOrder { get; set; }
    }
}
