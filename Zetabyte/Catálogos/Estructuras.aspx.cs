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
    public partial class Estructuras : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        Cls_CatalogoControlador Ctrl_Catalogo = new Cls_CatalogoControlador();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridViewEstructuras_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            Cls_Estructura Estructura = new Cls_Estructura();
            string IdentityUser = string.Empty;
            string MsjSQL = string.Empty;
            try
            {
                e.Cancel = true;
                Estructura.IdEstructura = 0;
                Estructura.Estructura = e.NewValues["Estructura"].ToString();

                string UUA = Session["NombreUsuario"].ToString();
                IdentityUser = FG.CrearIdentificadorUsuario(UUA);

                Ctrl_Catalogo.CrearActualizarEstructura(Estructura, IdentityUser, UUA);
                MsjSQL = "";
                MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    GridViewEstructuras.CancelEdit();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro agregado Correctamente');", true);
                    GridViewEstructuras.DataBind();
                    return;
                }

            }
            catch(Exception Ex)
            {
                Ctrl_Catalogo.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridViewEstructuras_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            Cls_Estructura Estructura = new Cls_Estructura();
            string IdentityUser = string.Empty;
            string MsjSQL = string.Empty;
            try
            {
                e.Cancel = true;
                Estructura.IdEstructura = Convert.ToInt32(e.Keys["IdEstructura"].ToString());
                Estructura.Estructura = e.NewValues["Estructura"].ToString();

                string UUA = Session["NombreUsuario"].ToString();
                IdentityUser = FG.CrearIdentificadorUsuario(UUA);

                Ctrl_Catalogo.CrearActualizarEstructura(Estructura, IdentityUser, UUA);
                MsjSQL = "";
                MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    GridViewEstructuras.CancelEdit();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro Actualizado Correctamente');", true);
                    GridViewEstructuras.DataBind();
                    return;
                }

            }
            catch (Exception Ex)
            {
                Ctrl_Catalogo.Controlador_Error(Ex, Page.Response);
            }
        }
    }
}