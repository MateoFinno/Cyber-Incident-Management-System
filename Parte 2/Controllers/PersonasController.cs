using dominio;
using Microsoft.AspNetCore.Mvc;

namespace Parte_2.Controllers
{
    public class PersonasController : Controller
    {
        Sistema _sistema = Sistema.ObtenerInstancia();
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("PersonaRol") != Rol.ADMIN.ToString())
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                List<Persona> ListaPersonas = _sistema.ObtenerPersonas();
                return View(ListaPersonas);
            }
            
        }



    }
}
