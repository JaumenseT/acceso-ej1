﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlaceMyBet.Models;
using PlaceMyBet.Repositories;

namespace PlaceMyBet.Controllers
{
    public class EventosController : ApiController
    {
        // GET: api/Eventos
        public IEnumerable<Evento> Get()
        {
            EventosRepository rep = new EventosRepository();
            return rep.RetrieveAll();
        }

        // GET: api/Eventos/5
        public string Get(int id)
        {
            return "value";
        }

        // GET: api/Eventos/5/Mercados

        // POST: api/Eventos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Eventos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
        }
    }
}
