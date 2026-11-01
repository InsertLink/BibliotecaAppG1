using BibliotecaAppG1.Data;
using BibliotecaAppG1.Entities;
using BibliotecaAppG1.Service;
using Microsoft.AspNetCore.Mvc;

public class AutoresController : Controller
{
    private readonly AutorServicio _servicio;
    
    public AutoresController(BibliotecaContext context)
    {
        _servicio = new AutorServicio(context);
    }
    
    public IActionResult Alta()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Alta(Autor autor)
    {
        if (ModelState.IsValid)
        {
            _servicio.AltaAutor(autor);
            // Redirige al alta de libros para que el usuario asocie el autor creado
            return RedirectToAction("Alta", "Libros");
        }
        return View(autor);
    }
}
