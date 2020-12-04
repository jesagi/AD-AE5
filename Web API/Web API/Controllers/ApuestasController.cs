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
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        public IEnumerable<Apuesta> Get()
        {
            var repo = new ApuestasRepository();
            List<Apuesta> apuestas = repo.Retrieve();
            return apuestas;
        }

        // GET: api/Apuestas?id=value1
        public IEnumerable<Apuesta> Get(int id)
        {
            var repo = new ApuestasRepository();
            List<Apuesta> apuesta = repo.RetrieveById(id);
            return apuesta;
        }

        // GET: api/Apuestas?idmercado=value1&emailusuario=value2
        [Authorize(Roles = "Admin")]
        public IEnumerable<ApuestaDTO3> Get(int mercado, string emailusuario)
        {
            var repo = new ApuestasRepository();
            List<ApuestaDTO3> apuesta = repo.RetrievebyMercadoUsuario(mercado, emailusuario);
            return apuesta;
        }

        // POST: api/Apuestas
        public void Post([FromBody]Apuesta apuesta)
        {
            var repo = new ApuestasRepository();
            repo.Save(apuesta);
            //repo.ActualizarCuota(apuesta);
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
