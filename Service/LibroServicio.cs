using BibliotecaAppG1.Data;
using BibliotecaAppG1.Entities;

namespace BibliotecaAppG1.Service
{
    public class LibroServicio
    {
        private readonly LibroRepositorio _repo = new LibroRepositorio();

        public void AltaLibro(Libro libro)
        {
            // Validaciones de negocio extra si son necesarias
            _repo.Agregar(libro);
        }
    }
}
