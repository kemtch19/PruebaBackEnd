using Microsoft.AspNetCore.Mvc;
using Prueba.Models;
using Prueba.Services;

namespace Prueba.AddControllers
{
  [ApiController]
  [Route("api/enrollments")]

  public class EnrollmentsController : ControllerBase
  {
    private readonly IEnrollmentRepository _enrollmentRepository;

    public EnrollmentsController(IEnrollmentRepository enrollmentRepository)
    {
      _enrollmentRepository = enrollmentRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Enrollment>> GetEnrollment()
    {
      try
      {
        return Ok(_enrollmentRepository.GetAll());
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Error al traer todas las matriculas: {ex.Message}");
      }
    }

    [HttpGet("{id}")]
    public IActionResult GetEnrollment(int id)
    {
      var enrollment = _enrollmentRepository.GetOne(id);
      if (enrollment == null)
      {
        return BadRequest($"la matricula con id {id} no fue encontrado");
      }
      try
      {
        return Ok(enrollment);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Error al traer la matricula con id {id}: {ex.Message}");
      }
    }

    // Endotpoints Medios
    [HttpGet, Route("enrollments/{date}/{id}")]
    public ActionResult<IEnumerable<Enrollment>> GetDateEnrollment(int id, DateOnly date)
    {
      var dateEnrollment = _enrollmentRepository.DateEnrollment(id, date);

      if (dateEnrollment == null)
      {
        return BadRequest($"Las matriculas con el id {id} en la fecha {date} no fueron encontradas");
      }
      try
      {
        return Ok(dateEnrollment);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Error al traer las matriculas con id {id} en la fecha {date}: {ex.Message}");
      }
    }
    [HttpGet, Route("teachers/Courses/{id}")]
    public ActionResult<IEnumerable<Teacher>> TeacherCourses(int id)
    {
      var teacherCourses = _enrollmentRepository.TeacherCourses(id);

      if (teacherCourses == null)
      {
        return BadRequest($"no encontrado");
      }
      try
      {
        return Ok(teacherCourses);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Error al traer los cursos del profesor con id {id}: {ex.Message}");
      }
    }
  }
}