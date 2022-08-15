<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estructuras.aspx.cs" Inherits="Zetabyte.Catálogos.Estructuras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row card-header justify-content-center font-weight-bold main" style="background-color:#00283C; color:white">ESTRUCTURAS</div>
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
            <dx:ASPxGridView ID="GridViewEstructuras" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceEstructuras" EnableCallBacks="False" EnableTheming="True" Theme="Material" KeyFieldName="IdEstructura" OnRowInserting="GridViewEstructuras_RowInserting" OnRowUpdating="GridViewEstructuras_RowUpdating">
                <SettingsEditing Mode="PopupEditForm">
                </SettingsEditing>
                <SettingsPopup>
                    <EditForm CloseOnEscape="True" Modal="True">
                    </EditForm>
                </SettingsPopup>
                <Columns>
                    <dx:GridViewCommandColumn ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="IdEstructura" ReadOnly="True" VisibleIndex="1" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Estructura" VisibleIndex="2" Width="250px">
                        <PropertiesTextEdit Width="500px">
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Styles>
                    <Header BackColor="#00283C" Font-Bold="True" ForeColor="White">
                    </Header>
                    <EditForm BackColor="#00283C">
                    </EditForm>
                </Styles>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSourceEstructuras" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IdEstructura], [Estructura] FROM [Estructuras]"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
