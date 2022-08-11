using ACTIVOFIJO_GENERAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeta_Datos.Equipos;

namespace Zeta_LogicaNegocio.Equipos
{
    public class Cls_BienesControlador : Cls_General
    {
        Cls_General FG = new Cls_General();
        #region::::::::::::::::::::::BIENES:::::::::::::::::::::::::::::
        public void ActualizarEquipo(Cls_Equipo Bien, string IdentityUser, string UUA)
        {
            /*PREPARAMOS EL PROCEDIMIENTO A EJECUTAR*/
            IniciarProcedimiento("SP_ActualizarEquipo");
            /*AGREGAMOS LOS PARAMETROS DEL PROCEDIMIENTO*/
            AgregarParametroProcedimiento("@IdEquipo", SqlDbType.Int, Bien.IdEquipo);
            AgregarParametroProcedimiento("@Descripcion", SqlDbType.NVarChar, Bien.Descripcion);
            AgregarParametroProcedimiento("@IdTipoArticulo", SqlDbType.Int, Bien.IdTipoArticulo);
            AgregarParametroProcedimiento("@IdModelo", SqlDbType.Int, Bien.IdModelo);
            AgregarParametroProcedimiento("@IdColor", SqlDbType.Int, Bien.IdColor);
            AgregarParametroProcedimiento("@Costo", SqlDbType.Int, Bien.Costo);
            AgregarParametroProcedimiento("@Numeroserie", SqlDbType.NVarChar, Bien.NumeroSerie);
            AgregarParametroProcedimiento("@NumeroInventario", SqlDbType.NVarChar, Bien.NumeroInventario);
            AgregarParametroProcedimiento("@Observaciones", SqlDbType.NVarChar, Bien.Observaciones);
            AgregarParametroProcedimiento("@FechaAdquisicion", SqlDbType.DateTime, Bien.FechaAdquisicion);
            AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
            AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            /*EJECUTAMOS EL PROCEDIMIENTO*/
            EjecutarProcedimiento();
        }
        public void BienEliminar(Cls_Equipo Bien, string IdentityUser, string UUA)
        {
            /*PREPARAMOS EL PROCEDIMIENTO A EJECUTAR*/
            IniciarProcedimiento("SP_EliminarEquipoAlta");
            /*AGREGAMOS LOS PARAMETROS DEL PROCEDIMIENTO*/
            AgregarParametroProcedimiento("@IdEquipo", SqlDbType.Int, Bien.IdEquipo);
            AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
            /*EJECUTAMOS EL PROCEDIMIENTO*/
            EjecutarProcedimiento();
        }
        //#endregion

        //#region::::::::::::::::::ASIGNACIONES:::::::::::::::::::::::
        //public string AsignacionBienCrearActualizar(clsAsignacionBien AsignacionBien, string IdentityUser, string UUA)
        //{
        //    string Retorno = "";
        //    /*PREPARAMOS EL PROCEDIMIENTO A EJECUTAR*/
        //    IniciarProcedimiento("SP_AsignacionBienAgregarActualizar");
        //    /*AGREGAMOS LOS PARAMETROS DEL PROCEDIMIENTO*/
        //    AgregarParametroProcedimiento("@IdAsignacionBien", SqlDbType.Int, AsignacionBien.IdAsignacionBien);
        //    AgregarParametroProcedimiento("@IdAsignadoA", SqlDbType.Int, AsignacionBien.IDAsignadoA);
        //    AgregarParametroProcedimiento("@Fecha_Asignacion", SqlDbType.DateTime, AsignacionBien.Fecha_Asignacion);
        //    AgregarParametroProcedimiento("@Observaciones", SqlDbType.NVarChar, AsignacionBien.Observaciones);
        //    AgregarParametroProcedimiento("@Tipo", SqlDbType.NVarChar, AsignacionBien.Tipo);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    /*EJECUTAMOS EL PROCEDIMIENTO*/
        //    var result = EjecutarProcedimiento();
        //    if (result != null)
        //        Retorno = result.ToString();

        //    return Retorno;
        //}
        //public void AsignacionBienAplicar(int IdAsignacionBien, string IdentityUser, string UUA)
        //{
        //    /*PREPARAMOS EL PROCEDIMIENTO A EJECUTAR*/
        //    IniciarProcedimiento("SP_AsignacionBienAplicar");
        //    /*AGREGAMOS LOS PARAMETROS DEL PROCEDIMIENTO*/
        //    AgregarParametroProcedimiento("@IdAsignacionBien", SqlDbType.Int, IdAsignacionBien);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    /*EJECUTAMOS EL PROCEDIMIENTO*/
        //    EjecutarProcedimiento();
        //}
        //public void AsignacionBienAnular(int IdAsignacionBien, string IdentityUser, string UUA)
        //{
        //    /*PREPARAMOS EL PROCEDIMIENTO A EJECUTAR*/
        //    IniciarProcedimiento("SP_AsignacionBienAnular");
        //    /*AGREGAMOS LOS PARAMETROS DEL PROCEDIMIENTO*/
        //    AgregarParametroProcedimiento("@IdAsignacionBien", SqlDbType.Int, IdAsignacionBien);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    /*EJECUTAMOS EL PROCEDIMIENTO*/
        //    EjecutarProcedimiento();
        //}
        //public void AsignacionBienDesaplicar(int IdAsignacionBien, string IdentityUser, string UUA, string Motivo)
        //{
        //    /*PREPARAMOS EL PROCEDIMIENTO A EJECUTAR*/
        //    IniciarProcedimiento("SP_AsignacionBienDesAplicar");
        //    /*AGREGAMOS LOS PARAMETROS DEL PROCEDIMIENTO*/
        //    AgregarParametroProcedimiento("@IdAsignacionBien", SqlDbType.Int, IdAsignacionBien);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    AgregarParametroProcedimiento("@Motivo", SqlDbType.NVarChar, Motivo);
        //    /*EJECUTAMOS EL PROCEDIMIENTO*/
        //    EjecutarProcedimiento();
        //}
        //public void AsignacionBienDetalleCrearActualizar(clsAsignacionBienDetalle AsignacionBienDetalle, string IdentityUser, string UUA)
        //{
        //    /*PREPARAMOS EL PROCEDIMIENTO A EJECUTAR*/
        //    IniciarProcedimiento("SP_AsignacionBienDetalleAgregarActualizar");
        //    /*AGREGAMOS LOS PARAMETROS DEL PROCEDIMIENTO*/
        //    AgregarParametroProcedimiento("@IdAsignacionBienDetalle", SqlDbType.Int, AsignacionBienDetalle.IdAsignacionBienDetalle);
        //    AgregarParametroProcedimiento("@IdAsignacionBien", SqlDbType.Int, AsignacionBienDetalle.IdAsignacionBien);
        //    AgregarParametroProcedimiento("@IdBien", SqlDbType.Int, AsignacionBienDetalle.IdBien);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    /*EJECUTAMOS EL PROCEDIMIENTO*/
        //    EjecutarProcedimiento();
        //}
        //public void AsignacionBIenDetalleEliminar(clsAsignacionBienDetalle AsignacionBienDetalle, string IdentityUser, string UUA)
        //{
        //    /*PREPARAMOS EL PROCEDIMIENTO A EJECUTAR*/
        //    IniciarProcedimiento("SP_AsignacionBienDetalleEliminar");
        //    /*AGREGAMOS LOS PARAMETROS DEL PROCEDIMIENTO*/
        //    AgregarParametroProcedimiento("@IdAsignacionBienDetalle", SqlDbType.Int, AsignacionBienDetalle.IdAsignacionBienDetalle);
        //    AgregarParametroProcedimiento("@IdBien", SqlDbType.Int, AsignacionBienDetalle.IdBien);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    /*EJECUTAMOS EL PROCEDIMIENTO*/
        //    EjecutarProcedimiento();
        //}
        //#endregion

        //#region:::::::::::::::::::::RETIROS::::::::::::::::::::::
        //public string RetiroBienCrearActualizar(clsRetiroBien RetiroBien, string IdentityUser, string UUA)
        //{
        //    string Retorno = "";
        //    /*PREPARAMOS EL PROCEDIMIENTO A EJECUTAR*/
        //    IniciarProcedimiento("SP_RetiroBienAgregarActualizar");
        //    /*AGREGAMOS LOS PARAMETROS DEL PROCEDIMIENTO*/
        //    AgregarParametroProcedimiento("@IdRetiroBien", SqlDbType.Int, RetiroBien.IdRetiroBien);
        //    AgregarParametroProcedimiento("@IdRetiradoA", SqlDbType.Int, RetiroBien.IdRetiradoA);
        //    AgregarParametroProcedimiento("@Fecha_Retiro", SqlDbType.DateTime, RetiroBien.Fecha_Retiro);
        //    AgregarParametroProcedimiento("@Observaciones", SqlDbType.NVarChar, RetiroBien.Observaciones);
        //    AgregarParametroProcedimiento("@TipoRetiro", SqlDbType.NVarChar, RetiroBien.TipoRetiro);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    /*EJECUTAMOS EL PROCEDIMIENTO*/
        //    var result = EjecutarProcedimiento();
        //    if (result != null)
        //        Retorno = result.ToString();

        //    return Retorno;
        //}
        //public void RetiroBienAplicar(int IdRetiroBien, string IdentityUser, string UUA)
        //{
        //    /*PREPARAMOS EL PROCEDIMIENTO A EJECUTAR*/
        //    IniciarProcedimiento("SP_RetiroBienAplicar");
        //    /*AGREGAMOS LOS PARAMETROS DEL PROCEDIMIENTO*/
        //    AgregarParametroProcedimiento("@IdRetiroBien", SqlDbType.Int, IdRetiroBien);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    /*EJECUTAMOS EL PROCEDIMIENTO*/
        //    EjecutarProcedimiento();
        //}
        //public void RetiroBienDesAplicar(int IdRetiroBien, string IdentityUser, string UUA, string Motivo)
        //{
        //    /*PREPARAMOS EL PROCEDIMIENTO A EJECUTAR*/
        //    IniciarProcedimiento("SP_RetiroBienDesAplicar");
        //    /*AGREGAMOS LOS PARAMETROS DEL PROCEDIMIENTO*/
        //    AgregarParametroProcedimiento("@IdRetiroBien", SqlDbType.Int, IdRetiroBien);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    AgregarParametroProcedimiento("@Motivo", SqlDbType.NVarChar, Motivo);
        //    /*EJECUTAMOS EL PROCEDIMIENTO*/
        //    EjecutarProcedimiento();
        //}
        //public void RetiroBienAnular(int IdRetiroBien, string IdentityUser, string UUA)
        //{
        //    /*PREPARAMOS EL PROCEDIMIENTO A EJECUTAR*/
        //    IniciarProcedimiento("SP_RetiroBienAnular");
        //    /*AGREGAMOS LOS PARAMETROS DEL PROCEDIMIENTO*/
        //    AgregarParametroProcedimiento("@IdRetiroBien", SqlDbType.Int, IdRetiroBien);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    /*EJECUTAMOS EL PROCEDIMIENTO*/
        //    EjecutarProcedimiento();
        //}
        //public void RetiroBienDetalleCrearActualizar(clsRetiroBienDetalle RetiroBienDetalle, string IdentityUser, string UUA)
        //{
        //    /*PREPARAMOS EL PROCEDIMIENTO A EJECUTAR*/
        //    IniciarProcedimiento("SP_RetiroBienDetalleAgregarActualizar");
        //    /*AGREGAMOS LOS PARAMETROS DEL PROCEDIMIENTO*/
        //    AgregarParametroProcedimiento("@IdRetiroBienDetalle", SqlDbType.Int, RetiroBienDetalle.IdRetiroBienDetalle);
        //    //AgregarParametroProcedimiento("@IdAsignacionBienDetalle", SqlDbType.Int, RetiroBienDetalle.IdAsignacionBienDetalle);
        //    AgregarParametroProcedimiento("@IdRetiroBien", SqlDbType.Int, RetiroBienDetalle.IdRetiroBien);
        //    AgregarParametroProcedimiento("@IdBien", SqlDbType.NVarChar, RetiroBienDetalle.IdBien);
        //    AgregarParametroProcedimiento("@IdBodega", SqlDbType.Int, RetiroBienDetalle.IdBodega);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
        //    /*EJECUTAMOS EL PROCEDIMIENTO*/
        //    EjecutarProcedimiento();
        //}
        //public void RetiroBienDetalleEliminar(clsRetiroBienDetalle RetiroBienDetalle, string IdentityUser, string UUA)
        //{
        //    /*PREPARAMOS EL PROCEDIMIENTO A EJECUTAR*/
        //    IniciarProcedimiento("SP_RetiroBienDetalleEliminar");
        //    /*AGREGAMOS LOS PARAMETROS DEL PROCEDIMIENTO*/
        //    AgregarParametroProcedimiento("@IdRetiroBienDetalle", SqlDbType.Int, RetiroBienDetalle.IdRetiroBienDetalle);
        //    AgregarParametroProcedimiento("@IdAsignacionBienDetalle", SqlDbType.Int, RetiroBienDetalle.IdAsignacionBienDetalle);
        //    AgregarParametroProcedimiento("@IdBien", SqlDbType.Int, RetiroBienDetalle.IdBien);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    /*EJECUTAMOS EL PROCEDIMIENTO*/
        //    EjecutarProcedimiento();
        //}
        //#endregion::::::::::::::::::::::::::::::::::::::::::::::::

        //#region::::::::::::::::::ALTAS::::::::::::::::::::::::::
        public string AltaCrearActualizar(Cls_Alta Alta, string IdentityUser, string UUA)
        {
            string Retorno = "";
            /*PREPARAMOS EL PROCEDIMIENTO A EJECUTAR*/
            IniciarProcedimiento("SP_AltaAgregarActualizar");
            /*AGREGAMOS LOS PARAMETROS DEL PROCEDIMIENTO*/
            AgregarParametroProcedimiento("@IdAlta", SqlDbType.Int, Alta.IdAlta);
            AgregarParametroProcedimiento("@TipoAlta", SqlDbType.NVarChar, Alta.TipoAlta);
            AgregarParametroProcedimiento("@Fecha_Alta", SqlDbType.DateTime, Alta.FechaAlta);
            AgregarParametroProcedimiento("@Factura", SqlDbType.NVarChar, Alta.Factura);
            AgregarParametroProcedimiento("@FechaFactura", SqlDbType.DateTime, Alta.FechaFactura);
            AgregarParametroProcedimiento("@MontoFactura", SqlDbType.Float, Alta.MontoFactura);
            AgregarParametroProcedimiento("@Observaciones", SqlDbType.NVarChar, Alta.Observaciones);
            AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
            AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            /*EJECUTAMOS EL PROCEDIMIENTO*/
            var result = EjecutarProcedimiento();
            if (result != null)
                Retorno = result.ToString();

            return Retorno;
        }
        public void EquipoAgregarAlta(Cls_Equipo Bien, string IdentityUser, string UUA)
        {
            /*PREPARAMOS EL PROCEDIMIENTO A EJECUTAR*/
            IniciarProcedimiento("SP_EquipoAgregarAlta");
            /*AGREGAMOS LOS PARAMETROS DEL PROCEDIMIENTO*/
            AgregarParametroProcedimiento("@IdEquipo", SqlDbType.Int, Bien.IdEquipo);
            AgregarParametroProcedimiento("@IdAlta", SqlDbType.Int, Bien.IDAlta);
            AgregarParametroProcedimiento("@Descripcion", SqlDbType.NVarChar, Bien.Descripcion);
            AgregarParametroProcedimiento("@NumeroInventario", SqlDbType.NVarChar, Bien.NumeroInventario);
            AgregarParametroProcedimiento("@NumeroSerie", SqlDbType.NVarChar, Bien.NumeroSerie);
            AgregarParametroProcedimiento("@IdTipoArticulo", SqlDbType.Int, Bien.IdTipoArticulo);
            AgregarParametroProcedimiento("@IdModelo", SqlDbType.Int, Bien.IdModelo);
            AgregarParametroProcedimiento("@IdColor", SqlDbType.Int, Bien.IdColor);
            AgregarParametroProcedimiento("@Procesador", SqlDbType.NVarChar, Bien.Procesador);
            AgregarParametroProcedimiento("@Almacenamiento", SqlDbType.NVarChar, Bien.Almacenamiento);
            AgregarParametroProcedimiento("@RAM", SqlDbType.NVarChar, Bien.RAM);
            AgregarParametroProcedimiento("@DireccionIP", SqlDbType.NVarChar, Bien.DireccionIP);
            AgregarParametroProcedimiento("@FechaAdquisicion", SqlDbType.DateTime, Bien.FechaAdquisicion);
            AgregarParametroProcedimiento("@Costo", SqlDbType.Float, Bien.Costo);
            AgregarParametroProcedimiento("@Observaciones", SqlDbType.NVarChar, Bien.Observaciones);
            AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
            /*EJECUTAMOS EL PROCEDIMIENTO*/
            EjecutarProcedimiento();
        }

        public void AplicarAlta(int IdAlta, string IdentityUser, string UUA)
        {
            /*PREPARAMOS EL PROCEDIMIENTO A EJECUTAR*/
            IniciarProcedimiento("SP_AplicarAlta");
            /*AGREGAMOS LOS PARAMETROS DEL PROCEDIMIENTO*/
            AgregarParametroProcedimiento("@IdAlta", SqlDbType.Int, IdAlta);
            AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
            AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
            /*EJECUTAMOS EL PROCEDIMIENTO*/
            EjecutarProcedimiento();
        }
        //#endregion::::::::::::::::::::::::::::::::::::::::::::::::

        //#region:::::::::::::::::::::::::BAJAS::::::::::::::::::::::::
        //public string BajaCrearActualizar(clsBaja Baja, string IdentityUser, string UUA)
        //{
        //    string Retorno = "";
        //    /*PREPARAMOS EL PROCEDIMIENTO A EJECUTAR*/
        //    IniciarProcedimiento("SP_BajaBienAgregarActualizar");
        //    /*AGREGAMOS LOS PARAMETROS DEL PROCEDIMIENTO*/
        //    AgregarParametroProcedimiento("@IdBajaBien", SqlDbType.Int, Baja.IdBajaBien);
        //    AgregarParametroProcedimiento("@FechaBaja", SqlDbType.DateTime, Baja.FechaBaja);
        //    AgregarParametroProcedimiento("@Observaciones", SqlDbType.NVarChar, Baja.Observaciones);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    /*EJECUTAMOS EL PROCEDIMIENTO*/
        //    var result = EjecutarProcedimiento();
        //    if (result != null)
        //        Retorno = result.ToString();

        //    return Retorno;
        //}
        //public void BajaBienAplicar(int IdBajaBien, string IdentityUser, string UUA)
        //{
        //    /*PREPARAMOS EL PROCEDIMIENTO A EJECUTAR*/
        //    IniciarProcedimiento("SP_BajaBienAplicar");
        //    /*AGREGAMOS LOS PARAMETROS DEL PROCEDIMIENTO*/
        //    AgregarParametroProcedimiento("@IdBajaBien", SqlDbType.Int, IdBajaBien);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    /*EJECUTAMOS EL PROCEDIMIENTO*/
        //    EjecutarProcedimiento();
        //}
        //public void BajaBienDetalleCrearActualizar(clsBajaBienDetalle BajaBienDetalle, string IdentityUser, string UUA)
        //{
        //    /*PREPARAMOS EL PROCEDIMIENTO A EJECUTAR*/
        //    IniciarProcedimiento("SP_BajaBienDetalleAgregarActualizar");
        //    /*AGREGAMOS LOS PARAMETROS DEL PROCEDIMIENTO*/
        //    AgregarParametroProcedimiento("@IdBajaBienDetalle", SqlDbType.Int, BajaBienDetalle.IdBajaBienDetalle);
        //    AgregarParametroProcedimiento("@IdBajaBien", SqlDbType.Int, BajaBienDetalle.IdBajaBien);
        //    AgregarParametroProcedimiento("@IdBien", SqlDbType.Int, BajaBienDetalle.IdBien);
        //    AgregarParametroProcedimiento("@MotivoBaja", SqlDbType.NVarChar, BajaBienDetalle.MotivoBaja);
        //    AgregarParametroProcedimiento("@IDBodega", SqlDbType.Int, BajaBienDetalle.IdBodega);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    /*EJECUTAMOS EL PROCEDIMIENTO*/
        //    EjecutarProcedimiento();
        //}
        //public void BajaBienDetalleEliminar(clsBajaBienDetalle BajaBienDetalle, string IdentityUser, string UUA)
        //{
        //    /*PREPARAMOS EL PROCEDIMIENTO A EJECUTAR*/
        //    IniciarProcedimiento("SP_BajaBienDetalleEliminar");
        //    /*AGREGAMOS LOS PARAMETROS DEL PROCEDIMIENTO*/
        //    AgregarParametroProcedimiento("@IdBajaBienDetalle", SqlDbType.Int, BajaBienDetalle.IdBajaBienDetalle);
        //    AgregarParametroProcedimiento("@IdBien", SqlDbType.Int, BajaBienDetalle.IdBien);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    /*EJECUTAMOS EL PROCEDIMIENTO*/
        //    EjecutarProcedimiento();
        //}
        #endregion:::::::::::::::::::::::::::::::::::::::::::::::::::

        #region::::::::::::::::::::::SOFTWARE:::::::::::::::::::::::::::::
        //public void SoftwareAgregarActualizar(clsSoftware software, string IdentityUser, string UUA)
        //{
        //    /*PREPARAMOS EL PROCEDIMIENTO A EJECUTAR*/
        //    IniciarProcedimiento("SP_SoftwareAgregarActualizar");
        //    /*AGREGAMOS LOS PARAMETROS DEL PROCEDIMIENTO*/
        //    AgregarParametroProcedimiento("@IdSoftware", SqlDbType.Int, software.IdSoftware);
        //    AgregarParametroProcedimiento("@Software", SqlDbType.NVarChar, software.Software);
        //    AgregarParametroProcedimiento("@Descripcion", SqlDbType.NVarChar, software.Descripcion);
        //    AgregarParametroProcedimiento("@CUB", SqlDbType.NVarChar, software.CUB);
        //    AgregarParametroProcedimiento("@CodigoSecaf", SqlDbType.NVarChar, software.CodigoSECAF);
        //    AgregarParametroProcedimiento("@CubSigaf", SqlDbType.NVarChar, software.CUBSIGAF);
        //    AgregarParametroProcedimiento("@Version", SqlDbType.NVarChar, software.Version);
        //    AgregarParametroProcedimiento("@Licencia", SqlDbType.NVarChar, software.Licencia);
        //    AgregarParametroProcedimiento("@Estado", SqlDbType.Bit, software.Estado);
        //    AgregarParametroProcedimiento("@NoRegistro", SqlDbType.NVarChar, software.NRegistro);
        //    AgregarParametroProcedimiento("@Desarrollador", SqlDbType.NVarChar, software.Desarrollador);
        //    AgregarParametroProcedimiento("@NoProyecto", SqlDbType.NVarChar, software.NProyecto);
        //    AgregarParametroProcedimiento("@Valor", SqlDbType.Float, software.Valor);
        //    AgregarParametroProcedimiento("@Fecha", SqlDbType.DateTime, software.FechaA);
        //    AgregarParametroProcedimiento("@PlataformaDes", SqlDbType.NVarChar, software.Plataforma);
        //    AgregarParametroProcedimiento("@Proveedor", SqlDbType.NVarChar, software.Proveedor);
        //    AgregarParametroProcedimiento("@NoABC", SqlDbType.Int, software.NAbc);
        //    AgregarParametroProcedimiento("@Factura", SqlDbType.NVarChar, software.Factura);
        //    AgregarParametroProcedimiento("@Observaciones", SqlDbType.NVarChar, software.Observaciones);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, UUA);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    /*EJECUTAMOS EL PROCEDIMIENTO*/
        //    EjecutarProcedimiento();
        //}
        #endregion:::::::::::::::::::::::::::::::::::::::::::::::::::

        #region::::::::::::::::::::::REPORTES:::::::::::::::::::::::::::::
        //public int CrearRegistroReporteEquipoTipoArea(string UnidadAdministrativa, string IdentityUser)
        //{
        //    int Retorno = 0;
        //    //INICIANDO EL PROCEDIMIENTO
        //    IniciarProcedimiento("SP_Reporte_EquipoTipoArea");
        //    //AGREGANDO PARAMETROS
        //    AgregarParametroProcedimiento("@UnidadAdministrativa", SqlDbType.VarChar, UnidadAdministrativa);
        //    AgregarParametroProcedimiento("@IdentityUser", SqlDbType.NVarChar, IdentityUser);
        //    AgregarParametroProcedimiento("@UUA", SqlDbType.NVarChar, _NombreUsuario);
        //    //EJECUTANDO EL PROCEDIMIENTO
        //    Retorno = Convert.ToInt32(EjecutarProcedimiento());
        //    return Retorno;
        //}
        //public DataSet ImprimirReporte(string Opcion, string IdentityUser, string Opcion2)
        //{
        //    DataSet DS_Reporte = new DataSet();
        //    string SQLConsulta = string.Empty;
        //    try
        //    {
        //        switch (Opcion)
        //        {
        //            case "AsignacionSoftware":
        //                SQLConsulta = "SELECT ROW_NUMBER() OVER (ORDER BY DESCRIPCION) AS C_1, CodigoSECAF AS C_2, CUBSIGAF AS C_3, Descripcion AS C_4, Version AS C_5, Licencia AS C_6, NoRegistro as C_7, Desarrollador AS C_8, CASE Activo WHEN 1 THEN 'Activo' ELSE 'Inactivo' END AS C_9, NoProyecto AS C_10, PlataformaD AS C_11, Proveedor AS C_12, ObservacionBien AS C_13, dbo.PrimerLetraMayuscula(Personal) AS C_14,  NumeroCedula AS C_15, dbo.PrimerLetraMayuscula(Cargo) AS C_16, dbo.PrimerLetraMayuscula(UnidadAdministrativa) AS C_17, NumeroAsignacion AS C_18, Fecha_Asignacion AS C_19, (SELECT TOP 1 dbo.PrimerLetraMayuscula(Personal) FROM VW_SP_INTERNO_EXTERNO WHERE CorreoInstitucional LIKE '%" + UserReg + "%')  AS C_20, (SELECT TOP 1 dbo.PrimerLetraMayuscula(Cargo) FROM VW_SP_INTERNO_EXTERNO WHERE CorreoInstitucional LIKE '%" + UserReg + "%')  AS C_21, (SELECT dbo.PrimerLetraMayuscula(NombreCompleto) FROM Firmas WHERE ACCION = 'Revisa') AS C_22, (SELECT dbo.PrimerLetraMayuscula(Cargo) FROM Firmas WHERE ACCION = 'Revisa') AS C_23, CASE Cargo WHEN 'Responsable Division General Administrativa Financiera' THEN (SELECT dbo.PrimerLetraMayuscula(NombreCompleto) FROM Firmas WHERE ACCION = 'Autoriza-Temporal') ELSE (SELECT dbo.PrimerLetraMayuscula(NombreCompleto) FROM Firmas WHERE ACCION = 'Autoriza') END AS C_24, CASE Cargo WHEN 'Responsable Division General Administrativa Financiera' THEN (SELECT Cargo FROM Firmas WHERE ACCION = 'Autoriza-Temporal') ELSE (SELECT Cargo FROM Firmas WHERE ACCION = 'Autoriza') END AS C_25, dbo.PrimerLetraMayuscula(PERSONAL)+' '+dbo.PrimerLetraMayuscula(CARGO) AS C_26, Observaciones AS C_27 FROM VW_Asignacion_Bienes WHERE IdAsignacionBien = '" + IdentityUser.ToString() + "' AND Estado = 'Aplicado'";
        //                break;
        //        }
        //        DS_Reporte = LlenarDataSet(SQLConsulta, "View_General");
        //        return DS_Reporte;
        //    }
        //    catch (Exception Ex)
        //    {
        //        return DS_Reporte;
        //    }
        //}
        #endregion:::::::::::::::::::::::::::::::::::::::::::::::::::
        //public int ObtenerID(string Descripcion, int Opcion)
        //{
        //    int Retorno = 0;
        //    string SQLConsulta = string.Empty;
        //    try
        //    {
        //        switch (Opcion)
        //        {
        //            case (int)EnumActivoFijo.TipoClasificacion: //  "TipoArticulo":
        //                SQLConsulta = "SELECT TC.IDTipoClasificacion FROM BIENES B JOIN CAT.TIPOARTICULO TA ON B.IDTipoArticulo = TA.IDTipoArticulo JOIN Cat.TipoClasificacion TC ON TA.IDTipoClasificacion = TC.IDTipoClasificacion WHERE B.IdBien ='" + Descripcion + "'";
        //                break;
        //            case (int)EnumActivoFijo.IdPersonal: //  "TipoArticulo":
        //                SQLConsulta = "SELECT IDPersonal FROM VW_SP_INTERNO_EXTERNO WHERE PERSONAL ='" + Descripcion + "'";
        //                break;
        //        }
        //        Retorno = Convert.ToInt32(ObtenerValorCampo(SQLConsulta));
        //        return Retorno;
        //    }
        //    catch (Exception)
        //    {
        //        //MessageBox.Show("Ocurrio un Error: \n" + Exec.Message.ToString() + "\n Consulte con el Administrador del Sistema.");
        //        return Retorno;
        //    }
        //}
        //public string ObtenerDato(string Descripcion, int Opcion)
        //{
        //string Retorno = "";
        //string SQLConsulta = string.Empty;
        //try
        //{
        //    switch (Opcion)
        //    {
        //        case (int)EnumActivoFijo.Area: //
        //            SQLConsulta = "SELECT UnidadAdministrativa FROM VW_SP_INTERNO_EXTERNO WHERE IDPersonal ='" + Descripcion + "'";
        //            break;
        //        case (int)EnumActivoFijo.NumeroCedula: //  
        //            SQLConsulta = "SELECT NumeroCedula FROM VW_SP_INTERNO_EXTERNO WHERE IDPersonal ='" + Descripcion + "'";
        //            break;
        //        case (int)EnumActivoFijo.Cargo: // 
        //            SQLConsulta = "SELECT Cargo FROM VW_SP_INTERNO_EXTERNO WHERE IDPersonal='" + Descripcion + "'";
        //            break;
        //    }
        //    Retorno = ObtenerValorCampo(SQLConsulta);
        //    return Retorno;
        //}
        //catch (Exception)
        //{
        //    //MessageBox.Show("Ocurrio un Error: \n" + Exec.Message.ToString() + "\n Consulte con el Administrador del Sistema.");
        //    return Retorno;
        //}
        //}
        public string ConsultaRegistroBienes(int Opcion, Int32 ID, int ID2)
        {
            string SQLConsulta = string.Empty;
            try
            {
                switch (Opcion)
                {
                    //case (int)EnumActivoFijo.BienesArmas: //  "Bienes Armas":
                    //    SQLConsulta = "SELECT [IdBien],[CodigoSECAF], [CUBSIGAF], [Descripcion],[NumeroSerie], [Marca], [Modelo], [IdTipoClasificacion], [NumeroChasis], [NumeroMotor], [Placa], [Version], [Licencia] FROM  [vw_Inventario_Bienes] WHERE IdTipoClasificacion = 9 AND (Estado = 'Disponible' OR Estado = 'Sin Asignar' AND[EstadoAlta] = 'Aplicado') OR IdBien IN(SELECT IdBien FROM vw_Asignacion_Bienes WHERE IdAsignacionBien = " + ID.ToString() + ") ORDER BY [Descripcion]";
                    //    break;
                    //case (int)EnumActivoFijo.BienesVehiculos:
                    //    SQLConsulta = "SELECT [IdBien],[CodigoSECAF], [CUBSIGAF], [Descripcion],[NumeroSerie], [Marca], [Modelo], [IdTipoClasificacion], [NumeroChasis], [NumeroMotor], [Placa], [Version], [Licencia] FROM[vw_Inventario_Bienes] WHERE IdTipoClasificacion = 7 AND(Estado = 'Disponible' OR Estado = 'Sin Asignar' AND[EstadoAlta] = 'Aplicado') OR IdBien IN(SELECT IdBien FROM vw_Asignacion_Bienes WHERE IdAsignacionBien = " + ID.ToString() + ") ORDER BY[Descripcion]";
                    //    break;
                    //case (int)EnumActivoFijo.BienesSoftware:
                    //    SQLConsulta = "SELECT [IdBien],[CodigoSECAF], [CUBSIGAF], [Descripcion],[NumeroSerie], [Marca], [Modelo], [IdTipoClasificacion], [NumeroChasis], [NumeroMotor], [Placa], [Version], [Licencia]  FROM  [vw_Inventario_Bienes] WHERE IdTipoClasificacion = 13 AND (Estado = 'Disponible' OR Estado = 'Sin Asignar' AND[EstadoAlta] = 'Aplicado') OR IdBien IN(SELECT IdBien FROM vw_Asignacion_Bienes WHERE IdAsignacionBien = " + ID.ToString() + ") ORDER BY [Descripcion]";
                    //    break;
                    //case (int)EnumActivoFijo.BienesOtros:
                    //    SQLConsulta = "SELECT [IdBien], [CodigoSECAF], [CUBSIGAF], [Descripcion],[NumeroSerie], [Marca], [Modelo], [IdTipoClasificacion], [NumeroChasis], [NumeroMotor], [Placa], [Version], [Licencia]  FROM  [vw_Inventario_Bienes] WHERE IdTipoClasificacion NOT IN (7,9,13) AND (Estado = 'Disponible' OR Estado = 'Sin Asignar' AND[EstadoAlta] = 'Aplicado') OR IdBien IN(SELECT IdBien FROM vw_Asignacion_Bienes WHERE IdAsignacionBien = " + ID.ToString() + ") ORDER BY [Descripcion]";
                    //    break;
                    //case (int)EnumActivoFijo.PersonalConArmas:
                    //    SQLConsulta = "SELECT DISTINCT(U.[IDPersonal]), U.[Personal], U.[Cargo], U.[UnidadAdministrativa], U.[NumeroCedula] FROM[VW_SP_INTERNO_EXTERNO] U JOIN AsignacionBien A ON U.IDPERSONAL = A.IDASIGNADOA AND A.ESTADO = 'Aplicado' JOIN ASIGNACIONBIENDETALLE AB ON A.IDASIGNACIONBIEN = AB.IDASIGNACIONBIEN AND AB.Actual = 1 JOIN Bienes B ON AB.IdBien = B.IdBien JOIN Cat.TipoArticulo T ON B.IdTipoArticulo = T.IdTipoArticulo AND T.IdTipoClasificacion = 9 WHERE U.ESTADO != 'INACTIVO'";
                    //    break;
                    //case (int)EnumActivoFijo.PersonalConVehiculos:
                    //    SQLConsulta = "SELECT DISTINCT(U.[IDPersonal]), U.[Personal], U.[Cargo], U.[UnidadAdministrativa], U.[NumeroCedula] FROM[VW_SP_INTERNO_EXTERNO] U JOIN AsignacionBien A ON U.IDPERSONAL = A.IDASIGNADOA AND A.ESTADO = 'Aplicado' JOIN ASIGNACIONBIENDETALLE AB ON A.IDASIGNACIONBIEN = AB.IDASIGNACIONBIEN AND AB.Actual = 1 JOIN Bienes B ON AB.IdBien = B.IdBien JOIN Cat.TipoArticulo T ON B.IdTipoArticulo = T.IdTipoArticulo AND T.IdTipoClasificacion = 7 WHERE U.ESTADO != 'INACTIVO'";
                    //    break;
                    //case (int)EnumActivoFijo.PersonalConSoftware:
                    //    SQLConsulta = "SELECT DISTINCT(U.[IDPersonal]), U.[Personal], U.[Cargo], U.[UnidadAdministrativa], U.[NumeroCedula] FROM[VW_SP_INTERNO_EXTERNO] U JOIN AsignacionBien A ON U.IDPERSONAL = A.IDASIGNADOA AND A.ESTADO = 'Aplicado' JOIN ASIGNACIONBIENDETALLE AB ON A.IDASIGNACIONBIEN = AB.IDASIGNACIONBIEN AND AB.Actual = 1 JOIN Bienes B ON AB.IdBien = B.IdBien JOIN Cat.TipoArticulo T ON B.IdTipoArticulo = T.IdTipoArticulo AND T.IdTipoClasificacion = 13 WHERE U.ESTADO != 'INACTIVO'";
                    //    break;
                    //case (int)EnumActivoFijo.PersonalOtrosBienes:
                    //    SQLConsulta = "SELECT DISTINCT(U.[IDPersonal]), U.[Personal], U.[Cargo], U.[UnidadAdministrativa], U.[NumeroCedula] FROM[VW_SP_INTERNO_EXTERNO] U JOIN AsignacionBien A ON U.IDPERSONAL = A.IDASIGNADOA AND A.ESTADO = 'Aplicado' JOIN ASIGNACIONBIENDETALLE AB ON A.IDASIGNACIONBIEN = AB.IDASIGNACIONBIEN AND AB.Actual = 1 JOIN Bienes B ON AB.IdBien = B.IdBien JOIN Cat.TipoArticulo T ON B.IdTipoArticulo = T.IdTipoArticulo AND T.IdTipoClasificacion NOT IN(13,7,9) WHERE U.ESTADO != 'INACTIVO'";
                    //    break;
                    //case (int)EnumActivoFijo.ArmasAsignadas:
                    //    SQLConsulta = "SELECT i.IdBien, i.CodigoSECAF, i.CUBSIGAF, i.Descripcion, i.Marca, i.Modelo, i.Color, i.IdAsignacionBienDetalle FROM vw_Inventario_Bienes i JOIN AsignacionBienDetalle a ON i.IdAsignacionBienDetalle = a.IdAsignacionBienDetalle JOIN AsignacionBien ab ON a.IdAsignacionBien = ab.IdAsignacionBien AND ab.Estado = 'Aplicado' WHERE i.IDTipoClasificacion = 9 AND(i.IdAsignadoA = " + ID2.ToString() + " AND i.Actual = 1) OR i.IdBien IN(SELECT IdBien FROM vw_Retiro_Bienes WHERE IdRetiroBien = " + ID.ToString() + ")";
                    //    break;
                    //case (int)EnumActivoFijo.VehiculosAsignados:
                    //    SQLConsulta = "SELECT i.IdBien, i.CodigoSECAF, i.CUBSIGAF, i.Descripcion, i.Marca, i.Modelo, i.Color, i.IdAsignacionBienDetalle FROM vw_Inventario_Bienes i JOIN AsignacionBienDetalle a ON i.IdAsignacionBienDetalle = a.IdAsignacionBienDetalle JOIN AsignacionBien ab ON a.IdAsignacionBien = ab.IdAsignacionBien AND ab.Estado = 'Aplicado' WHERE i.IDTipoClasificacion = 7 AND(i.IdAsignadoA = " + ID2.ToString() + " AND i.Actual = 1) OR i.IdBien IN(SELECT IdBien FROM vw_Retiro_Bienes WHERE IdRetiroBien = " + ID.ToString() + ")";
                    //    break;
                    //case (int)EnumActivoFijo.SoftwareAsignados:
                    //    SQLConsulta = "SELECT i.IdBien, i.CodigoSECAF, i.CUBSIGAF, i.Descripcion, i.Marca, i.Modelo, i.Color, i.IdAsignacionBienDetalle FROM vw_Inventario_Bienes i JOIN AsignacionBienDetalle a ON i.IdAsignacionBienDetalle = a.IdAsignacionBienDetalle JOIN AsignacionBien ab ON a.IdAsignacionBien = ab.IdAsignacionBien AND ab.Estado = 'Aplicado' WHERE i.IDTipoClasificacion = 13 AND(i.IdAsignadoA = " + ID2.ToString() + " AND i.Actual = 1) OR i.IdBien IN(SELECT IdBien FROM vw_Retiro_Bienes WHERE IdRetiroBien = " + ID.ToString() + ")";
                    //    break;
                    //case (int)EnumActivoFijo.BienesAsignados:
                    //    SQLConsulta = "SELECT i.IdBien, i.CodigoSECAF, i.CUBSIGAF, i.Descripcion, i.Marca, i.Modelo, i.Color, i.IdAsignacionBienDetalle FROM vw_Inventario_Bienes i JOIN AsignacionBienDetalle a ON i.IdAsignacionBienDetalle = a.IdAsignacionBienDetalle JOIN AsignacionBien ab ON a.IdAsignacionBien = ab.IdAsignacionBien AND ab.Estado = 'Aplicado' WHERE i.IDTipoClasificacion NOT IN(13,7,9) AND(i.IdAsignadoA = " + ID2.ToString() + " AND i.Actual = 1) OR i.IdBien IN(SELECT IdBien FROM vw_Retiro_Bienes WHERE IdRetiroBien = " + ID.ToString() + ")";
                    //    break;
                }
                return SQLConsulta;
            }
            catch (Exception)
            {
                //MessageBox.Show("Ocurrio un Error: \n" + Exec.Message.ToString() + "\n Consulte con el Administrador del Sistema.");
                return SQLConsulta;
            }
        }
    }
}
