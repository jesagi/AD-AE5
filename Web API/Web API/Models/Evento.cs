using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionWeb.Models
{
    public class Evento
    {
        public Evento(int idEvento, string equipoLocal, string equipoVisitante, int refMercado, string fecha)
        {
            IdEvento = idEvento;
            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
            RefMercado = refMercado;
            Fecha = fecha;
        }

        public int IdEvento { get; set; }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public int RefMercado { get; set; }
        public string Fecha { get; set; }
    }

    public class EventoDTO
    {
        public EventoDTO(string equipoLocal, string equipoVisitante, string fecha)
        {
            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
            Fecha = fecha;
        }

        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public string Fecha { get; set; }
    }
}