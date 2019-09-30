using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    public class Comic : Producto
    {
        private string autor;
        private TipoComic tipoComic;

        public Comic(string descripcion, int stock, double precio, string autor, TipoComic tipoComic)
            :base(descripcion,stock,precio)
        {
            this.autor = autor;
            this.tipoComic = tipoComic;
        }

        public override string ToString()
        {
            StringBuilder retStr = new StringBuilder();
            retStr.Append(base.ToString());
            retStr.AppendFormat("Autor: {0}\r\n", this.autor);
            retStr.AppendFormat("Tipo de comic: {0}\r\n", this.tipoComic,ToString());
            return retStr.ToString();
        }

        public enum TipoComic
        {
            Occidental,
            Oriental
        }
    }
}
