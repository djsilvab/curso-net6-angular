using System.ComponentModel.DataAnnotations;

namespace MyFirstBackend.Models.DataModels
{
    public enum TipoNivel
    {
        Basico = 1,        
        Intermedio,
        Avanzado,
        Experto
    }

    public class Curso : BaseEntity
    {
        [Required, StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required, StringLength(280)]
        public string DescripcionCorta { get; set; } = string.Empty;
        [Required]
        public string DescripcionLarga { get; set; } = string.Empty;

        public string PublicoObjetivo { get; set; } = string.Empty;

        public string Objetivos { get; set; } = string.Empty;

        public string Requisitos { get; set; } = string.Empty;

        public TipoNivel Nivel { get; set; } = TipoNivel.Basico;

        [Required]
        public Chapter Chapter { get; set; } = new Chapter();

        [Required]
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        [Required]
        public ICollection<Student> Students { get; set; } = new List<Student>();

    }
}
