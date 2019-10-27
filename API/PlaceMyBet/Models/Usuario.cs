using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models {
    public class Usuario {
        public Usuario(int idUsuario, string nombre, string apellidos, int edad, string email) {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
            Email = email;
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
    }
}