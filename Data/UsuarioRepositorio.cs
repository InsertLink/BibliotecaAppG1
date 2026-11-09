using BibliotecaAppG1.Entities;

namespace BibliotecaAppG1.Data
{
    public class UsuarioRepositorio
    {
        private readonly BibliotecaContext _context;

        public UsuarioRepositorio(BibliotecaContext context)
        {
            _context = context;
        }

        public Usuario ObtenerPorNombre(string nombreUsuario)
        {
            return _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario);
        }

        public void Agregar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }
    }
}