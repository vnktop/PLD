<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmCatalogos.aspx.cs" Inherits="PLD.Web.Cargas.frmCatalogos" %>

<%@ Register Src="~/UserControl/Comun/Mensaje.ascx" TagPrefix="uc1" TagName="Mensaje" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server" ID="UPD_BotonCargaCat">
        <ContentTemplate>
            <table>
                <tr>
                    <td class="Titulo">Procesos</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button runat="server" ID="btnCargaCatalogos" Text="Carga Catalogos" CssClass="Boton" OnClick="btnCargaCatalogos_OnClick" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <uc1:Mensaje runat="server" ID="Mensaje" />
</asp:Content>
