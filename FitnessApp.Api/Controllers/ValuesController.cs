using System.Collections.Generic;
using System.Linq;
using FitnessApp.Api.Models;
using FitnessApp.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Api.Controllers
{
    [Route("api/exercise-categories")]
    [ApiController]
    public class ExerciseCategoriesController : ControllerBase
    {
        private readonly IExerciseCategoriesService _exerciseCategoriesService;

        public ExerciseCategoriesController(IExerciseCategoriesService exerciseCategoriesService)
        {
            _exerciseCategoriesService = exerciseCategoriesService;
        }

        // GET api/exercise-categories
        [HttpGet, Route("")]
        public ActionResult<IEnumerable<ExerciseCategory>> Get()
        {
            var task = _exerciseCategoriesService.GetExerciseCategories();
            task.Wait();

            return task.Result.ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
