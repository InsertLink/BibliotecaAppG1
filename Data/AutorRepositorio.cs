using BibliotecaAppG1.Entities;

namespace BibliotecaAppG1.Data
{
    public class AutorRepositorio
    {
        private readonly BibliotecaContext _context;

        public AutorRepositorio(BibliotecaContext context)
        {
            _context = context;
        }

        public void Agregar(Autor autor)
        {
            _context.Autores.Add(autor);
            _context.SaveChanges();
        }

        public List<Autor> ObtenerTodos()
        {
            return _context.Autores.ToList();
        }
    }
}