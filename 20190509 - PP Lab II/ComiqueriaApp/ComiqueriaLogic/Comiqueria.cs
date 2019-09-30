using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    public class Comiqueria
    {
        private List<Producto> productos;
        private List<Venta> ventas;

        public Producto this[Guid codigo]
        {
            get
            {
                Producto retorno = null;
                foreach(Producto prod in this.productos)
                {
                    if (codigo == (Guid)prod)
                    {
                        retorno = prod;
                        break;
                    }
                }
                return retorno;
            }
        }

        public Comiqueria()
        {
            this.productos = new List<Producto>();
            this.ventas = new List<Venta>();
        }

        public void Vender(Producto producto, int cantidad)
        {
            Venta venta = new Venta(producto, cantidad);
            this.ventas.Add(venta);
        }
        public void Vender(Producto producto)
        {
            this.Vender(producto, 1);
        }
        public Dictionary<Guid,string>ListarProductos()
        {
            Dictionary<Guid, string> diccionario = new Dictionary<Guid, string>();
            foreach(Producto prod in this.productos)
            {
                diccionario.Add((Guid)prod, prod.ToString());
            }
            return diccionario;
        }
        public string ListarVentas()
        {
            this.ventas.Sort(Venta.OrdenarPorFecha);
            StringBuilder ventas = new StringBuilder();            
            foreach(Venta ven in this.ventas)
            {
                ventas.AppendLine(ven.ObtenerDescripcionBreve());
            }            
            return ventas.ToString();
        }

        public static bool operator ==(Comiqueria comiqueria, Producto producto)
        {
            bool retorno = false;
            Guid codigoDeProducto = (Guid)producto;
            if (comiqueria[codigoDeProducto] != null)
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator !=(Comiqueria comiqueria, Producto producto)
        {
            return !(comiqueria == producto);
        }
        public static Comiqueria operator +(Comiqueria comiqueria, Producto producto)
        {
            if (comiqueria != producto)
            {
                comiqueria.productos.Add(producto);
            }
            return comiqueria;
        }
    }
}
