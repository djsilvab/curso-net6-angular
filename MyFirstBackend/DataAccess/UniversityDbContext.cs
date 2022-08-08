using Microsoft.EntityFrameworkCore;
using MyFirstBackend.Models.DataModels;

namespace MyFirstBackend.DataAccess
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
            : base(options)
        {

        }

        //Add DbSets (Tables of our Data Base)
        public DbSet<User>? Users { get; set; }
        public DbSet<Curso>? Cursos { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }

    }
}
