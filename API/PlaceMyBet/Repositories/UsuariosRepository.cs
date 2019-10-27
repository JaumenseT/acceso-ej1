using MySql.Data.MySqlClient;
using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Repositories {
    public class UsuariosRepository {
        internal void Save(Usuario u) {
            MySqlConnection con = Database.GetConnection();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert into usuario(nombre, apellidos, edad, email) values" +
            "(@nombre, @apellidos, @edad, @email)";
            command.Parameters.AddWithValue("nombre", u.Nombre);
            command.Parameters.AddWithValue("apellidos", u.Apellidos);
            command.Parameters.AddWithValue("edad", u.Edad);
            command.Parameters.AddWithValue("email", u.Email);
            Debug.WriteLine("comando" + command.CommandText);
            try {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            } catch (MySqlException e) {
                Debug.WriteLine("Se ha producido un error de conexion");
            }
        }
    }
}