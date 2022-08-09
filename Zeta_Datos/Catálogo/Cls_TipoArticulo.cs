using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeta_Datos.Catálogo
{
    public class Cls_TipoArticulo
    {
        private int _IDTipoArticulo;
        public int IDTipoArticulo
        {
            get { return _IDTipoArticulo; }
            set { _IDTipoArticulo = value; }
        }
        private string _TipoArticulo;
        public string TipoArticulo
        {
            get { return _TipoArticulo; }
            set { _TipoArticulo = value; }
        }
       
    }
}
