using Microsoft.EntityFrameworkCore;
using Prueba.Data;
using Prueba.Models;

namespace Prueba.Services
{
  public class TeacherRepository : ITeacherRepository
  {
    private readonly PruebaContext _context;

    public TeacherRepository(PruebaContext context)
    {
      _context = context;
    }
    public IEnumerable<Teacher> GetAll()
    {
      var teacher = _context.Teachers.ToList();
      return teacher;
    }
    public Teacher GetOne(int id)
    {
      var teacher = _context.Teachers.FirstOrDefault(m => m.Id == id);
      return teacher;
    }
    public void Create(Teacher teacher)
    {
      _context.Teachers.Add(teacher);
      _context.SaveChanges();
    }
    public void Update(Teacher teacher)
    {
      _context.Teachers.Update(teacher);
      _context.SaveChanges();
    }
  }
}