using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models {
    public class Apuesta {
        public Apuesta(int idApuesta, char tipoApuesta, double cuota, double dineroApostado, int idMercado, int idUsuario, double tipoMercado, string emailUsuario, int idEvento)
        {
            this.IdApuesta = idApuesta;
            this.TipoApuesta = tipoApuesta;
            this.Cuota = cuota;
            this.DineroApostado = dineroApostado;
            this.IdMercado = idMercado;
            this.IdUsuario = idUsuario;
            this.TipoMercado = tipoMercado;
            this.EmailUsuario = emailUsuario;
            this.IdEvento = idEvento;
        }

        public int IdApuesta { get; set; }
        public char TipoApuesta { get; set; }
        public double Cuota { get; set; }
        public double DineroApostado { get; set; }
        public int IdMercado { get; set; }
        public int IdUsuario { get; set; }
        public double TipoMercado { get; set; }
        public string EmailUsuario { get; set; }
        public int IdEvento { get; set; }
    }
}