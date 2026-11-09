using BibliotecaAppG1.Entities;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAppG1.Data
{
    public class LibroRepositorio
    {
        private readonly BibliotecaContext _context;

        public LibroRepositorio(BibliotecaContext context)
        {
            _context = context;
        }
 
        public List<Libro> Buscar(string titulo, string genero)
        {
            var query = _context.Libros.Include(l => l.Autor).AsQueryable();

            if (!string.IsNullOrEmpty(titulo))
            {
                query = query.Where(l => l.Titulo.Contains(titulo));
            }

            if (!string.IsNullOrEmpty(genero))
            {
                query = query.Where(l => l.Genero.Contains(genero));
            }

            return query.ToList();
        }

        public void Agregar(Libro libro)
        {
            _context.Libros.Add(libro);
            _context.SaveChanges();
        }

        public List<Libro> ObtenerTodos()
        {
            return _context.Libros.Include(l => l.Autor).ToList();
        }

        public Libro ObtenerPorId(int id)
        {
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