<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Colores.aspx.cs" Inherits="Zetabyte.Catálogos.Colores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row card-header justify-content-center font-weight-bold main" style="background-color: #00283C; color: white">CATALOGO DE COLORES</div>
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
            <dx:ASPxGridView ID="GridViewColores" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceColores" EnableCallBacks="False" EnableTheming="True" KeyFieldName="IDColor" Theme="Material" OnRowInserting="GridViewColores_RowInserting">
                <SettingsEditing Mode="PopupEditForm">
                </SettingsEditing>
                <Settings ShowFilterRow="True" />
                <SettingsBehavior AllowSelectByRowClick="True" ConfirmDelete="True" />
                <SettingsPopup>
                    <EditForm CloseOnEscape="True" HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter">
                    </EditForm>
                </SettingsPopup>
                <Columns>
                    <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="IDColor" ReadOnly="True" Visible="False" VisibleIndex="1">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Color" VisibleIndex="2" Width="150px">
                        <PropertiesTextEdit Width="450px">
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Styles>
                    <Header BackColor="#00283C" Font-Bold="True" Font-Size="Large" ForeColor="White">
                    </Header>
                </Styles>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSourceColores" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IDColor], [Color] FROM [Colores]"></asp:SqlDataSource>

</div>
    </div>
</asp:Content>
