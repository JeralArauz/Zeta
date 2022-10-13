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
    public partial class Personal : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        Cls_CatalogoControlador Ctrl_Catalogo = new Cls_CatalogoControlador();
        protected void Page_Load(object sender, EventArgs e)
        {
            Ctrl_Catalogo._NombreUsuario = Session["NombreUsuario"].ToString();
        }

        protected void GridViewPersonal_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            Cls_Personal Personal = new Cls_Personal();
            string IdentityUser = string.Empty;
            string MsjSQL = string.Empty;
            try
            {
                e.Cancel = true;
                Personal.IdPersonal = 0;
                Personal.Nombres = e.NewValues["Nombres"].ToString();
                Personal.Apellidos = e.NewValues["Apellidos"].ToString();
                Personal.IdCargo = Convert.ToInt32(e.NewValues["IdCargo"].ToString());
                Personal.IdDenominacion = Convert.ToInt32(e.NewValues["IdDenominacion"].ToString());
                Personal.Activo = Convert.ToBoolean(e.NewValues["Estado"].ToString());

                string UUA = Session["NombreUsuario"].ToString();
                IdentityUser = FG.CrearIdentificadorUsuario(UUA);

                Ctrl_Catalogo.CrearActualizarPersonal(Personal, IdentityUser, UUA);
                MsjSQL = "";
                MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    GridViewPersonal.CancelEdit();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro agregado Correctamente');", true);
                    GridViewPersonal.DataBind();
                    return;
                }
            }
            catch (Exception Exec)
            {
                Ctrl_Catalogo.Controlador_Error(Exec, Page.Response);
            }
        }

        protected void GridViewPersonal_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            Cls_Personal Personal = new Cls_Personal();
            string IdentityUser = string.Empty;
            string MsjSQL = string.Empty;
            try
            {
                e.Cancel = true;
                Personal.IdPersonal = Convert.ToInt32(e.Keys["IdPersonal"].ToString());
                Personal.Nombres = e.NewValues["Nombres"].ToString();
                Personal.Apellidos = e.NewValues["Apellidos"].ToString();
                Personal.IdCargo = Convert.ToInt32(e.NewValues["IdCargo"].ToString());
                Personal.IdDenominacion = Convert.ToInt32(e.NewValues["IdDenominacion"].ToString());
                Personal.Activo = Convert.ToBoolean(e.NewValues["Estado"].ToString());

                string UUA = Session["NombreUsuario"].ToString();
                IdentityUser = FG.CrearIdentificadorUsuario(UUA);

                Ctrl_Catalogo.CrearActualizarPersonal(Personal, IdentityUser, UUA);
                MsjSQL = "";
                MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    GridViewPersonal.CancelEdit();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro actualizado Correctamente');", true);
                    GridViewPersonal.DataBind();
                    return;
                }
            }
            catch (Exception Exec)
            {
                Ctrl_Catalogo.Controlador_Error(Exec, Page.Response);
            }
        }
    }
}