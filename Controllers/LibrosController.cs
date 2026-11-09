using BibliotecaAppG1.Data;
using BibliotecaAppG1.Entities;
using BibliotecaAppG1.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

[Authorize]
public class LibrosController : Controller
{

    private readonly LibroServicio _libroServicio;
    private readonly AutorServicio _autorServicio;

    public LibrosController(BibliotecaContext context)
    {
        _libroServicio = new LibroServicio(new LibroRepositorio(context));
        _autorServicio = new AutorServicio(new AutorRepositorio(context));
    }

    public IActionResult Index(string buscarTitulo, string buscarGenero)
    {
        ViewData["FiltroTitulo"] = buscarTitulo;
        ViewData["FiltroGenero"] = buscarGenero;

        var libros = _libroServicio.BuscarLibros(buscarTitulo, buscarGenero);

        return View(libros);
    }

    public IActionResult Alta()
    {
        CargarCombos();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Alta(Libro libro)
    {
        ModelState.Remove("Autor");

        if (ModelState.IsValid)
        {
            _libroServicio.AltaLibro(libro);
            return RedirectToAction("Index");
        }

        CargarCombos();
        return View(libro);
    }

    public IActionResult Editar(int id)
    {
        var libro = _libroServicio.ObtenerPorId(id);
        if (libro == null)
        {
            return NotFound();
        }

        CargarCombos();
        return View(libro);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Editar(int id, Libro libro)
    {
        if (id != libro.Id)
        {
            return NotFound();
        }

        ModelState.Remove("Autor");

        if (ModelState.IsValid)
        {
            _libroServicio.ModificarLibro(libro);
            return RedirectToAction("Index");
        }

        CargarCombos();
        return View(libro);
    }

    public IActionResult Eliminar(int id)
    {
        var libro = _libroServicio.ObtenerPorId(id);
        if (libro == null)
        {
            return NotFound();
        }
        return View(libro);
    }

    [HttpPost, ActionName("Eliminar")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _libroServicio.EliminarLibro(id);
        return RedirectToAction("Index");
    }

    public IActionResult Detalles(int id)
    {
        var libro = _libroServicio.ObtenerPorId(id);
        if (libro == null)
        {
            return NotFound();
        }
        return View(libro);
    }

    private void CargarCombos()
    {
        ViewBag.Generos = new SelectList(new[] { "Novela", "Cuento", "Ensayo", "Poesía", "Técnico" });
        ViewBag.Estados = new SelectList(new[] { "Disponible", "Agotado", "Proximamente" });
        ViewBag.Autores = new SelectList(_autorServicio.ObtenerTodos(), "Id", "Nombre");
    }

}
