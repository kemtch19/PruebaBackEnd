using Microsoft.AspNetCore.Mvc;
using Prueba.Models;
using Prueba.Services;

namespace Prueba.AddControllers
{
  [ApiController]
  [Route("api/enrollments/Update")]

  public class EnrollmentUpdateController : ControllerBase
  {
    private readonly IEnrollmentRepository _enrollmentRepository;

    public EnrollmentUpdateController(IEnrollmentRepository enrollmentRepository)
    {
      _enrollmentRepository = enrollmentRepository;
    }
    [HttpPut("{id}")]
    public IActionResult UpdateEnrollment(Enrollment enrollment)
    {
      if (enrollment == null)
      {
        return BadRequest($"Datos Nulos");
      }
      try
      {
        _enrollmentRepository.Update(enrollment);
        return Ok(enrollment);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Error al actualizar el curso: {ex.Message}");
      }
    }
  }
}