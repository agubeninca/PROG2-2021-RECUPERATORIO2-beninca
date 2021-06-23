using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logica;

namespace RecuperatorioProg2.Controllers
{
    public class MovimientoController : ApiController
    {
        public IAplicacion aplicacion { get; set; }
        public MovimientoController(IAplicacion aplicaion)
        {
            this.aplicacion = aplicacion ?? Aplicacion.Instance;
        }

        // GET: api/Movimiento
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Movimiento/5
        public IHttpActionResult Get(string dni)
        {
            List<Movimiento> lista = aplicacion.ObtenerListaMovimientosPorDNI(dni);
            if (lista != null)
                return Ok(lista);
            else
                return NotFound();
        }

        // POST: api/Movimiento
        public IHttpActionResult Post(string dni1, string dni2, string descripcion, decimal monto)
        {
            Resultado movimiento = aplicacion.ComprobarNuevoMovimiento(dni1, dni1, descripcion, monto);
            if (movimiento != null)
            {
                return Content(HttpStatusCode.Created, "");
            }
            return Content(HttpStatusCode.BadRequest, "");
        }

        // PUT: api/Movimiento/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Movimiento/5
        public IHttpActionResult Delete(int id1, int id2)
        {
            Resultado movimiento = aplicacion.CancelarMovimientoPorID(id1, id2);
            if (movimiento == null)
                return Content(HttpStatusCode.NotFound, movimiento);
            else
                return Ok(movimiento);
        }
    }
}
