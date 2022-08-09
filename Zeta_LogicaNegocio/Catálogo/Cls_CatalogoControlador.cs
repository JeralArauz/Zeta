using ACTIVOFIJO_GENERAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeta_Datos;
using Zeta_Datos.Catálogo;

namespace Zeta_LogicaNegocio.Catálogo
{
    public class Cls_CatalogoControlador : Cls_General
    {


        #region "CATALOGO TIPO ARTICULO"

        public void CrearActualizarTipoArticulo(Cls_TipoArticulo TipoArticulo, string IdentityUser)
        {
            //INICIANDO EL PROCEDIMIENTO
            IniciarProcedimiento("SP_TipoArticuloCrearActualizar");
            //AGREGANDO PARAMETROS
            AgregarParametroProcedimiento("@IDTipoArticulo", SqlDbType.Int, TipoArticulo.IDTipoArticulo);
            AgregarParametroProcedimiento("@TipoArticulo", SqlDbType.NVarChar, TipoArticulo.TipoArticulo);
            AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, _NombreUsuario);
            //EJECUTANDO EL PROCEDIMIENTO
            EjecutarProcedimiento();
        }
        ////PROCEDIMIENTO PARA ELIMINAR UN REGISTRO DEL CATALOGO TIPO ARTICULO
        public void EliminarTipoArticulo(Cls_TipoArticulo TipoArticulo, string IdentityUser)
        {
            //INICIANDO EL PROCEDIMIENTO
            IniciarProcedimiento("SP_TipoArticuloEliminar");
            //AGREGANDO PARAMETROS
            AgregarParametroProcedimiento("@IDTipoArticulo", SqlDbType.Int, TipoArticulo.IDTipoArticulo);
            AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, _NombreUsuario);
            //EJECUTANDO EL PROCEDIMIENTO
            EjecutarProcedimiento();
        }
        public Boolean ValidarTipoArticuloRepetido(Cls_TipoArticulo TipoArticulo)
        {
            Boolean Retorno = false;
            try
            {
                Retorno = ExistenDatos("SELECT * FROM TipoArticulo WHERE TipoArticulo='" + TipoArticulo.TipoArticulo + "' AND IDTipoArticulo<>" + TipoArticulo.IDTipoArticulo.ToString());
                return Retorno;
            }
            catch (Exception)
            {
                return Retorno;
            }
        }

        //#endregion


        #region "CATALOGO Colores"

        public void CrearActualizarColor(Cls_Color color, string IdentityUser)
        {
            //INICIANDO EL PROCEDIMIENTO
            IniciarProcedimiento("SP_ColorCrearActualizar");
            //AGREGANDO PARAMETROS
            AgregarParametroProcedimiento("@IDColor", SqlDbType.Int, color.IDColor);
            AgregarParametroProcedimiento("@Color", SqlDbType.NVarChar, color.Color);
            AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, _NombreUsuario);
            //EJECUTANDO EL PROCEDIMIENTO
            EjecutarProcedimiento();
        }
        //PROCEDIMIENTO PARA ELIMINAR UN REGISTRO DEL CATALOGO TIPO ARTICULO
        public void EliminarColor(Cls_Color color, string IdentityUser)
        {
            //INICIANDO EL PROCEDIMIENTO
            IniciarProcedimiento("SP_ColorEliminar");
            //AGREGANDO PARAMETROS
            AgregarParametroProcedimiento("@IDColor", SqlDbType.Int, color.IDColor);
            AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, _NombreUsuario);
            //EJECUTANDO EL PROCEDIMIENTO
            EjecutarProcedimiento();
        }
        public Boolean ValidarColorRepetido(Cls_Color color)
        {
            Boolean Retorno = false;
            try
            {
                Retorno = ExistenDatos("SELECT * FROM Colores WHERE Color='" + color.Color + "' AND IDColor<>" + color.IDColor.ToString());
                return Retorno;
            }
            catch (Exception)
            {
                return Retorno;
            }
        }

        #endregion

        #region "CATALOGO MARCA"

        public void CrearActualizarMarca(Cls_Marcas Marca, string IdentityUser)
        {
            //INICIANDO EL PROCEDIMIENTO
            IniciarProcedimiento("SP_MarcaCrearActualizar");
            //AGREGANDO PARAMETROS
            AgregarParametroProcedimiento("@IDMarca", SqlDbType.Int, Marca.IDMarca);
            AgregarParametroProcedimiento("@Marca", SqlDbType.NVarChar, Marca.Marca);
            AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, _NombreUsuario);
            //EJECUTANDO EL PROCEDIMIENTO
            EjecutarProcedimiento();
        }
        ////PROCEDIMIENTO PARA ELIMINAR UN REGISTRO DEL CATALOGO TIPO ARTICULO
        //public void EliminarMarca(Cls_Marca Marca, string IdentityUser)
        //{
        //    //INICIANDO EL PROCEDIMIENTO
        //    IniciarProcedimiento("SP_Cat_MarcaEliminar");
        //    //AGREGANDO PARAMETROS
        //    AgregarParametroProcedimiento("@IDMarca", SqlDbType.Int, Marca.IDMarca);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, _NombreUsuario);
        //    //EJECUTANDO EL PROCEDIMIENTO
        //    EjecutarProcedimiento();
        //}
        public Boolean ValidarMarcaRepetido(Cls_Marcas Marca)
        {
            Boolean Retorno = false;
            try
            {
                Retorno = ExistenDatos("SELECT * FROM Marcas WHERE Marca='" + Marca.Marca);
                return Retorno;
            }
            catch (Exception)
            {
                return Retorno;
            }
        }

        #endregion

        //#region "CATALOGO MODELO"

        public void CrearActualizarModelo(Cls_Modelos Modelo, string IdentityUser)
        {
            //INICIANDO EL PROCEDIMIENTO
            IniciarProcedimiento("SP_ModeloCrearActualizar");
            //AGREGANDO PARAMETROS
            AgregarParametroProcedimiento("@IDModelo", SqlDbType.Int, Modelo.IDModelo);
            AgregarParametroProcedimiento("@IDMarca", SqlDbType.Int, Modelo.IDMarca);
            AgregarParametroProcedimiento("@Modelo", SqlDbType.NVarChar, Modelo.Modelo);
            AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, _NombreUsuario);
            //EJECUTANDO EL PROCEDIMIENTO
            EjecutarProcedimiento();
        }
        ////PROCEDIMIENTO PARA ELIMINAR UN REGISTRO DEL CATALOGO TIPO ARTICULO
        public void EliminarModelo(Cls_Modelos Modelo, string IdentityUser)
        {
            //INICIANDO EL PROCEDIMIENTO
            IniciarProcedimiento("SP_ModeloEliminar");
            //AGREGANDO PARAMETROS
            AgregarParametroProcedimiento("@IDModelo", SqlDbType.Int, Modelo.IDModelo);
            AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, _NombreUsuario);
            //EJECUTANDO EL PROCEDIMIENTO
            EjecutarProcedimiento();
        }
        public Boolean ValidarModeloRepetido(Cls_Modelos Modelo)
        {
            Boolean Retorno = false;
            try
            {
                Retorno = ExistenDatos("SELECT * FROM Modelos WHERE Modelo='" + Modelo.Modelo + "' AND IDModelo<>" + Modelo.IDModelo.ToString() + " AND IdMarca=" + Modelo.IDMarca);
                return Retorno;
            }
            catch (Exception)
            {
                //MessageBox.Show("Ocurrio un Error: \n" + Exec.Message.ToString() + "\n Consulte con el Administrador del Sistema.");
                return Retorno;
            }
        }

        //#endregion


        //#region "CATALOGO TIPO CLASIFICACION"

        //public void CrearActualizarTipoClasificacion(Cls_TipoClasificacion TipoClasificacion, string IdentityUser)
        //{
        //    //INICIANDO EL PROCEDIMIENTO
        //    IniciarProcedimiento("SP_Cat_TipoClasificacionCrearActualizar");
        //    //AGREGANDO PARAMETROS
        //    AgregarParametroProcedimiento("@IDTipoClasificacion", SqlDbType.Int, TipoClasificacion.IDTipoClasificacion);
        //    AgregarParametroProcedimiento("@TipoClasificacion", SqlDbType.NVarChar, TipoClasificacion.TipoClasificacion);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, _NombreUsuario);
        //    //EJECUTANDO EL PROCEDIMIENTO
        //    EjecutarProcedimiento();
        //}
        ////PROCEDIMIENTO PARA ELIMINAR UN REGISTRO DEL CATALOGO TIPO ARTICULO
        //public void EliminarTipoClasificacion(Cls_TipoClasificacion TipoClasificacion, string IdentityUser)
        //{
        //    //INICIANDO EL PROCEDIMIENTO
        //    IniciarProcedimiento("SP_Cat_TipoClasificacionEliminar");
        //    //AGREGANDO PARAMETROS
        //    AgregarParametroProcedimiento("@IDTipoClasificacion", SqlDbType.Int, TipoClasificacion.IDTipoClasificacion);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, _NombreUsuario);
        //    //EJECUTANDO EL PROCEDIMIENTO
        //    EjecutarProcedimiento();
        //}
        //public Boolean ValidarTipoClasificacionRepetido(Cls_TipoClasificacion TipoClasificacion)
        //{
        //    Boolean Retorno = false;
        //    try
        //    {
        //        Retorno = ExistenDatos("SELECT * FROM Cat.TipoClasificacion WHERE TipoClasificacion='" + TipoClasificacion.TipoClasificacion + "' AND IDTipoClasificacion<>" + TipoClasificacion.IDTipoClasificacion.ToString());
        //        return Retorno;
        //    }
        //    catch (Exception)
        //    {
        //        //MessageBox.Show("Ocurrio un Error: \n" + Exec.Message.ToString() + "\n Consulte con el Administrador del Sistema.");
        //        return Retorno;
        //    }
        //}

        //#endregion



        //#region "CATALOGO TIPO RETIRO"

        //public void CrearActualizarTipoRetiro(Cls_TipoRetiro TipoRetiro, string IdentityUser)
        //{
        //    //INICIANDO EL PROCEDIMIENTO
        //    IniciarProcedimiento("SP_Cat_TipoRetiroCrearActualizar");
        //    //AGREGANDO PARAMETROS
        //    AgregarParametroProcedimiento("@IDTipoRetiro", SqlDbType.Int, TipoRetiro.IDTipoRetiro);
        //    AgregarParametroProcedimiento("@TipoRetiro", SqlDbType.NVarChar, TipoRetiro.TipoRetiro);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, _NombreUsuario);
        //    //EJECUTANDO EL PROCEDIMIENTO
        //    EjecutarProcedimiento();
        //}
        ////PROCEDIMIENTO PARA ELIMINAR UN REGISTRO DEL CATALOGO TIPO ARTICULO
        //public void EliminarTipoRetiro(Cls_TipoRetiro TipoRetiro, string IdentityUser)
        //{
        //    //INICIANDO EL PROCEDIMIENTO
        //    IniciarProcedimiento("SP_Cat_TipoRetiroEliminar");
        //    //AGREGANDO PARAMETROS
        //    AgregarParametroProcedimiento("@IDTipoRetiro", SqlDbType.Int, TipoRetiro.IDTipoRetiro);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, _NombreUsuario);
        //    //EJECUTANDO EL PROCEDIMIENTO
        //    EjecutarProcedimiento();
        //}
        //public Boolean ValidarTipoRetiroRepetido(Cls_TipoRetiro TipoRetiro)
        //{
        //    Boolean Retorno = false;
        //    try
        //    {
        //        Retorno = ExistenDatos("SELECT * FROM Cat.TipoRetiro WHERE TipoRetiro='" + TipoRetiro.TipoRetiro + "' AND IDTipoRetiro<>" + TipoRetiro.IDTipoRetiro.ToString());
        //        return Retorno;
        //    }
        //    catch (Exception)
        //    {
        //        //MessageBox.Show("Ocurrio un Error: \n" + Exec.Message.ToString() + "\n Consulte con el Administrador del Sistema.");
        //        return Retorno;
        //    }
        //}

        //#endregion

        //#region "CATALOGO BODEGA"

        //public void CrearActualizarBodega(Cls_Bodega Bodega, string IdentityUser)
        //{
        //    //INICIANDO EL PROCEDIMIENTO
        //    IniciarProcedimiento("SP_Cat_BodegaCrearActualizar");
        //    //AGREGANDO PARAMETROS
        //    AgregarParametroProcedimiento("@IDBodega", SqlDbType.Int, Bodega.IDBodega);
        //    AgregarParametroProcedimiento("@Bodega", SqlDbType.NVarChar, Bodega.Bodega);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, _NombreUsuario);
        //    //EJECUTANDO EL PROCEDIMIENTO
        //    EjecutarProcedimiento();
        //}
        ////PROCEDIMIENTO PARA ELIMINAR UN REGISTRO DEL CATALOGO TIPO ARTICULO
        //public void EliminarBodega(Cls_Bodega Bodega, string IdentityUser)
        //{
        //    //INICIANDO EL PROCEDIMIENTO
        //    IniciarProcedimiento("SP_Cat_BodegaEliminar");
        //    //AGREGANDO PARAMETROS
        //    AgregarParametroProcedimiento("@IDBodega", SqlDbType.Int, Bodega.IDBodega);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, _NombreUsuario);
        //    //EJECUTANDO EL PROCEDIMIENTO
        //    EjecutarProcedimiento();
        //}
        //public Boolean ValidarBodegaRepetido(Cls_Bodega Bodega)
        //{
        //    Boolean Retorno = false;
        //    try
        //    {
        //        Retorno = ExistenDatos("SELECT * FROM Cat.Bodega WHERE Bodega='" + Bodega.Bodega + "' AND IDBodega<>" + Bodega.IDBodega.ToString());
        //        return Retorno;
        //    }
        //    catch (Exception)
        //    {
        //        //MessageBox.Show("Ocurrio un Error: \n" + Exec.Message.ToString() + "\n Consulte con el Administrador del Sistema.");
        //        return Retorno;
        //    }
        //}

        //#endregion



        //#region "CATALOGO PERSOAL EXTERNO"

        //public void CrearActualizarPersonalExterno(Cls_PersonalExterno PersonalExterno, string IdentityUser)
        //{
        //    //INICIANDO EL PROCEDIMIENTO
        //    IniciarProcedimiento("SP_Cat_PersonalExternoCrearActualizar");
        //    //AGREGANDO PARAMETROS
        //    AgregarParametroProcedimiento("@IDPersonalExterno", SqlDbType.Int, PersonalExterno.IDPersonalExterno);
        //    AgregarParametroProcedimiento("@Nombres", SqlDbType.NVarChar, PersonalExterno.Nombres);
        //    AgregarParametroProcedimiento("@Apellidos", SqlDbType.NVarChar, PersonalExterno.Apellidos);
        //    AgregarParametroProcedimiento("@Cargo", SqlDbType.NVarChar, PersonalExterno.Cargo);
        //    AgregarParametroProcedimiento("@UnidadAdministrativa", SqlDbType.NVarChar, PersonalExterno.UnidadAdministrativa);
        //    AgregarParametroProcedimiento("@Correo", SqlDbType.NVarChar, PersonalExterno.Correo);
        //    AgregarParametroProcedimiento("@Estado", SqlDbType.NVarChar, PersonalExterno.Estado);
        //    AgregarParametroProcedimiento("@Cedula", SqlDbType.NVarChar, PersonalExterno.Cedula);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, _NombreUsuario);
        //    //EJECUTANDO EL PROCEDIMIENTO
        //    EjecutarProcedimiento();
        //}
        ////PROCEDIMIENTO PARA ELIMINAR UN REGISTRO DEL CATALOGO TIPO ARTICULO
        //public void EliminarPersonalExterno(Cls_PersonalExterno PersonalExterno, string IdentityUser)
        //{
        //    //INICIANDO EL PROCEDIMIENTO
        //    IniciarProcedimiento("SP_Cat_PersonalExternoEliminar");
        //    //AGREGANDO PARAMETROS
        //    AgregarParametroProcedimiento("@IDPersonalExterno", SqlDbType.Int, PersonalExterno.IDPersonalExterno);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, _NombreUsuario);
        //    //EJECUTANDO EL PROCEDIMIENTO
        //    EjecutarProcedimiento();
        //}
        //public Boolean ValidarPersonalExternoRepetido(Cls_PersonalExterno PersonalExterno)
        //{
        //    Boolean Retorno = false;
        //    try
        //    {
        //        Retorno = ExistenDatos("SELECT * FROM Cat.PersonalExterno WHERE UPPER(PersonalExterno)='" + PersonalExterno.Nombres.ToUpper() + ' ' + PersonalExterno.Apellidos.ToUpper() + "' AND IDPersonalExterno<>" + PersonalExterno.IDPersonalExterno.ToString());
        //        return Retorno;
        //    }
        //    catch (Exception)
        //    {
        //        //MessageBox.Show("Ocurrio un Error: \n" + Exec.Message.ToString() + "\n Consulte con el Administrador del Sistema.");
        //        return Retorno;
        //    }
        //}

        //#endregion

        //#region "CATALOGO FIRMAS"

        //public void CrearActualizarFirmas(Cls_Firmas Firmas, string IdentityUser)
        //{
        //    //INICIANDO EL PROCEDIMIENTO
        //    IniciarProcedimiento("SP_FirmasCrearActualizar");
        //    //AGREGANDO PARAMETROS
        //    AgregarParametroProcedimiento("@IdFirma", SqlDbType.Int, Firmas.IdFirma);
        //    AgregarParametroProcedimiento("@NombreCompleto", SqlDbType.NVarChar, Firmas.NombreCompleto);
        //    AgregarParametroProcedimiento("@Cargo", SqlDbType.NVarChar, Firmas.Cargo);
        //    AgregarParametroProcedimiento("@Accion", SqlDbType.NVarChar, Firmas.Accion);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, _NombreUsuario);
        //    //EJECUTANDO EL PROCEDIMIENTO
        //    EjecutarProcedimiento();
        //}
        ////PROCEDIMIENTO PARA ELIMINAR UN REGISTRO DEL CATALOGO TIPO ARTICULO
        //public void EliminarFirmas(Cls_Firmas Firmas, string IdentityUser)
        //{
        //    //INICIANDO EL PROCEDIMIENTO
        //    IniciarProcedimiento("SP_FirmasEliminar");
        //    //AGREGANDO PARAMETROS
        //    AgregarParametroProcedimiento("@IdFirma", SqlDbType.NVarChar, Firmas.IdFirma);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, _NombreUsuario);
        //    //EJECUTANDO EL PROCEDIMIENTO
        //    EjecutarProcedimiento();
        //}
        //public Boolean ValidarFirmasRepetido(Cls_Firmas Firmas)
        //{
        //    Boolean Retorno = false;
        //    try
        //    {
        //        Retorno = ExistenDatos("SELECT * FROM FIRMAS WHERE UPPER(NOMBRECOMPLETO)='" + Firmas.NombreCompleto.ToUpper() + "' AND CARGO='" + Firmas.Cargo + "' AND ACCION ='" + Firmas.Accion + "' AND IDFIRMA<>" + Firmas.IdFirma.ToString());
        //        return Retorno;
        //    }
        //    catch (Exception)
        //    {
        //        return Retorno;
        //    }
        //}

        #endregion

        #region "PROCEDIMIENTOS Y FUNCIONES"

        public string ConsultaRegistrosCatalogo(int Opcion)
        {
            string SQLConsulta = string.Empty;
            try
            {
                switch (Opcion)
                {
                    case (int)EnumZetabyte.TipoArticulo: //  "TipoArticulo":
                        SQLConsulta = "SELECT DISTINCT IDTipoArticulo, TipoArticulo, ContieneCI FROM Cat.TipoArticulo ORDER BY TipoArticulo";
                        break;
                    case (int)EnumZetabyte.Marcas: //  "Marca":
                        SQLConsulta = "SELECT DISTINCT IDMarca, Marca FROM Cat.Marca ORDER BY Marca";
                        break;
                    case (int)EnumZetabyte.Modelos: //  "Modelo":
                        SQLConsulta = "SELECT DISTINCT mo.IDModelo, mo.Modelo, m.IDMarca, m.Marca FROM Cat.Modelo mo LEFT JOIN Cat.Marca m on mo.IDMarca = m.IDMarca ORDER BY mo.Modelo";
                        break;

                    case (int)EnumZetabyte.TipoClasificacion: //  "TipoClasificacion":
                        SQLConsulta = "SELECT DISTINCT IDTipoClasificacion, TipoClasificacion FROM Cat.TipoClasificacion ORDER BY TipoClasificacion";
                        break;
                    case (int)EnumZetabyte.TipoRetiro: //  "TipoRetiro":
                        SQLConsulta = "SELECT DISTINCT IDTipoRetiro, TipoRetiro FROM Cat.TipoRetiro ORDER BY TipoRetiro";
                        break;
                    case (int)EnumZetabyte.Bodega: //  "Bodega":
                        SQLConsulta = "SELECT DISTINCT IDBodega, Bodega FROM Cat.Bodega ORDER BY Bodega";
                        break;
                }
                return SQLConsulta;
            }
            catch (Exception)
            {
                //MessageBox.Show("Ocurrio un Error: \n" + Exec.Message.ToString() + "\n Consulte con el Administrador del Sistema.");
                return SQLConsulta;
            }
        }

        public int ObtenerID(string Descripcion, int Opcion)
        {
            int Retorno = 0;
            string SQLConsulta = string.Empty;
            try
            {
                switch (Opcion)
                {
                    case (int)EnumZetabyte.TipoClasificacion: //  "TipoArticulo":
                        SQLConsulta = "SELECT TC.IDTipoClasificacion FROM BIENES B JOIN CAT.TIPOARTICULO TA ON B.IDTipoArticulo = TA.IDTipoArticulo JOIN Cat.TipoClasificacion TC ON TA.IDTipoClasificacion = TC.IDTipoClasificacion WHERE B.IdBien ='" + Descripcion + "'";
                        break;

                }
                Retorno = Convert.ToInt32(ObtenerValorCampo(SQLConsulta));
                return Retorno;
            }
            catch (Exception)
            {
                //MessageBox.Show("Ocurrio un Error: \n" + Exec.Message.ToString() + "\n Consulte con el Administrador del Sistema.");
                return Retorno;
            }
        }

        #endregion

    }
}
