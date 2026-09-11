using dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Parte_2.Controllers
{
    public class ActivoController : Controller
    {
        Sistema _sistema = Sistema.ObtenerInstancia();
        public IActionResult MisActivos()
        {
            if (HttpContext.Session.GetString("PersonaCedula") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            try
            {
                string cedula = HttpContext.Session.GetString("PersonaCedula")!;
                Persona p = _sistema.BuscarPersonaPorCedula(cedula);

                List<Activo> lista = _sistema.ObtenerActivoPorPersona(p);

                return View(lista);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult Listar(int codigoCuenta)
        {
            if (HttpContext.Session.GetString("PersonaRol") != Rol.ADMIN.ToString())
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                List<Activo> ListaActivos = _sistema.ListarActivosPorCodCuenta(codigoCuenta);
                ViewBag.cuenta = codigoCuenta;
                return View(ListaActivos);
            }

        }

        public IActionResult Asociar(int codigoCuenta)
        {
            if (HttpContext.Session.GetString("PersonaRol") != Rol.ADMIN.ToString())
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.cuenta = codigoCuenta;
                Cuenta cuenta = _sistema.BuscarCuentaPorCodigo(codigoCuenta);
                return View(cuenta);
            }
        }

        public IActionResult Desasociar(string codigo)
        {
            if (HttpContext.Session.GetString("PersonaRol") != Rol.ADMIN.ToString())
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                try
                {
                    _sistema.EliminarActivoPorCodigo(codigo);
                    TempData["MensajeExito"] = "El activo se ha desasociado correctamente";
                }
                catch(Exception ex)
                {
                    TempData["MensajeError"] = ex.Message;
                }
                return RedirectToAction("Index", "Personas");
            }
        }

        [HttpPost]
        public IActionResult Asociar(string Nombre,int Criticidad,bool Backup, int codigoCuenta, TipoActivo TipoActivo)
        {
            Cuenta cuenta = _sistema.BuscarCuentaPorCodigo(codigoCuenta);

            try
            {
                Activo nuevoActivo = new Activo(Nombre, TipoActivo, Criticidad, cuenta, Backup);
                _sistema.AltaActivo(nuevoActivo);
                ViewBag.MensajeExito = "El activo se ha asociado correctamente";
            }
            catch(Exception ex)
            {
                ViewBag.MensajeError = ex.Message;
                
            }
            return View(cuenta);
        }
    }
}
