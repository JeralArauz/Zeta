using ACTIVOFIJO_GENERAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress;

namespace Zetabyte.Procesos.Asignaciones
{
    public partial class RegistrarAsignaciones : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Date_FechaAsignacion.MaxDate = DateTime.Today;
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void AgregarNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txtEstado.Text != "Registrado")
                //{
                //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('No puede agregar bienes.');", true);
                //    return;
                //}
                PopupBienes.ShowOnPageLoad = true;
                PopupBienes.PopupHorizontalAlign = DevExpress.Web.PopupHorizontalAlign.WindowCenter;
                PopupBienes.PopupVerticalAlign = DevExpress.Web.PopupVerticalAlign.WindowCenter;
                PopupBienes.CloseOnEscape = true;
                PopupBienes.AllowDragging = true;
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
    }
}