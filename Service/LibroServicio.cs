using BibliotecaAppG1.Data;
using BibliotecaAppG1.Entities;

namespace BibliotecaAppG1.Service
{
    public class LibroServicio
    {
        private readonly LibroRepositorio _repo;

        public LibroServicio(LibroRepositorio repo)
        {
            _repo = repo;
        }

        public List<Libro> BuscarLibros(string titulo, string genero)
        {
            return _repo.Buscar(titulo, genero);
        }

        public void AltaLibro(Libro libro)
        {
            _repo.Agregar(libro);
        }

        public List<Libro> ObtenerTodos()
        {
            return _repo.ObtenerTodos();
        }

        public Libro ObtenerPorId(int id)
        {
            return _repo.ObtenerPorId(id);
        }

        public void ModificarLibro(Libro libro)
        {
            _repo.Modificar(libro);
        }

        public void EliminarLibro(int id)
        {
            _repo.Eliminar(id);
        }
    }
}