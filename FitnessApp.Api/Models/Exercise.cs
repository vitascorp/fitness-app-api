namespace FitnessApp.Api.Models
{
    public class Exercise
    {
        public int? Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }
    }
}
