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
            command.CommandText = "select idEvento, fechaEvento, e1.Nombre as nomLocal, e2.Nombre as nomVisitante from evento," +
                " equipo e1, equipo e2 where evento.idLocal = e1.idEquipo and evento.idVisitante = e2.idEquipo;";

            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            List<Evento> resultado = new List<Evento>();
            
            while (reader.Read()) {
                resultado.Add(new Evento(reader.GetInt32("idEvento"), reader.GetDateTime("fechaEvento"),
                    reader.GetString("nomLocal"), reader.GetString("nomVisitante")));
            }
            con.Close();
            return resultado.ToArray();
        }
    }
}