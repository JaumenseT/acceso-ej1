using PlaceMyBet.Models;
using PlaceMyBet.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        [Authorize(Roles = "Admin")]
        public IEnumerable<Apuesta> Get()
        {
            ApuestasRepository rep = new ApuestasRepository();
            return rep.RetrieveAll();
        }

        public IEnumerable<Apuesta> Get(string email) {
            ApuestasRepository rep = new ApuestasRepository();
            return rep.RetrieveByEmail(email);
        }

        public IEnumerable<Apuesta> GetMercado(int idMercado) {
            ApuestasRepository rep = new ApuestasRepository();
            return rep.RetrieveByMercado(idMercado);
        }

        // GET: api/Apuestas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Apuestas
        [Authorize]
        public string Post([FromBody]Apuesta a)
        {
            ApuestasRepository rep = new ApuestasRepository();
            MercadosRepository repMer = new MercadosRepository();
            Mercado mer = repMer.Retrieve(a.IdMercado);
            a.Cuota = a.TipoApuesta == 'A' ? mer.CuotaOver : mer.CuotaUnder;
            mer.RecalculaCuotas(a.TipoApuesta, a.DineroApostado);
            repMer.Save(mer);
            rep.Save(a);
            return "OK";
        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}
