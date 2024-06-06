using Microsoft.AspNetCore.Mvc;
using Prueba.Models;
using Prueba.Services;

namespace Prueba.AddControllers
{
  [ApiController]
  [Route("api/enrollments/Create")]

  public class EnrollmentCreateController : ControllerBase
  {
    private readonly IEnrollmentRepository _enrollmentRepository;

    public EnrollmentCreateController(IEnrollmentRepository enrollmentRepository)
    {
      _enrollmentRepository = enrollmentRepository;
    }
    [HttpPost]
    public IActionResult CreateEnrollment(Enrollment enrollment)
    {
      if (enrollment == null)
      {
        return BadRequest($"Datos Nulos");
      }
      try
      {
        _enrollmentRepository.Create(enrollment);
        return Ok(enrollment);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Error al crear la matricula: {ex.Message}");
      }
    }
  }
}