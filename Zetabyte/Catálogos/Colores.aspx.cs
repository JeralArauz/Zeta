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
    public partial class Colores : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        Cls_CatalogoControlador Ctrl_Catalogo = new Cls_CatalogoControlador();
        protected void Page_Load(object sender, EventArgs e)
        {
            Ctrl_Catalogo._NombreUsuario = Session["NombreUsuario"].ToString();
        }

        protected void GridViewColores_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            Cls_Color Color = new Cls_Color();
            string IdentityUser = string.Empty;
            string MsjSQL = string.Empty;
            try
            {
                Color.IDColor = 0;
                Color.Color = e.NewValues["Color"].ToString();

                SqlDataSourceColores.ConnectionString = Ctrl_Catalogo.Conexion.ConnectionString;
                SqlDataSourceColores.InsertCommand = "UPDATE Colores SET Color = Color WHERE IdColor = 0";

                //CREANDO ID DE IDENTIFICACION
                IdentityUser = Ctrl_Catalogo.CrearIdentificadorUsuario(Ctrl_Catalogo._NombreUsuario);

                //EJECUTANDO EL PROCEDIMIENTO ALMACENADO
                Ctrl_Catalogo.CrearActualizarColor(Color, IdentityUser);
                MsjSQL = Ctrl_Catalogo.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL == "")     //SI EL PROCEDIMIENTO ENVIA LA DESCRIPCION VACIA, ENTONCES SE EJECUTO CORRECTAMENTE
                {
                    this.Lbl_Mensaje.Text = "El Registro se Guardó Correctamente";
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('El Registro se Guardó Correctamente.');", true);
                }
                else
                {
                    this.Lbl_Mensaje.Text = "  " + MsjSQL;
                }
                this.Lbl.Visible = true;
                GridViewColores.DataBind();
            }
            catch (Exception Ex)
            {
                Ctrl_Catalogo.Controlador_Error(Ex, Page.Response);
            }
        }
    }
}