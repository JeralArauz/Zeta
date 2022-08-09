using ACTIVOFIJO_GENERAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zeta_Datos.Catálogo;
using Zeta_LogicaNegocio.Catálogo;

namespace Zetabyte.Catálogos
{
    public partial class TipoArtículos : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        Cls_CatalogoControlador Ctrl_Catalogo = new Cls_CatalogoControlador();
        protected void Page_Load(object sender, EventArgs e)
        {
            Ctrl_Catalogo._NombreUsuario = Session["NombreUsuario"].ToString();
        }

        protected void GridViewTipoArticulos_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            Cls_TipoArticulo TipoArticulo = new Cls_TipoArticulo();
            string IdentityUser = string.Empty;
            string MsjSQL = string.Empty;
            try
            {
                if (e.NewValues["IDTipoArticulo"] == null) e.NewValues["IDTipoArticulo"] = 0;
                if (e.NewValues["TipoArticulo"] == null) e.NewValues["TipoArticulo"] = "";
                if (e.NewValues["ContieneCI"] == null) e.NewValues["ContieneCI"] = false;
                TipoArticulo.IDTipoArticulo = Convert.ToInt32(e.NewValues["IDTipoArticulo"]);
                TipoArticulo.TipoArticulo = e.NewValues["TipoArticulo"].ToString();

                //SE EJECUTA UNA INSTRUCCION QUE NO AFECTE NINGUN VALOR PARA ASI ACTIVAR EL CURSO NORMAL DEL SQLDATASOURCE.
                SqlDataSourceTipoArticulos.InsertCommand = "UPDATE TipoArticulo SET TipoArticulo=TipoArticulo WHERE IDTipoArticulo=0";
                SqlDataSourceTipoArticulos.ConnectionString = Ctrl_Catalogo.Conexion.ConnectionString;
                if (ValidarTipoArticulo(TipoArticulo) == true)
                {
                    //CREANDO ID DE IDENTIFICACION
                    IdentityUser = Ctrl_Catalogo.CrearIdentificadorUsuario(Ctrl_Catalogo._NombreUsuario);
                    //EJECUTANDO EL PROCEDIMIENTO ALMACENADO
                    Ctrl_Catalogo.CrearActualizarTipoArticulo(TipoArticulo, IdentityUser);
                    MsjSQL = Ctrl_Catalogo.Obtener_MensajeSQL(IdentityUser);
                    if (MsjSQL == "")     //SI EL PROCEDIMIENTO ENVIA LA DESCRIPCION VACIA, ENTONCES SE EJECUTO CORRECTAMENTE
                    {
                        this.Lbl_Mensaje.Text = "El Registro se Guardó Correctamente";
                    }
                    else
                    {

                        this.Lbl_Mensaje.Text = "  " + MsjSQL;
                    }
                    this.Lbl.Visible = true;
                    GridViewTipoArticulos.DataBind();
                }
                else
                {
                    GridViewTipoArticulos.DataBind();
                    e.Cancel = true;
                }
            }
            catch (Exception Exec)
            {
                Ctrl_Catalogo.Controlador_Error(Exec, Page.Response);
            }
        }

        private Boolean ValidarTipoArticulo(Cls_TipoArticulo TipoArticulo)
        {
            Boolean Retorno = false;
            try
            {
                if (TipoArticulo.TipoArticulo.Trim().ToString() == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Debe ingresar una descripción valida.');", true);
                    goto Finalizar;
                }
                if (Ctrl_Catalogo.ValidarTipoArticuloRepetido(TipoArticulo) == true)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('La Descripción que intenta ingresar ya existe en el catálogo.');", true);
                    goto Finalizar;
                }
                Retorno = true;
            Finalizar:
                return Retorno;
            }
            catch (Exception Exec)
            {
                Ctrl_Catalogo.Controlador_Error(Exec, Page.Response);
                return Retorno;
            }
        }

        protected void GridViewTipoArticulos_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            Cls_TipoArticulo TipoArticulo = new Cls_TipoArticulo();
            string IdentityUser = string.Empty;
            string MsjSQL = string.Empty;
            try
            {
                if (e.NewValues["TipoArticulo"] == null) e.NewValues["TipoArticulo"] = "";
                TipoArticulo.IDTipoArticulo = Convert.ToInt32(e.Keys["IDTipoArticulo"].ToString());
                TipoArticulo.TipoArticulo = e.NewValues["TipoArticulo"].ToString();

                //SE EJECUTA UNA INSTRUCCION QUE NO AFECTE NINGUN VALOR PARA ASI ACTIVAR EL CURSO NORMAL DEL SQLDATASOURCE.
                SqlDataSourceTipoArticulos.UpdateCommand = "UPDATE TipoArticulo SET TipoArticulo=TipoArticulo WHERE IDTipoArticulo=0";
                SqlDataSourceTipoArticulos.ConnectionString = Ctrl_Catalogo.Conexion.ConnectionString;
                if (ValidarTipoArticulo(TipoArticulo) == true)
                {
                    //CREANDO ID DE IDENTIFICACION
                    IdentityUser = Ctrl_Catalogo.CrearIdentificadorUsuario(Ctrl_Catalogo._NombreUsuario);
                    //EJECUTANDO EL PROCEDIMIENTO ALMACENADO
                    Ctrl_Catalogo.CrearActualizarTipoArticulo(TipoArticulo, IdentityUser);
                    MsjSQL = Ctrl_Catalogo.Obtener_MensajeSQL(IdentityUser);
                    if (MsjSQL == "")     //SI EL PROCEDIMIENTO ENVIA LA DESCRIPCION VACIA, ENTONCES SE EJECUTO CORRECTAMENTE
                    {
                        this.Lbl_Mensaje.Text = "El Registro se Guardó Correctamente";
                    }
                    else
                    {
                        this.Lbl_Mensaje.Text = "  " + MsjSQL;
                    }
                    this.Lbl.Visible = true;
                    GridViewTipoArticulos.DataBind();
                }
                else
                {
                    GridViewTipoArticulos.DataBind();
                    e.Cancel = true;
                }
            }
            catch (Exception Exec)
            {
                Ctrl_Catalogo.Controlador_Error(Exec, Page.Response);
            }
        }

        protected void GridViewTipoArticulos_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            Cls_TipoArticulo TipoArticulo = new Cls_TipoArticulo();
            string IdentityUser = string.Empty;
            string MsjSQL = string.Empty;
            try
            {
                TipoArticulo.IDTipoArticulo = Convert.ToInt32(e.Keys["IDTipoArticulo"].ToString());
                //SE EJECUTA UNA INSTRUCCION QUE NO AFECTE NINGUN VALOR PARA ASI ACTIVAR EL CURSO NORMAL DEL SQLDATASOURCE.
                SqlDataSourceTipoArticulos.DeleteCommand = "DELETE FROM TipoArticulo WHERE IDTipoArticulo=0";
                SqlDataSourceTipoArticulos.ConnectionString = Ctrl_Catalogo.Conexion.ConnectionString;
                //CREANDO ID DE IDENTIFICACION
                IdentityUser = Ctrl_Catalogo.CrearIdentificadorUsuario(Ctrl_Catalogo._NombreUsuario);
                //EJECUTANDO EL PROCEDIMIENTO ALMACENADO
                Ctrl_Catalogo.EliminarTipoArticulo(TipoArticulo, IdentityUser);
                MsjSQL = Ctrl_Catalogo.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL == "")     //SI EL PROCEDIMIENTO ENVIA LA DESCRIPCION VACIA, ENTONCES SE EJECUTO CORRECTAMENTE
                {
                    this.Lbl_Mensaje.Text = "El Registro se Eliminó Correctamente";
                }
                else
                {
                    this.Lbl_Mensaje.Text = "  " + MsjSQL;
                }
                this.Lbl.Visible = true;
                GridViewTipoArticulos.DataBind();
            }
            catch (Exception Exec)
            {
                Ctrl_Catalogo.Controlador_Error(Exec, Page.Response);
            }
        }
    }
}