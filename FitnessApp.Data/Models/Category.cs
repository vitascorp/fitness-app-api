using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Data.Models
{
    public class Category
    {
        [Key]
        public int? Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public ushort Order { get; set; }
    }
}
