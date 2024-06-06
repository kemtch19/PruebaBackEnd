using Microsoft.EntityFrameworkCore;
using Prueba.AddControllers;
using Prueba.Data;
using Prueba.Models;

namespace Prueba.Services
{
  public class EnrollmentRepository : IEnrollmentRepository
  {
    private readonly PruebaContext _context;

    public EnrollmentRepository(PruebaContext context)
    {
      _context = context;
    }
    public IEnumerable<Enrollment> GetAll()
    {
      var enrollments = _context.Enrollments.Include(s => s.Student).Include(c => c.Course).ToList();
      return enrollments;
    }
    public Enrollment GetOne(int id)
    {
      var enrollment = _context.Enrollments.Include(s => s.Student).Include(c => c.Course).FirstOrDefault(m => m.Id == id);
      return enrollment;
    }
    public void Update(Enrollment enrollment)
    {
      _context.Enrollments.Update(enrollment);
      _context.SaveChanges();
    }
    public void Create(Enrollment enrollment)
    {
      _context.Enrollments.Add(enrollment);
      _context.SaveChanges();

      var student = _context.Students.Find(enrollment.StudentId);
      var course = _context.Courses.Find(enrollment.CourseId);
      var teacher = _context.Teachers.Find(course.TeacherId);
      MailController Email = new MailController();
      Email.EnviarCorreo(student.Email, student.Names, teacher.Names, course.Name, enrollment.DateEnrollments);
    }

    // Endpoints Medios
    public IEnumerable<Enrollment> DateEnrollment(int id, DateOnly date)
    {
      var dateEnrollment = _context.Enrollments.Include(s => s.Student).Include(c => c.Course).Where(c => c.DateEnrollments == date && c.Id == id);
      return dateEnrollment;
    }

    public IEnumerable<Enrollment> TeacherCourses(int id)
    {
      var teacherCourses = _context.Enrollments.Include(s => s.CourseId).ToList();
      return teacherCourses;
    }
  }
}