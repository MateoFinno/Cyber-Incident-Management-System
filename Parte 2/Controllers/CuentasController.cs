using dominio;
using Microsoft.AspNetCore.Mvc;

namespace Parte_2.Controllers
{
    public class CuentasController : Controller
    {
        Sistema _sistema = Sistema.ObtenerInstancia();
        public IActionResult Index(string cedula)
        {
            if(HttpContext.Session.GetString("PersonaRol") != Rol.ADMIN.ToString())
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Persona UsuarioLogeado = _sistema.BuscarPersonaPorCedula(cedula);
                List<Cuenta> ListaCuentas = _sistema.BuscarCuentasPorPersona(UsuarioLogeado);
                ViewBag.Cedula = cedula;
                return View(ListaCuentas);
            }
            
        }

        public IActionResult Crearcuenta(string cedulaTitular)
        {
            if (HttpContext.Session.GetString("PersonaRol") != Rol.ADMIN.ToString())
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Persona UsuarioLogeado = _sistema.BuscarPersonaPorCedula(cedulaTitular);
                List<Cuenta> ListaCuentas = _sistema.BuscarCuentasPorPersona(UsuarioLogeado);
                ViewBag.Cedula = cedulaTitular;
                return View(ListaCuentas);
            }
        }

            [HttpPost]
        public IActionResult CrearCuenta(string cedulaTitular)
        {
            if (HttpContext.Session.GetString("PersonaRol") != Rol.ADMIN.ToString())
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                try
                {
                    Persona titularCuenta = _sistema.BuscarPersonaPorCedula(cedulaTitular);
                    Cuenta nuevaCuenta = new Cuenta(DateTime.Now, false, titularCuenta);
                    _sistema.AltaCuenta(nuevaCuenta);
                    TempData["MensajeExito"] = "La cuenta se ha creado correctamente";
                }
                catch(Exception ex)
                {
                    TempData["MensajeError"] = ex.Message;
                }
                return RedirectToAction("Index", "Personas");
            }
        }
    }
}
