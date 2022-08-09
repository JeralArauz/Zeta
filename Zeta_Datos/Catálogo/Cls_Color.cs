using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeta_Datos.Catálogo
{
    public class Cls_Color
    {
        private int _IDColor;
        public int IDColor
        {
            get { return _IDColor; }
            set { _IDColor = value; }
        }

        private string _Color;
        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }
    }
}
