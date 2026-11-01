using BibliotecaAppG1.Data;
using BibliotecaAppG1.Entities;
using BibliotecaAppG1.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class LibrosController : Controller
{

    private readonly LibroServicio _libroServicio;
    private readonly AutorServicio _autorServicio;

    public LibrosController(BibliotecaContext context)
    {
        _libroServicio = new LibroServicio(context);
        _autorServicio = new AutorServicio(context);
    }

    
    public IActionResult Index()
    {
        var libros = _libroServicio.ObtenerTodos();
        return View(libros);
    }

    // GET: Mostrar formulario
    public IActionResult Alta()
    {
        CargarCombos();
        return View();
    }

    // POST: Procesar alta
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Alta(Libro libro)
    {
        if (ModelState.IsValid)
        {
            _libroServicio.AltaLibro(libro);
            return RedirectToAction("Index"); // o a una vista de éxito
        }
        CargarCombos();
        return View(libro);
    }

    // GET: Cargar el formulario de edición
    public IActionResult Edit(int id)
    {
        var libro = _libroServicio.ObtenerPorId(id);
        if (libro == null)
        {
            return NotFound();
        }

        CargarCombos(); // Reutilizamos el método para llenar los dropdowns
        return View(libro);
    }

    // POST: Procesar la modificación
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Libro libro)
    {
        // Seguridad: verificar que el ID de la URL coincida con el ID del objeto
        if (id != libro.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _libroServicio.ModificarLibro(libro);
            return RedirectToAction("Index");
        }

        // Si la validación falla, recargamos los combos y volveamos a mostrar la vista
        CargarCombos();
        return View(libro);
    }

    // GET: Mostrar página de confirmación de borrado
    public IActionResult Delete(int id)
    {
        var libro = _libroServicio.ObtenerPorId(id);
        if (libro == null)
        {
            return NotFound();
        }
        return View(libro);
    }

    // POST: Procesar la eliminación
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _libroServicio.EliminarLibro(id);
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var libro = _libroServicio.ObtenerPorId(id);
        if (libro == null)
        {
            return NotFound(); // Retorna error 404 si el libro no existe
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
