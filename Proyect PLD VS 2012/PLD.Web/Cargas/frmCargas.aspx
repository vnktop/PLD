<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmCargas.aspx.cs" Inherits="PLD.Web.Cargas.frmCargas" %>

<%@ Register Src="~/UserControl/Comun/Mensaje.ascx" TagPrefix="uc1" TagName="Mensaje" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td align="center">
                <asp:UpdatePanel runat="server" ID="UPD_BotonCargaCat">
                    <ContentTemplate>
                        <asp:Button runat="server" ID="btnCargaCatalogos" Text="Carga Catalogos" CssClass="Boton" OnClick="btnCargaCatalogos_OnClick" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>

    <uc1:Mensaje runat="server" ID="Mensaje" />
</asp:Content>
