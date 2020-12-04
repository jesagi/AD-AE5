using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_API.Models;

namespace AplicacionWeb.Models
{
    public class Usuario
    {
        public Usuario()
        {
        }

        public Usuario(int usuarioId, string nombre, string apellidos, int edad)
        {
            UsuarioId = usuarioId;
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
        }

        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public Cuenta Cuenta { get; set; }
        public List<Apuesta> Apuesta { get; set; }

    }
}