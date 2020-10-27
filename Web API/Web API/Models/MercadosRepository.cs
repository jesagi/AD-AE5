using AplicacionWeb.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Web_API.Models
{
    public class MercadosRepository
    {
        private MySqlConnection Connect()
        {
            string constring = "Server=127.0.0.1;Port=3306;Database=placemybet;uid=root;password=;sslMode=none";
            MySqlConnection con = new MySqlConnection(constring);
            return con;
        }

        internal List<Mercado> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Mercados";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Mercado m = null;
                List<Mercado> mercados = new List<Mercado>();

                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetDouble(5));
                    m = new Mercado(res.GetInt32(0), res.GetInt32(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5), res.GetDouble(6));
                    mercados.Add(m);
                }

                con.Close();
                return mercados;
            }
            catch (MySqlException m)
            {
                Debug.WriteLine("Error de conexion");
                return null;
            }

        }

        internal List<MercadoDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Mercados";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                MercadoDTO m = null;
                List<MercadoDTO> mercados = new List<MercadoDTO>();

                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + " " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3));
                    m = new MercadoDTO(res.GetDouble(1), res.GetDouble(2), res.GetDouble(3));
                    mercados.Add(m);
                }

                con.Close();
                return mercados;
            }
            catch (MySqlException m)
            {
                Debug.WriteLine("Error de conexion");
                return null;
            }

        }
        internal List<Mercado> RetrievebyEventoMercado(int refevento, double tipomercado)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Mercados where refevento = @A and tipomercado = @A2";
            command.Parameters.AddWithValue("@A", refevento);
            command.Parameters.AddWithValue("@A2", tipomercado);

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Mercado m = null;
                List<Mercado> mercados = new List<Mercado>();

                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetDouble(5) + " " + res.GetDouble(6));
                    m = new Mercado(res.GetInt32(0), res.GetInt32(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5), res.GetDouble(6));
                    mercados.Add(m);
                }

                con.Close();
                return mercados;
            }
            catch (MySqlException m)
            {
                Debug.WriteLine("Error de conexion");
                return null;
            }

        }

    }
}