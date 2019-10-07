namespace FitnessApp.Api.Models
{
    public class TrainingExerciseAttempt
    {
        public int? Id { get; set; }

        public ushort Weight { get; set; } 

        public ushort Amount { get; set; }

        public ushort Order { get; set; }

        public ushort SupersetOrder { get; set; }
    }
}
