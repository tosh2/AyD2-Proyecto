using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoLabAD2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewData["Datos"] = "HOLA MUNDO !!!";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Sistema()
        {
            if (Session["cuenta"] == null || Session["nombre"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}