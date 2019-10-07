using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.Data.Models
{
    public class TrainingExercise
    {
        [Key]
        public int? Id { get; set; }

        public int TrainingId { get; set; }

        [ForeignKey("TrainingId")]
        public Training Training { get; set; }

        [Range(0, 100)]
        public ushort Order { get; set; }

        public ICollection<TrainingExerciseTitle> Titles { get; set; }

        public ICollection<TrainingExerciseAttempt> Attempts { get; set; }
    }
}
