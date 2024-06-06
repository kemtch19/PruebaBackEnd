
using Prueba.Models;

namespace Prueba.Services
{
  public interface IEnrollmentRepository
  {
    public IEnumerable<Enrollment> GetAll();
    public Enrollment GetOne(int id);
    public void Update(Enrollment enrollment);
    public void Create(Enrollment enrollment);
    public IEnumerable<Enrollment> DateEnrollment(int id, DateOnly date);
    public IEnumerable<Enrollment> TeacherCourses(int id);
  }
}