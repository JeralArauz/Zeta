<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Areas.aspx.cs" Inherits="Zetabyte.Catálogos.Areas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row card-header justify-content-center font-weight-bold main" style="background-color:#00283C; color:white">AREAS</div>
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
            <dx:ASPxGridView ID="GridViewAreas" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceAreas" EnableCallBacks="False" EnableTheming="True" Theme="Material" KeyFieldName="IdArea" OnRowInserting="GridViewAreas_RowInserting" OnRowUpdating="GridViewAreas_RowUpdating">
                <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="1">
                </SettingsEditing>
                <SettingsPopup>
                    <EditForm CloseOnEscape="True" Modal="True" HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter">
                    </EditForm>
                </SettingsPopup>
                <Columns>
                    <dx:GridViewCommandColumn ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="Area" VisibleIndex="2" Width="250px">
                        <PropertiesTextEdit Width="500px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                        <EditFormSettings Visible="True" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Estructura" VisibleIndex="4" Width="250px">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="IdArea" ReadOnly="True" Visible="False" VisibleIndex="1">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="IdEstructura" Visible="False" VisibleIndex="3" Caption="Estructura">
                        <PropertiesComboBox DataSourceID="SqlDataSourceEstructuras" TextField="Estructura" ValueField="IdEstructura" Width="500px">
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
            <asp:SqlDataSource ID="SqlDataSourceAreas" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT A.IdArea, A.Area, A.IdEstructura, E.Estructura FROM AREAS A JOIN Estructuras E ON A.IdEstructura = E.IdEstructura"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceEstructuras" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDatosSistema %>" SelectCommand="SELECT [IdEstructura], [Estructura] FROM [Estructuras]"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
