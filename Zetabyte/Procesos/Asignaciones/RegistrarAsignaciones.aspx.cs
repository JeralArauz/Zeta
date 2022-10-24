using ACTIVOFIJO_GENERAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress;
using Zeta_Datos.Equipos;
using Zeta_LogicaNegocio.Equipos;
using System.Data;

namespace Zetabyte.Procesos.Asignaciones
{
    public partial class RegistrarAsignaciones : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        Cls_BienesControlador bienesControlador = new Cls_BienesControlador();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["IdAsignacion"].ToString() != "0" && Session["IdAsignacion"] != null)
                    {
                        CargarDatos(Session["IdAsignacion"].ToString());
                    }
                }
                Date_FechaAsignacion.MaxDate = DateTime.Today;
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        public void CargarDatos(string IdAsignacionBien)
        {
            try
            {
                DataSet Datos = new DataSet();
                FG.MakeRecordSet(Datos, "SELECT * FROM View_Asignaciones WHERE IdAsignacion = '" + IdAsignacionBien + "'", "");
                if (Datos.Tables[0].Rows.Count != 0)
                {
                    ComboBox_AsignadoA.Value = Datos.Tables[0].Rows[0]["IdAsignadoA"];
                    ComboBox_AsignadoA.Text = Datos.Tables[0].Rows[0]["Personal"].ToString();
                    TextBox_Area.Text = Datos.Tables[0].Rows[0]["Area"].ToString();
                    ASPxCargo.Text = Datos.Tables[0].Rows[0]["Cargo"].ToString();
                    Observaciones.Text = Datos.Tables[0].Rows[0]["Observacion"].ToString();
                    Date_FechaAsignacion.Date = Convert.ToDateTime(Datos.Tables[0].Rows[0]["FechaAsignacion"].ToString());
                    txbNumeroAsignacion.Text = Datos.Tables[0].Rows[0]["NumeroAsignacion"].ToString();
                    txtEstado.Text = Datos.Tables[0].Rows[0]["Estado"].ToString();
                }
            }
            catch (Exception Ex)
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

        protected void ComboBox_AsignadoA_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox_Area.Text = ComboBox_AsignadoA.SelectedItem.GetFieldValue("Area").ToString() + " - " + ComboBox_AsignadoA.SelectedItem.GetFieldValue("Estructura").ToString();
                ASPxCargo.Text = ComboBox_AsignadoA.SelectedItem.GetFieldValue("Cargo").ToString();
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void Btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(ComboBox_AsignadoA.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Seleccione el personal');", true);
                    return;
                }
                if (Date_FechaAsignacion.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Seleccione la Fecha de la Asignación');", true);
                    return;
                }

                Cls_Asignacion Asignacion = new Cls_Asignacion();
                Asignacion.IdAsignacion = Convert.ToInt32(Session["IdAsignacionBien"]);
                Asignacion.IDAsignadoA = Convert.ToInt32(ComboBox_AsignadoA.Items.FindByText(ComboBox_AsignadoA.Text).GetFieldValue("IdPersonal"));
                Asignacion.Fecha_Asignacion = Date_FechaAsignacion.Date;
                Asignacion.Observaciones = Observaciones.Text;

                string UUA = Session["NombreUsuario"].ToString();
                string IdentityUser = FG.CrearIdentificadorUsuario(UUA);
                string IdAsignacion = bienesControlador.AsignacionCrearActualizar(Asignacion, IdentityUser, UUA);

                string MsjSQL = "";
                MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    if (IdAsignacion != "")
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro Guardado Correctamente');", true);
                        Session["IdAsignacion"] = IdAsignacion;
                        CargarDatos(IdAsignacion);
                    }
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            try
            {
                Session["IdAsignacion"] = "";
                Response.Redirect("Asignaciones.aspx");
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
    }
}