using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionWeb.Models
{
    public class Mercado
    {
        public Mercado(int idMercado, double tipoMercado, double cuotaUnder, double dineroOver, double dineroUnder)
        {
            IdMercado = idMercado;
            TipoMercado = tipoMercado;
            CuotaUnder = cuotaUnder;
            DineroOver = dineroOver;
            DineroUnder = dineroUnder;
        }

        public int IdMercado { get; set; }
        public double TipoMercado { get; set; }
        public double CuotaUnder { get; set; }
        public double DineroOver { get; set; }
        public double DineroUnder { get; set; }
    }
}