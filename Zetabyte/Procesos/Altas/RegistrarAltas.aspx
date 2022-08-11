<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarAltas.aspx.cs" Inherits="Zetabyte.Procesos.Altas.RegistrarAltas" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .row {
            padding-top: 5px;
            margin-right: 20px;
            margin-left: 20px;
            text-align: left;
            height: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row card-header justify-content-center font-weight-bold main">Registrar Alta de Bienes</div>
    <div class="row" style="text-align: right">
        <div class="col-md-8"></div>
        <div class="col-md-4">
            <dx:ASPxButton ID="BtnVolver" runat="server" Text="Regresar" BackColor="White" ForeColor="#009999" Theme="Material" OnClick="BtnVolver_Click">
                <Image IconID="navigation_backward_svg_16x16">
                </Image>
                <Border BorderColor="#006600" BorderStyle="Solid" BorderWidth="1px" />
            </dx:ASPxButton>
        </div>
    </div>
    <div class="row">
        <div class="col-md-5 btn-group">
            <dx:ASPxButton ID="Btn_Guardar" Text="Guardar" Theme="Material" runat="server" BackColor="#006699" OnClick="Btn_Guardar_Click"></dx:ASPxButton>
            <dx:ASPxButton ID="Btn_Nuevo" Text="Nuevo" Theme="Material" runat="server" BackColor="#006699"></dx:ASPxButton>
            <dx:ASPxButton ID="Btn_Aplicar" Text="Aplicar" Theme="Material" runat="server" BackColor="#006699" OnClick="Btn_Aplicar_Click"></dx:ASPxButton>
            <dx:ASPxButton ID="Btn_Imprimir" Text="Imprimir" Theme="Material" runat="server" BackColor="#006699"></dx:ASPxButton>
            <dx:ASPxLabel ID="IDAlta" runat="server" Visible="false"></dx:ASPxLabel>
        </div>
        <div class="col-md-4 btn-group">
        </div>
        <div class="col-md-2 btn-group">
            <dx:ASPxTextBox ID="txbNumeroAlta" runat="server" Caption="Numero Alta" Font-Bold="True" ForeColor="#006600" CaptionSettings-Position="Left" Width="124px" ReadOnly="True" Theme="Moderno" HorizontalAlign="Center" BackColor="White">
                <CaptionSettings Position="Left" HorizontalAlign="Center" VerticalAlign="Bottom"></CaptionSettings>
                <CaptionStyle BackColor="White" ForeColor="Black">
                </CaptionStyle>
                <BorderLeft BorderStyle="None" />
                <BorderTop BorderStyle="None" />
                <BorderRight BorderStyle="None" />
                <BorderBottom BorderStyle="Solid" />
            </dx:ASPxTextBox>
        </div>
    </div>
    <div class="row">

        <div class="col-md-4">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <dx:ASPxComboBox ID="ComboBox_TipoAlta" AutoPostBack="true" Width="160px" runat="server" Caption="Tipo de Alta:" Theme="MaterialCompact">
                        <Items>
                            <dx:ListEditItem Text="Compra" Value="Compra" />
                            <dx:ListEditItem Text="Donación" Value="Donación" />
                            <dx:ListEditItem Text="Traslado Institucional" Value="Traslado Institucional" />
                            <dx:ListEditItem Text="Otros" Value="Otros" />
                        </Items>
                        <CaptionStyle Font-Size="Medium">
                        </CaptionStyle>
                    </dx:ASPxComboBox>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-md-5">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <dx:ASPxDateEdit ID="Date_FechaAlta" Width="160px" runat="server" Caption="Fecha:" Theme="MaterialCompact">
                        <CaptionStyle Font-Size="Medium">
                        </CaptionStyle>
                    </dx:ASPxDateEdit>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-md-3" style="text-align: right">
            <asp:UpdatePanel ID="UdpEstado" runat="server">
                <ContentTemplate>
                    <dx:ASPxTextBox ID="txtEstado" Font-Bold="true" ForeColor="#006600" runat="server" HorizontalAlign="Center" BackColor="White" CaptionSettings-Position="Left" Width="100px" ReadOnly="true" Caption="Estado:">
                        <CaptionSettings HorizontalAlign="Right" Position="Left" />
                        <CaptionStyle Font-Size="Medium" ForeColor="Black">
                        </CaptionStyle>
                    </dx:ASPxTextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <dx:ASPxTextBox ID="Text_Factura" runat="server" Width="100%" Caption="Número de Factura:" Theme="MaterialCompact">
                        <CaptionStyle Font-Size="Medium">
                        </CaptionStyle>
                    </dx:ASPxTextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="col-md-4">
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <dx:ASPxDateEdit ID="Date_FechaFactura" runat="server" Width="100%" Theme="MaterialCompact" Caption="Fecha Factura:">
                        <CaptionStyle Font-Size="Medium">
                        </CaptionStyle>
                    </dx:ASPxDateEdit>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-md-4">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <dx:ASPxSpinEdit ID="Spin_MotoFactura" Width="100%" runat="server" MinValue="1" MaxValue="999999999999" DecimalPlaces="2" DisplayFormatString="N2" Caption="Monto:" Theme="MaterialCompact">
                        <CaptionStyle Font-Size="Medium">
                        </CaptionStyle>
                    </dx:ASPxSpinEdit>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <dx:ASPxMemo ID="Memo_Observaciones" Width="100%" runat="server" Theme="MaterialCompact" Caption="Observaciones:">
                        <CaptionStyle Font-Size="Medium">
                        </CaptionStyle>
                    </dx:ASPxMemo>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">&nbsp;</div>
    </div>
    <div class="row">
        <div class="col-md-12" style="padding-left: 35px; padding-right: 35px; top: -38px; left: -11px; margin-top: 0px;">
            <asp:UpdatePanel ID="UdpGrid" runat="server">
                <ContentTemplate>
                    <dx:ASPxGridView ID="GridViewAltas" runat="server" Theme="Material" AutoGenerateColumns="False" DataSourceID="SqlDataSourceInventario" EnableCallBacks="False" KeyFieldName="IdEquipo" Width="1425px" OnCommandButtonInitialize="GridViewAltas_CommandButtonInitialize" OnRowDeleting="GridViewAltas_RowDeleting" OnRowInserting="GridViewAltas_RowInserting" OnStartRowEditing="GridViewAltas_StartRowEditing">
                        <SettingsEditing Mode="PopupEditForm">
                        </SettingsEditing>
                        <SettingsBehavior ConfirmDelete="True" />
                        <SettingsPopup>
                            <EditForm CloseOnEscape="True" HorizontalAlign="WindowCenter" Modal="True" VerticalAlign="WindowCenter" Width="800px">
                            </EditForm>
                        </SettingsPopup>
                        <Columns>
                            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn FieldName="IdEquipo" ReadOnly="True" VisibleIndex="1" Visible="False">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Descripcion" VisibleIndex="2">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Costo" VisibleIndex="8" Visible="False">
                                <EditFormSettings Visible="True" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="NumeroSerie" VisibleIndex="9">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="FechaAdquisicion" VisibleIndex="10" Visible="False">
                                <EditFormSettings Visible="True" />
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="Observaciones" VisibleIndex="11">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn Caption="Tipo Equipo" FieldName="IdTipoEquipo" ShowInCustomizationForm="True" VisibleIndex="3">
                                <PropertiesComboBox DataSourceID="SqlDataSourceTipoArticulo" TextField="TipoArticulo" ValueField="IDTipoArticulo">
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn Caption="Marca" FieldName="IdMarca" ShowInCustomizationForm="True" VisibleIndex="5">
                                <PropertiesComboBox DataSourceID="SqlDataSourceMarcas" TextField="Marca" ValueField="IDMarca">
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn Caption="Modelo" FieldName="IdModelo" ShowInCustomizationForm="True" VisibleIndex="6">
                                <PropertiesComboBox DataSourceID="SqlDataSourceModelos" TextField="Modelo" ValueField="IDModelo">
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn Caption="Color" FieldName="IdColor" ShowInCustomizationForm="True" VisibleIndex="7">
                                <PropertiesComboBox DataSourceID="SqlDataSourceColores" TextField="Color" ValueField="IDColor">
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataTextColumn FieldName="NumeroInventario" ShowInCustomizationForm="True" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Procesador" Visible="False" VisibleIndex="12">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Almacenamiento" Visible="False" VisibleIndex="13">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="RAM" Visible="False" VisibleIndex="14">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="DireccionIP" Visible="False" VisibleIndex="15">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <Styles>
                            <Header BackColor="#00283C" Font-Bold="True" ForeColor="White">
                            </Header>
                        </Styles>
                    </dx:ASPxGridView>
                    <asp:SqlDataSource ID="SqlDataSourceInventario" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT b.IdEquipo, b.Descripcion, b.NumeroInventario,b.IdTipoEquipo, m.IdMarca, b.IdModelo, b.IdColor, 
b.Procesador, b.Almacenamiento, b.RAM, b.DireccionIP, b.Costo, b.NumeroSerie, b.FechaAdquisicion,
b.Observaciones
FROM Equipos b LEFT JOIN Modelos m on b.IdModelo = m.IdModelo
WHERE (IdAltaEquipos = @IdAlta)
ORDER BY b.FAR">
                        <SelectParameters>
                            <asp:SessionParameter Name="IdAlta" SessionField="IdAlta" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSourceTipoArticulo" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IDTipoArticulo], [TipoArticulo] FROM [TipoArticulo] ORDER BY [TipoArticulo]"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSourceModelos" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IDModelo], [Modelo] FROM [Modelos]"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSourceMarcas" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IDMarca], [Marca] FROM [Marcas]"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSourceColores" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IDColor], [Color] FROM [Colores]"></asp:SqlDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
