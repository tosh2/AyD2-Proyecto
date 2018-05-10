using ProyectoLabAD2.Entidades;
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

        //[System.Web.Http.HttpPost]
        //[System.Web.Http.AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Login()
        {
            NameValueCollection nvc = Request.Form;
            CuentaModel nuevaCuenta = new CuentaModel();
            string cuenta = nvc["numerocuenta"].ToString();
            string password = nvc["password"].ToString();
            string nombre = nuevaCuenta.inicioSesionValido(cuenta,password);
            if (nombre!=null)
            {

                //var result = await _signInManager.PasswordSignInAsync(model.Email,model.Password, model.RememberMe,     lockoutOnFailure: false);
                Session["cuenta"]= cuenta;
                Session["nombre"] = nombre;

                return RedirectToAction("Sistema", "Home");
            }
            else
            {

            }
            return RedirectToAction("About", "Home");
        }


        public ActionResult Profile()
        {
            if (Session["cuenta"]==null || Session["nombre"]==null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = "Perfil";
            string cuenta = Session["cuenta"].ToString();
            CuentaModel nuevaCuenta = new CuentaModel();
            Usuario perfil=nuevaCuenta.getProfile(cuenta);
            //string password = Session["password"].ToString();
            ViewData["perfil"] = perfil;
            return View();
        }

        public ActionResult Logout()
        {
            Session["nombre"]= null;
            Session["cuenta"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Saldo()
        {
            if (Session["cuenta"] == null || Session["nombre"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            CuentaModel perfil = new CuentaModel();
            ViewData["saldoActual"] = perfil.getSaldoActual(Session["cuenta"].ToString());
            return View();
        }

        public ActionResult Transferencia()
        {
            if (Session["cuenta"] == null || Session["nombre"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Transferir()
        {
            if (Session["cuenta"] == null || Session["nombre"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            NameValueCollection nvc = Request.Form;
            string cuentaDestino=nvc["cuentaDestino"];
            string cantidad= nvc["cantidad"];
            CuentaModel perfil = new CuentaModel();
            bool estado = perfil.transferible(Session["cuenta"].ToString(),double.Parse(cantidad));
            if (estado)
            {
                bool exito = perfil.transferir(Session["cuenta"].ToString(),cuentaDestino,double.Parse(cantidad));
                if (exito)
                {
                    ViewData["mensaje"] = "Se realizó la transferencia monetaria correctamente!";
                }
                else
                {
                    ViewData["mensaje"] = "Ha ocurrido un error al momento de hacer la transferencia";
                }
            }else
            {
                ViewData["mensaje"] = "Ha ocurrido un error al momento de hacer la transferencia";
            }
            return View("Transferencia");
        }
    }

}