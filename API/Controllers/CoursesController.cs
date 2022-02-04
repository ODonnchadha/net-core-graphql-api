using API.Models;
using API.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository repository;
        public CoursesController(ICourseRepository repository) => this.repository = repository;

        [HttpGet]
        public IActionResult GetAll()
        {
            var allCourses = repository.GetAllCourses();
            return Ok(allCourses);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = repository.GetCourseById(id);
            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Course course)
        {
            var addedCourse = repository.AddCourse(course);
            return Ok(addedCourse);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Course course)
        {
            var updatedCourse = repository.UpdateCourse(id, course);
            return Ok(updatedCourse);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repository.DeleteCourse(id);
            return Ok();
        }
    }
}
