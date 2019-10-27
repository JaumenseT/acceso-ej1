using MySql.Data.MySqlClient;
using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Repositories {
    public class ApuestasRepository {
        internal Apuesta[] RetrieveAll()
        {
            MySqlConnection con = Database.GetConnection();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "Select idApuesta, tipoApuesta, cuota, dineroApostado, apuesta.idMercado, apuesta.idUsuario, tipoMercado, email, idEvento from apuesta, mercado, usuario Where" +
            " apuesta.idMercado = Mercado.idMercado and apuesta.idUsuario = usuario.idUsuario;";

            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            List<Apuesta> resultado = new List<Apuesta>();

            while (reader.Read()) {
                resultado.Add(new Apuesta(reader.GetInt32("idApuesta"), reader.GetChar("tipoApuesta"),
                    reader.GetDouble("cuota"), reader.GetDouble("dineroApostado"), reader.GetInt32("idMercado"),
                    reader.GetInt32("idUsuario"), reader.GetDouble("tipoMercado"), reader.GetString("email"), reader.GetInt32("idEvento")));
            }
            con.Close();
            return resultado.ToArray();
        }

        internal IEnumerable<Apuesta> RetrieveByEmail(string email) {
            MySqlConnection con = Database.GetConnection();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "Select idApuesta, tipoApuesta, cuota, dineroApostado, apuesta.idMercado, apuesta.idUsuario, tipoMercado, email, idEvento from apuesta, mercado, usuario Where" +
            " apuesta.idMercado = Mercado.idMercado and apuesta.idUsuario = usuario.idUsuario and usuario.email = '" + email + "' order by idApuesta;";

            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            List<Apuesta> resultado = new List<Apuesta>();

            while (reader.Read()) {
                resultado.Add(new Apuesta(reader.GetInt32("idApuesta"), reader.GetChar("tipoApuesta"),
                    reader.GetDouble("cuota"), reader.GetDouble("dineroApostado"), reader.GetInt32("idMercado"),
                    reader.GetInt32("idUsuario"), reader.GetDouble("tipoMercado"), reader.GetString("email"), reader.GetInt32("idEvento")));
            }
            con.Close();
            return resultado.ToArray();
        }

        internal IEnumerable<Apuesta> RetrieveByMercado(int id) {
            MySqlConnection con = Database.GetConnection();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "Select idApuesta, tipoApuesta, cuota, dineroApostado, apuesta.idMercado, apuesta.idUsuario, tipoMercado, email, idEvento from apuesta, mercado, usuario Where" +
            " apuesta.idMercado = Mercado.idMercado and apuesta.idUsuario = usuario.idUsuario and apuesta.idMercado = " + id + " order by idApuesta;";

            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            List<Apuesta> resultado = new List<Apuesta>();

            while (reader.Read()) {
                resultado.Add(new Apuesta(reader.GetInt32("idApuesta"), reader.GetChar("tipoApuesta"),
                    reader.GetDouble("cuota"), reader.GetDouble("dineroApostado"), reader.GetInt32("idMercado"),
                    reader.GetInt32("idUsuario"), reader.GetDouble("tipoMercado"), reader.GetString("email"), reader.GetInt32("idEvento")));
            }
            con.Close();
            return resultado.ToArray();
        }

        internal void Save(Apuesta a)
        {
            MySqlConnection con = Database.GetConnection();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert into apuesta(tipoApuesta, cuota, dineroApostado, idMercado, idUsuario) values" +
            "(@tipoApuesta, @cuota, @dineroApostado, @idMercado, @idUsuario)";
            command.Parameters.AddWithValue("tipoApuesta", a.TipoApuesta);
            command.Parameters.AddWithValue("cuota", a.Cuota);
            command.Parameters.AddWithValue("dineroApostado", a.DineroApostado);
            command.Parameters.AddWithValue("idMercado", a.IdMercado);
            command.Parameters.AddWithValue("idUsuario", a.IdUsuario);
            Debug.WriteLine("comando" + command.CommandText);
            try {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException e) {
                Debug.WriteLine("Se ha producido un error de conexion");
            }
        }
    }
}