using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionWeb.Models
{
    public class Apuesta
    {
        public Apuesta()
        {
        }

        public Apuesta(int idApuesta, int mercado, string tipoApuesta, double cuota, double dinieroApostado, string fecha, int usuarioId, int eventoId)
        {
            ApuestaId = idApuesta;
            Mercado = mercado;
            TipoApuesta = tipoApuesta;
            Cuota = cuota;
            DinieroApostado = dinieroApostado;
            Fecha = fecha;
            UsuarioId = usuarioId;
            EventoId = eventoId;
        }

        public int ApuestaId { get; set; }
        public int Mercado { get; set; }
        public string TipoApuesta { get; set; }
        public double Cuota { get; set; }
        public double DinieroApostado { get; set; }
        public string Fecha { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }

    }
    public class ApuestaDTO
    {
        public ApuestaDTO(string tipoApuesta, double dineroApostado, string nombre)
        {
            TipoApuesta = tipoApuesta;
            DineroApostado = dineroApostado;
            Nombre = nombre;
        }

        public string TipoApuesta { get; set; }
        public double DineroApostado { get; set; }
        public string Nombre { get; set; }
    }

    /***EJERCICIO 2 ***/
    public class ApuestaDTO2
    {
        public ApuestaDTO2(string tipoApuesta, string eLocal, string eVisitante)
        {
            TipoApuesta = tipoApuesta;
            EquipoLocal = eLocal;
            EquipoVisitante = eVisitante;
        }

        public string TipoApuesta { get; set; }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
    }
    /*** EJERCICIO 2 ***/

    public class ApuestaDTO3
    {
        public ApuestaDTO3(double tipoMercado, string tipoApuesta, double cuota, double dinieroApostado)
        {
            TipoMercado = tipoMercado;
            TipoApuesta = tipoApuesta;
            Cuota = cuota;
            DinieroApostado = dinieroApostado;
        }

        public double TipoMercado { get; set; }
        public string TipoApuesta { get; set; }
        public double Cuota { get; set; }
        public double DinieroApostado { get; set; }
    }
}