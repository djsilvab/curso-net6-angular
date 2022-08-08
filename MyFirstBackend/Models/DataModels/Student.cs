using System.ComponentModel.DataAnnotations;

namespace MyFirstBackend.Models.DataModels
{
    public class Student : BaseEntity
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public DateTime DateOfBirth { get; set; }
        public ICollection<Curso> Courses { get; set; } = new List<Curso>();
    }
}
