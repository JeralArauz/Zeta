using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeta_Datos.Catálogo
{
    public class Cls_Estructura
    {
        private int _IdEstructura;
        public int IdEstructura
        {
            get { return _IdEstructura; }
            set { _IdEstructura = value; }
        }

        private string _Estructura;
        public string Estructura
        {
            get { return _Estructura; }
            set { _Estructura = value; }
        }
    }
}
