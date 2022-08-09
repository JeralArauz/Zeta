using ACTIVOFIJO_GENERAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zetabyte.Procesos.Altas
{
    public partial class Altas : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridViewAltas_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            try
            {
                Session["IdAlta"] = "0";
                Response.Redirect("RegistrarAltas.aspx");
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridViewAltas_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            try
            {
                Session["IdAlta"] = e.EditingKeyValue.ToString().Split('|')[0];
                Response.Redirect("RegistrarAltas.aspx");
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
    }
}