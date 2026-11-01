using System.ComponentModel.DataAnnotations;

namespace BibliotecaAppG1.Entities
{
    public class Autor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        // Propiedad de navegación (Un autor tiene muchos libros)
        public List<Libro> Libros { get; set; } = new List<Libro>();
    }
}