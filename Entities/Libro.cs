using System.ComponentModel.DataAnnotations;

namespace BibliotecaAppG1.Entities
{
    public class Libro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(100, MinimumLength = 2)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un autor")]
        public int AutorId { get; set; } 

        public Autor Autor { get; set; } 

        [Required(ErrorMessage = "El ISBN es obligatorio")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un género")]
        public string Genero { get; set; } // combo

        [Required(ErrorMessage = "La fecha de publicación es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime FechaPublicacion { get; set; }

        [Required(ErrorMessage = "El número de páginas es obligatorio")]
        [Range(1, 5000, ErrorMessage = "Las páginas deben estar entre 1 y 1000")]
        public int Paginas { get; set; }

        [Required(ErrorMessage = "La editorial es obligatoria")]
        public string Editorial { get; set; }

        [Required(ErrorMessage = "El idioma es obligatorio")]
        public string Idioma { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un estado")]
        public string Estado { get; set; } // combo
    }
}
