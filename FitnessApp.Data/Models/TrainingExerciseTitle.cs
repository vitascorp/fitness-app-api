using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.Data.Models
{
    public class TrainingExerciseTitle
    {
        [Key]
        public int? Id { get; set; }

        public int TrainingExerciseId { get; set; }

        [ForeignKey("TrainingExerciseId")]
        public TrainingExercise TrainingExercise { get; set; }

        public int ExerciseId { get; set; }

        [ForeignKey("ExcerciseId")]
        public Exercise Excercise { get; set; }

        public int MeasureId { get; set; }

        [ForeignKey("MeasureId")]
        public Measure Measure { get; set; }

        [Range(0, 100)]
        public ushort SupersetOrder { get; set; }
    }
}