using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Api.Models;
using FitnessApp.Data;

namespace FitnessApp.Api.Services
{
    public class MeasuresService : IMeasuresService
    {
        private readonly IMeasuresRepository _measuresRepository;

        public MeasuresService(IMeasuresRepository measuresRepository)
        {
            _measuresRepository = measuresRepository;
        }

        public async Task<IEnumerable<Measure>> GetMeasures()
        {
            var measures = await _measuresRepository.GetMeasures();
            return measures.Select(e => new Measure { Id = e.Id, Name = e.Name, ShortName = e.ShortName, KgCoef = e.KgCoef });
        }

        public async Task<Measure> GetMeasure(int measureId)
        {
            var measure = await _measuresRepository.GetMeasure(measureId);
            return new Measure { Id = measure.Id, Name = measure.Name, ShortName = measure.ShortName, KgCoef = measure.KgCoef };
        }

        public async Task<Measure> SaveMeasure(Measure measure)
        {
            var entity = new Data.Models.Measure { Id = measure.Id, Name = measure.Name, ShortName = measure.ShortName, KgCoef = measure.KgCoef };
            entity = await _measuresRepository.SaveMeasure(entity);

            return new Measure { Id = measure.Id, Name = measure.Name, ShortName = measure.ShortName, KgCoef = measure.KgCoef };
        }

        public async Task DeleteMeasure(int measureId)
        {
            await _measuresRepository.DeleteMeasure(measureId);
        }
    }
}
