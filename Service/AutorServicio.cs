using BibliotecaAppG1.Data;
using BibliotecaAppG1.Entities;

namespace BibliotecaAppG1.Service
{
    public class AutorServicio
    {
        private readonly AutorRepositorio _repo;

        public AutorServicio(AutorRepositorio repo)
        {
            _repo = repo;
        }

        public void AltaAutor(Autor autor)
        {
            _repo.Agregar(autor);
        }

        public List<Autor> ObtenerTodos()
        {
            return _repo.ObtenerTodos();
        }
    }
}