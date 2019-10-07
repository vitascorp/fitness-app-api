using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Data.Models
{
    public class Measure
    {
        [Key]
        public int? Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(2)]
        public string ShortName { get; set; }

        public double KgCoef { get; set; }

        public ushort Order { get; set; }
    }
}
