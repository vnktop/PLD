<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="frmCarga.aspx.cs" Inherits="PLD.Web.Logs.frmCarga" %>

<%@ Register Src="~/UserControl/Comun/Mensaje.ascx" TagPrefix="uc1" TagName="Mensaje" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td style="vertical-align: central;" align="center" >

                <asp:Button ID="bntConsulta" runat="server" Text="Buscar" CssClass="Boton" />
            </td>

        </tr>
        <tr>
            <td style="vertical-align: central;" align="center">
                <asp:UpdatePanel ID="UPD_Cargas" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grvCargas" runat="Server" AutoGenerateColumns="false" OnRowCommand="grvCargas_RowCommand">
                            <AlternatingRowStyle CssClass="alternatingrowstyle" />
                            <HeaderStyle CssClass="headerstyle" />
                            <RowStyle CssClass="rowstyle" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="intLogIDT" runat="server" Text="Carga No."></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="intLogID" runat="server" CssClass="letra" Text='<%#Bind("intLogID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="FechaT" runat="server" Text="Fecha de Carga"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="sFecha" runat="server" CssClass="letra" Text='<%#Bind("sdatFecha") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblErrorC" runat="server" Text="Con Error"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblError" runat="server" CssClass="letra" Text='<%#Bind("sintNoError") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblExitoC" runat="server" Text="Exitosos"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblExito" runat="server" CssClass="letra" Text='<%#Bind("sintNoExito") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblDescC" runat="server" Text="Descripcion"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesc" runat="server" CssClass="letra" Text='<%#Bind("vchDescripcion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblUsuC" runat="server" Text="vchUsuario"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblUsu" runat="server" CssClass="letra" Text='<%#Bind("vchUsuario") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblXmlC" runat="server" Text="Errores"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblXML" Visible="false" runat="server" CssClass="letra" Text='<%#Bind("vchXMLError") %>'></asp:Label>
                                        <asp:ImageButton runat="server" ID="btnXML" CommandName="xml" ImageUrl="../App_Images/exclamation.png" ImageAlign="Middle" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>

    </table>
    <uc1:Mensaje runat="server" ID="Mensaje" />
</asp:Content>
