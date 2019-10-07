namespace FitnessApp.Api.Models
{
    public class Measure
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public double KgCoef { get; set; }

        public ushort Order { get; set; }
    }
}
