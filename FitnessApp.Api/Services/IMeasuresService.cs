using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessApp.Api.Models;

namespace FitnessApp.Api.Services
{
    public interface IMeasuresService
    {
        Task<IEnumerable<Measure>> GetMeasures();

        Task<Measure> GetMeasure(int measureId);

        Task<Measure> SaveMeasure(Measure measure);

        Task DeleteMeasure(int measureId);
    }
}
