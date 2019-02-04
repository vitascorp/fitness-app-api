using System.Collections.Generic;
using System.Linq;
using FitnessApp.Api.Models;
using FitnessApp.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IExerciseCategoriesService _exerciseCategoriesService;

        public CategoriesController(IExerciseCategoriesService exerciseCategoriesService)
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
        public ActionResult<ExerciseCategory> Get(int id)
        {
            var task = _exerciseCategoriesService.GetExerciseCategory(id);
            task.Wait();

            return task.Result;
        }

        // POST api/values
        [HttpPost]
        public ActionResult<ExerciseCategory> Post([FromBody] ExerciseCategory category)
        {
            var task = _exerciseCategoriesService.SaveExerciseCategory(category);
            task.Wait();

            return task.Result;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var task = _exerciseCategoriesService.DeleteExerciseCategory(id);
            task.Wait();
        }
    }
}
