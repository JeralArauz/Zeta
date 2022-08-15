<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventario.aspx.cs" Inherits="Zetabyte.Procesos.Inventario" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.Bootstrap.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.Bootstrap" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row card-header justify-content-center font-weight-bold main">EQUIPOS REGISTRADOS</div>
        <div class="row">
            <div class="col-md-12" style="padding-left:200px;padding-right:200px; top: -38px; left: -11px; margin-top: 0px;">
                <asp:UpdatePanel ID="UdpGrid" runat="server">
                    <ContentTemplate>
                        <dx:ASPxGridView ID="GridViewInventario" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceInventario" EnableCallBacks="False" EnableTheming="True" KeyFieldName="IdEquipo" Theme="Material" OnRowUpdating="GridViewInventario_RowUpdating" OnStartRowEditing="GridViewInventario_StartRowEditing" Width="100%">
                            <SettingsAdaptivity AdaptiveColumnPosition="Left" AdaptivityMode="HideDataCellsWindowLimit" HideDataCellsAtWindowInnerWidth="800">
                            </SettingsAdaptivity>
                            <SettingsEditing Mode="PopupEditForm">
                            </SettingsEditing>
                            <Settings HorizontalScrollBarMode="Visible" />
                            <SettingsBehavior AllowSelectByRowClick="True" SortMode="DisplayText" />
                            <SettingsPopup>
                                <EditForm CloseOnEscape="True" HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" Width="800px">
                                </EditForm>
                            </SettingsPopup>
                            <Columns>
                                <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="IdEquipo" Visible="False" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Descripcion" VisibleIndex="2" Width="150px">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Estado" ReadOnly="True" VisibleIndex="17" Width="150px">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Marca" ReadOnly="True" VisibleIndex="5" Width="100px">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Modelo" ReadOnly="True" VisibleIndex="6" Width="150px">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NumeroSerie" VisibleIndex="7" Width="150px">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Color" VisibleIndex="8" Width="100px">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NumeroInventario" VisibleIndex="16" Width="100px" Caption="N Inventario">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="IdAltaEquipos" Visible="False" VisibleIndex="18">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="TipoAlta" Visible="False" VisibleIndex="19">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="FechaAlta" Visible="False" VisibleIndex="20">
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="ObservacionesAlta" Visible="False" VisibleIndex="21">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="EstadoAlta" Visible="False" VisibleIndex="22">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Costo" Visible="False" VisibleIndex="23">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="FechaAdquisicion" Visible="False" VisibleIndex="24">
                                    <EditFormSettings Visible="True" />
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="Observaciones" VisibleIndex="25" Width="150px">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="IdMarca" Visible="False" VisibleIndex="13" Caption="Marca">
                                    <PropertiesComboBox DataSourceID="SqlDataSourceMarcas" TextField="Marca" ValueField="IDMarca">
                                    </PropertiesComboBox>
                                    <EditFormSettings Visible="True" />
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="IdModelo" Visible="False" VisibleIndex="14" Caption="Modelo">
                                    <PropertiesComboBox DataSourceID="SqlDataSourceModelos" TextField="Modelo" ValueField="IDModelo">
                                    </PropertiesComboBox>
                                    <EditFormSettings Visible="True" />
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="IdColor" Visible="False" VisibleIndex="15" Caption="Color">
                                    <PropertiesComboBox DataSourceID="SqlDataSourceColores" TextField="Color" ValueField="IDColor">
                                    </PropertiesComboBox>
                                    <EditFormSettings Visible="True" />
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="TipoArticulo" ShowInCustomizationForm="True" Visible="False" VisibleIndex="3">
                                    <PropertiesComboBox DataSourceID="SqlDataSourceTipoArticulo" TextField="TipoArticulo" ValueField="IDTipoArticulo">
                                    </PropertiesComboBox>
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn Caption="Tipo Equipo" FieldName="IdTipoEquipo" ShowInCustomizationForm="True" Visible="False" VisibleIndex="4">
                                    <PropertiesComboBox DataSourceID="SqlDataSourceTipoArticulo" TextField="TipoArticulo" ValueField="IDTipoArticulo">
                                    </PropertiesComboBox>
                                    <EditFormSettings Visible="True" />
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataTextColumn FieldName="Procesador" VisibleIndex="9">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Almacenamiento" VisibleIndex="10" Width="150px">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="RAM" VisibleIndex="11">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DireccionIP" VisibleIndex="12">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <Styles>
                                <Header BackColor="#00283C" Font-Bold="True" ForeColor="White">
                                </Header>
                            </Styles>
                        </dx:ASPxGridView>
                        <asp:SqlDataSource ID="SqlDataSourceInventario" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IdEquipo], [Descripcion], [Estado], [TipoArticulo], [Marca], [Modelo], [NumeroSerie], [Color], [IdMarca], [IdModelo], [IdColor], [NumeroInventario], [IdAltaEquipos], [TipoAlta], [FechaAlta], [ObservacionesAlta], [EstadoAlta], [Costo], [FechaAdquisicion], [Observaciones], [IdTipoEquipo], [Procesador], [Almacenamiento], [RAM], [DireccionIP] FROM [View_Inventario]"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSourceMarcas" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IDMarca], [Marca] FROM [Marcas]"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSourceTipoArticulo" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IDTipoArticulo], [TipoArticulo] FROM [TipoArticulo]"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSourceModelos" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IDModelo], [Modelo] FROM [Modelos]"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSourceColores" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IDColor], [Color] FROM [Colores]"></asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
</asp:Content>
