using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionWeb.Models
{
    public class Apuesta
    {
        public Apuesta(int idApuesta, int mercado, string tipoApuesta, double cuota, double dinieroApostado, string fecha, int refEvento, string usuarioId)
        {
            IdApuesta = idApuesta;
            Mercado = mercado;
            TipoApuesta = tipoApuesta;
            Cuota = cuota;
            DinieroApostado = dinieroApostado;
            Fecha = fecha;
            RefEvento = refEvento;
            UsuarioId = usuarioId;
        }

        public int IdApuesta { get; set; }
        public int Mercado { get; set; }
        public string TipoApuesta { get; set; }
        public double Cuota { get; set; }
        public double DinieroApostado { get; set; }
        public string Fecha { get; set; }
        public int RefEvento { get; set; }
        public string UsuarioId { get; set; }
        public Usuario usuario { get; set; }
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

    public class ApuestaDTO2
    {
        public ApuestaDTO2(string tipoApuesta, double cuota, double dinieroApostado, int refEvento)
        {
            TipoApuesta = tipoApuesta;
            Cuota = cuota;
            DinieroApostado = dinieroApostado;
            RefEvento = refEvento;
        }

        public string TipoApuesta { get; set; }
        public double Cuota { get; set; }
        public double DinieroApostado { get; set; }
        public int RefEvento { get; set; }
    }

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