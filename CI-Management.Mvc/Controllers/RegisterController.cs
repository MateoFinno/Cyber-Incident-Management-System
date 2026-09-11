using dominio;
using Microsoft.AspNetCore.Mvc;

namespace Parte_2.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string cedula,string nombre,string email,string contraseña,int telefono)
        {
            Sistema _sistema = Sistema.ObtenerInstancia();
            try
            {   
                Persona nuevaPersona = new Persona(cedula,nombre,email,telefono,Rol.OPERADOR,contraseña);
                _sistema.AltaPersona(nuevaPersona);
                HttpContext.Session.SetString("PersonaRol", nuevaPersona.Rol.ToString());
                HttpContext.Session.SetString("PersonaNombre", nuevaPersona.Nombre);
                HttpContext.Session.SetString("PersonaCedula", nuevaPersona.Cedula);
                TempData["MensajeExito"] = "Persona registrada correctamente";
                return RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {
                ViewBag.MensajeError = ex.Message;
                return View();
            }
        }
    }

}
