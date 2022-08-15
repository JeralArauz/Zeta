using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeta_Datos.Catálogo
{
    public class Cls_Cargo
    {
        private int _IdCargo;
        public int IdCargo
        {
            get { return _IdCargo; }
            set { _IdCargo = value; }
        }

        private string _Cargo;
        public string Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }

        private int _IdArea;
        public int IdArea
        {
            get { return _IdArea; }
            set { _IdArea = value; }
        }
    }
}
