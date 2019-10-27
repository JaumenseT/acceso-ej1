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
    public class MercadosController : ApiController
    {
        // GET: api/Mercados
        public IEnumerable<Mercado> Get()
        {
            MercadosRepository rep = new MercadosRepository();
            return rep.RetrieveAll();
        }

        public IEnumerable<Mercado> Get(int id) {
            MercadosRepository rep = new MercadosRepository();
            return rep.RetrieveByEvento(id);
        }

        

        // POST: api/Mercados
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mercados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercados/5
        public void Delete(int id)
        {
        }
    }
}
