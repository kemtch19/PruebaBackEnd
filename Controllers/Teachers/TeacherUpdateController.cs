using Microsoft.AspNetCore.Mvc;
using Prueba.Models;
using Prueba.Services;

namespace Prueba.AddControllers
{
  [ApiController]
  [Route("api/teachers/Update")]

  public class TeacherUpdateController : ControllerBase
  {
    private readonly ITeacherRepository _teacherRepository;

    public TeacherUpdateController(ITeacherRepository teacherRepository)
    {
      _teacherRepository = teacherRepository;
    }
    [HttpPut("{id}")]
    public IActionResult UpdateTeacher(Teacher teacher)
    {
      if (teacher == null)
      {
        return BadRequest($"Datos Nulos");
      }

      try
      {
        _teacherRepository.Update(teacher);
        return Ok(teacher);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Error al actualizar al profesor: {ex.Message}");
      }
    }
  }
}