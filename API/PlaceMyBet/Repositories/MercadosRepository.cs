using MySql.Data.MySqlClient;
using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Repositories {
    public class MercadosRepository {
        internal Mercado[] RetrieveAll()
        {
            MySqlConnection con = Database.GetConnection();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "Select * from mercado";

            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            List<Mercado> resultado = new List<Mercado>();

            while (reader.Read())
            {
                resultado.Add(new Mercado(reader.GetInt32("idMercado"), reader.GetDouble("tipoMercado"),
                    reader.GetDouble("cuotaOver"), reader.GetDouble("cuotaUnder"), reader.GetDouble("apuestaOver"),
                    reader.GetDouble("apuestaUnder"), reader.GetInt32("idEvento")));
            }
            con.Close();
            return resultado.ToArray();
        }
    }
}