using Microsoft.AspNetCore.Mvc;
using Prueba.Models;
using Prueba.Services;

namespace Prueba.AddControllers
{
  [ApiController]
  [Route("api/courses/Update")]

  public class CourseUpdateController : ControllerBase
  {
    private readonly ICourseRepository _courseRepository;

    public CourseUpdateController(ICourseRepository courseRepository)
    {
      _courseRepository = courseRepository;
    }
    [HttpPut("{id}")]
    public IActionResult UpdateCourse(Course course)
    {
      if (course == null)
      {
        return BadRequest($"Datos Nulos");
      }
      try
      {
        _courseRepository.Update(course);
        return Ok(course);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Error al actualizar el curso: {ex.Message}");
      }
    }
  }
}