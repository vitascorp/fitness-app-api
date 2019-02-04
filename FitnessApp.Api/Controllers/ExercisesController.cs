using System.Collections.Generic;
using System.Linq;
using FitnessApp.Api.Models;
using FitnessApp.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Api.Controllers
{
    [Route("api/exercises")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExercisesService _exercisesService;

        public ExercisesController(IExercisesService exerciseCsService)
        {
            _exercisesService = exerciseCsService;
        }

        // GET api/exercises
        [HttpGet, Route("")]
        public ActionResult<IEnumerable<Exercise>> Get()
        {
            var task = _exercisesService.GetExercises();
            task.Wait();

            return task.Result.ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Exercise> Get(int id)
        {
            var task = _exercisesService.GetExercise(id);
            task.Wait();

            return task.Result;
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Exercise> Post([FromBody] Exercise exercise)
        {
            var task = _exercisesService.SaveExercise(exercise);
            task.Wait();

            return task.Result;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var task = _exercisesService.DeleteExercise(id);
            task.Wait();
        }
    }
}
