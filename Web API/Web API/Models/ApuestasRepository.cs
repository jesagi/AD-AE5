using AplicacionWeb.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Web_API.Models
{
    public class ApuestasRepository
    {
        private MySqlConnection Connect()
        {
            string constring = "Server=127.0.0.1;Port=3306;Database=placemybet;uid=root;password=;sslMode=none";
            MySqlConnection con = new MySqlConnection(constring);
            return con;
        }

        internal List<Apuesta> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Apuestas";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Apuesta a = null;
                List<Apuesta> apuestas = new List<Apuesta>();

                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetString(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetString(5) + " " + res.GetInt32(6) + " " + res.GetString(7));
                    a = new Apuesta(res.GetInt32(0), res.GetInt32(1), res.GetString(2), res.GetDouble(3), res.GetDouble(4), res.GetString(5), res.GetInt32(6), res.GetString(7));
                    apuestas.Add(a);
                }

                con.Close();
                return apuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexion");
                return null;
            }

        }
        internal List<ApuestaDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Apuestas";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO a = null;
                List<ApuestaDTO> apuestas = new List<ApuestaDTO>();

                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(1) + " " + res.GetString(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetString(5) + " " + res.GetString(7));
                    a = new ApuestaDTO(res.GetInt32(1), res.GetString(2), res.GetDouble(3), res.GetDouble(4), res.GetString(5), res.GetString(7));
                    apuestas.Add(a);
                }

                con.Close();
                return apuestas;
            }
            catch (MySqlException a)
            {
                Debug.WriteLine("Error de conexion");
                return null;
            }

        }

        internal List<ApuestaDTO2> RetrievebyUsuarioMercado(string email, double mercado)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select tipoapuesta, cuota, dineroapostado, apuestas.refevento from apuestas LEFT JOIN mercados ON apuestas.idmercado=mercados.idmercado WHERE refusuario = @A AND tipomercado= @A2";
            command.Parameters.AddWithValue("@A", email);
            command.Parameters.AddWithValue("@A2", mercado);

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO2 a = null;
                List<ApuestaDTO2> apuestas = new List<ApuestaDTO2>();

                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2) + res.GetString(3));
                    a = new ApuestaDTO2(res.GetString(0), res.GetDouble(1), res.GetDouble(2), res.GetInt32(3));
                    apuestas.Add(a);
                }

                con.Close();
                return apuestas;
            }
            catch (MySqlException a)
            {
                Debug.WriteLine("Error de conexion");
                return null;
            }

        }

        internal List<ApuestaDTO3> RetrievebyMercadoUsuario(int mercado, string email)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select tipomercado, tipoapuesta, cuota, dineroapostado from apuestas LEFT JOIN mercados ON apuestas.idmercado=mercados.idmercado WHERE refusuario = @A AND mercados.idmercado = @A2";
            command.Parameters.AddWithValue("@A", mercado);
            command.Parameters.AddWithValue("@A2", email);

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO3 a = null;
                List<ApuestaDTO3> apuestas = new List<ApuestaDTO3>();

                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetDouble(0) + " " + res.GetString(1) + " " + res.GetDouble(2) + res.GetDouble(3));
                    a = new ApuestaDTO3(res.GetDouble(0), res.GetString(1), res.GetDouble(2), res.GetDouble(3));
                    apuestas.Add(a);
                }

                con.Close();
                return apuestas;
            }
            catch (MySqlException a)
            {
                Debug.WriteLine("Error de conexion");
                return null;
            }

        }

        public void Save(Apuesta a)
        {
            MySqlConnection con = Connect();
            MySqlCommand com = con.CreateCommand();
            com.CommandText = "insert into apuestas(mercado, tipoapuesta, cuota, dineroapostado, fecha, refevento, refusuario) values ('" + a.Mercado + "','" + a.TipoApuesta + "','" + a.Cuota + "','" + a.DinieroApostado + "''" + DateTime.Now.ToString("yyy/mm/dd") + "','" + 1 + "','" + a.RefUsuario + "') ";
            Debug.WriteLine("Comando: " + com.CommandText);
            try
            {
                con.Open();
                com.ExecuteNonQuery();  //Problema en esta linea, da fallo de conexion
                con.Close();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexion");
            }
        }

        public void ActualizarCuota(Apuesta a)
        {
            double probOver;
            double probUnder;
            double dineroOver = a.DinieroApostado;
            double dineroUnder = a.DinieroApostado;
            double cuotaOver;
            double cuotaUnder;

            MySqlConnection con = Connect();
            MySqlCommand comOver = con.CreateCommand();
            MySqlCommand comUnder = con.CreateCommand();
            MySqlCommand updateCuota = con.CreateCommand();
            comOver.CommandText = "select dineroover from mercados where idmercado is '" + a.Mercado + "'";
            comUnder.CommandText = "select dinerounder from mercados where idmercado is '" + a.Mercado +"'";

            try
            {
                con.Open();
                dineroOver =+ double.Parse(comOver.ExecuteReader().ToString());
                dineroUnder =+ double.Parse(comUnder.ExecuteReader().ToString());
                con.Close();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexion");
            }

            probOver = dineroOver / (dineroOver + dineroUnder);
            probUnder = dineroUnder / (dineroOver + dineroUnder);

            cuotaOver = 1 / probOver * 0.95;
            cuotaUnder = 1 / probUnder * 0.95;

            comOver.CommandText = "update mercados set cuotaover='" + cuotaOver + "', cuotaunder='" + cuotaUnder + "', dineroover='" + dineroOver + "', dinerounder='" + dineroUnder + "'";
            comUnder.CommandText = "select dinerounder from mercados where idmercado is '" + a.Mercado + "'";

            try
            {
                con.Open();
                comOver.ExecuteReader();
                comUnder.ExecuteReader();
                con.Close();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexion");
            }

        }
    }
}