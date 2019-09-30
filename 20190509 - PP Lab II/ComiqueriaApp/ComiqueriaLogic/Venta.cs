using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    public sealed class Venta
    {
        private DateTime fecha;
        private static int porcentajeIva;
        private double precioFinal;
        private Producto producto;

        internal DateTime Fecha
        {
            get
            {
                return this.fecha;
            }
        }

        static Venta()
        {
            Venta.porcentajeIva = 21;
        }
        internal Venta(Producto producto, int cantidad)
        {
            this.producto = producto;
            this.Vender(cantidad);
        }

        public static double CalcularPrecioFinal(double precioUnidad, int cantidad)
        {
            double precioSinIva, precioConIva;
            precioSinIva = precioUnidad * cantidad;
            precioConIva = ((precioSinIva / 100) * Venta.porcentajeIva) + precioSinIva;
            return precioConIva;
        }
        private void Vender(int cantidad)
        {
            this.producto.Stock = this.producto.Stock - cantidad;
            this.fecha = DateTime.Now;
            this.precioFinal = Venta.CalcularPrecioFinal(this.producto.Precio, cantidad);
        }
        public string ObtenerDescripcionBreve()
        {
            StringBuilder descrpcion = new StringBuilder();
            descrpcion.AppendFormat("{0} - {1} - {2}",
                this.Fecha.ToString(), this.producto.Descripcion, this.precioFinal.ToString("N2"));
            return descrpcion.ToString();
        }
        internal static int OrdenarPorFecha(Venta v1, Venta v2)
        {
            return DateTime.Compare(v1.Fecha, v2.Fecha);
        }
    }
}
