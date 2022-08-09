using ACTIVOFIJO_GENERAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zetabyte
{
    public partial class SiteMaster : MasterPage
    {
        Cls_General CG = new Cls_General();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ASPxButton_Finalizar_Sesion_Click(object sender, EventArgs e)
        {
            Session["NombrePagina"] = null;
            Session["NombreUsuario"] = null;
            FormsAuthentication.SignOut();
            CG.Limpiar_Cookies(Page.Response);
            DisablePageCaching();
            Session.Clear(); //limpiar variables de sesiones al cambiar de usuario
                             // FormsAuthentication.RedirectToLoginPage();

            Session["Mensaje"] = "La sesión ha caducado, ingrese sus credenciales.";
            Response.Redirect("~/Account/Login.aspx");

            return;
        }

        public static void DisablePageCaching()
        {
            //Used for disabling page caching
            HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
            HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();
        }
    }
}