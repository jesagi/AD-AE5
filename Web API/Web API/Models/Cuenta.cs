using AplicacionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_API.Models
{
    public class Cuenta
    {
        public Cuenta()
        {
        }

        public Cuenta(int cuentaId, double saldo, string nombreBanco, int usuarioId)
        {
            CuentaId = cuentaId;
            Saldo = saldo;
            NombreBanco = nombreBanco;
            UsuarioId = usuarioId;
        }

        public int CuentaId { get; set; }
        public double Saldo { get; set; }
        public string NombreBanco { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}