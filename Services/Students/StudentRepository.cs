using Microsoft.EntityFrameworkCore;
using Prueba.Data;
using Prueba.Models;

namespace Prueba.Services
{
  public class StudentRepository : IStudentRepository
  {
    private readonly PruebaContext _context;

    public StudentRepository(PruebaContext context)
    {
      _context = context;
    }
    public IEnumerable<Student> GetAll()
    {
      var students = _context.Students.ToList();
      return students;
    }
    public Student GetOne(int id)
    {
      var student = _context.Students.FirstOrDefault(m => m.Id == id);
      return student;
    }
    public void Create(Student student)
    {
      _context.Students.Add(student);
      _context.SaveChanges();
    }
    public void Update(Student student)
    {
      _context.Students.Update(student);
      _context.SaveChanges();
    }
  }
}