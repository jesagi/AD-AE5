using AplicacionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API.Models;

namespace Web_API.Controllers
{
    public class MercadosController : ApiController
    {
        // GET: api/Mercados
        public IEnumerable<MercadoDTO> Get()
        {
            var repo = new MercadosRepository();
            List<MercadoDTO> mercados = repo.RetrieveDTO();
            return mercados;
        }

        // GET: api/Mercados?id=valor1
        public IEnumerable<Mercado> Get(int id)
        {
            var repo = new MercadosRepository();
            List<Mercado> mercados = repo.RetrieveById(id);
            return mercados;
        }

        // POST: api/Mercados
        public void Post([FromBody]Mercado mercado)
        {
            var repo = new MercadosRepository();
            repo.Save(mercado);
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
