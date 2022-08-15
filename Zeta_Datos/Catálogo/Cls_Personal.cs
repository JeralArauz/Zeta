using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeta_Datos.Catálogo
{
    public class Cls_Personal
    {
        private int _IdPersonal;
        public int IdPersonal
        {
            get { return _IdPersonal; }
            set { _IdPersonal = value; }
        }
        private string _Nombres;
        public string Nombres
        {
            get { return _Nombres; }
            set { _Nombres = value; }
        }

        private string _Apellidos;
        public string Apellidos
        {
            get { return _Apellidos; }
            set { _Apellidos = value; }
        }

        private string _Estructura;
        public string Estructura
        {
            get { return _Estructura; }
            set { _Estructura = value; }
        }

        private string _Area;
        public string Area
        {
            get { return _Area; }
            set { _Area = value; }
        }
        private string _Cargo;
        public string Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }
    }
}
