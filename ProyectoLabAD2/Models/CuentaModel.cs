using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data.SqlClient;
using ProyectoLabAD2.Entidades;

namespace ProyectoLabAD2.Models
{
    public class CuentaModel
    {
        private String connectionString = "Data Source=TOSH-PC;Initial Catalog=ad2-proyecto;Integrated Security=True";
        private SqlConnection connection;
        private bool connection_open;

        private void Get_Connection()
        {
            connection_open = false;

            connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            if (Open_Local_Connection())
            {
                connection_open = true;
            }
            else{ connection_open = false; }
        }

        private bool Open_Local_Connection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public String inicioSesionValido(String cuenta,String password)
        {
            Get_Connection();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT nombres, apellidos FROM USUARIO WHERE cuenta=@cuenta AND password=@password"
                                                ,connection);
                cmd.Parameters.AddWithValue("@cuenta",cuenta);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    String nombres = reader.GetString(0);

                    reader.Close();
                    connection.Close();
                    return nombres;
                }
                else {
                    reader.Close();
                    connection.Close();
                    return null;
                }
                
            }
            catch (SqlException e) { }

            return null;
        }

        public int crearCuenta() {
            Get_Connection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO USUARIO "
                                    +" VALUES(@cuenta, @nombres, @apellidos, @dpi, @saldoinicial,"
                                    +"@correo, @password,@saldoactual);";
                cmd.Parameters.AddWithValue("@cuenta", this.Cuenta);
                cmd.Parameters.AddWithValue("@nombres", this.nombres);
                cmd.Parameters.AddWithValue("@apellidos", this.apellidos);
                cmd.Parameters.AddWithValue("@dpi", this.dpi);
                cmd.Parameters.AddWithValue("@saldoinicial", this.saldoInicial);
                cmd.Parameters.AddWithValue("@saldoactual", this.saldoInicial);
                cmd.Parameters.AddWithValue("@correo", this.correo);
                cmd.Parameters.AddWithValue("@password", this.password);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException e) { }
            return 0;
        }

        public Usuario getProfile(String cuenta)
        {
            Get_Connection();
            Usuario u=null;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM USUARIO WHERE cuenta=@cuenta"
                                                , connection);
                cmd.Parameters.AddWithValue("@cuenta", cuenta);
                //cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    u = new Usuario(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), reader.GetValue(5).ToString(), reader.GetValue(6).ToString());
                    reader.Close();
                    connection.Close();
                }
                else
                {
                    reader.Close();
                    connection.Close();
                    return null;
                }

            }
            catch (SqlException e) { }
            return u;
        }

        public Double getSaldoActual(String cuenta)
        {
            Get_Connection();
            Double saldoActual = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT SaldoActual FROM USUARIO WHERE cuenta=@cuenta"
                                                , connection);
                cmd.Parameters.AddWithValue("@cuenta", cuenta);
                //cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    saldoActual = Double.Parse(reader.GetValue(0).ToString());
                    reader.Close();
                    connection.Close();
                }
                else
                {
                    reader.Close();
                    connection.Close();
                    return -1;
                }

            }
            catch (SqlException e) { }
            return saldoActual;
        }



        public Boolean transferible(String cuenta,Double cantidad)
        {
            Get_Connection();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT SaldoActual FROM USUARIO WHERE cuenta=@cuenta"
                                                , connection);
                cmd.Parameters.AddWithValue("@cuenta", cuenta);
                //cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Double saldoActual = Double.Parse(reader.GetValue(0).ToString());
                    
                    reader.Close();
                    connection.Close();
                    if (saldoActual >= cantidad)
                    {
                        return true;
                    }else
                    {
                        return false;
                    }
                }
                else
                {
                    reader.Close();
                    connection.Close();
                    return false;
                }

            }
            catch (SqlException e) { }
            return false;
        }

        public Boolean transferir(String cuenta,String cuentaDestino, Double cantidad)
        {
            Get_Connection();
            try
            {
                SqlCommand cmd = new SqlCommand("Update USUARIO set saldoActual=saldoActual-@cantidad WHERE cuenta=@cuenta"
                                                , connection);
                cmd.Parameters.AddWithValue("@cuenta", cuenta);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                int estado = cmd.ExecuteNonQuery();

                if (estado==0)
                {
                    connection.Close();
                    return false;
                }
                cmd = new SqlCommand("Update USUARIO set saldoActual=saldoActual+@cantidad WHERE cuenta=@cuentaDestino"
                                                , connection);
                cmd.Parameters.AddWithValue("@cuentaDestino", cuentaDestino);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                estado = cmd.ExecuteNonQuery();
                if (estado==0)
                {
                    connection.Close();
                    return false;
                }
                connection.Close();
                return true;
            }
            catch (SqlException e) {

                return false;
            }
            
        }


        public String Cuenta { get; set; }
        public String nombres { get; set; }
        public String apellidos { get; set; }
        public String dpi { get; set; }
        public String saldoInicial { get; set; }
        public String correo { get; set; }
        public String password { get; set; }


    }
}