using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    public class Figura : Producto
    {
        private double altura;

        public Figura(string descripcion, int stock, double precio, double altura)
            :base(descripcion,stock,precio)
        {
            this.altura = altura;
        }
        public Figura(int stock, double precio, double altura)
            : this("pendiente", stock, precio, altura)
        {
            StringBuilder descripcion = new StringBuilder();
            descripcion.AppendFormat("Figura {0} cm", altura.ToString("N2"));
            this.descripcion = descripcion.ToString();
        }

        public override string ToString()
        {
            StringBuilder retStr = new StringBuilder();
            retStr.Append(base.ToString());
            retStr.AppendFormat("Altura: {0} cm\r\n", this.altura.ToString("N2"));
            return retStr.ToString();
        }
    }
}
