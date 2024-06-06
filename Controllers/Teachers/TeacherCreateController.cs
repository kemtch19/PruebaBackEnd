using Microsoft.AspNetCore.Mvc;
using Prueba.Models;
using Prueba.Services;

namespace Prueba.AddControllers
{
  [ApiController]
  [Route("api/teachers/Create")]

  public class TeacherCreateController : ControllerBase
  {
    private readonly ITeacherRepository _teacherRepository;

    public TeacherCreateController(ITeacherRepository teacherRepository)
    {
      _teacherRepository = teacherRepository;
    }
    public IActionResult CreateTeacher(Teacher teacher)
    {
      if (teacher == null)
      {
        return BadRequest($"Datos Nulos");
      }
      try
      {
        _teacherRepository.Create(teacher);
        return Ok(teacher);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Error al crear el profesor: {ex.Message}");
      }
    }
  }
}