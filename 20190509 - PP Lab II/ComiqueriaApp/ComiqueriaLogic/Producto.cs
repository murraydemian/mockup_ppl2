using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    public abstract class Producto
    {
        protected Guid codigo;
        protected string descripcion;
        protected double precio;
        protected int stock;

        protected Producto(string descripcion, int stock, double precio)
        {
            this.codigo = Guid.NewGuid();            
            this.descripcion = descripcion;
            this.stock = stock;
            this.precio = precio;
        }

        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
        }
        public double Precio
        {
            get
            {
                return this.precio;
            }
        }
        public int Stock
        {
            get
            {
                return this.stock;
            }
            set
            {
                if (value >= 0)
                {
                    this.stock = value;
                }
            }
        }

        public static explicit operator Guid (Producto p)
        {
            return p.codigo;
        }

        public override string ToString()
        {
            StringBuilder retStr = new StringBuilder();
            retStr.AppendFormat("Descripcion: {0}\r\n", this.Descripcion);
            retStr.AppendFormat("Codigo: {0}\r\n", this.codigo.ToString());
            retStr.AppendFormat("Precio: ${0}\r\n", this.Precio.ToString());
            retStr.AppendFormat("Stock: {0} unidades\r\n", this.Stock.ToString());
            return retStr.ToString();
        }
    }
}
