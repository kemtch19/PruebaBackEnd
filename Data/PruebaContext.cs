using Microsoft.EntityFrameworkCore;
using Prueba.Models;

namespace Prueba.Data
{
  public class PruebaContext : DbContext
  {
    public PruebaContext(DbContextOptions<PruebaContext> options) : base(options)
    {

    }
    public DbSet<Student> Students { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
  }
}