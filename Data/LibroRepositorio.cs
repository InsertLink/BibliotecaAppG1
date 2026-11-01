using BibliotecaAppG1.Entities;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAppG1.Data
{
    public class LibroRepositorio
    {
        private readonly BibliotecaContext _context;

        // Inyectamos el contexto de la base de datos
        public LibroRepositorio(BibliotecaContext context)
        {
            _context = context;
        }

        public void Agregar(Libro libro)
        {
            _context.Libros.Add(libro);
            _context.SaveChanges();
        }

        public List<Libro> ObtenerTodos()
        {
            // Usamos Include(l => l.Autor) para traer los datos del autor relacionado usando LINQ
            return _context.Libros.Include(l => l.Autor).ToList();
        }

        public Libro ObtenerPorId(int id)
        {
            // Usamos LINQ para buscar el libro y su autor
            return _context.Libros.Include(l => l.Autor).FirstOrDefault(l => l.Id == id);
        }

        public void Modificar(Libro libroModificado)
        {
            _context.Libros.Update(libroModificado);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var libro = ObtenerPorId(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
                _context.SaveChanges();
            }
        }
    }
}