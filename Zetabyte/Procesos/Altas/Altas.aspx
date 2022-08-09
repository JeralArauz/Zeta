<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Altas.aspx.cs" Inherits="Zetabyte.Procesos.Altas.Altas" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row card-header justify-content-center font-weight-bold main">ALTAS DE EQUIPOS REGISTRADAS</div>
        <br />
    <div class="row">
            <div class="col-md-12" style="padding-left:30px;padding-right:30px;">
                <asp:UpdatePanel ID="UdpGrid" runat="server">
                    <ContentTemplate>
                        <dx:ASPxGridView ID="GridViewAltas" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceAltas" EnableTheming="True" KeyFieldName="IdAltaEquipos" Theme="Material" EnableCallBacks="False" OnInitNewRow="GridViewAltas_InitNewRow" OnStartRowEditing="GridViewAltas_StartRowEditing">
                            <SettingsCommandButton>
                                <NewButton>
                                    <Image IconID="actions_insert_16x16">
                                    </Image>
                                </NewButton>
                                <EditButton ButtonType="Image" RenderMode="Image">
                                    <Image IconID="tasks_edittask_16x16">
                                    </Image>
                                </EditButton>
                            </SettingsCommandButton>
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="IdAltaEquipos" ReadOnly="True" Visible="False" VisibleIndex="1">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="FechaAlta" VisibleIndex="3" Width="150px">
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="TipoAlta" VisibleIndex="4" Width="150px">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Observaciones" VisibleIndex="5" Width="250px">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Estado" VisibleIndex="6" Width="150px">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NumeroAlta" ReadOnly="True" VisibleIndex="2" Width="150px">
                                    <Settings FilterMode="DisplayText" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewCommandColumn Caption="Opciones" Name="Opciones" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                                </dx:GridViewCommandColumn>
                            </Columns>
                            <Styles>
                                <Header BackColor="#00283C" Font-Bold="True" ForeColor="White">
                                </Header>
                            </Styles>
                        </dx:ASPxGridView>
                        <asp:SqlDataSource ID="SqlDataSourceAltas" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT DISTINCT [IdAltaEquipos], [FechaAlta], [TipoAlta], [Observaciones],[Estado],CASE [NumeroAlta] WHEN '' THEN '' ELSE 
                                            SUBSTRING(CONVERT(NVARCHAR,FechaAlta),7,5)+'-'+CONVERT(NVARCHAR,NumeroAlta) END AS NumeroAlta
                                            FROM [AltaEquipos] ORDER BY IdAltaEquipos DESC"></asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
</asp:Content>
