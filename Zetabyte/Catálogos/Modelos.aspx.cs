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
    public partial class Modelos : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        Cls_CatalogoControlador Ctrl_Catalogo = new Cls_CatalogoControlador();
        protected void Page_Load(object sender, EventArgs e)
        {
            Ctrl_Catalogo._NombreUsuario = Session["NombreUsuario"].ToString();
        }

        protected void GridViewModelos_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            Cls_Modelos Modelo = new Cls_Modelos();
            string IdentityUser = string.Empty;
            string MsjSQL = string.Empty;
            try
            {
                e.Cancel = true;
                if (e.NewValues["IDModelo"] == null) e.NewValues["IDModelo"] = 0;
                if (e.NewValues["Modelo"] == null) e.NewValues["Modelo"] = "";
                Modelo.IDModelo = Convert.ToInt32(e.NewValues["IDModelo"]);
                Modelo.Modelo = e.NewValues["Modelo"].ToString();
                Modelo.IDMarca = Convert.ToInt32(e.NewValues["IDMarca"].ToString());
                //SE EJECUTA UNA INSTRUCCION QUE NO AFECTE NINGUN VALOR PARA ASI ACTIVAR EL CURSO NORMAL DEL SQLDATASOURCE.
                SqlDataSourceModelos.InsertCommand = "UPDATE Modelos SET Modelo=Modelo FROM Modelos WHERE IDModelo=0";
                SqlDataSourceModelos.ConnectionString = Ctrl_Catalogo.Conexion.ConnectionString;
                if (ValidarModelo(Modelo) == true)
                {
                    //CREANDO ID DE IDENTIFICACION
                    IdentityUser = Ctrl_Catalogo.CrearIdentificadorUsuario(Ctrl_Catalogo._NombreUsuario);
                    //EJECUTANDO EL PROCEDIMIENTO ALMACENADO
                    Ctrl_Catalogo.CrearActualizarModelo(Modelo, IdentityUser);
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
                    GridViewModelos.DataBind();
                }
                else
                {
                    GridViewModelos.DataBind();
                    e.Cancel = true;
                }
            }
            catch (Exception Exec)
            {
                Ctrl_Catalogo.Controlador_Error(Exec, Page.Response);
            }
        }

        private Boolean ValidarModelo(Cls_Modelos Modelo)
        {
            Boolean Retorno = false;
            try
            {
                if (Modelo.Modelo.Trim().ToString() == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Debe ingresar una descripción valida.');", true);
                    goto Finalizar;
                }
                if (Ctrl_Catalogo.ValidarModeloRepetido(Modelo) == true)
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

        protected void GridViewModelos_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            Cls_Modelos Modelo = new Cls_Modelos();
            string IdentityUser = string.Empty;
            string MsjSQL = string.Empty;
            try
            {
                //string m = e.NewValues["Marca"].ToString();
                if (e.NewValues["Modelo"] == null) e.NewValues["Modelo"] = "";
                Modelo.IDModelo = Convert.ToInt32(e.Keys["IdModelo"].ToString());
                Modelo.Modelo = e.NewValues["Modelo"].ToString();
                Modelo.IDMarca = Convert.ToInt32(e.NewValues["IDMarca"].ToString());
                //SE EJECUTA UNA INSTRUCCION QUE NO AFECTE NINGUN VALOR PARA ASI ACTIVAR EL CURSO NORMAL DEL SQLDATASOURCE.
                SqlDataSourceModelos.UpdateCommand = "UPDATE Modelos SET Modelo=Modelo FROM Modelos WHERE IDModelo=0";
                SqlDataSourceModelos.ConnectionString = Ctrl_Catalogo.Conexion.ConnectionString;
                if (ValidarModelo(Modelo) == true)
                {
                    //CREANDO ID DE IDENTIFICACION
                    IdentityUser = Ctrl_Catalogo.CrearIdentificadorUsuario(Ctrl_Catalogo._NombreUsuario);
                    //EJECUTANDO EL PROCEDIMIENTO ALMACENADO
                    Ctrl_Catalogo.CrearActualizarModelo(Modelo, IdentityUser);
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
                    GridViewModelos.DataBind();
                }
                else
                {
                    GridViewModelos.DataBind();
                    e.Cancel = true;
                }
            }
            catch (Exception Exec)
            {
                Ctrl_Catalogo.Controlador_Error(Exec, Page.Response);
            }
        }

        protected void GridViewModelos_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            Cls_Modelos Modelo = new Cls_Modelos();
            string IdentityUser = string.Empty;
            string MsjSQL = string.Empty;
            try
            {
                Modelo.IDModelo = Convert.ToInt32(e.Keys["IdModelo"].ToString());
                //SE EJECUTA UNA INSTRUCCION QUE NO AFECTE NINGUN VALOR PARA ASI ACTIVAR EL CURSO NORMAL DEL SQLDATASOURCE.
                SqlDataSourceModelos.DeleteCommand = "DELETE FROM Modelos WHERE IDModelo=0";
                SqlDataSourceModelos.ConnectionString = Ctrl_Catalogo.Conexion.ConnectionString;
                //CREANDO ID DE IDENTIFICACION
                IdentityUser = Ctrl_Catalogo.CrearIdentificadorUsuario(Ctrl_Catalogo._NombreUsuario);
                //EJECUTANDO EL PROCEDIMIENTO ALMACENADO
                Ctrl_Catalogo.EliminarModelo(Modelo, IdentityUser);
                MsjSQL = Ctrl_Catalogo.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL == "")     //SI EL PROCEDIMIENTO ENVIA LA DESCRIPCION VACIA, ENTONCES SE EJECUTO CORRECTAMENTE
                {
                    this.Lbl_Mensaje.Text = "El Registro se Eliminó Correctamente";
                }
                else
                {
                    this.Lbl_Mensaje.Text = "  " + MsjSQL;
                }
                this.Lbl.Visible = true;
                GridViewModelos.DataBind();
            }
            catch (Exception Ex)
            {
                Ctrl_Catalogo.Controlador_Error(Ex, Page.Response);
            }
        }
    }
}