using BibliotecaAppG1.Entities;
using BibliotecaAppG1.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class LibrosController : Controller
{
    private readonly LibroServicio _servicio = new LibroServicio();

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
            _servicio.AltaLibro(libro);
            return RedirectToAction("Index"); // o a una vista de éxito
        }
        CargarCombos();
        return View(libro);
    }

    private void CargarCombos()
    {
        ViewBag.Generos = new SelectList(new[] { "Novela", "Cuento", "Ensayo", "Poesía", "Técnico" });
        ViewBag.Estados = new SelectList(new[] { "Disponible", "Agotado", "En reparación" });
    }
}
