using AplicacionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_API.Models
{
    public class Cuenta
    {
        public int CuentaId { get; set; }
        public double Saldo { get; set; }
        public string NombreBanco { get; set; }
        public int UsuarioId { get; set; }
        public Usuario usuario { get; set; }
    }
}