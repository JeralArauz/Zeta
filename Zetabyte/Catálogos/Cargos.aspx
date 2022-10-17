<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cargos.aspx.cs" Inherits="Zetabyte.Catálogos.Cargos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row card-header justify-content-center font-weight-bold main" style="background-color:#00283C; color:white">CARGOS</div>
    <div class="row">
        <div class="col-md-12" style="padding-left:35px;padding-right:35px; top: -38px; left: -11px; margin-top: 0px;">
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
            <dx:ASPxGridView ID="GridViewCargos" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceCargos" EnableCallBacks="False" EnableTheming="True" 
                Theme="Material" KeyFieldName="IdCargo" OnRowInserting="GridViewCargos_RowInserting" OnRowUpdating="GridViewCargos_RowUpdating" Width="60%">
                <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="1">
                </SettingsEditing>
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
                <SettingsPopup>
                    <EditForm CloseOnEscape="True" Modal="True" HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter">
                    </EditForm>
                </SettingsPopup>
                <Columns>
                    <dx:GridViewCommandColumn ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="IdCargo" VisibleIndex="1" ReadOnly="True" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Cargo" VisibleIndex="2" Width="350px">
                        <PropertiesTextEdit>
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Area" VisibleIndex="4" Width="300px">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Estructura" VisibleIndex="5" Width="500px">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="IdArea" Visible="False" VisibleIndex="3" Width="300px" Caption="Area">
                        <PropertiesComboBox DataSourceID="SqlDataSourceAreas" TextField="Area" ValueField="IdArea">
                            <Columns>
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
            <asp:SqlDataSource ID="SqlDataSourceCargos" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT C.IdCargo, C.Cargo, C.IdArea, A.Area, E.Estructura 
FROM Cargos C 
JOIN Areas A ON C.IdArea = A.IdArea
JOIN Estructuras E ON A.IdEstructura = E.IdEstructura"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceAreas" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT A.IdArea, A.Area, E.Estructura
FROM  Areas A
JOIN Estructuras E ON A.IdEstructura = E.IdEstructura"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
