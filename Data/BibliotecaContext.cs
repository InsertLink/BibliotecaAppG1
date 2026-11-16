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

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // default user
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    NombreUsuario = "admin",
                    PasswordHash = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5"
                }
            );

            modelBuilder.Entity<Autor>().HasData(
                new Autor { Id = 3, Nombre = "Gabriel García Márquez" },
                new Autor { Id = 4, Nombre = "George Orwell" },
                new Autor { Id = 5, Nombre = "Jorge Luis Borges" }
            );

            // 3. Sembrar Libros de prueba
            modelBuilder.Entity<Libro>().HasData(
                new Libro
                {
                    Id = 1,
                    Titulo = "Cien años de soledad",
                    AutorId = 3,
                    ISBN = "978-0307474728",
                    Editorial = "Sudamericana",
                    Idioma = "Español",
                    Genero = "Novela",
                    FechaPublicacion = new DateTime(1967, 5, 30),
                    Paginas = 417,
                    Stock = 15,
                    Estado = "Disponible"
                },
                new Libro
                {
                    Id = 2,
                    Titulo = "1984",
                    AutorId = 4,
                    ISBN = "978-0451524935",
                    Editorial = "Secker & Warburg",
                    Idioma = "Inglés",
                    Genero = "Novela",
                    FechaPublicacion = new DateTime(1949, 6, 8),
                    Paginas = 328,
                    Stock = 5,
                    Estado = "Disponible"
                },
                new Libro
                {
                    Id = 3,
                    Titulo = "Ficciones",
                    AutorId = 5,
                    ISBN = "978-8420633120",
                    Editorial = "Sur",
                    Idioma = "Español",
                    Genero = "Cuento",
                    FechaPublicacion = new DateTime(1944, 1, 1),
                    Paginas = 200,
                    Stock = 0,
                    Estado = "Agotado"
                }
            );
        }
    }
}