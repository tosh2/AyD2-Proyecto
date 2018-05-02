using ProyectoLabAD2.Models;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace ProyectoLabAD2.Controllers
{
    public class CuentaController : Controller
    {
        //CuentaModel modeloCuenta = new CuentaModel();

        public ActionResult Registro()
        {
            NameValueCollection nvc = Request.Form;
            if (string.IsNullOrEmpty(nvc["numerocuenta"])   || string.IsNullOrEmpty(nvc["dpi"])         ||
                string.IsNullOrEmpty(nvc["nombres"])        || string.IsNullOrEmpty(nvc["apellidos"])   ||
                string.IsNullOrEmpty(nvc["saldoinicial"])   || string.IsNullOrEmpty(nvc["email"])       ||
                string.IsNullOrEmpty(nvc["password"]))
            {

            }
            else {
                //<p class="alert alert-success"> <strong>Success! </strong>Your Password has been successfully changed.</p>
                CuentaModel nuevaCuenta = new CuentaModel();
                nuevaCuenta.Cuenta = nvc["numerocuenta"];
                nuevaCuenta.dpi = nvc["dpi"];
                nuevaCuenta.nombres = nvc["nombres"];
                nuevaCuenta.apellidos = nvc["apellidos"];
                nuevaCuenta.saldoInicial = nvc["saldoinicial"];
                nuevaCuenta.correo = nvc["email"];
                nuevaCuenta.password = nvc["password"];

                int result = nuevaCuenta.crearCuenta();

            }
            return RedirectToAction("Index", "Home");
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login()
        {
            NameValueCollection nvc = Request.Form;
            CuentaModel nuevaCuenta = new CuentaModel();
            nuevaCuenta.Cuenta = nvc["numerocuenta"];
            nuevaCuenta.password = nvc["password"];
            if (nuevaCuenta.inicioSesionValido())
            {

                //var result = await _signInManager.PasswordSignInAsync(model.Email,model.Password, model.RememberMe,     lockoutOnFailure: false);

                return RedirectToAction("Index", "Home");
            }
            else
            {

            }
            return RedirectToAction("About", "Home");
        }
    }

}