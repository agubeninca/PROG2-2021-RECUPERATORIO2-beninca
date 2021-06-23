using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Usuario
    {
        public string NombreApellido { get; set; }
        public string DNI { get; set; }
        public decimal Saldo { get; set; }
        public List<Movimiento> ListaMovimientos { get; set; }
    }
}
