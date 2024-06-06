using Microsoft.AspNetCore.Mvc;
using Prueba.Models;
using Prueba.Services;

namespace Prueba.AddControllers
{
  [ApiController]
  [Route("api/students")]

  public class StudentsController : ControllerBase
  {
    private readonly IStudentRepository _studentRepository;

    public StudentsController(IStudentRepository studentRepository)
    {
      _studentRepository = studentRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Student>> GetStudents()
    {
      try
      {
        return Ok(_studentRepository.GetAll());
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Error al traer todos los estudiantes: {ex.Message}");
      }
    }

    [HttpGet("{id}")]
    public IActionResult GetStudent(int id)
    {
      var student = _studentRepository.GetOne(id);
      if (student == null)
      {
        return BadRequest($"El estudiante con id {id} no fue encontrado");
      }
      try
      {
        return Ok(student);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Error al traer el estudiante con id {id}: {ex.Message}");
      }
    }
  }
}