using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeta_Datos.Equipos
{
    public class Cls_Bien
    {
        private int _IdEquipo;
        public int IdEquipo
        {
            get { return _IdEquipo; }
            set { _IdEquipo = value; }
        }

        private int _IdAlta;
        public int IDAlta
        {
            get { return _IdAlta; }
            set { _IdAlta = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _Estado;
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }


        private int _IdTipoArticulo;
        public int IdTipoArticulo
        {
            get { return _IdTipoArticulo; }
            set { _IdTipoArticulo = value; }
        }

        private int _IdMarca;
        public int IdMarca
        {
            get { return _IdMarca; }
            set { _IdMarca = value; }
        }

        private int _IdModelo;
        public int IdModelo
        {
            get { return _IdModelo; }
            set { _IdModelo = value; }
        }

        private int _IdColor;
        public int IdColor
        {
            get { return _IdColor; }
            set { _IdColor = value; }
        }

        private string _NumeroSerie;
        public string NumeroSerie
        {
            get { return _NumeroSerie; }
            set { _NumeroSerie = value; }
        }

        private string _NumeroInventario;
        public string NumeroInventario
        {
            get { return _NumeroInventario; }
            set { _NumeroInventario = value; }
        }

        private Double _Costo;
        public Double Costo
        {
            get { return _Costo; }
            set { _Costo = value; }
        }

        private DateTime _FechaAdquisicion;
        public DateTime FechaAdquisicion
        {
            get { return _FechaAdquisicion; }
            set { _FechaAdquisicion = value; }
        }
       
        private string _Observaciones;
        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }
        
    }
}
