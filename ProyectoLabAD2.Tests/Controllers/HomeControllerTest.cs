using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoLabAD2;
using ProyectoLabAD2.Controllers;
using ProyectoLabAD2.Models;

namespace ProyectoLabAD2.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void testTransferencia()
        {
            String cuenta="201213402";
            Double cantidad=20000;
            CuentaModel perfil = new CuentaModel();
            Boolean estado = perfil.transferible(cuenta,cantidad);
            Assert.AreEqual(estado, true);

        }

        [TestMethod]
        public void testUserTransferencia()
        {
            String cuenta = "201213402";
            String cuentaDestino = "1234";
            Double cantidad = 300;
            CuentaModel perfil = new CuentaModel();
            Boolean estado = perfil.transferir(cuenta,cuentaDestino,cantidad);
            Assert.AreEqual(estado,true);
        }

        [TestMethod]
        public void testLogin()
        {
            String cuenta = "201213402";
            String password = "201213402";
            CuentaModel perfil = new CuentaModel();
            String dato = perfil.inicioSesionValido(cuenta,password);
            Assert.AreNotEqual(dato,null);
        }


    }
}
