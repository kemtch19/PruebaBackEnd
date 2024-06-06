using Microsoft.AspNetCore.Mvc;
using Prueba.Models;
using Prueba.Services;

namespace Prueba.AddControllers
{
  [ApiController]
  [Route("api/courses/Create")]

  public class CourseCreateController : ControllerBase
  {
    private readonly ICourseRepository _courseRepository;

    public CourseCreateController(ICourseRepository courseRepository)
    {
      _courseRepository = courseRepository;
    }
    [HttpPost]
    public IActionResult CreateCourse(Course course)
    {
      if (course == null)
      {
        return BadRequest($"Datos Nulos");
      }
      try
      {
        _courseRepository.Create(course);
        return Ok(course);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Error al crear el curso: {ex.Message}");
      }
    }
  }
}