using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using BibliotecaAppG1.Models;
using BibliotecaAppG1.Data;
using BibliotecaAppG1.Service;

namespace BibliotecaAppG1.Controllers
{
    public class LoginController : Controller
    {
        private readonly UsuarioServicio _servicio;

        public LoginController(BibliotecaContext context)
        {
            _servicio = new UsuarioServicio(context);
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Libros");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Ahora usamos el servicio con la base de datos
                if (_servicio.ValidarCredenciales(model.Usuario, model.Password))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Usuario)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Libros");
                }

                ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos.");
            }
            return View(model);
        }

        public IActionResult Registro()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Libros");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registro(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool registrado = _servicio.RegistrarUsuario(model.Usuario, model.Password);

                if (registrado)
                {
                    TempData["MensajeExito"] = "Usuario registrado correctamente. Ya puede iniciar sesión.";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, "El nombre de usuario ya está en uso.");
            }
            return View(model);
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}