using dominio;
using Microsoft.AspNetCore.Mvc;

namespace Parte_2.Controllers
{
    public class PerfilController : Controller
    {
        public IActionResult Index()
        {
            Sistema _sistema = Sistema.ObtenerInstancia();
            Persona UsuarioLogeado =_sistema.BuscarPersonaPorCedula(HttpContext.Session.GetString("PersonaCedula"));
            List<Cuenta> ListaCuentas = _sistema.BuscarCuentasPorPersona(UsuarioLogeado);
            ViewBag.Cuentas = ListaCuentas;

            return View(UsuarioLogeado);
        }

    }

        
}
