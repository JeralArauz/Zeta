using ACTIVOFIJO_GENERAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zeta_Datos.Equipos;
using Zeta_LogicaNegocio.Equipos;

namespace Zetabyte.Procesos.Altas
{
    public partial class RegistrarAltas : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        Cls_BienesControlador bienesControlador = new Cls_BienesControlador();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["IdAlta"].ToString() != "0" && Session["IdAlta"] != null)
                    {
                        CargarDatos(Session["IdAlta"].ToString());
                    }
                }
                HabilitarCampos();
                Date_FechaAlta.MaxDate = DateTime.Today;
                Date_FechaFactura.MaxDate = DateTime.Today;
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
        public void CargarDatos(string IdAlta)
        {
            try
            {
                DataSet Datos = new DataSet();
                FG.MakeRecordSet(Datos, "SELECT IdAltaEquipos, TipoAlta, FechaAlta, Factura, FechaFactura, MontoFactura, Observaciones, Estado, UAR, FAR, UUA,FUA, CASE(ISNULL(NumeroAlta, 0)) WHEN 0 THEN '' ELSE CONVERT(NVARCHAR, YEAR(FechaAlta)) + '-' + CONVERT(NVARCHAR, NumeroAlta) END AS NumeroAlta FROM AltaEquipos WHERE IdAltaEquipos = " + IdAlta + "", "");
                if (Datos.Tables[0].Rows.Count != 0)
                {
                    ComboBox_TipoAlta.Text = Datos.Tables[0].Rows[0]["TipoAlta"].ToString();
                    Memo_Observaciones.Text = Datos.Tables[0].Rows[0]["Observaciones"].ToString();
                    Date_FechaAlta.Date = Convert.ToDateTime(Datos.Tables[0].Rows[0]["FechaAlta"].ToString());
                    Text_Factura.Text = Datos.Tables[0].Rows[0]["Factura"].ToString();
                    if (Datos.Tables[0].Rows[0]["FechaFactura"].ToString() != "")
                    {
                        Date_FechaFactura.Date = Convert.ToDateTime(Datos.Tables[0].Rows[0]["FechaFactura"].ToString());
                    }
                    Spin_MotoFactura.Text = Datos.Tables[0].Rows[0]["MontoFactura"].ToString();
                    txtEstado.Text = Datos.Tables[0].Rows[0]["Estado"].ToString();
                    //DateTime año = Convert.ToDateTime(Datos.Tables[0].Rows[0]["FechaAlta"].ToString());
                    txbNumeroAlta.Text = Datos.Tables[0].Rows[0]["NumeroAlta"].ToString();
                    Session["IdAlta"] = Datos.Tables[0].Rows[0]["IdAltaEquipos"].ToString();
                    IDAlta.Text = IdAlta;
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        public void HabilitarCampos()
        {
            try
            {
                if (txtEstado.Text == "Aplicado")
                {
                    ComboBox_TipoAlta.Enabled = false;
                    Memo_Observaciones.Enabled = false;
                    Date_FechaAlta.Enabled = false;
                    Text_Factura.Enabled = false;
                    Date_FechaFactura.Enabled = false;
                    Spin_MotoFactura.Enabled = false;
                    Btn_Aplicar.Enabled = false;
                    Btn_Guardar.Enabled = false;
                    Btn_Imprimir.Enabled = true;
                }
                else
                {
                    ComboBox_TipoAlta.Enabled = true;
                    Memo_Observaciones.Enabled = true;
                    Date_FechaAlta.Enabled = true;
                    Text_Factura.Enabled = true;
                    Date_FechaFactura.Enabled = true;
                    Spin_MotoFactura.Enabled = true;
                    Btn_Aplicar.Enabled = true;
                    Btn_Guardar.Enabled = true;
                    Btn_Imprimir.Enabled = false;
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
        protected void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if (ComboBox_TipoAlta.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Seleccione el tipo de Alta');", true);
                return;
            }
            if (ComboBox_TipoAlta.Text == "Compra")
            {
                if (Text_Factura.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Debe ingresar el número de factura.');", true);
                    Text_Factura.Focus();
                    return;
                }
                else if (Date_FechaFactura.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Debe seleccionar la fecha de factura');", true);
                    Date_FechaFactura.Focus();
                    return;
                }
                else if (Spin_MotoFactura.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Debe ingresar el monto de factura.');", true);
                    Spin_MotoFactura.Focus();
                    return;
                }
            }
            if (Date_FechaAlta.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Seleccione la Fecha del Alta');", true);
                return;
            }
            Cls_Alta Alta = new Cls_Alta();
            Alta.IdAlta = Convert.ToInt32(Session["IdAlta"]);
            Alta.TipoAlta = ComboBox_TipoAlta.Text;
            Alta.FechaAlta = Date_FechaAlta.Date;
            Alta.Observaciones = Memo_Observaciones.Text;
            Alta.Factura = Text_Factura.Text;
            string monto;
            if (Spin_MotoFactura.Text != "")
            {
                monto = Convert.ToString(Spin_MotoFactura.Text);
            }
            else
            {
                monto = "0";
            }
            Alta.MontoFactura = Convert.ToDouble(monto);
            DateTime FechaF;
            if (Date_FechaFactura.Date != Convert.ToDateTime("1/1/0001 00:00:00"))
            {
                FechaF = Date_FechaFactura.Date;
            }
            else
            {
                FechaF = DateTime.Now;
            }

            Alta.FechaFactura = FechaF;

            string UUA = Session["NombreUsuario"].ToString();
            string IdentityUser = FG.CrearIdentificadorUsuario(UUA);
            string IdAltaBien = bienesControlador.AltaCrearActualizar(Alta, IdentityUser, UUA);
            string MsjSQL = "";
            MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
            if (MsjSQL != "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                return;
            }
            else
            {
                if (IdAltaBien != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro Guardado Correctamente');", true);
                    Session["IdAltaBien"] = IdAltaBien;
                    CargarDatos(IdAltaBien);
                }
            }
        }

        protected void GridViewAltas_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            try
            {
                if (Session["IdAlta"].ToString() != "0" && Session["IdAlta"] != null)
                {
                    if (txtEstado.Text == "Aplicado")
                    {
                        e.Visible = false;
                    }
                    else
                        e.Visible = true;
                }
                else
                    e.Visible = false;
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridViewAltas_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                Cls_Bien Bien = new Cls_Bien();
               
                Bien.IdEquipo = 0;
                Bien.IDAlta = Convert.ToInt32(Session["IdAlta"]);
                Bien.Descripcion = (string)e.NewValues["Descripcion"] ?? "";
                Bien.NumeroInventario = (string)e.NewValues["NumeroInventario"] ?? "";
                Bien.NumeroSerie = (string)e.NewValues["NumeroSerie"] ?? "";
                Bien.IdTipoArticulo = Convert.ToInt32(e.NewValues["IdTipoEquipo"]);
                Bien.IdModelo = Convert.ToInt32(e.NewValues["IdModelo"]);
                Bien.IdColor = Convert.ToInt32(e.NewValues["IdColor"]);
                Bien.Costo = Convert.ToDouble(e.NewValues["Costo"]);
                Bien.Observaciones = (string)e.NewValues["Observaciones"] ?? "";
                Bien.FechaAdquisicion = Convert.ToDateTime(e.NewValues["FechaAdquisicion"].ToString());
                string UUA = Session["NombreUsuario"].ToString();
                string IdentityUser = FG.CrearIdentificadorUsuario(UUA);
                bienesControlador.EquipoAgregarAlta(Bien, IdentityUser, UUA);
                string MsjSQL = "";
                MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    GridViewAltas.CancelEdit();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro Creado Correctamente');", true);
                    return;
                }

            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridViewAltas_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;
            Cls_Bien Bien = new Cls_Bien();

            Bien.IdEquipo = Convert.ToInt32(e.Keys["IdEquipo"]);

            string UUA = Session["NombreUsuario"].ToString();
            string IdentityUser = FG.CrearIdentificadorUsuario(UUA);
            bienesControlador.BienEliminar(Bien, IdentityUser, UUA);
            string MsjSQL = "";
            MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
            if (MsjSQL != "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                return;
            }
            else
            {
                GridViewAltas.CancelEdit();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro Eliminado Correctamente');", true);
                return;
            }
        }

        protected void Btn_Aplicar_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtEstado.Text == "Aplicado")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('El registro ya está aplicado.');", true);
                }
                if (Session["IdAlta"] != null && Session["IdAlta"].ToString() != "0")
                {
                    string UUA = Session["NombreUsuario"].ToString();
                    string IdentityUser = FG.CrearIdentificadorUsuario(UUA);
                    bienesControlador.AplicarAlta(Convert.ToInt32(Session["IdAlta"]), IdentityUser, UUA);
                    string MsjSQL = "";
                    MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                    if (MsjSQL != "")
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                        return;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro Aplicado Correctamente');", true);
                        CargarDatos(Session["IdAlta"].ToString());
                        HabilitarCampos();
                        GridViewAltas.DataBind();
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
            Response.Redirect("Altas.aspx");
        }
    }
}