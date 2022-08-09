using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeta_Datos.Catálogo
{
    public class Cls_Modelos
    {
        private int _IDModelo;
        public int IDModelo
        {
            get { return _IDModelo; }
            set { _IDModelo = value; }
        }
        private string _Modelo;
        public string Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }

        private int _IDMarca;
        public int IDMarca
        {
            get { return _IDMarca; }
            set { _IDMarca = value; }
        }
    }
}
