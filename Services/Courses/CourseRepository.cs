using Microsoft.EntityFrameworkCore;
using Prueba.Data;
using Prueba.Models;

namespace Prueba.Services
{
  public class CourseRepository : ICourseRepository
  {
    private readonly PruebaContext _context;

    public CourseRepository(PruebaContext context)
    {
      _context = context;
    }
    public IEnumerable<Course> GetAll()
    {
      var course = _context.Courses.Include(t=>t.Teacher).ToList();
      return course;
    }
    public Course GetOne(int id)
    {
      var course = _context.Courses.Include(t => t.Teacher).FirstOrDefault(m => m.Id == id);
      return course;
    }
    public void Create(Course course)
    {
      _context.Courses.Add(course);
      _context.SaveChanges();
    }
    public void Update(Course course)
    {
      _context.Courses.Update(course);
      _context.SaveChanges();
    }
  }
}