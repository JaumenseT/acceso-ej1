using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlaceMyBet.Models;

namespace PlaceMyBet.Repositories {
    public class EventosRepository {
        internal Evento[] RetrieveAll() {
            MySqlConnection con = Database.GetConnection();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "Select * from evento";

            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            List<Evento> resultado = new List<Evento>();
            
            while (reader.Read()) {
                resultado.Add(new Evento(reader.GetInt32("idEvento"), reader.GetDateTime("fechaEvento"),
                    reader.GetInt32("idLocal"), reader.GetInt32("idVisitante")));
            }
            con.Close();
            return resultado.ToArray();
        }
    }
}