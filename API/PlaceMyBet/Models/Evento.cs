using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models {
    public class Evento {
        public Evento(int idEvento, DateTime fechaEvento, string local, string visitante)
        {
            this.IdEvento = idEvento;
            this.FechaEvento = fechaEvento;
            this.Local = local;
            this.Visitante = visitante;
        }

        public int IdEvento { get; set; }
        public DateTime FechaEvento { get; set; }
        public string Local { get; set; }
        public string Visitante { get; set; }
    }

}