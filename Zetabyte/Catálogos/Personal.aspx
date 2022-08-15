<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personal.aspx.cs" Inherits="Zetabyte.Catálogos.Personal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row card-header justify-content-center font-weight-bold main" style="background-color:#00283C; color:white">PERSONAL  REGISTRADO</div>
    <div class="row">
        <div class="col-md-12" style="padding-left: 30px; padding-right: 30px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Label ID="Lbl" runat="server" Text=" Mensaje :" Visible="false" Font-Names="Tahoma" Font-Size="Small" ForeColor="#006600" Width="100%" Height="20px" Font-Bold="True">
                    </asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Label ID="Lbl_Mensaje" runat="server" Text=" "
                        Font-Names="Tahoma" Font-Size="Small" ForeColor="Blue" Width="430px"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
            <dx:ASPxGridView ID="GridViewPersonal" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourcePersonal" EnableCallBacks="False" EnableTheming="True" Theme="Material" OnRowInserting="GridViewPersonal_RowInserting" KeyFieldName="IdPersonal">
                <SettingsEditing Mode="PopupEditForm">
                </SettingsEditing>
                <SettingsPopup>
                    <EditForm CloseOnEscape="True" Modal="True">
                    </EditForm>
                </SettingsPopup>
                <Columns>
                    <dx:GridViewCommandColumn ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="IdPersonal" ReadOnly="True" Visible="False" VisibleIndex="1">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Nombres" VisibleIndex="2" Width="150px">
                        <PropertiesTextEdit Width="300px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Apellidos" VisibleIndex="3" Width="150px">
                        <PropertiesTextEdit Width="300px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Estructura" VisibleIndex="7" Width="130px">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Area" VisibleIndex="5" Width="130px">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Cargo" VisibleIndex="4" Width="150px">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataCheckColumn Caption="Activo" FieldName="Estado" VisibleIndex="8">
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="IdCargo" Visible="False" VisibleIndex="6" Caption="Cargo">
                        <PropertiesComboBox EnableFocusedStyle="False" DataSourceID="SqlDataSourceCargos" TextField="Cargo" ValueField="IdCargo" Width="300px">
                            <Columns>
                                <dx:ListBoxColumn FieldName="Cargo" Width="200px">
                                </dx:ListBoxColumn>
                                <dx:ListBoxColumn FieldName="Area" Width="200px">
                                </dx:ListBoxColumn>
                                <dx:ListBoxColumn FieldName="Estructura" Width="200px">
                                </dx:ListBoxColumn>
                            </Columns>
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesComboBox>
                        <EditFormSettings Visible="True" />
                    </dx:GridViewDataComboBoxColumn>
                </Columns>
                <Styles>
                    <Header BackColor="#00283C" Font-Bold="True" ForeColor="White">
                    </Header>
                    <EditForm BackColor="#00283C">
                    </EditForm>
                </Styles>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSourcePersonal" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IdPersonal], [Nombres], [Apellidos], E.[Estructura], A.[Area], C.[Cargo], P.IdCargo, P.Estado
                FROM [Personal] P
                JOIN Cargos C ON P.IdCargo = C.IdCargo
                JOIN Areas A ON C.IdArea = A.IdArea
                JOIN Estructuras E ON A.IdEstructura = E.IdEstructura"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceCargos" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT C.[IdCargo], C.[Cargo], A.Area, E.Estructura 
FROM [Cargos] C
JOIN Areas A ON C.IdArea = A.IdArea
JOIN Estructuras E ON A.IdEstructura = E.IdEstructura"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
