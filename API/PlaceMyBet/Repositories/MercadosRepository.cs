using MySql.Data.MySqlClient;
using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Repositories {
    public class MercadosRepository {
        internal Mercado[] RetrieveAll() {
            MySqlConnection con = Database.GetConnection();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "Select * from mercado";

            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            List<Mercado> resultado = new List<Mercado>();

            while (reader.Read())
            {
                resultado.Add(Read(reader));
            }
            con.Close();
            return resultado.ToArray();
        }

        internal Mercado Retrieve(int idMercado) {
            MySqlConnection con = Database.GetConnection();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "Select * from mercado where idMercado = @idMercado";
            command.Parameters.AddWithValue("@idMercado", idMercado);

            con.Open();
            Mercado m = null;
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read()) {
                m = Read(reader);
            }
            con.Close();
            return m;

        }

        private Mercado Read(MySqlDataReader reader) {
            return new Mercado(reader.GetInt32("idMercado"), reader.GetDouble("tipoMercado"),
                    reader.GetDouble("cuotaOver"), reader.GetDouble("cuotaUnder"), reader.GetDouble("apuestaOver"),
                    reader.GetDouble("apuestaUnder"), reader.GetInt32("idEvento"));
        }

        public void Save(Mercado mer) {
            MySqlConnection con = Database.GetConnection();
            MySqlCommand command = con.CreateCommand();
            if (mer.IdMercado == 0) {
                command.CommandText = "insert into apuesta(tipoMercado, cuotaOver, cuotaUnder, apuestaOver, apuestaUnder, idEvento) values" +
            "(@tipoMercado, @cuotaOver, @cuotaUnder, @apuestaOver, @apuestaUnder, @idEvento)";
                command.Parameters.AddWithValue("tipoMercado", mer.TipoMercado);
                command.Parameters.AddWithValue("cuotaOver", mer.CuotaOver);
                command.Parameters.AddWithValue("cuotaUnder", mer.CuotaUnder);
                command.Parameters.AddWithValue("apuestaOver", mer.ApuestaOver);
                command.Parameters.AddWithValue("apuestaUnder", mer.ApuestaUnder);
                command.Parameters.AddWithValue("idEvento", mer.IdEvento);
            } else {
                command.CommandText = "update mercado set tipoMercado = @tipoMercado, cuotaOver = @cuotaOver, cuotaUnder = @cuotaUnder, " +
            "apuestaOver = @apuestaOver, apuestaUnder = @apuestaUnder, idEvento = @idEvento where idMercado = @idMercado";
                command.Parameters.AddWithValue("idMercado", mer.IdMercado);
                command.Parameters.AddWithValue("tipoMercado", mer.TipoMercado);
                command.Parameters.AddWithValue("cuotaOver", mer.CuotaOver);
                command.Parameters.AddWithValue("cuotaUnder", mer.CuotaUnder);
                command.Parameters.AddWithValue("apuestaOver", mer.ApuestaOver);
                command.Parameters.AddWithValue("apuestaUnder", mer.ApuestaUnder);
                command.Parameters.AddWithValue("idEvento", mer.IdEvento);
            }
            
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