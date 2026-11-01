using BibliotecaAppG1.Entities;

namespace BibliotecaAppG1.Data
{
    public class LibroRepositorio
    {
        private static List<Libro> _libros = new List<Libro>();
        private static int _ultimoId = 0;

        public void Agregar(Libro libro)
        {
            libro.Id = ++_ultimoId;
            _libros.Add(libro);
        }
    }
}
