using Microsoft.AspNetCore.Mvc;
using Prueba.Models;
using Prueba.Services;

namespace Prueba.AddControllers
{
  [ApiController]
  [Route("api/students/Update")]

  public class StudentUpdateController : ControllerBase
  {
    private readonly IStudentRepository _studentRepository;

    public StudentUpdateController(IStudentRepository studentRepository)
    {
      _studentRepository = studentRepository;
    }
    [HttpPut("{id}")]
    public IActionResult UpdateStudent(Student student)
    {
      if (student == null)
      {
        return BadRequest($"Datos Nulos");
      }

      try
      {
        _studentRepository.Update(student);
        return Ok(student);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Error al actualizar el estudiante: {ex.Message}");
      }
    }
  }
}