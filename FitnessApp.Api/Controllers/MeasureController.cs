using System.Collections.Generic;
using System.Linq;
using FitnessApp.Api.Models;
using FitnessApp.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Api.Controllers
{
    [Route("api/measures")]
    [ApiController]
    public class MeasuresController : ControllerBase
    {
        private readonly IMeasuresService _measuresService;

        public MeasuresController(IMeasuresService measureCsService)
        {
            _measuresService = measureCsService;
        }

        [HttpGet, Route("")]
        public ActionResult<IEnumerable<Measure>> Get()
        {
            var task = _measuresService.GetMeasures();
            task.Wait();

            return task.Result.ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<Measure> Get(int id)
        {
            var task = _measuresService.GetMeasure(id);
            task.Wait();

            return task.Result;
        }

        [HttpPost]
        public ActionResult<Measure> Post([FromBody] Measure measure)
        {
            var task = _measuresService.SaveMeasure(measure);
            task.Wait();

            return task.Result;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var task = _measuresService.DeleteMeasure(id);
            task.Wait();
        }
    }
}
