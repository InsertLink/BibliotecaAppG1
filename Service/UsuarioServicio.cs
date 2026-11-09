using BibliotecaAppG1.Data;
using BibliotecaAppG1.Entities;
using System.Security.Cryptography;
using System.Text;

namespace BibliotecaAppG1.Service
{
    public class UsuarioServicio
    {
        private readonly UsuarioRepositorio _repo;

        public UsuarioServicio(BibliotecaContext context)
        {
            _repo = new UsuarioRepositorio(context);
        }

        public bool ValidarCredenciales(string nombreUsuario, string passwordClaro)
        {
            var usuario = _repo.ObtenerPorNombre(nombreUsuario);
            if (usuario == null)
            {
                return false;
            }

            var hashGenerado = GenerarHash(passwordClaro);
            return hashGenerado == usuario.PasswordHash;
        }

        public bool RegistrarUsuario(string nombreUsuario, string passwordClaro)
        {
            if (_repo.ObtenerPorNombre(nombreUsuario) != null)
            {
                return false;
            }

            var nuevoUsuario = new Usuario
            {
                NombreUsuario = nombreUsuario,
                PasswordHash = GenerarHash(passwordClaro)
            };

            _repo.Agregar(nuevoUsuario);
            return true;
        }

        public string GenerarHash(string textoClaro)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(textoClaro));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}