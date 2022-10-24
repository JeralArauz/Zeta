<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarAsignaciones.aspx.cs" Inherits="Zetabyte.Procesos.Asignaciones.RegistrarAsignaciones" %>

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
    <script type="text/javascript">
        function CloseGridLookup() {
            GLE_Area.ConfirmCurrentSelection();
            GLE_Area.HideDropDown();
            GLE_Area.Focus();
        }
        function OnCheckedChanged(s, e) {
            var gv = GLE_Area.GetGridView();
            if (s.GetChecked())
                gv.SelectRows();
            else
                gv.UnselectRows();
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row card-header justify-content-center font-weight-bold main">Registrar Asignación de Equipos</div>
    <div class="row" style="text-align: right">
        <div class="col-md-8"></div>
        <div class="col-md-4">
            <dx:ASPxButton ID="BtnVolver" runat="server" Text="Regresar" BackColor="White" ForeColor="#006600" Theme="Material">
                <Image IconID="navigation_backward_svg_16x16">
                </Image>
                <Border BorderColor="#006600" BorderStyle="Double" BorderWidth="1px" />
            </dx:ASPxButton>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6 btn-group">
            <dx:ASPxButton ID="Btn_Guardar" Text="Guardar" Theme="Material" runat="server" BackColor="#006699"></dx:ASPxButton>
            <dx:ASPxButton ID="Btn_Nuevo" Text="Nuevo" Theme="Material" runat="server" BackColor="#006699"></dx:ASPxButton>
            <dx:ASPxButton ID="Btn_Aplicar" Text="Aplicar" Theme="Material" runat="server" BackColor="#006699"></dx:ASPxButton>
            <dx:ASPxButton ID="Btn_Desaplicar" Text="Desaplicar" Theme="Material" runat="server" BackColor="#006699"></dx:ASPxButton>
            <dx:ASPxButton ID="Btn_Anular" Text="Anular" Theme="Material" runat="server" BackColor="#006699"></dx:ASPxButton>
        </div>
        <div class="col-md-3 btn-group">
            <dx:ASPxButton ID="Btn_Imprimir" Text="Imprimir" Theme="Material" runat="server" BackColor="#006699"></dx:ASPxButton>
            <dx:ASPxButton ID="Btn_Seguimiento" Text="Bitácora" Theme="Material" runat="server" BackColor="#006699"></dx:ASPxButton>
        </div>
        <div class="col-md" style="text-align: right">
            <asp:UpdatePanel ID="UdpEstado" runat="server">
                <ContentTemplate>
                    <dx:ASPxTextBox ID="txtEstado" Font-Bold="true" ForeColor="#006600" runat="server" Caption="Estado" CaptionSettings-Position="Left" Width="100px" ReadOnly="true" Theme="Moderno">
                        <CaptionSettings Position="Left" VerticalAlign="Bottom" />
                        <CaptionStyle ForeColor="Black">
                            <BorderLeft BorderStyle="None" />
                            <BorderTop BorderStyle="None" />
                            <BorderRight BorderStyle="None" />
                            <BorderBottom BorderStyle="None" />
                        </CaptionStyle>
                        <BorderLeft BorderStyle="None" />
                        <BorderTop BorderStyle="None" />
                        <BorderRight BorderStyle="None" />
                        <BorderBottom BorderStyle="None" />
                    </dx:ASPxTextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-md">
            <asp:UpdatePanel ID="UdpNumero" runat="server">
                <ContentTemplate>
                    <dx:ASPxTextBox ID="txbNumeroAsignacion" Caption="Nº Asignación" runat="server" Width="119px" ReadOnly="true" Theme="Moderno" Font-Bold="True" ForeColor="#006600" HorizontalAlign="Center">
                        <CaptionSettings VerticalAlign="Bottom" />
                        <CaptionStyle Font-Bold="True" ForeColor="Black">
                        </CaptionStyle>
                        <BorderLeft BorderStyle="None" />
                        <BorderTop BorderStyle="None" />
                        <BorderRight BorderStyle="None" />
                        <BorderBottom BorderStyle="None" />
                    </dx:ASPxTextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-1">Asignado A:</div>
        <div class="col-md-6">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <dx:ASPxComboBox ID="ComboBox_AsignadoA" runat="server" AutoPostBack="True" Width="100%" Theme="Material" DataSourceID="SqlDataSourcePersonal" TextField="Personal" ValueField="IdPersonal" OnSelectedIndexChanged="ComboBox_AsignadoA_SelectedIndexChanged">
                        <Columns>
                            <dx:ListBoxColumn FieldName="IdPersonal" Visible="False">
                            </dx:ListBoxColumn>
                            <dx:ListBoxColumn Caption="Usuario" FieldName="Personal">
                            </dx:ListBoxColumn>
                            <dx:ListBoxColumn FieldName="Cargo" Visible="False">
                            </dx:ListBoxColumn>
                            <dx:ListBoxColumn FieldName="Area" Visible="False">
                            </dx:ListBoxColumn>
                            <dx:ListBoxColumn FieldName="Estructura" Visible="False">
                            </dx:ListBoxColumn>
                        </Columns>
                    </dx:ASPxComboBox>
                    <asp:SqlDataSource ID="SqlDataSourcePersonal" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IdPersonal], [Denominacion]+' '+ [Personal] AS Personal, [Cargo], [Area], [Estructura] FROM [View_Personal]"></asp:SqlDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-md-1"></div>

        <div class="col-md-1">Fecha:</div>
        <div class="col-md-2">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <dx:ASPxDateEdit ID="Date_FechaAsignacion" Width="100%" runat="server" Theme="Material"></dx:ASPxDateEdit>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-1">Cargo:</div>
        <div class="col-md-6">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <dx:ASPxTextBox ID="ASPxCargo" Width="100%" runat="server" ReadOnly="true" Theme="Material"></dx:ASPxTextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-1">Area:</div>
        <div class="col-md-6">
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <dx:ASPxTextBox ID="TextBox_Area" Width="100%" runat="server" ReadOnly="true" Theme="Material"></dx:ASPxTextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
                <dx:ASPxGridView ID="GridViewDetalle" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceDetalleAsignacion" EnableTheming="True" Theme="Material" Width="970px" ClientInstanceName="gridDetalle" EnableCallBacks="False" KeyFieldName="IDAsignacionDetalle">
                    <SettingsEditing Mode="PopupEditForm">
                    </SettingsEditing>
                    <Settings ShowFilterRow="True" />
                    <SettingsCommandButton>
                        <NewButton ButtonType="Image" RenderMode="Image">
                            <Image IconID="actions_addfile_32x32" ToolTip="Agregar Nuevo">
                            </Image>
                        </NewButton>
                        <UpdateButton ButtonType="Image" RenderMode="Image">
                            <Image IconID="actions_apply_32x32" ToolTip="Aceptar">
                            </Image>
                        </UpdateButton>
                        <CancelButton ButtonType="Image" RenderMode="Image">
                            <Image IconID="actions_cancel_32x32" ToolTip="Cancelar">
                            </Image>
                        </CancelButton>
                        <DeleteButton ButtonType="Image" RenderMode="Image">
                            <Image IconID="edit_delete_32x32" ToolTip="Eliminar">
                            </Image>
                        </DeleteButton>
                    </SettingsCommandButton>
                    <SettingsDataSecurity AllowEdit="False" />
                    <Columns>
                        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" ShowClearFilterButton="True">
                            <HeaderTemplate>
                                <dx:ASPxButton ID="AgregarNuevo" runat="server" OnClick="AgregarNuevo_Click" RenderMode="Link" Theme="Material">
                                    <Image IconID="actions_addfile_32x32" ToolTip="Agregar Nuevo">
                                    </Image>
                                </dx:ASPxButton>
                            </HeaderTemplate>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="IDAsignacionDetalle" Visible="False" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Descripcion" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Marca" ReadOnly="True" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Modelo" ReadOnly="True" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="NumeroSerie" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="NumeroInventario" VisibleIndex="6">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Styles>
                        <Header BackColor="#00283C" Font-Bold="True" ForeColor="White">
                        </Header>
                    </Styles>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="SqlDataSourceDetalleAsignacion" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IdAsignacion], [IDAsignacionDetalle], [Descripcion], [Marca], [Modelo], [NumeroSerie], [NumeroInventario] FROM [View_Asignaciones]"></asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <dx:ASPxPopupControl ID="PopupBienes" runat="server" Height="27px" Width="722px" AllowDragging="True" CloseOnEscape="True" HeaderText="Agregar Equipos" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Theme="Material">
                <ContentCollection>
                    <dx:PopupControlContentControl runat="server">
                        <dx:ASPxGridLookup ID="GridLookUpEquipos" runat="server" AutoGenerateColumns="False" Caption="Equipos:" SelectionMode="Multiple" ClientInstanceName="GLE_Area"
                            DataSourceID="SqlDataSourceEquipos" KeyFieldName="IdEquipo" Theme="Material" Width="615px" TextFormatString="{3}">
                            <GridViewProperties>
                                <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                            </GridViewProperties>
                            <Columns>
                                <dx:GridViewCommandColumn ShowSelectCheckbox="True" Caption="Select." ShowInCustomizationForm="True" VisibleIndex="0">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        Todos
                                        <dx:ASPxCheckBox ID="ASPxCheckBox_SelectAll" runat="server" AllowGrayed="True" AllowGrayedByClick="False" ClientInstanceName="cb" Theme="MaterialCompact">
                                            <ClientSideEvents CheckedChanged="OnCheckedChanged" />
                                        </dx:ASPxCheckBox>
                                    </HeaderTemplate>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="IdEquipo" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Descripcion" ShowInCustomizationForm="True" VisibleIndex="2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Estado" ShowInCustomizationForm="True" VisibleIndex="3">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Marca" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="4">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Modelo" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="5">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Color" ShowInCustomizationForm="True" VisibleIndex="6">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NumeroSerie" ShowInCustomizationForm="True" VisibleIndex="7">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NumeroInventario" ShowInCustomizationForm="True" VisibleIndex="8">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <GridViewProperties>
                                <Templates>
                                    <StatusBar>
                                        <table class="OptionsTable" style="float: right">
                                            <tr>
                                                <td>
                                                    <dx:ASPxButton ID="Close" runat="server" AutoPostBack="false" Text="Cerrar" ClientSideEvents-Click="CloseGridLookup" Theme="MaterialCompact" BackColor="#006699" />
                                                </td>
                                            </tr>
                                        </table>
                                    </StatusBar>
                                </Templates>
                                <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
                                <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" />
                                <SettingsPager AlwaysShowPager="true" PageSize="10" EnableAdaptivity="true" />
                            </GridViewProperties>
                            <CaptionStyle Font-Bold="True">
                            </CaptionStyle>
                        </dx:ASPxGridLookup>
                        <br />
                        <dx:ASPxButton ID="btnCancelar" runat="server" Theme="Material" Style="float: right;" RenderMode="Link">
                            <Image IconID="actions_cancel_32x32">
                            </Image>
                            <Border BorderColor="White" BorderStyle="Solid" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btonAceptar" runat="server" Theme="Material" Style="float: right;" RenderMode="Link">
                            <Image IconID="actions_apply_32x32" ToolTip="Aceptar">
                            </Image>
                            <Border BorderColor="White" BorderStyle="Solid" />
                        </dx:ASPxButton>
                    </dx:PopupControlContentControl>
                </ContentCollection>
            </dx:ASPxPopupControl>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:SqlDataSource ID="SqlDataSourceEquipos" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT IdEquipo, Descripcion, Estado, Marca, Modelo, Color, NumeroSerie, NumeroInventario FROM View_Inventario WHERE (Estado = 'Disponible')"></asp:SqlDataSource>
</asp:Content>
