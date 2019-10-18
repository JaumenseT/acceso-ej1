using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models {
    public class Evento {
        public Evento(int idEvento, DateTime fechaEvento, int idLocal, int idVisitante)
        {
            this.idEvento = idEvento;
            this.fechaEvento = fechaEvento;
            this.idLocal = idLocal;
            this.idVisitante = idVisitante;
        }

        public int idEvento { get; set; }
        public DateTime fechaEvento { get; set; }
        public int idLocal { get; set; }
        public int idVisitante { get; set; }
    }

}