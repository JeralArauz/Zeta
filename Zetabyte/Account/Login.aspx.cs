using ACTIVOFIJO_GENERAL;
using System;
using System.Collections.Specialized;
using System.Web.Configuration;
using System.Web.Security;

namespace Zetabyte.Account
{
    public partial class Login : System.Web.UI.Page
    {
        Cls_General CG = new Cls_General();

        public NameValueCollection appSettings = WebConfigurationManager.AppSettings as NameValueCollection;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                ASPxLabelVersion.Text = "v " + version.ToString();
            }
            catch(Exception Ex)
            {
                this.ASPxLabel_Mensjae_Login.Text = Ex.Message.ToString();
                ASPxLabel_Mensjae_Login.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        protected void ASPxButton_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string Nombre_Usuario = "";
                string Contraseña = "";

                Nombre_Usuario = LoginUser.Text.Trim();
                Contraseña = LoginPassword.Text.Trim();

                if (Nombre_Usuario == "")
                {
                    ASPxLabel_Mensjae_Login.ForeColor = System.Drawing.Color.Red;
                    ASPxLabel_Mensjae_Login.Text = "Por favor escriba su usuario.";
                    LoginUser.Focus();
                    return;
                }
                else if (Contraseña == "")
                {
                    ASPxLabel_Mensjae_Login.Text = "Por favor escriba su contraseña para continuar.";
                    LoginPassword.Focus();
                    return;
                }
                else
                {
                    if(CG.ExistenDatos("Exec Iniciar_Sesion "+Nombre_Usuario+","+Contraseña)==true)
                    {
                        Session["NombreUsuario"] = Nombre_Usuario.Trim().ToString();
                        //CG.Logueos_Usuarios(LoginUser.Text.Trim());
                        Response.Redirect("~/Default.aspx", true);
                    }
                    else
                    {
                        ASPxLabel_Mensjae_Login.Text = "Error de usuario o contraseña, intente nuevamente.";
                        LoginUser.Text = "";
                        LoginPassword.Text = "";
                    }
                }
            }
            catch (Exception Ex)
            {
                this.ASPxLabel_Mensjae_Login.Text = Ex.Message.ToString();
                return;
            }
        }
    }
}