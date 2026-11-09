using System.ComponentModel.DataAnnotations;

namespace BibliotecaAppG1.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}