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
        private int _IdCargo;
        public int IdCargo
        {
            get { return _IdCargo; }
            set { _IdCargo = value; }
        }

        private bool _Activo;
        public bool Activo
        {
            get { return _Activo; }
            set { _Activo = value; }
        }
    }
}
