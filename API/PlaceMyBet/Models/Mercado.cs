using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models {
    public class Mercado {
        public Mercado(int idMercado, double tipoMercado, double cuotaOver, double cuotaUnder, double apuestaOver, double apuestaUnder, int idEvento)
        {
            this.idMercado = idMercado;
            this.tipoMercado = tipoMercado;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            this.apuestaOver = apuestaOver;
            this.apuestaUnder = apuestaUnder;
            this.idEvento = idEvento;
        }

        public int idMercado { get; set; }
        public double tipoMercado { get; set; }
        public double cuotaOver { get; set; }
        public double cuotaUnder { get; set; }
        public double apuestaOver { get; set; }
        public double apuestaUnder { get; set; }
        public int idEvento { get; set; }
    }
}