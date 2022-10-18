using DevExpress.Web;
using DevExpress.Web.Bootstrap;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace ACTIVOFIJO_GENERAL
{
    public enum TipoMensaje { MsgBox, Etiqueta };
    public class Cls_General
    {
        //INICIALIZANDO LA CLASE(CONSTRUCTOR)
        public Cls_General()
        {

            //_Conexion = new SqlConnection("Data Source=" + _NombreInstancia.ToString() + ";Initial Catalog=" + _NombreBD.ToString() + ";Persist Security Info=True;User ID=" + _NombreUsuarioBD.ToString() + ";Password=" + _ContraseñaUsuario.ToString());
            //_Conexion = new SqlConnection("Data Source=SRV-DB;Initial Catalog=ActivoFijo;Integrated Security=True");
            _Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDatosSistema"].ConnectionString);
        }

        #region "VARIABLES, PROPIEDADES Y ENUMERADORES"
        //public string Hostname = "Aplicacionesmem";
        public string Nombre_Sistema = "Zetabyte";
        public string NS = "Zetabyte";
        public string NDB = "Zetabyte";
        public NameValueCollection appSettings = WebConfigurationManager.AppSettings;
        private SqlConnection _Conexion;
        public SqlConnection Conexion
        {
            get { return _Conexion; }
            set { _Conexion = value; }
        }

        private int _i;
        public int i
        {
            get { return _i; }
            set { _i = value; }
        }

        private string _sFile;
        public string sFile
        {
            get { return _sFile; }
            set { _sFile = value; }
        }
        public string _UserReg;
        public string UserReg
        {
            get { return _UserReg; }
            set { _UserReg = value; }
        }
        public string _NombreInstancia;
        public string NombreInstancia
        {
            get { return _NombreInstancia; }
            set { _NombreInstancia = value; }
        }
        public string _NombreBD;
        public string NombreBD
        {
            get { return _NombreBD; }
            set { _NombreBD = value; }
        }
        public string _NombreUsuario;
        public string NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }
        public string _NombreUsuarioBD;
        public string NombreUsuarioBD
        {
            get { return _NombreUsuarioBD; }
            set { _NombreUsuarioBD = value; }
        }
        public string _ContraseñaUsuario;
        public string ContraseñaUsuario
        {
            get { return _ContraseñaUsuario; }
            set { _ContraseñaUsuario = value; }
        }
        private SqlCommand _SqlComando;
        public SqlCommand SqlComando
        {
            get { return _SqlComando; }
            set { _SqlComando = value; }
        }

        private SqlDataAdapter _SqlAdapter;
        public SqlDataAdapter SqlAdapter
        {
            get { return _SqlAdapter; }
            set { _SqlAdapter = value; }
        }
        private SqlDataReader _SqlReader;
        public SqlDataReader SqlReader
        {
            get { return _SqlReader; }
            set { _SqlReader = value; }
        }
        private DataSet _MyDataSet;
        public DataSet MyDataSet
        {
            get { return _MyDataSet; }
            set { _MyDataSet = value; }
        }
        private DataSet _DataSetGlobal;
        public DataSet DataSetGlobal
        {
            get { return _DataSetGlobal; }
            set { _DataSetGlobal = value; }
        }
        private string _CadenaSql;
        public string CadenaSql
        {
            get { return _CadenaSql; }
            set { _CadenaSql = value; }
        }
        public string DocsGenerados = HttpContext.Current.Server.MapPath("~\\Documentos\\");
        public string DocsGenerados_Server_BD = "\\" + "\\SRV-DB\\DocsGenerados\\";
        public bool Repeat;
        private string _Ubicacion;
        public string Ubicacion
        {
            get { return _Ubicacion; }
            set { _Ubicacion = value; }
        }
        private string _Sesion_Id;
        public string Sesion_Id
        {
            get { return _Sesion_Id; }
            set { _Sesion_Id = value; }
        }
        private string _Servidor_Correo_Saliente;
        public string Servidor_Correo_Saliente
        {
            get { return _Servidor_Correo_Saliente; }
            set { _Servidor_Correo_Saliente = value; }
        }


        //ENUMERADOR GENERAL DEL SISTEMA
        public enum EnumZetabyte
        {   
            Articulo,
            TipoClasificacion,
            TipoArticulo,
            Marcas,
            Modelos,
            TipoRetiro,
            Bodega,

        }
        #endregion

        public void AbrirConexion()
        {
            if (_Conexion.State == ConnectionState.Closed)
            {
                _Conexion.Open();
            }
        }

        ////Funcion que cierra la conexión con la base de datos
        public void CerrarConexion()
        {

            if (_Conexion.State == ConnectionState.Open)
            {
                _Conexion.Close();
            }
        }
        //'*****************************************************************************************************
        //'FUNCION PARA EXTRAER EL VALOR DE UN REGISTRO EN UN CAMPO DE LA BD, PUEDE SER STRING, ENTERO, BOOLEAN
        //'HAY QUE CONVERTIR LO QUE DEVUELVE LA FUNCION EN LA CAPA DE NEGOCIO
        //'*****************************************************************************************************
        public string ObtenerValorCampo(string StrSQL)
        {
            string Retorno = string.Empty;
            _SqlComando = new SqlCommand();
            _SqlReader = null;
            AbrirConexion();
            _SqlComando.Connection = _Conexion;
            if (_SqlComando.Connection.State == ConnectionState.Closed)
            {
                _SqlComando.Connection.Open();
            }
            _SqlComando.CommandTimeout = 0;
            _SqlComando.CommandText = StrSQL;
            _SqlComando.CommandType = CommandType.Text;
            _SqlReader = _SqlComando.ExecuteReader(CommandBehavior.Default);
            while (_SqlReader.Read())
            {
                Retorno = _SqlReader.GetValue(0).ToString();
            }
            _SqlReader.Close();
            _SqlComando.Connection.Close();
            CerrarConexion();
            return Retorno;
        }
        //'*****************************************************************************************************
        //'FUNCION PARA VERIFICAR SI LA CONSULTA ENVIADA DEVUELVE AL MENOS UN REGISTRO
        //'*****************************************************************************************************
        public Boolean ExistenDatos(string Cadena)
        {
            Boolean Retorno = false;
            _MyDataSet = new DataSet();
            AbrirConexion();
            _SqlAdapter = new SqlDataAdapter(Cadena, _Conexion.ConnectionString);
            _SqlAdapter.Fill(_MyDataSet, "Data");
            if (_MyDataSet.Tables["Data"].Rows.Count != 0)
            {
                Retorno = true;
            }
            else
            {
                Retorno = false;
            }
            _MyDataSet = null;
            _SqlAdapter = null;
            CerrarConexion();
            return Retorno;
        }
        //'*****************************************************************************************************
        //EJECUTA UNA SENTENCIA SQL(EXEC, INSERT, UPDATE, DELETE, ETC)
        //'*****************************************************************************************************
        public void ExecuteSql(string Sqlstr)
        {
            _SqlComando = new SqlCommand();
            AbrirConexion();
            _SqlComando.Connection = _Conexion;
            if (_SqlComando.Connection.State == ConnectionState.Closed)
            {
                _SqlComando.Connection.Open();
            }
            _SqlComando.CommandTimeout = 0;
            _SqlComando.CommandText = Sqlstr;
            _SqlComando.CommandType = CommandType.Text;
            _SqlComando.ExecuteReader();
            _SqlComando.Connection.Close();
            CerrarConexion();
        }
        //'*****************************************************************************************************
        //EJECUTA UNA SENTENCIA SQL ESCALAR PARA OBTENER UN REGISTRO DE TIPO OBJECT(STRING, ENTERO, DECIMAL, ETC)
        //HAY QUE CONVERTIR LO QUE DEVUELVE LA FUNCION EN LA CAPA DE NEGOCIO   
        //'*****************************************************************************************************
        public Object ExecuteSQLEscalar(string Sqlstr)
        {
            object Retorno = new object();
            _SqlComando = new SqlCommand();
            AbrirConexion();
            _SqlComando.Connection = _Conexion;
            if (_SqlComando.Connection.State == ConnectionState.Closed)
            {
                _SqlComando.Connection.Open();
            }
            _SqlComando.CommandTimeout = 0;
            _SqlComando.CommandText = Sqlstr;
            _SqlComando.CommandType = CommandType.Text;
            Retorno = _SqlComando.ExecuteScalar();
            _SqlComando.Connection.Close();
            CerrarConexion();
            return Retorno;
        }
        //'*****************************************************************************************************
        // DEVUELVE UN DATASET CON REGISTROS DE UNA CONSULTA PARA QUE POSTERIORMENTE SE PUEDA RECORRER
        //'*****************************************************************************************************
        public DataSet LlenarDataSet(string Sqlstr, string NameTable)
        {
            DataSet Retorno = new DataSet();
            AbrirConexion();
            _SqlAdapter = new SqlDataAdapter(Sqlstr, _Conexion.ConnectionString);
            _MyDataSet = new DataSet();
            if (NameTable.Length != 0)
            {
                _SqlAdapter.Fill(_MyDataSet, NameTable);
            }
            else
            {
                _SqlAdapter.Fill(_MyDataSet);
            }
            Retorno = _MyDataSet;
            _MyDataSet = null;
            _SqlAdapter = null;
            CerrarConexion();
            return Retorno;
        }
        //'*****************************************************************************************************
        //FUNCION QUE DEVUELVE UN DATATABLE DE UNA LISTA (DE DISTINTOS TIPOS)
        //'*****************************************************************************************************
        public DataTable ConvertToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        public DataTable LlenarTbl(string SqlString)
        {
            DataTable Retorno = new DataTable();
            _SqlComando = new SqlCommand();
            _SqlAdapter = new SqlDataAdapter();
            AbrirConexion();
            _SqlComando.Connection = _Conexion;
            if (_SqlComando.Connection.State == ConnectionState.Closed)
            {
                _SqlComando.Connection.Open();
            }
            _SqlComando.CommandTimeout = 0;
            _SqlComando.CommandType = CommandType.Text;
            _SqlComando.CommandText = SqlString;

            _SqlAdapter.SelectCommand = _SqlComando;
            _SqlAdapter.Fill(Retorno);
            _SqlComando.Connection.Close();
            CerrarConexion();
            return Retorno;
        }
        //FUNCION PARA EJECUTAR UN PROCEDIMIENTO UTILIZANDO LA VARIABLE _SQLCOMMAND, ESTA VARIABLE DEBE ESTAR CON LOS PARAMETROS INGRESADOS ANTES DE EJECUTAR DICHA FUNCION
        public object EjecutarProcedimiento()
        {
            Object Retorno = null;
            Retorno = _SqlComando.ExecuteScalar();
            _SqlComando.Parameters.Clear();
            _SqlComando.Connection.Close();
            return Retorno;
        }
        //FUNCION PARA INICIAR LA EJECUCION DE UN PROCEDIMIENTO ALMACENADO CON LA VARIABLE _SQLCOMMAND
        public void IniciarProcedimiento(string NombreProcedimiento)
        {
            _SqlComando = null;
            _SqlComando = new SqlCommand();
            _SqlComando.Connection = Conexion;
            if (_SqlComando.Connection.State == ConnectionState.Open)
                _SqlComando.Connection.Close();
            _SqlComando.Connection.Open();
            _SqlComando.CommandType = CommandType.StoredProcedure;
            _SqlComando.CommandTimeout = 0;
            _SqlComando.CommandText = NombreProcedimiento;
        }
        //FUNCION PARA AGREGAR UN PARAMETRO A LA VARIABLE _SQLCOMMAND QUE ES CON LA CUAL SE EJECUTA LA FUNCION EJECUTAR_PROCEDIMIENTO
        public void AgregarParametroProcedimiento(String NombreParametro, System.Data.SqlDbType TipoParametro, Object ValorParametro)
        {
            _SqlComando.Parameters.Add(NombreParametro, TipoParametro).Value = ValorParametro;
        }

        public string CrearIdentificadorUsuario(string NombreUsuarioConectado)
        {
            string Retorno = string.Empty;
            Retorno = NombreUsuarioConectado + System.DateTime.Now.Date.ToShortDateString() + System.DateTime.Now.ToString("HH:mm:ss");
            return Retorno;
        }
        public string Obtener_MensajeSQL(string IdentityUser)
        {
            DataSet ErroresSQL = new DataSet();
            string MensajeErrorSQL = string.Empty;
            ErroresSQL = LlenarDataSet("SELECT DISTINCT(ISNULL(Error,'')) AS Error FROM dbo.ErrorSQL WHERE IdentityUser='" + IdentityUser + "' AND ISNULL(Error,'') <> ''", "Tbl");
            if (ErroresSQL.Tables["Tbl"].Rows.Count > 0)
            {
                MensajeErrorSQL = ErroresSQL.Tables["Tbl"].Rows[0][0].ToString();
                //ExecuteSql("DELETE FROM dbo.ErrorSQL WHERE IdentityUser='" + IdentityUser + "'");
            }
            return MensajeErrorSQL;
        }
        //FUNCION QUE LLENA UN GRIDCONTROL CON GRIDMASTER Y GRIDDETALLE
        public DataTable CargarMasterDetalle(string StrSQLMaster, string StrSQLDetalle, string Str_IDRelacionado)
        {
            DataTable Retorno = null;
            DataSet DSMaster = null;
            DataTable TblMaster = null;
            DataTable TblDetalle = null;
            DSMaster = new DataSet();
            TblMaster = new DataTable();
            TblMaster.TableName = "Marster";
            TblDetalle = new DataTable();
            TblDetalle.TableName = "Detalle";
            TblMaster = LlenarTbl(StrSQLMaster);
            TblDetalle = LlenarTbl(StrSQLDetalle);
            DSMaster.Tables.Add(TblMaster);
            DSMaster.Tables.Add(TblDetalle);
            DSMaster.Relations.Add("Detalle", DSMaster.Tables[0].Columns[Str_IDRelacionado], DSMaster.Tables[1].Columns[Str_IDRelacionado], false);
            Retorno = TblMaster;
            return Retorno;
        }
        //VALIDANDO UNA FECHA CON DATO NO NULO
        public Boolean IsDate(String fecha)
        {
            try
            {
                if ((DateTime.Parse(fecha)).Year > 1900)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        //'*****************************************************************************************************
        //EJECUTA UNA SENTENCIA SQL PARA EL CAMBIO DE CONTRASEÑA DE USUARIO
        //'*****************************************************************************************************
        public void Cambiar_Contraseña_SQL(string Usuario, string Password_Anterior, string Password_Nuevo)
        {
            ExecuteSql("sp_password @old =" + Password_Anterior + ", @new =" + Password_Nuevo + " , @loginame=" + Usuario + string.Empty);
        }
        //'*****************************************************************************************************
        //FUNCION PARA VALIDAR EL FORMATO CORRECTO DE UNA CONTRASEÑA DE USUARIO
        //'*****************************************************************************************************
        public bool ValidarPassword(string Pwd)
        {
            int i = 0; bool HayNumero = false; bool HayMayuscula = false; bool HayMinuscula = false; bool HayCaracterEspecial = false;

            //Validar Longitud
            if (Pwd.Length <= 7)
            {
                return false;
            }
            //BUSCAR NUMERO
            for (i = 0; i < Pwd.Length; i++)
            {
                if (char.IsNumber(Pwd, i) == true)
                {
                    HayNumero = true;
                    break;
                }
            }

            //BUSCAR MAYUSCULA
            for (i = 0; i < Pwd.Length; i++)
            {
                if (char.IsUpper(Pwd, i) == true)
                {
                    HayMayuscula = true;
                    break;
                }
            }

            //BUSCAR MINUSCULA
            for (i = 0; i < Pwd.Length; i++)
            {
                if (char.IsLower(Pwd, i) == true)
                {
                    HayMinuscula = true;
                    break;
                }
            }

            string caracter;
            Encoding Ascii = Encoding.ASCII;
            //BUSCAR CARACTER ESPECIAL
            for (i = 0; i < Pwd.Length; i++)
            {
                caracter = Pwd.Substring(i, 1);
                byte[] Valor = Ascii.GetBytes(caracter);
                if ((Valor[0] >= 60 && Valor[0] <= 64) || (Valor[0] >= 30 && Valor[0] <= 47)) //ENTRE 60 Y 64 Ó 30 Y 47
                {
                    HayCaracterEspecial = true;
                    break;
                }
            }

            //SI HAY VALOR
            if (HayNumero == true && HayCaracterEspecial == true && HayMayuscula == true && HayMinuscula == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void FilldataSource(SqlDataSource SqlDS, string SqlstrDS)
        {
            AbrirConexion();
            SqlDS.ConnectionString = Conexion.ConnectionString;
            SqlDS.SelectCommandType = SqlDataSourceCommandType.Text;
            SqlDS.SelectCommand = SqlstrDS;
            CerrarConexion();
        }
        public void FilldataSource_DataBind_Dev(Control Ctrl, string Sqlstr, object LinQ, Boolean ActivePropertyGrid)
        {

            if (_Conexion.State == ConnectionState.Closed)
            {
                _Conexion.Open();
            }
            if (Sqlstr != string.Empty)
            {
                SqlDataAdapter MysqlAdapter = new SqlDataAdapter(Sqlstr, _Conexion);
                DataSet Mydataset = new DataSet();
                MysqlAdapter.Fill(Mydataset);
                if (Ctrl is ASPxGridView)
                {
                    ASPxGridView Ctrl1 = (ASPxGridView)Ctrl;
                    Ctrl1.DataSource = Mydataset.Tables[0];
                }
                if (Ctrl is ASPxGridLookup)
                {
                    ASPxGridLookup Ctrl1 = (ASPxGridLookup)Ctrl;
                    Ctrl1.DataSource = Mydataset.Tables[0];
                }
                if (Ctrl is ASPxComboBox)
                {
                    ASPxComboBox Ctrl1 = (ASPxComboBox)Ctrl;
                    Ctrl1.DataSource = Mydataset.Tables[0];
                }
                if (Ctrl is BootstrapComboBox)
                {
                    BootstrapComboBox Ctrl1 = (BootstrapComboBox)Ctrl;
                    Ctrl1.DataSource = Mydataset.Tables[0];
                }
            }
            else
            {
                if (Ctrl is ASPxGridView)
                {
                    ASPxGridView Ctrl1 = (ASPxGridView)Ctrl;
                    Ctrl1.DataSource = LinQ;
                }
                if (Ctrl is ASPxGridLookup)
                {
                    ASPxGridLookup Ctrl1 = (ASPxGridLookup)Ctrl;
                    Ctrl1.DataSource = LinQ;
                }
                if (Ctrl is ASPxComboBox)
                {
                    ASPxComboBox Ctrl1 = (ASPxComboBox)Ctrl;
                    Ctrl1.DataSource = LinQ;
                }
                if (Ctrl is BootstrapComboBox)
                {
                    BootstrapComboBox Ctrl1 = (BootstrapComboBox)Ctrl;
                    Ctrl1.DataSource = LinQ;
                }
            }
            if (ActivePropertyGrid == false)
            {
                if (Ctrl is ASPxGridView)
                {
                    ASPxGridView Ctrl1 = (ASPxGridView)Ctrl;
                    Ctrl1.DataBind();
                }
                if (Ctrl is ASPxGridLookup)
                {
                    ASPxGridLookup Ctrl1 = (ASPxGridLookup)Ctrl;
                    Ctrl1.DataBind();
                }
                if (Ctrl is ASPxComboBox)
                {
                    ASPxComboBox Ctrl1 = (ASPxComboBox)Ctrl;
                    Ctrl1.DataBind();
                }
                if (Ctrl is BootstrapComboBox)
                {
                    BootstrapComboBox Ctrl1 = (BootstrapComboBox)Ctrl;
                    Ctrl1.DataBind();
                }
            }
            _Conexion.Close();
        }
        public void MakeRecordSet(DataSet MyDataSet, string Sqlstr, string NameTable)
        {
            if (_Conexion.State == ConnectionState.Closed)
            {
                _Conexion.Open();
            }
            SqlDataAdapter MySqlAdapter = new SqlDataAdapter(Sqlstr, _Conexion.ConnectionString);
            if (NameTable.Length != 0)
            {
                MySqlAdapter.Fill(MyDataSet, NameTable);
            }
            else
            {
                MySqlAdapter.Fill(MyDataSet);
            }
            MyDataSet = null;
        }
        public HttpCookie CrearCokie(string Cokie, string Valor)
        {
            HttpCookie CrearCokie = new HttpCookie(Cokie, HttpUtility.HtmlDecode(Valor));
            return CrearCokie;
        }
        //Procedimiento que permite abrir una pantalla modal
        public void Show_Windows(Page Pagina, Type Tipe, string Funcion)
        {
            ScriptManager.RegisterStartupScript(Pagina, Tipe, "PopupMensajes", "<script>" + Funcion + ";</script>", false);
        }
        private Type _tipo;
        public Type Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public HttpCookie EliminarCokie(string Cokie, string Valor)
        {
            HttpCookie EliminarCokie = new HttpCookie(Cokie, HttpUtility.HtmlDecode(Valor));
            EliminarCokie.Expires = DateTime.Now.AddDays(-1d);
            return EliminarCokie;

        }
        public void Limpiar_Cookies(HttpResponse Resp)
        {
            Resp.Cookies.Add(EliminarCokie("NombreGrupo", string.Empty));
            Resp.Cookies.Add(EliminarCokie("NombreUsuario", string.Empty));
            Resp.Cookies.Add(EliminarCokie("MyLogSI", string.Empty));
        }
        public void BorrarArchivo(string Archivo)
        {
            string FileToDelete;

            FileToDelete = DocsGenerados + Archivo;
            if (File.Exists(FileToDelete) == true)
            {
                File.Delete(FileToDelete);
            }
        }
        public string GenerarNombreFichero()
        {
            int ultimoTick = 0;
            while (ultimoTick == Environment.TickCount)
            {
                System.Threading.Thread.Sleep(1);
            }
            ultimoTick = Environment.TickCount;
            return DateTime.Now.ToString("yyyyMMddhhmmss") + "." +
            ultimoTick.ToString();
        }
        public void CargarArchivoLeer(string SqlCadenaArchivo, string NameArchivo)
        {
            SqlCommand mysql1 = new SqlCommand();
            mysql1.Connection = _Conexion;

            if (mysql1.Connection.State == ConnectionState.Closed)
            {
                mysql1.Connection.Open();
            }
            mysql1.CommandText = SqlCadenaArchivo;
            mysql1.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(mysql1);
            DataSet ds = new DataSet("Binarios");
            da.Fill(ds);
            if (ds.Tables[0].Rows[0].ItemArray[0].GetType().Name == "DBNull") { return; }
            byte[] bits = (byte[])(ds.Tables[0].Rows[0].ItemArray[0]);
            mysql1.Connection.Close();

            //sFile = "tmp_" + GenerarNombreFichero() + "_" + NameArchivo +".pdf";
            _sFile = "tmp_" + GenerarNombreFichero() + "_" + NameArchivo;
            //sFile = NameArchivo;
            FileStream fs = new FileStream(DocsGenerados + _sFile, FileMode.Create);
            fs.Write(bits, 0, Convert.ToInt32(bits.Length));
            fs.Close();
        }
        public void RegisterUpdatePanel(UpdatePanel UpdatePanel, Page Page)
        {
            var sType = typeof(ScriptManager);
            var mInfo = sType.GetMethod("System.Web.UI.IScriptManagerInternal.RegisterUpdatePanel", BindingFlags.NonPublic | BindingFlags.Instance);
            if (mInfo != null)
                mInfo.Invoke(ScriptManager.GetCurrent(Page), new object[] { UpdatePanel });
        }

        //CONTROLAR LOS ERRORES DEL SISTEMA
        public void Controlador_Error_old(Exception Ex, HttpResponse Resp)
        {
            if (Ex.Message != "Subproceso anulado.")
            {
                if (Repeat == false)//LA VARIABLE SE USA PARA CONTROLAR QUE EL EVENTO NO SE EJECUTE MAS DE UNA VEZ
                {
                    Repeat = true;
                    if (Ex is SqlException)
                    {
                        SqlException SqlEx = (SqlException)Ex;
                        //AQUI SE PONDRAN LOS NUMEROS DE ERRORES PERSONALIZADOS
                        if (SqlEx.Number == 53)//ERROR DE CONEXION
                        {
                            Resp.Cookies.Add(CrearCokie("lblMensajeErrorPage", "Error de conexion al servidor. Contacte al administrador del sistema"));
                        }
                        else
                        {
                            Resp.Cookies.Add(CrearCokie("lblMensajeErrorPage", Ex.Message));
                        }
                        Resp.Redirect("~/Error_Page.aspx", true);
                        Limpiar_Cookies(Resp);
                    }
                    //if (HttpContext.Current.Request.Cookies.Get("lblMensajeErrorPage") != null && HttpContext.Current.Request.Cookies.Get("lblMensajeErrorPage").Value != "")
                    //{
                    //    Resp.Redirect("~/Error_Page.aspx", true);
                    //    Limpiar_Cookies(Resp);
                    //}
                    else
                    {
                        Resp.Cookies.Add(CrearCokie("lblMensajeErrorPage", Ex.Message));
                        Resp.Redirect("~/Error_Page.aspx", true);
                        Limpiar_Cookies(Resp);
                    }
                }
            }
        }
        
        //Nuevo Controlador Error
        public void Controlador_Error_old2(Exception Ex, HttpResponse Resp, Enum TipoMessage = null)
        {
            if (Ex.Message == "Subproceso anulado.") { return; }
            if (Repeat == false)
            {
                Page PG = HttpContext.Current.Handler as Page;
                string NombrePagina = HttpContext.Current.Session["NombrePagina"] != null ? HttpContext.Current.Session["NombrePagina"].ToString() : PG.Request.Url.Segments[PG.Request.Url.Segments.Length - 1];
                string usuario = string.Empty;
                Repeat = true;
                string CodError = string.Empty;

                if (TipoMessage == null)
                {
                    TipoMessage = TipoMensaje.Etiqueta;
                }

                if (HttpContext.Current.Request.Cookies.AllKeys.Contains("NombreUsuario") == true)
                {
                    usuario = HttpContext.Current.Request.Cookies.Get("NombreUsuario").Value;//Accedo a la cookie del NombreUsuario
                }
                else
                {
                    usuario = HttpContext.Current.Request.UserHostName; //Ip del Usuario que ejecuta

                }
                string error = Ex.Message.Replace("'", " ");//Reemplazo comillas simples para evitar error al ejecutar la Insercion
                StackTrace stackTrace = new StackTrace(Ex, true);
                error = error + Environment.NewLine + "Origen:" + stackTrace.GetFrame(stackTrace.FrameCount - 1).GetMethod().Name + Environment.NewLine + "Linea: " + stackTrace.GetFrame(stackTrace.FrameCount - 1).GetFileLineNumber();

                CodError = DateTime.Now.ToString("yyyy-MMddhhmmss");//Codigo unico del error para referencia del usuario

                ExecuteSql("INSERT INTO COMUN..ErroresSistema (Sistema,Descripcion, Fecha, Usuario, Pantalla,CodError) VALUES('" + Nombre_Sistema + "','" + error + "',GETDATE(),'" + usuario + "','" + NombrePagina + "','" + CodError + "')");


                //WebUserControlMensajes WUCMensajes = (WebUserControlMensajes)PG.LoadControl(@"~/Procesos/WebUserControlMensajes.ascx");

                //Verifico si la pagina esta asociado a un Site Master
                var master = PG.Master;
                //Validar que tipo de mensaje se mostrara
                if (TipoMessage.ToString() == "MsgBox")
                {
                    //WebUserControlMensajes WUCMensajes = (WebUserControlMensajes)PG.LoadControl(@"~/Procesos/WebUserControlMensajes.ascx");
                    if (master != null)
                    {
                        System.Web.UI.HtmlControls.HtmlForm form = (System.Web.UI.HtmlControls.HtmlForm)PG.Master.FindControl("form1");
                        //  form.Controls.Add(WUCMensajes);
                    }
                    else
                    {
                        System.Web.UI.HtmlControls.HtmlForm form = (System.Web.UI.HtmlControls.HtmlForm)PG.FindControl("form1");
                        //form.Controls.Add(WUCMensajes);
                    }
                    //WUCMensajes.MostrarPopup(Ex.Message, 0, false);
                }
                else
                {
                    if (master != null)
                    {
                        ASPxLabel lblMaster = (ASPxLabel)PG.Master.FindControl("lblMaster");
                        lblMaster.Text = "Se ha producido un error, reintente o contacte al Administrador del Sistema. Ref.: " + CodError; ;
                    }
                    else
                    {
                        ASPxLabel lblMaster = (ASPxLabel)PG.Form.FindControl("lblMaster");
                        lblMaster.Text = Ex.Message;
                    }
                }
            }
        }
        public void Controlador_Error(Exception Ex, HttpResponse Resp, Enum TipoMessage = null)
        {
            if (Ex.Message == "Subproceso anulado.") { return; }
            if (Repeat == false)
            {
                Page PG = HttpContext.Current.Handler as Page;
                string NombrePagina = HttpContext.Current.Session["NombrePagina"] != null ? HttpContext.Current.Session["NombrePagina"].ToString() : PG.Page.AppRelativeVirtualPath.Substring(PG.Page.AppRelativeVirtualPath.LastIndexOf("/") + 1);
                ;
                string usuario = string.Empty;
                Repeat = true;
                string CodError = string.Empty;

                if (TipoMessage == null)
                {
                    TipoMessage = TipoMensaje.Etiqueta;
                }

                if (HttpContext.Current.Request.Cookies.AllKeys.Contains("NombreUsuario") == true)
                {
                    usuario = HttpContext.Current.Request.Cookies.Get("NombreUsuario").Value;//Accedo a la cookie del NombreUsuario
                }
                else
                {
                    usuario = HttpContext.Current.Request.UserHostName; //Ip del Usuario que ejecuta

                }
                string error = Ex.Message.Replace("'", " ");//Reemplazo comillas simples para evitar error al ejecutar la Insercion
                if (Ex.InnerException != null)
                {
                    error = error + Ex.InnerException.Message.Replace("'", " ");
                }
                StackTrace stackTrace = new StackTrace(Ex, true);
                error = error + Environment.NewLine + "Origen:" + stackTrace.GetFrame(stackTrace.FrameCount - 1).GetMethod().Name + Environment.NewLine + "Linea: " + stackTrace.GetFrame(stackTrace.FrameCount - 1).GetFileLineNumber();

                CodError = DateTime.Now.ToString("yyyy-MMddhhmmss");//Codigo unico del error para referencia del usuario


                ExecuteSql("INSERT INTO ErrorSQL (Error, IdentityUser) VALUES('" + error + "', '" + usuario + "')");

                if (Ex.GetType().FullName != "System.Web.HttpUnhandledException")
                    Ejecutar_Funcion_JavaScript(PG, PG.GetType(), "err_msg", "alert('Se ha producido un error inesperado.');");

            }
        }
        public string Acceso_Sistema(HttpResponse Resp, HttpRequest Req, string Usuario, string Perfil, string Pantalla)
        {
            try
            {
                //PREGUNTAR POR LA CO0KIE DE SESION
                HttpCookie authCookie = Req.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null)
                {
                    return "TimeOut";
                }
                else if (Req.Cookies.Get("NombreGrupo").Value == null)
                {
                    return "Ninguno";
                }
                else
                {
                    return "Si";
                }
            }
            catch (Exception Ex)
            {
                Limpiar_Cookies(Resp);
                Resp.Cookies.Add(CrearCokie("lblMensajeErrorPage", Ex.Message));
                Resp.Redirect("~/Error_Page.aspx", true);
                return "Ninguno";
            }
        }
        public void ObtenerParametrosComun()
        {
            DataSet DataSetGlobal = new DataSet();
            MakeRecordSet(DataSetGlobal, "SELECT * FROM VW_PARAMETROS_COMUN", "T");
            if (DataSetGlobal.Tables["T"].Rows.Count != 0)
            {
                _Ubicacion = DataSetGlobal.Tables["T"].Rows[0]["Ubicacion"].ToString();
                _Servidor_Correo_Saliente = DataSetGlobal.Tables["T"].Rows[0]["Servidor_Correo_Saliente"].ToString();
            }
            DataSetGlobal.Clear();
        }
        public string ObtenerMensaje(int Mensaje_Id)
        {
            _DataSetGlobal = new DataSet();
            MakeRecordSet(_DataSetGlobal, "SELECT Descripcion FROM COMUN..Catalogo_Mensajes WHERE (Mensaje_Id = " + Mensaje_Id + ")", "T");
            if (_DataSetGlobal.Tables["T"].Rows.Count != 0)
            {
                return _DataSetGlobal.Tables["T"].Rows[0]["Descripcion"].ToString();
            }
            else
            {
                return "No hay mensaje que mostrar. Consulte al administrador del sistema";
            }
        }
        public void Logueos_Usuarios(string Usuario)
        {
            string clientMachineName = HttpContext.Current.Request.UserHostAddress;
            string Sesion_Id = (DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString()).ToString();
            ExecuteSql("INSERT INTO COMUN..Control_Acceso_Usuarios (Sesion_Id, Usuario, Perfil, FAR, PC, Aplicacion) VALUES (" + Sesion_Id + ", '" + Usuario.Trim() + "', 'Administradores', GETDATE(), '" + clientMachineName.Trim() + "', '" + Nombre_Sistema + "')");
        }
        public string Grupo(string Usuario)
        {

            if (_Conexion.State == ConnectionState.Closed)
            {
                _Conexion.Open();
            }

            string NGrupo = string.Empty;
            DataSet DataSetGlobal = new DataSet();
            MakeRecordSet(DataSetGlobal, "SELECT Perfil FROM COMUN..vw_aspnet_UsersInRoles WHERE (Usuario = '" + Usuario + "') AND (Aplicacion = '" + appSettings.Get("NAPLICATION") + "')", "T");
            if (DataSetGlobal.Tables["T"].Rows.Count != 0)
            {
                NGrupo = DataSetGlobal.Tables["T"].Rows[0]["Perfil"].ToString();
            }

            _Conexion.Close();
            return NGrupo;
        }

        //EJECUTAR FUNCION JAVASCRIPT
        public void Ejecutar_Funcion_JavaScript(Page Pagina, Type Tipe, string KeyInstanceName, string Funcion)
        {
            ScriptManager.RegisterStartupScript(Pagina, Tipe, KeyInstanceName, "<script>" + Funcion + ";</script>", false);
        }

        //LEE UN LOGO CON LOS PARAMETROS REQUERIDOS
        public byte[] LeerLogoByte(string TipoLogo, int Año)
        {
            byte[] Retorno = null;
            DataSet DS = new DataSet();
            DS = LlenarDataSet("SELECT Logo FROM [config].[Logo] WHERE Año=" + Año.ToString() + " AND TipoLogo='" + TipoLogo + "'", "Tbl");
            if (DS.Tables["Tbl"].Rows.Count != 0)
            {
                Retorno = (byte[])DS.Tables["Tbl"].Rows[0]["Logo"];
            }
            return Retorno;
        }
        public MemoryStream LeerLogoBinaryImage(string TipoLogo, int Año)
        {
            MemoryStream MsReturn = new MemoryStream();
            System.Data.DataTable Logo = new System.Data.DataTable();
            Logo = LlenarTbl("SELECT Logo FROM Config.Logo WHERE TipoLogo='" + TipoLogo + "' AND Año=" + Año.ToString());
            MsReturn.Seek(0, System.IO.SeekOrigin.Begin);
            byte[] byteArray;
            if (Logo.Rows.Count > 0)
            {
                byteArray = (byte[])Logo.Rows[0][0];
                MsReturn.Write((byte[])Logo.Rows[0][0], 0, byteArray.Length);
            }
            else
                MsReturn = null;
            return MsReturn;
        }
        public System.Drawing.Image CargarLogo(string TipoLogo, int AñoLogo)
        {
            try
            {
                return System.Drawing.Image.FromStream(new MemoryStream(LeerLogoByte(TipoLogo, AñoLogo)));
            }
            catch (Exception)
            {
                return null;
            }
        }
        public void Seguimiento_Estados(string Tabla, int Id, string Usuario, string Texto)
        {
            ExecuteSql("INSERT INTO Seguimientos (Tabla_Id, Tabla,  Usuario, Fecha, Texto) VALUES ('" + Id + "', " + Tabla+ ", '" + Usuario + "', GETDATE()," + Texto + ")");
        }
        public Boolean Perfil_Acceso_Pantallas(string Pantalla, string Usuario)
        {
            CadenaSql = "SELECT Usuario, Pantalla, Sistema FROM COMUN..VW_SISTEMA_PERFIL_PANTALLA WHERE(Usuario = '" + Usuario + "') AND(Pantalla = '" + Pantalla + "') AND(Sistema = 'ActivoFijo')";

            if (ExistenDatos(CadenaSql) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Validar_Permiso_Pantalla()
        {
            Page PG = HttpContext.Current.Handler as Page;

            string MenuActual = HttpContext.Current.Session["MenuActual"].ToString();
            string Usuario = PG.Response.Cookies.Get("NombreUsuario").Value;
            string Perfil = PG.Response.Cookies.Get("NombreGrupo").Value;
            if (HttpContext.Current.Session["NombrePagina"] != null ) 
            {
                if (HttpContext.Current.Session["NombrePagina"].ToString() != "")
                {
                    if (HttpContext.Current.Session["NombrePagina"].ToString() != "Default.aspx")
                    {
                        if (ExistenDatos("SELECT MenuName FROM COMUN..VW_MENU_NAME WHERE (Perfil = '" + Perfil + "') AND (Usuario = '" + Usuario + "') AND MenuName='" + MenuActual + "'"))
                        {
                            return true;
                        }
                        else
                        {
                            PG.Response.Redirect("~/Default.aspx", true);
                            return false;
                        }

                    }
                    else
                    {
                        PG.Response.Redirect("~/Default.aspx", true);
                        return true;
                    }
                }
            }
            return false;
        }
        public string Obtener_Lista_GridLookup(ASPxGridLookup Ctrl, string Campo)
        {
            string Valores = "";
            //for (i = 0; i < Ctrl.GridView.Selection.Count; i++)
            for (i = 0; i < Ctrl.GridView.VisibleRowCount; i++)
            {
                if (Ctrl.GridView.Selection.IsRowSelected(i) == true)
                {
                    Valores = Valores.ToString() + ',' + Ctrl.GridView.GetRowValues(i, Campo).ToString();
                }
            }
            Valores = Valores.Substring(1);
            return Valores;
        }

    }
}
