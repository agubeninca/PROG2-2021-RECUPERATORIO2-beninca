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
        //PODRIA USAR UNA CLASE REQUEST PARA NO RECIBIR LOS PARAMETROS POR SEPARADO
        public IHttpActionResult Post(string dni1, string dni2, string descripcion, decimal monto)
        {
            //DEBERIA CREAR UNA CLASE PARA PASAR A LA LOGICA DE NEGOCIO Y NO LOS PARAMETROS POR SEPARADO
            Resultado movimiento = aplicacion.ComprobarNuevoMovimiento(dni1, dni1, descripcion, monto);

            if (movimiento != null)
            {
                return Content(HttpStatusCode.Created, "");
            }

            //DEBERIA RETORNAR EL MOTIVO DEL BADREQUEST AL CLIENTE
            return Content(HttpStatusCode.BadRequest, "");
        }

        // PUT: api/Movimiento/5
        //PUEDE ELIMINARSE SI NO ES NECESARIO
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
