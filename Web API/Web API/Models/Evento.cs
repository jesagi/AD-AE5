using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionWeb.Models
{
    public class Evento
    {
        public Evento()
        {
        }

        public Evento(int idEvento, string equipoLocal, string equipoVisitante, string fecha)
        {
            EventoId = idEvento;
            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
            Fecha = fecha;
        }

        public int EventoId { get; set; }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public string Fecha { get; set; }
        public Mercado Mercado { get; set; }
        public List<Apuesta> Apuestas { get; set; }
    }

    public class EventoDTO
    {
        public EventoDTO(string equipoLocal, string equipoVisitante)
        {
            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
        }

        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
    }
}