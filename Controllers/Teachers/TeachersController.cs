using Microsoft.AspNetCore.Mvc;
using Prueba.Models;
using Prueba.Services;

namespace Prueba.AddControllers
{
  [ApiController]
  [Route("api/teachers")]

  public class TeachersController : ControllerBase
  {
    private readonly ITeacherRepository _teacherRepository;

    public TeachersController(ITeacherRepository teacherRepository)
    {
      _teacherRepository = teacherRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Teacher>> GetTeachers()
    {
      try
      {
        return Ok(_teacherRepository.GetAll());
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Error al traer todos los profesores: {ex.Message}");
      }
    }

    [HttpGet("{id}")]
    public IActionResult GetTeacher(int id)
    {
      var teacher = _teacherRepository.GetOne(id);
      if (teacher == null)
      {
        return BadRequest($"El profesor con id {id} no fue encontrado");
      }
      try
      {
        return Ok(teacher);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Error al traer el profesor con id {id}: {ex.Message}");
      }
    }
  }
}