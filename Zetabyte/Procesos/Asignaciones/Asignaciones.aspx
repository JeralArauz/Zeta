<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Asignaciones.aspx.cs" Inherits="Zetabyte.Procesos.Asignaciones.Asignaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row card-header justify-content-center font-weight-bold main">ASIGNACIONES DE EQUIPOS</div>
        <br />
    <div class="row">
        <div class="col-md-12" style="padding-left:30px;padding-right:30px;">
            <asp:UpdatePanel ID="UdpGrid" runat="server">
                <ContentTemplate>
                    <dx:ASPxGridView ID="GridViewAsignaciones" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceAsignaciones" EnableTheming="True" KeyFieldName="IdEquipo" Theme="Material">

                        <SettingsCommandButton>
                            <NewButton ButtonType="Image" RenderMode="Image">
                                <Image IconID="actions_addfile_32x32" ToolTip="Agregar Nuevo">
                                </Image>
                            </NewButton>
                            <CancelButton ButtonType="Image" RenderMode="Image">
                                <Image IconID="actions_cancel_32x32" ToolTip="Cancelar">
                                </Image>
                            </CancelButton>
                            <EditButton ButtonType="Image" RenderMode="Image">
                                <Image IconID="edit_edit_32x32" ToolTip="Editar">
                                </Image>
                            </EditButton>
                        </SettingsCommandButton>
                        <SettingsDataSecurity AllowDelete="False" />
                        <Columns>
                            <dx:GridViewCommandColumn ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn FieldName="IdEquipo" ReadOnly="True" Visible="False" VisibleIndex="1">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Descripcion" VisibleIndex="2">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Estado" VisibleIndex="3">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="TipoArticulo" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Marca" ReadOnly="True" VisibleIndex="5">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <Styles>
                            <Header BackColor="#00283C" Font-Bold="True" ForeColor="White">
                            </Header>
                        </Styles>

                    </dx:ASPxGridView>
                    <asp:SqlDataSource ID="SqlDataSourceAsignaciones" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IdEquipo], [Descripcion], [Estado], [TipoArticulo], [Marca] FROM [View_Inventario]"></asp:SqlDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
