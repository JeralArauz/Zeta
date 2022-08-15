using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeta_Datos.Catálogo
{
    public class Cls_Area
    {
        private int _IdArea;
        public int IdArea
        {
            get { return _IdArea; }
            set { _IdArea = value; }
        }

        private string _Area;
        public string Area
        {
            get { return _Area; }
            set { _Area = value; }
        }

        private int _IdEstructura;
        public int IdEstructura
        {
            get { return _IdEstructura; }
            set { _IdEstructura = value; }
        }
    }
}
