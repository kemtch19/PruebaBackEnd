using Microsoft.AspNetCore.Mvc;
using Prueba.Models;
using Prueba.Services;

namespace Prueba.AddControllers
{
  [ApiController]
  [Route("api/courses")]

  public class CoursesController : ControllerBase
  {
    private readonly ICourseRepository _courseRepository;

    public CoursesController(ICourseRepository courseRepository)
    {
      _courseRepository = courseRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Course>> GetCourses()
    {
      try
      {
        return Ok(_courseRepository.GetAll());
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Error al traer todos los cursos: {ex.Message}");
      }
    }

    [HttpGet("{id}")]
    public IActionResult GetCourse(int id)
    {
      var course = _courseRepository.GetOne(id);
      if (course == null)
      {
        return BadRequest($"El curso con id {id} no fue encontrado");
      }
      try
      {
        return Ok(course);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Error al traer el curso con id {id}: {ex.Message}");
      }
    }
  }
}