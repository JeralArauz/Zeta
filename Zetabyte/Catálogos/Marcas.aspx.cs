using ACTIVOFIJO_GENERAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zeta_Datos;
using Zeta_LogicaNegocio.Catálogo;

namespace Zetabyte.Catálogos
{
    public partial class Marcas : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        Cls_CatalogoControlador Ctrl_Catalogo = new Cls_CatalogoControlador();
        protected void Page_Load(object sender, EventArgs e)
        {
            Ctrl_Catalogo._NombreUsuario = Session["NombreUsuario"].ToString();
        }

        protected void GridViewMarcas_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            Cls_Marcas Marca = new Cls_Marcas();
            string IdentityUser = string.Empty;
            string MsjSQL = string.Empty;
            try
            {
                if (e.NewValues["IDMarca"] == null) e.NewValues["IDMarca"] = 0;
                if (e.NewValues["Marca"] == null) e.NewValues["Marca"] = "";
                Marca.IDMarca = Convert.ToInt32(e.NewValues["IDMarca"]);
                Marca.Marca = e.NewValues["Marca"].ToString();
                //SE EJECUTA UNA INSTRUCCION QUE NO AFECTE NINGUN VALOR PARA ASI ACTIVAR EL CURSO NORMAL DEL SQLDATASOURCE.
                SqlDataSourceMarcas.InsertCommand = "UPDATE Marcas SET Marca=Marca FROM Marcas WHERE IDMarca=0";
                SqlDataSourceMarcas.ConnectionString = Ctrl_Catalogo.Conexion.ConnectionString;

                if (ValidarMarca(Marca) == true)
                {
                    //CREANDO ID DE IDENTIFICACION
                    IdentityUser = Ctrl_Catalogo.CrearIdentificadorUsuario(Ctrl_Catalogo._NombreUsuario);
                    //EJECUTANDO EL PROCEDIMIENTO ALMACENADO
                    Ctrl_Catalogo.CrearActualizarMarca(Marca, IdentityUser);
                    MsjSQL = Ctrl_Catalogo.Obtener_MensajeSQL(IdentityUser);
                    if (MsjSQL == "")     //SI EL PROCEDIMIENTO ENVIA LA DESCRIPCION VACIA, ENTONCES SE EJECUTO CORRECTAMENTE
                    {
                        this.Lbl_Mensaje.Text = "El Registro se Guardó Correctamente";
                    }
                    else
                    {
                        this.Lbl_Mensaje.Text = "  " + MsjSQL;
                    }
                    this.Lbl.Visible = true;
                    GridViewMarcas.DataBind();
                }
                else
                {
                    GridViewMarcas.DataBind();
                    e.Cancel = true;
                }
            }
            catch(Exception Ex)
            {
                Ctrl_Catalogo.Controlador_Error(Ex, Page.Response);
            }
        }

        private Boolean ValidarMarca(Cls_Marcas Marca)
        {
            Boolean Retorno = false;
            try
            {
                if (Marca.Marca.Trim().ToString() == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Debe ingresar una descripción valida.');", true);
                    goto Finalizar;
                }
                if (Ctrl_Catalogo.ValidarMarcaRepetido(Marca) == true)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('La Descripción que intenta ingresar ya existe en el catálogo.');", true);
                    goto Finalizar;
                }
                Retorno = true;
            Finalizar:
                return Retorno;
            }
            catch (Exception Exec)
            {
                Ctrl_Catalogo.Controlador_Error(Exec, Page.Response);
                return Retorno;
            }
        }

        protected void GridViewMarcas_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            Cls_Marcas Marca = new Cls_Marcas();
            string IdentityUser = string.Empty;
            string MsjSQL = string.Empty;
            try
            {
                if (e.NewValues["Marca"] == null) e.NewValues["Marca"] = "";
                Marca.IDMarca = Convert.ToInt32(e.Keys["IDMarca"].ToString());
                Marca.Marca = e.NewValues["Marca"].ToString();
                //SE EJECUTA UNA INSTRUCCION QUE NO AFECTE NINGUN VALOR PARA ASI ACTIVAR EL CURSO NORMAL DEL SQLDATASOURCE.
                SqlDataSourceMarcas.UpdateCommand = "UPDATE Marcas SET Marca=Marca WHERE IDMarca=0";
                SqlDataSourceMarcas.ConnectionString = Ctrl_Catalogo.Conexion.ConnectionString;
                if (ValidarMarca(Marca) == true)
                {
                    //CREANDO ID DE IDENTIFICACION
                    IdentityUser = Ctrl_Catalogo.CrearIdentificadorUsuario(Ctrl_Catalogo._NombreUsuario);
                    //EJECUTANDO EL PROCEDIMIENTO ALMACENADO
                    Ctrl_Catalogo.CrearActualizarMarca(Marca, IdentityUser);
                    MsjSQL = Ctrl_Catalogo.Obtener_MensajeSQL(IdentityUser);
                    if (MsjSQL == "")     //SI EL PROCEDIMIENTO ENVIA LA DESCRIPCION VACIA, ENTONCES SE EJECUTO CORRECTAMENTE
                    {
                        this.Lbl_Mensaje.Text = "El Registro se Guardó Correctamente";
                    }
                    else
                    {
                        this.Lbl_Mensaje.Text = "  " + MsjSQL;
                    }
                    this.Lbl.Visible = true;
                    GridViewMarcas.DataBind();
                }
                else
                {
                    GridViewMarcas.DataBind();
                    e.Cancel = true;
                }
            }
            catch (Exception Exec)
            {
                Ctrl_Catalogo.Controlador_Error(Exec, Page.Response);
            }
        }
    }
}