using System.ComponentModel.DataAnnotations;

namespace MyFirstBackend.Models.DataModels
{
    public class Chapter : BaseEntity
    {        
        public int CourseID { get; set; }
        public virtual Curso Course { get; set; } = new Curso();

        [Required]
        public string List { get; set; } = string.Empty;
    }
}
