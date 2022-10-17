using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeta_Datos.Catálogo
{
    public class Cls_Denominacion
    {
        private int _IdDenominacion;
        public int IdDenominacion
        {
            get { return _IdDenominacion; }
            set { _IdDenominacion = value; }
        }

        private string _Denominacion;
        public string Denominacion
        {
            get { return _Denominacion; }
            set { _Denominacion = value; }
        }

    }
}
