using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Aplicacion:IAplicacion
    {
        public List<Usuario> Usuarios { get; set; }
        public List<Movimiento> Movimientos { get; set; }

        private readonly static Aplicacion instance_ = new Aplicacion();
        private Aplicacion()
        {
            if (Usuarios==null)
                Usuarios=new List<Usuario>();
            if (Movimientos == null)
                Usuarios = new List<Usuario>();
        }
        public static Aplicacion Instance
        {
            get
            {
                return instance_;
            }
        }

        public Resultado ComprobarNuevoMovimiento(string dni1, string dni2, string descripcion, decimal monto)
        {
            Usuario usuario1 = BuscarXDni(dni1);
            Usuario usuario2 = BuscarXDni(dni2);
            if (usuario1==null || usuario2==null)
                return new Resultado("Error, no se encontro el usuario.", false);
            if (usuario1.Saldo>=monto)
            {
                usuario1.Saldo += monto;
                usuario2.Saldo -= monto;

                Movimiento nuevoMovimiento1 = new Movimiento(descripcion, (usuario1.Saldo + monto));
                Movimiento nuevoMovimiento2 = new Movimiento(descripcion, (usuario2.Saldo - monto));
                usuario1.ListaMovimientos.Add(nuevoMovimiento1);
                usuario2.ListaMovimientos.Add(nuevoMovimiento2);
                Movimientos.Add(nuevoMovimiento1);
                Movimientos.Add(nuevoMovimiento2);
                return new Resultado(true, "Se realizo el movimiento.");
            }
            return new Resultado("Saldo insuficiente.", false);
        }

        public Resultado CancelarMovimientoPorID(int id1, int id2)
        {
            Movimiento movimiento1 = Movimientos.Find(x => x.ID == id1);
            Movimiento movimiento2 = Movimientos.Find(x => x.ID == id2);
            if (movimiento1 != null&& movimiento2 != null)
            {
                movimiento1 = new Movimiento($"CANCELACION: {movimiento1.Descripcion}", movimiento1.Monto * -1);
                movimiento2 = new Movimiento($"CANCELACION: {movimiento2.Descripcion}", movimiento2.Monto * -1);
                Movimientos.Add(movimiento1);
                Movimientos.Add(movimiento2);
                return new Resultado(true, "Movimiento cancelado.");
            }
            return new Resultado("No se pudo realizar el movimiento.", false);
        }

        public List<Movimiento> ObtenerListaMovimientosPorDNI(string dni)
        {
            Usuario usuarioEncontrado = BuscarXDni(dni);
            if (usuarioEncontrado == null)
                return null;
            else
            {
                usuarioEncontrado.ListaMovimientos.OrderByDescending(x => x.Fecha);
                return usuarioEncontrado.ListaMovimientos;
            }
        }
        public Usuario BuscarXDni(string dni)
        {
            if (Usuarios.Find(x => x.DNI == dni) == null)
                return null;
            else
                return Usuarios.Find(x => x.DNI == dni);
        }

    }
}
