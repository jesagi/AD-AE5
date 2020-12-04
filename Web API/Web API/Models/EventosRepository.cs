using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WebApplication2.Models;

namespace AplicacionWeb.Models
{
    public class EventosRepository
    {
        /*
        private MySqlConnection Connect()
        {
            string constring = "Server=127.0.0.1;Port=3306;Database=placemybet;uid=root;password=;sslMode=none";
            MySqlConnection con = new MySqlConnection(constring);
            return con;
        }
        */
        public static EventoDTO ToDTO(Evento e) {
            return new EventoDTO(e.EquipoLocal, e.EquipoVisitante);
        }

        internal List<Evento> Retrieve()
        {
            List<Evento> eventos = new List<Evento>();

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                eventos = context.Eventos.ToList();
            }

            return eventos;
            /*
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
            */
        }

        internal void ActualizarEquipos(int id, string eLocal, string eVisitante)
        {
            List<EventoDTO> eventos = new List<EventoDTO>();

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                var evento = context.Eventos.Single(e => e.EventoId == id );
                evento.EquipoLocal = eLocal;
                evento.EquipoVisitante = eVisitante;
                context.SaveChanges();
            }
        }

        internal void Save(Evento e)
        {
            using (var context = new PlaceMyBetContext())
            {
                context.Eventos.Add(new Evento { EventoId = e.EventoId, EquipoLocal = e.EquipoLocal, EquipoVisitante = e.EquipoVisitante, Fecha = e.Fecha });
                context.SaveChanges();
            }
        }

        internal List<EventoDTO> RetrieveDTO()
        {
            List<EventoDTO> eventos = new List<EventoDTO>();

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                eventos = context.Eventos.Select(p => ToDTO(p)).ToList(); 
            }

            return eventos;
            /*
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Eventos";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                EventoDTO e = null;
                List<EventoDTO> eventos = new List<EventoDTO>();

                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetString(4));
                    e = new EventoDTO(res.GetString(1), res.GetString(2), res.GetString(4));
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
            */
        }


    }
}