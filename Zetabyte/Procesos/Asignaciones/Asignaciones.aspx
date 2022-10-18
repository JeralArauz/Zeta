<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Asignaciones.aspx.cs" Inherits="Zetabyte.Procesos.Asignaciones.Asignaciones" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row card-header justify-content-center font-weight-bold main">ASIGNACIONES DE EQUIPOS</div>
        <br />
    <div class="row">
        <div class="col-md-12" style="padding-left:30px;padding-right:30px;">
            <asp:UpdatePanel ID="UdpGrid" runat="server">
                <ContentTemplate>
                    <dx:ASPxGridView ID="GridViewAsignaciones" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceAsignaciones" EnableTheming="True" KeyFieldName="IdAsignacion" Theme="Material" OnStartRowEditing="GridViewAsignaciones_StartRowEditing" Width="962px" EnableCallBacks="False" OnInitNewRow="GridViewAsignaciones_InitNewRow">

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
                            <EditButton ButtonType="Image" RenderMode="Image">
                                <Image IconID="edit_edit_32x32" ToolTip="Editar">
                                </Image>
                            </EditButton>
                        </SettingsCommandButton>
                        <SettingsDataSecurity AllowDelete="False" />
                        <Columns>
                            <dx:GridViewCommandColumn ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn FieldName="IdAsignacion" ReadOnly="True" VisibleIndex="1">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="FechaAsignacion" VisibleIndex="3">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="IdAsignadoPor" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="IdAsignadoA" VisibleIndex="5">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Personal" VisibleIndex="6" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="NumeroAsignacion" VisibleIndex="2">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Estado" VisibleIndex="7">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <Styles>
                            <Header BackColor="#00283C" Font-Bold="True" ForeColor="White">
                            </Header>
                        </Styles>

                    </dx:ASPxGridView>
                    <asp:SqlDataSource ID="SqlDataSourceAsignaciones" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IdAsignacion], [FechaAsignacion], [IdAsignadoPor], [IdAsignadoA], [Personal], [NumeroAsignacion], [Estado] FROM [View_Asignaciones]"></asp:SqlDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
