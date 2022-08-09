<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Zetabyte.Account.Login" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script type="text/javascript" language="javascript">
        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
    </script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login - Zetabyte</title>

    <style>
    .input-group .form-control
    {
        height:44px;
    }
    .btn {
        padding:11px 12px;
        height:44px;
    }
    .form-control
    {
        height:43px;
    }
    .input
    {
        height:43px;
    }

    .column_responsive {
    padding: 10px;
    height: auto; /* Should be removed. Only for demonstration */
    text-align:center;
    position:relative;
}
    @media (max-width: 700px)
    {
        .column_responsive
        {
            width: 100%;
        }


        .center_content
        {
            margin: auto;
            width: 60%;
            padding: 10px;
        }


        @media screen and (max-width: 300px)
        {
            span.psw
            {
                display: block;
                float: none;
            }

            .cancelbtn
            {
                width: 100%;
            }
        }

        .auto-style3
        {
            color: #FF9900;
        }
    }

     @media (max-width: 700px)
        {
            .column
            {
                width: 100%;
            }

             .div
            {
                width: 100%;
            }


            .auto-style3
            {
                margin-left: 18px;
                height: 32px;
            }

            }


    .auto-style4
    {
        color: #FF9900;
    }

      .field-icon {
            float: right;
            margin-left: -25px;
            margin-top: -25px;
            margin-right:5px;
            position: relative;
            z-index: 4;
            height: auto;
        }
      .input-group{
            text-align:left;
        }
        .form-control {
            border-radius:0px;
        }
        .dxbs-3 .dxbs-dropdown-edit .input-group div:not(.input-group-btn) + .input-group-btn:last-child > .btn:not(:hover):not(:active):not(:focus) {
            z-index: auto;
            height: 34px;
            padding-top: 15px;
        }

</style>
    <script src="Scripts/jquery.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <link href="../Styles/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/font-awesome.css" rel="stylesheet" />
    <link href="../Styles/w3.css" rel="stylesheet" />
</head>
<%--<body style="background-repeat: repeat; background-image: linear-gradient(rgb(10, 42, 63), rgb(45, 66, 107)); height: -webkit-fill-available; background-attachment: fixed">--%>
<body style="background-repeat: repeat; background-image: linear-gradient(rgb(1 34 51), rgb(1 34 51)); height: -webkit-fill-available; background-attachment: fixed">

    <form id="form1" class="column_responsive" aling="center" runat="server" style="text-align: center; height: 100%;">
        &nbsp;&nbsp;&nbsp;
            <%--<asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>--%>
        <div align="center" valign="Top" class="column_responsive">
            <br />

            <h1 class="w3-text-white">Sistema de Control Equipos Informáticos</h1>
            <div runat="server" class="w3-animate-opacity" style="text-align: -webkit-center; margin: auto; width: 100%; max-width: 600PX; min-width: 300PX; padding: 10px; top: 0px; left: 0px;">
                <br />
                <img style="height: 100px; width: 100px; border-radius: 200px 200px 200px 200px; 
                        -moz-border-radius: 200px 200px 200px 200px; 
                        -webkit-border-radius: 200px 200px 200px 200px; border: 0px solid #000000;"
                        id="profile-img" class="profile-img-card" src="<%: ResolveUrl("~/Imagenes/avatar_2x.png") %>" />
                <h1 class="w3-text-white">Inicio de Sesión</h1>
                <div class="row" style="text-align: center; background-color: #EFEFEF; min-width: 300px; max-width: 486px; border-radius: 23px 23px 23px 23px; -moz-border-radius: 23px 23px 23px 23px; -webkit-border-radius: 23px 23px 23px 23px; border: 0px solid #000000; -webkit-box-shadow: -2px 9px 37px 1px rgba(0,0,0,0.75); -moz-box-shadow: -2px 9px 37px 1px rgba(0,0,0,0.75); box-shadow: -2px 9px 37px 1px rgba(0,0,0,0.75); top: 0px; left: 928px;">
                    <div style="width: 100%; height: auto">
                        <br>
                        <div align="center">
                            <br />
                            <br />
                            <div style="max-width: 300px; width: 100%">
                                <div align="Center" class="input-group" runat="server">
                                    <div class="input-group-addon" style="height: 27px" valign="top">
                                        <i class="fa fa-user fa-2x"></i>
                                    </div>
                                    <dx:BootstrapTextBox ID="LoginUser" runat="server" NullText="Ingrese Usuario o Email" Width="253px">
                                        <ValidationSettings>
                                            <RequiredField IsRequired="True" ErrorText="" />
                                        </ValidationSettings>
                                    </dx:BootstrapTextBox>
                                </div>
                                <br />
                                <div class="input-group">
                                     <span class="input-group-addon" style="height: 27px"><i class="fa fa-lock fa-2x"></i></span>
                                    <dx:BootstrapTextBox ID="LoginPassword" ClientInstanceName="bstLoginPassword" runat="server" NullText="Ingrese Contraseña" Password="True" Width="253px" MaxLength="15">
                                        <ValidationSettings>
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:BootstrapTextBox>
                                    <span toggle="#bstLoginPassword" style="height: 24px; top: -9px; left: -17px; width: 3.8em;" class="fa fa-fw fa-eye field-icon toggle-password"></span>
                                </div>
                            </div>
                        </div>
                        <%--<span>
                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="0" DynamicLayout="False">
                                <ProgressTemplate>
                                    <span class="auto-style3">Conectando...</span>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </span>--%>
                        <br />
                        <br />
                        <div>
                            <dx:BootstrapButton ID="ASPxButton_Aceptar" runat="server" AutoPostBack="False" CssClasses-Control="btn btn-primary" Text="Iniciar Sesión" OnClick="ASPxButton_Aceptar_Click">
                            </dx:BootstrapButton>
                            <br />
                            <br />
                            <div>
                                <asp:Label ID="ASPxLabel_Mensjae_Login" runat="server" Font-Bold="False" Font-Underline="False" Style="font-size: small" ViewStateMode="Disabled" ForeColor="Red"></asp:Label>
                            </div>
                            <br />
                            <asp:LinkButton ID="LinkButton_Recup_Contra" runat="server" ForeColor="#0099FF" TabIndex="-1">Recuperar Contraseña</asp:LinkButton>
                            <br />
                            <br />
                        </div>
                         <span>
                                  <dx:ASPxLabel ID="ASPxLabelVersion" runat="server">
                                  </dx:ASPxLabel>
                                </span>
                    </div>
                </div>
            </div>

        </div>
    </form>
    <script type="text/javascript" src='<%= ResolveUrl("~/Scripts/jquery.min.js") %>'></script>
             <script type="text/javascript">
                 $(document).on('click', '.toggle-password', function () {

                     $(this).toggleClass("fa-eye fa-eye-slash");

                     var input = bstLoginPassword.GetInputElement();
                     var tipo = input.attributes["type"].nodeValue;
                     //alert(tipo);
                     tipo === 'password' ? input.setAttribute("type", "text") : input.setAttribute("type", "password");
                 });

             </script>
</body>
</html>
