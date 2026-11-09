using System.ComponentModel.DataAnnotations;

namespace BibliotecaAppG1.Entities
{
    public class Autor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public required string Nombre { get; set; }

        public List<Libro> Libros { get; set; } = new List<Libro>();
    }
}