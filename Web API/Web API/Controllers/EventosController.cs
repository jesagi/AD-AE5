using AplicacionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web_API.Controllers
{
    public class EventosController : ApiController
    {
        // GET: api/Eventos
        public IEnumerable<EventoDTO> Get()
        {
            var repo = new EventosRepository();
            List<EventoDTO> eventos = repo.RetrieveDTO();
            return eventos;
        }

        // GET: api/Eventos/5
        public Evento Get(int id)
        {
            return null;
        }

        // POST: api/Eventos
        public void Post([FromBody]Evento evento)
        {
            var repo = new EventosRepository();
            repo.Save(evento);
        }

        // PUT: api/Eventos?id=value1&eLocal=value2&eVisitatne=value3
        public void Put(int id, string eLocal, string eVisitante)
        {
            var repo = new EventosRepository();
            repo.ActualizarEquipos(id, eLocal, eVisitante);
        }

        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
            var repo = new EventosRepository();
            repo.BorrarEvento(id);
        }
    }
}
