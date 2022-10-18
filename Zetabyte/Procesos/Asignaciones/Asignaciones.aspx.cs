using ACTIVOFIJO_GENERAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zetabyte.Procesos.Asignaciones
{
    public partial class Asignaciones : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridViewAsignaciones_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            try
            {
                Session["IdAsignacionBien"] = e.EditingKeyValue.ToString().Split('|')[0];
                Response.Redirect("RegistrarAsignaciones.aspx");
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridViewAsignaciones_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            try
            {
                Session["IdAsignacionBien"] = "0";
                Response.Redirect("RegistrarAsignaciones.aspx");
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
    }
}