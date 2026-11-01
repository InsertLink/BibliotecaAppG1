using BibliotecaAppG1.Entities;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAppG1.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
    }
}