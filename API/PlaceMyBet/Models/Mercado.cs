using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models {
    public class Mercado {
        public Mercado(int idMercado, double tipoMercado, double cuotaOver, double cuotaUnder, double apuestaOver, double apuestaUnder, int idEvento)
        {
            this.IdMercado = idMercado;
            this.TipoMercado = tipoMercado;
            this.CuotaOver = cuotaOver;
            this.CuotaUnder = cuotaUnder;
            this.ApuestaOver = apuestaOver;
            this.ApuestaUnder = apuestaUnder;
            this.IdEvento = idEvento;
        }

        public int IdMercado { get; set; }
        public double TipoMercado { get; set; }
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }
        public double ApuestaOver { get; set; }
        public double ApuestaUnder { get; set; }
        public int IdEvento { get; set; }

        public void RecalculaCuotas(char tipoApuesta, double dineroApostado) {
            if (tipoApuesta == 'A') {
                ApuestaOver += dineroApostado;
            } else {
                ApuestaUnder += dineroApostado;
            }

            double propabilidadOver = ApuestaOver / (ApuestaOver + ApuestaUnder);
            double propabilidadUnder = ApuestaUnder / (ApuestaUnder + ApuestaOver);

            CuotaOver = (1 / propabilidadOver) * 0.95;
            CuotaUnder = (1 / propabilidadUnder) * 0.95;
        }
    }
}