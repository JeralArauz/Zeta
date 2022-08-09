<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TipoArtículos.aspx.cs" Inherits="Zetabyte.Catálogos.TipoArtículos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row card-header justify-content-center font-weight-bold main" style="background-color:#00283C; color:white">CATALOGO DE TIPOS ARTÍCULOS</div>
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
            <dx:ASPxGridView ID="GridViewTipoArticulos" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceTipoArticulos" EnableCallBacks="False" EnableTheming="True" KeyFieldName="IDTipoArticulo" OnRowDeleting="GridViewTipoArticulos_RowDeleting" OnRowInserting="GridViewTipoArticulos_RowInserting" OnRowUpdating="GridViewTipoArticulos_RowUpdating" Theme="Material">
                <SettingsEditing Mode="PopupEditForm">
                </SettingsEditing>
                <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="True" />
                <SettingsPopup>
                    <EditForm CloseOnEscape="True" HorizontalAlign="WindowCenter" Modal="True" VerticalAlign="WindowCenter">
                    </EditForm>
                </SettingsPopup>
                <Columns>
                    <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowInCustomizationForm="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="IDTipoArticulo" ReadOnly="True" ShowInCustomizationForm="True" Visible="False" VisibleIndex="1" Width="80px">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn CellRowSpan="2" FieldName="TipoArticulo" ShowInCustomizationForm="True" VisibleIndex="2" Width="180px">
                        <PropertiesTextEdit Width="450px">
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Styles>
                    <Header BackColor="#00283C" Font-Bold="True" Font-Size="Large" ForeColor="White">
                    </Header>
                </Styles>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSourceTipoArticulos" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IDTipoArticulo], [TipoArticulo] FROM [TipoArticulo]"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
