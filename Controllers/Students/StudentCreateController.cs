using Microsoft.AspNetCore.Mvc;
using Prueba.Models;
using Prueba.Services;

namespace Prueba.AddControllers
{
  [ApiController]
  [Route("api/students/Create")]

  public class StudentCreateController : ControllerBase
  {
    private readonly IStudentRepository _studentRepository;

    public StudentCreateController(IStudentRepository studentRepository)
    {
      _studentRepository = studentRepository;
    }
    [HttpPost]
    public IActionResult CreateStudent(Student student)
    {
      if (student == null)
      {
        return BadRequest($"Datos Nulos");
      }
      try
      {
        _studentRepository.Create(student);
        return Ok(student);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Error al crear el estudiante: {ex.Message}");
      }
    }
  }
}