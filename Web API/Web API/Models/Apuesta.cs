using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionWeb.Models
{
    public class Apuesta
    {
        public Apuesta(int idApuesta, int mercado, string tipoApuesta, double cuota, double dinieroApostado, string fecha, int refEvento, string refUsuario)
        {
            IdApuesta = idApuesta;
            Mercado = mercado;
            TipoApuesta = tipoApuesta;
            Cuota = cuota;
            DinieroApostado = dinieroApostado;
            Fecha = fecha;
            RefEvento = refEvento;
            RefUsuario = refUsuario;
        }

        public int IdApuesta { get; set; }
        public int Mercado { get; set; }
        public string TipoApuesta { get; set; }
        public double Cuota { get; set; }
        public double DinieroApostado { get; set; }
        public string Fecha { get; set; }
        public int RefEvento { get; set; }
        public string RefUsuario { get; set; }
    }
    public class ApuestaDTO
    {
        public ApuestaDTO(int mercado, string tipoApuesta, double cuota, double dinieroApostado, string fecha, string refUsuario)
        {
            Mercado = mercado;
            TipoApuesta = tipoApuesta;
            Cuota = cuota;
            DinieroApostado = dinieroApostado;
            Fecha = fecha;
            RefUsuario = refUsuario;
        }

        public int Mercado { get; set; }
        public string TipoApuesta { get; set; }
        public double Cuota { get; set; }
        public double DinieroApostado { get; set; }
        public string Fecha { get; set; }
        public string RefUsuario { get; set; }
    }
}