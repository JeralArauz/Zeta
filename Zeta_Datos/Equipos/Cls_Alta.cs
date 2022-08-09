using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeta_Datos.Equipos
{
    public class Cls_Alta
    {
        private int _IdAlta;
        public int IdAlta
        {
            get { return _IdAlta; }
            set { _IdAlta = value; }
        }

        private DateTime _FechaAlta;
        public DateTime FechaAlta
        {
            get { return _FechaAlta; }
            set { _FechaAlta = value; }
        }


        private string _TipoAlta;
        public string TipoAlta
        {
            get { return _TipoAlta; }
            set { _TipoAlta = value; }
        }

        private string _Factura;
        public string Factura
        {
            get { return _Factura; }
            set { _Factura = value; }
        }

        private DateTime _FechaFactura;
        public DateTime FechaFactura
        {
            get { return _FechaFactura; }
            set { _FechaFactura = value; }
        }

        private Double _MontoFactura;
        public Double MontoFactura
        {
            get { return _MontoFactura; }
            set { _MontoFactura = value; }
        }

        private string _Observaciones;
        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }
    }
}
