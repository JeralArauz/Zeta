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
    public partial class Areas : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        Cls_CatalogoControlador Ctrl_Catalogo = new Cls_CatalogoControlador();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridViewAreas_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            Cls_Area Area = new Cls_Area();
            string IdentityUser = string.Empty;
            string MsjSQL = string.Empty;

            try
            {
                e.Cancel = true;
                Area.IdArea = 0;
                Area.Area = e.NewValues["Area"].ToString();
                Area.IdEstructura = Convert.ToInt32(e.NewValues["IdEstructura"].ToString());

                string UUA = Session["NombreUsuario"].ToString();
                IdentityUser = FG.CrearIdentificadorUsuario(UUA);

                Ctrl_Catalogo.CrearActualizarArea(Area, IdentityUser, UUA);
                MsjSQL = "";
                MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    GridViewAreas.CancelEdit();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro agregado Correctamente');", true);
                    GridViewAreas.DataBind();
                    return;
                }
            }
            catch(Exception Ex)
            {
                Ctrl_Catalogo.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridViewAreas_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            Cls_Area Area = new Cls_Area();
            string IdentityUser = string.Empty;
            string MsjSQL = string.Empty;

            try
            {
                e.Cancel = true;
                Area.IdArea = Convert.ToInt32(e.Keys["IdArea"].ToString());
                Area.Area = e.NewValues["Area"].ToString();
                Area.IdEstructura = Convert.ToInt32(e.NewValues["IdEstructura"].ToString());

                string UUA = Session["NombreUsuario"].ToString();
                IdentityUser = FG.CrearIdentificadorUsuario(UUA);

                Ctrl_Catalogo.CrearActualizarArea(Area, IdentityUser, UUA);
                MsjSQL = "";
                MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    GridViewAreas.CancelEdit();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro Actualizado Correctamente');", true);
                    GridViewAreas.DataBind();
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