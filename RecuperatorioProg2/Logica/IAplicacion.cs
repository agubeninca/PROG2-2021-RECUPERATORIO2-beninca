using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public interface IAplicacion
    {
        Resultado ComprobarNuevoMovimiento(string dni1, string dni2, string descripcion, decimal monto);
        Resultado CancelarMovimientoPorID(int id1, int id2);
        List<Movimiento> ObtenerListaMovimientosPorDNI(string dni);
        Usuario BuscarXDni(string dni);

    }
}
