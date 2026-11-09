using BibliotecaAppG1.Data;
using BibliotecaAppG1.Entities;
using BibliotecaAppG1.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class AutoresController : Controller
{
    private readonly AutorServicio _servicio;
    
    public AutoresController(BibliotecaContext context)
    {
        _servicio = new AutorServicio(new AutorRepositorio(context));
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
            _servicio.Alta(autor);
            return RedirectToAction("Index", "Libros");
        }
        return View(autor);
    }
}
