using ACTIVOFIJO_GENERAL;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zeta_Datos.Equipos;
using Zeta_LogicaNegocio.Equipos;

namespace Zetabyte.Procesos
{
    public partial class Inventario : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        Cls_BienesControlador bienesControlador = new Cls_BienesControlador();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridViewInventario_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                Cls_Equipo Equipo = new Cls_Equipo();
                Equipo.IdEquipo = Convert.ToInt32(e.Keys["IdEquipo"]);
                Equipo.Descripcion = (string)(e.NewValues["Descripcion"] ?? "");
                Equipo.NumeroSerie = (string)(e.NewValues["NumeroSerie"] ?? "");
                Equipo.NumeroInventario = (string)(e.NewValues["NumeroInventario"] ?? "");
                Equipo.IdTipoArticulo = Convert.ToInt32(e.NewValues["IdTipoEquipo"]);
                Equipo.IdMarca = Convert.ToInt32(e.NewValues["IdMarca"]);
                Equipo.IdModelo = Convert.ToInt32(e.NewValues["IdModelo"]);
                Equipo.IdColor = Convert.ToInt32(e.NewValues["IdColor"]);
                Equipo.Costo = Convert.ToDouble(e.NewValues["Costo"] ?? 0.00);
                Equipo.FechaAdquisicion = Convert.ToDateTime(e.NewValues["FechaAdquisicion"].ToString());
                Equipo.Observaciones = (string)(e.NewValues["Observaciones"] ?? "");


                string UUA = Session["NombreUsuario"].ToString();
                string IdentityUser = FG.CrearIdentificadorUsuario(UUA);
                bienesControlador.ActualizarEquipo(Equipo, IdentityUser, UUA);
                string MsjSQL = "";
                MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    GridViewInventario.CancelEdit();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro Actualizado Correctamente');", true);
                    GridViewInventario.DataBind();
                    return;
                }

            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridViewInventario_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            try
            {
                ((GridViewDataDateColumn)GridViewInventario.Columns["FechaAdquisicion"]).PropertiesDateEdit.MaxDate = DateTime.Now;
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
    }
}