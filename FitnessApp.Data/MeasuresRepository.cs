using FitnessApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Data
{
    public class MeasuresRepository : IMeasuresRepository
    {
        private readonly FitnessAppDbContext _context;

        public MeasuresRepository(FitnessAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Measure>> GetMeasures()
        {
            return await _context.Measures.ToArrayAsync();
        }

        public async Task<Measure> GetMeasure(int measureId)
        {
            return await _context.Measures.FirstOrDefaultAsync(e => e.Id == measureId);
        }

        public async Task<Measure> SaveMeasure(Measure measure)
        {
            if (!measure.Id.HasValue)
                _context.Measures.Add(measure);
            else
                _context.Measures.Update(measure);

            await _context.SaveChangesAsync();

            return measure;            
        }

        public async Task DeleteMeasure(int measureId)
        {
            var measure = await _context.Measures.FirstOrDefaultAsync(e => e.Id == measureId);
            _context.Remove(measure);

            await _context.SaveChangesAsync();
        }
    }
}
