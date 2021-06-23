using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Movimiento
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }

        public Movimiento(string descripcion, decimal monto)
        {
            this.Descripcion = descripcion;
            this.Monto = monto;
            Random nro = new Random();
            this.ID = nro.Next(1, 999999);
            this.Fecha = DateTime.Today.Date;
        }
    }
}
