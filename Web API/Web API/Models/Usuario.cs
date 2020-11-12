using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_API.Models;

namespace AplicacionWeb.Models
{
    public class Usuario
    {
        public Usuario(string usuarioId, string nombre, string apellidos, int edad, int refCuentaBancaria)
        {
            UsuarioId = usuarioId;
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
            RefCuentaBancaria = refCuentaBancaria;
        }

        public string UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public int RefCuentaBancaria { get; set; }
        public Cuenta cuenta { get; set; }
        public List<Apuesta> Apuesta { get; set; }
    }