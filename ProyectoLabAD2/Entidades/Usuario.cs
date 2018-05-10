using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLabAD2.Entidades
{
    public class Usuario
    {
        public String cuenta { get; set; }
        public String nombres { get; set; }
        public String apellidos { get; set; }
        public String dpi { get; set; }
        public String saldoInicial { get; set; }
        public String correo { get; set; }
        public String password { get; set; }

        public Usuario(String cuenta,String nombres,String apellidos,String dpi,String saldoInicial,String correo,String password)
        {
            this.cuenta = cuenta;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.dpi = dpi;
            this.saldoInicial = saldoInicial;
            this.correo = correo;
            this.password = password;

        }
    }
}