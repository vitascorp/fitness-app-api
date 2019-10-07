using System.Collections.Generic;

namespace FitnessApp.Api.Models
{
    public class TrainingExercise
    {
        public int? Id { get; set; }

        public ushort Order { get; set; }

        public IEnumerable<TrainingExerciseTitle> Titles { get; set; }

        public IEnumerable<TrainingExerciseAttempt> Attempts { get; set; }
    }
}
