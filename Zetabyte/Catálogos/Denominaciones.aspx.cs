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
    public partial class Denominaciones : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        Cls_CatalogoControlador Ctrl_Catalogo = new Cls_CatalogoControlador();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Ctrl_Catalogo._NombreUsuario = Session["NombreUsuario"].ToString();
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridViewDenominaciones_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            Cls_Denominacion Denominacion = new Cls_Denominacion();
            string IdentityUser = string.Empty;
            string MsjSQL = string.Empty;
            try
            {
                e.Cancel = true;
                Denominacion.IdDenominacion = 0;
                Denominacion.Denominacion = e.NewValues["Denominacion"].ToString();

                string UUA = Session["NombreUsuario"].ToString();
                IdentityUser = FG.CrearIdentificadorUsuario(UUA);

                Ctrl_Catalogo.CrearActualizarDenominacion(Denominacion, IdentityUser, UUA);

                MsjSQL = "";
                MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    GridViewDenominaciones.CancelEdit();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro agregado Correctamente');", true);
                    GridViewDenominaciones.DataBind();
                }
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridViewDenominaciones_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            Cls_Denominacion Denominacion = new Cls_Denominacion();
            string IdentityUser = string.Empty;
            string MsjSQL = string.Empty;
            try
            {
                e.Cancel = true;
                Denominacion.IdDenominacion = Convert.ToInt32(e.Keys["IdDenominacion"].ToString());
                Denominacion.Denominacion = e.NewValues["Denominacion"].ToString();

                string UUA = Session["NombreUsuario"].ToString();
                IdentityUser = FG.CrearIdentificadorUsuario(UUA);

                Ctrl_Catalogo.CrearActualizarDenominacion(Denominacion, IdentityUser, UUA);

                MsjSQL = "";
                MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    GridViewDenominaciones.CancelEdit();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro actualizado Correctamente');", true);
                    GridViewDenominaciones.DataBind();
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
    }
}