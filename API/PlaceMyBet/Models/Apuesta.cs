using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models {
    public class Apuesta {
        public Apuesta(int idApuestea, char tipoApuesta, double cuota, double dineroApostado, int idMercado, int idUsuario)
        {
            this.idApuestea = idApuestea;
            this.tipoApuesta = tipoApuesta;
            this.cuota = cuota;
            this.dineroApostado = dineroApostado;
            this.idMercado = idMercado;
            this.idUsuario = idUsuario;
        }

        public int idApuestea { get; set; }
        public char tipoApuesta { get; set; }
        public double cuota { get; set; }
        public double dineroApostado { get; set; }
        public int idMercado { get; set; }
        public int idUsuario { get; set; }
    }
}