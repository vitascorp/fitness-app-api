using FitnessApp.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Data
{
    public interface IMeasuresRepository
    {
        Task<IEnumerable<Measure>> GetMeasures();

        Task<Measure> GetMeasure(int measureId);

        Task<Measure> SaveMeasure(Measure measure);

        Task DeleteMeasure(int measureId);
    }
}
