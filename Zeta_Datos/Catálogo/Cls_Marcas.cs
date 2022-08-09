using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeta_Datos
{
    public class Cls_Marcas
    {
        private int _IDMarca;
        public int IDMarca
        {
            get { return _IDMarca; }
            set { _IDMarca = value; }
        }
        private string _Marca;
        public string Marca
        {
            get { return _Marca; }
            set { _Marca = value; }
        }
    }
}
