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
            <dx:ASPxGridView ID="GridViewPersonal" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourcePersonal" EnableCallBacks="False" EnableTheming="True" Theme="Material" OnRowInserting="GridViewPersonal_RowInserting" KeyFieldName="IdPersonal" OnRowUpdating="GridViewPersonal_RowUpdating">
                <SettingsEditing Mode="PopupEditForm">
                </SettingsEditing>
                <Settings ShowHeaderFilterButton="True" ShowFilterRow="True" />
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
                    <DeleteButton ButtonType="Image" RenderMode="Image">
                        <Image IconID="edit_delete_32x32" ToolTip="Eliminar">
                        </Image>
                    </DeleteButton>
                </SettingsCommandButton>
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
                    <dx:GridViewDataTextColumn FieldName="Nombres" VisibleIndex="4" Width="150px">
                        <PropertiesTextEdit Width="300px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                        <SettingsHeaderFilter Mode="CheckedList">
                        </SettingsHeaderFilter>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Apellidos" VisibleIndex="5" Width="150px">
                        <PropertiesTextEdit Width="300px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                        <SettingsHeaderFilter Mode="CheckedList">
                        </SettingsHeaderFilter>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Estructura" VisibleIndex="9" Width="130px">
                        <SettingsHeaderFilter Mode="CheckedList">
                        </SettingsHeaderFilter>
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Area" VisibleIndex="7" Width="130px">
                        <SettingsHeaderFilter Mode="CheckedList">
                        </SettingsHeaderFilter>
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Cargo" VisibleIndex="6" Width="150px">
                        <SettingsHeaderFilter Mode="CheckedList">
                        </SettingsHeaderFilter>
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataCheckColumn Caption="Activo" FieldName="Estado" VisibleIndex="10">
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="IdCargo" Visible="False" VisibleIndex="8" Caption="Cargo">
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
                    <dx:GridViewDataComboBoxColumn FieldName="IdDenominacion" VisibleIndex="3" Caption="Denominación" Visible="False">
                        <PropertiesComboBox DataSourceID="SqlDataSourceDenominacines" TextField="Denominacion" ValueField="IdDenominacion">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesComboBox>
                        <EditFormSettings Visible="True" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn FieldName="Denominacion" VisibleIndex="2">
                        <SettingsHeaderFilter Mode="CheckedList">
                        </SettingsHeaderFilter>
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Styles>
                    <Header BackColor="#00283C" Font-Bold="True" ForeColor="White">
                    </Header>
                    <EditForm BackColor="#00283C">
                    </EditForm>
                </Styles>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSourcePersonal" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IdPersonal], [Nombres], [Apellidos], E.[Estructura], A.[Area], C.[Cargo], D.Denominacion, D.IdDenominacion, P.IdCargo, P.Estado
            FROM [Personal] P
               JOIN Cargos C ON P.IdCargo = C.IdCargo
               LEFT JOIN Denominaciones D on P.IdDenominacion = D.IdDenominacion
               JOIN Areas A ON C.IdArea = A.IdArea
               JOIN Estructuras E ON A.IdEstructura = E.IdEstructura"></asp:SqlDataSource>
      <asp:SqlDataSource ID="SqlDataSourceCargos" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT C.[IdCargo], C.[Cargo], A.Area, E.Estructura 
        FROM [Cargos] C
        JOIN Areas A ON C.IdArea = A.IdArea
        JOIN Estructuras E ON A.IdEstructura = E.IdEstructura"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceDenominacines" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IdDenominacion], [Denominacion] FROM [Denominaciones]"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
