<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Modelos.aspx.cs" Inherits="Zetabyte.Catálogos.Modelos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row card-header justify-content-center font-weight-bold main" style="background-color:#00283C; color:white">CATALOGO DE MODELOS</div>
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
            <dx:ASPxGridView ID="GridViewModelos" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceModelos" EnableTheming="True" Theme="Material" KeyFieldName="IdModelo" EnableCallBacks="False" OnRowInserting="GridViewModelos_RowInserting" OnRowUpdating="GridViewModelos_RowUpdating" OnRowDeleting="GridViewModelos_RowDeleting">
                <SettingsEditing Mode="PopupEditForm">
                </SettingsEditing>
                <Settings ShowFilterRow="True" ShowHeaderFilterButton="True" />
                <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" ConfirmDelete="True" />
                <SettingsPopup>
                    <EditForm CloseOnEscape="True" HorizontalAlign="WindowCenter" Modal="True" VerticalAlign="WindowCenter">
                    </EditForm>
                    <HeaderFilter CloseOnEscape="True">
                    </HeaderFilter>
                </SettingsPopup>
                <Columns>
                    <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" Width="80px">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="IdModelo" ReadOnly="True" Visible="False" VisibleIndex="1">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Modelo" VisibleIndex="2" Width="130px">
                        <PropertiesTextEdit Width="250px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Marca" VisibleIndex="4" Width="130px">
                        <PropertiesTextEdit Width="250px">
                        </PropertiesTextEdit>
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="IDMarca" Visible="False" VisibleIndex="3" Caption="Marca">
                        <PropertiesComboBox DataSourceID="SqlDataSourceMarcas" TextField="Marca" ValueField="IDMarca" Width="250px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesComboBox>
                        <EditFormSettings Visible="True" />
                    </dx:GridViewDataComboBoxColumn>
                </Columns>
                <Styles>
                    <Header BackColor="#00283C" Font-Bold="True" Font-Size="Large" ForeColor="White">
                    </Header>
                    <SelectedRow BackColor="#0099CC">
                    </SelectedRow>
                </Styles>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSourceModelos" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT Mo.IdModelo, Modelo, M.IDMarca, M.Marca FROM MODELOS MO LEFT JOIN Marcas M ON MO.IDMarca = M.IDMarca"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceMarcas" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IDMarca], [Marca] FROM [Marcas]"></asp:SqlDataSource>
            </div>
    </div>
</asp:Content>
