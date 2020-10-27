using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionWeb.Models
{
    public class Mercado
    {
        public Mercado(int idMercado, int refEvento, double tipoMercado, double cuotaUnder, double cuotaOver, double dineroOver, double dineroUnder)
        {
            IdMercado = idMercado;
            RefEvento = refEvento;
            TipoMercado = tipoMercado;
            CuotaUnder = cuotaUnder;
            CuotaOver = cuotaOver;
            DineroOver = dineroOver;
            DineroUnder = dineroUnder;
        }

        public int IdMercado { get; set; }
        public int RefEvento { get; set; }
        public double TipoMercado { get; set; }
        public double CuotaUnder { get; set; }
        public double CuotaOver { get; set; }
        public double DineroOver { get; set; }
        public double DineroUnder { get; set; }
    }

    public class MercadoDTO
    {
        public MercadoDTO(double tipoMercado, double cuotaUnder, double cuotaOver)
        {
            TipoMercado = tipoMercado;
            CuotaUnder = cuotaUnder;
            CuotaOver = cuotaOver;
        }

        public double TipoMercado { get; set; }
        public double CuotaUnder { get; set; }
        public double CuotaOver { get; set; }
    }
}