using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.Data.Models
{
    public class TrainingCardio
    {
        [Key]
        public int? Id { get; set; }

        public int TrainingId { get; set; }

        [ForeignKey("TrainingId")]
        public Training Training { get; set; }

        public decimal Angle { get; set; }

        public decimal Speed { get; set; }

        public decimal Time { get; set; }
    }
}