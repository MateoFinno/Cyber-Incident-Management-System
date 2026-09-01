using dominio;
using Microsoft.AspNetCore.Mvc;

namespace Parte_2.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string mail, string contrasena)
        {
            Sistema _sistema = Sistema.ObtenerInstancia();

            try
            {
                Persona personaLogeada = _sistema.BuscarPersonaPorEmailYContraseña(mail, contrasena);
                HttpContext.Session.SetString("PersonaRol", personaLogeada.Rol.ToString());
                HttpContext.Session.SetString("PersonaNombre", personaLogeada.Nombre);
                HttpContext.Session.SetString("PersonaCedula", personaLogeada.Cedula);
                TempData["MensajeExito"] = "Usuario accedió correctamente";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.MensajeError = ex.Message;
                return View();
            }

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
}
}

