using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeta_Datos.Equipos
{
    public class Cls_Asignacion
    {
        private int _IdAsignacion;
        public int IdAsignacion
        {
            get { return _IdAsignacion; }
            set { _IdAsignacion = value; }
        }

        private int _IdAsignadoA;
        public int IDAsignadoA
        {
            get { return _IdAsignadoA; }
            set { _IdAsignadoA = value; }
        }

        private DateTime _Fecha_Asignacion;
        public DateTime Fecha_Asignacion
        {
            get { return _Fecha_Asignacion; }
            set { _Fecha_Asignacion = value; }
        }

        private string _Estado;
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        private string _Observaciones;
        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }
    }
}
