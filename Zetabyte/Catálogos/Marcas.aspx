<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="Zetabyte.Catálogos.Marcas" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row card-header justify-content-center font-weight-bold main" style="background-color:#00283C; color:white">CATALOGO DE MARCAS</div>
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
            <dx:ASPxGridView ID="GridViewMarcas" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceMarcas" EnableTheming="True" KeyFieldName="IDMarca" Theme="Material" Caption="CATÁLOGO DE MARCAS" EnableCallBacks="False" OnRowInserting="GridViewMarcas_RowInserting" OnRowUpdating="GridViewMarcas_RowUpdating">
                <SettingsEditing Mode="PopupEditForm">
                </SettingsEditing>
                <Settings ShowFilterRow="True" ShowHeaderFilterButton="True" />
                <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" />
                <SettingsPopup>
                    <EditForm CloseOnEscape="True" HorizontalAlign="WindowCenter" Modal="True" VerticalAlign="WindowCenter">
                    </EditForm>
                    <HeaderFilter CloseOnEscape="True">
                    </HeaderFilter>
                </SettingsPopup>
                <Columns>
                    <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" Width="50px">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="IDMarca" ReadOnly="True" Visible="False" VisibleIndex="1">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Marca" VisibleIndex="2" Width="250px" Caption="Marcas">
                        <PropertiesTextEdit Width="500px">
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Styles>
                    <Header BackColor="#00283C" Font-Bold="True" Font-Size="Large" ForeColor="White" HorizontalAlign="Center">
                    </Header>
                </Styles>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSourceMarcas" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IDMarca], [Marca] FROM [Marcas]"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
