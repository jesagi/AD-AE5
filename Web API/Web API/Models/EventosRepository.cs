using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Diagnostics;

namespace AplicacionWeb.Models
{
    public class EventosRepository
    {
        private MySqlConnection Connect()
        {
            string constring = "Server=127.0.0.1;Port=3306;Database=placemybet;uid=root;password=;sslMode=none";
            MySqlConnection con = new MySqlConnection(constring);
            return con;
        }

        internal List<Evento> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Eventos";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Evento e = null;
                List<Evento> eventos = new List<Evento>();

                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetInt32(3) + " " + res.GetString(4));
                    e = new Evento(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetInt32(3), res.GetString(4));
                    eventos.Add(e);
                }

                con.Close();
                return eventos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error de conexion");
                return null;
            }
            
        }
    }
}