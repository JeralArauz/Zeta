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
                Personal.Estructura = e.NewValues["Estructura"].ToString();
            }
            catch (Exception Exec)
            {
                Ctrl_Catalogo.Controlador_Error(Exec, Page.Response);
            }
        }    
    }
}