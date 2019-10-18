using MySql.Data.MySqlClient;
using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Repositories {
    public class ApuestasRepository {
        internal Apuesta[] RetrieveAll()
        {
            MySqlConnection con = Database.GetConnection();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "Select * from apuesta";

            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            List<Apuesta> resultado = new List<Apuesta>();

            while (reader.Read()) {
                resultado.Add(new Apuesta(reader.GetInt32("idApuesta"), reader.GetChar("tipoApuesta"),
                    reader.GetDouble("cuota"), reader.GetDouble("dineroApostado"), reader.GetInt32("idMercado"),
                    reader.GetInt32("idUsuario")));
            }
            con.Close();
            return resultado.ToArray();
        }
    }
}