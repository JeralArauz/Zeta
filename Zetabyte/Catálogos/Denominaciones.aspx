<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Denominaciones.aspx.cs" Inherits="Zetabyte.Catálogos.Denominaciones" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row card-header justify-content-center font-weight-bold main" style="background-color:#00283C; color:white">DENOMINACIONES</div>
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
            <dx:ASPxGridView ID="GridViewDenominaciones" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceDenominaciones" KeyFieldName="IdDenominacion" EnableTheming="True" OnRowInserting="GridViewDenominaciones_RowInserting" Theme="Material" Width="550px" EnableCallBacks="False" OnRowUpdating="GridViewDenominaciones_RowUpdating">
                <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="1">
                </SettingsEditing>
                <SettingsCommandButton>
                    <NewButton ButtonType="Image" RenderMode="Image">
                        <Image IconID="actions_addfile_32x32">
                        </Image>
                    </NewButton>
                    <UpdateButton ButtonType="Image" RenderMode="Image">
                        <Image IconID="actions_apply_32x32">
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
                    <dx:GridViewDataTextColumn FieldName="IdDenominacion" ReadOnly="True" VisibleIndex="1" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Denominacion" VisibleIndex="2">
                        <PropertiesTextEdit>
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Styles>
                    <Header BackColor="#00283C" Font-Bold="True" ForeColor="White">
                    </Header>
                </Styles>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSourceDenominaciones" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IdDenominacion], [Denominacion] FROM [Denominaciones]"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
