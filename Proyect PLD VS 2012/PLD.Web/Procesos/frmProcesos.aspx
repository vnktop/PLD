<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmProcesos.aspx.cs" Inherits="PLD.Web.Procesos.frmProcesos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="~/UserControl/Comun/Mensaje.ascx" TagPrefix="uc1" TagName="Mensaje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center; width: 100%;">

        <asp:UpdatePanel runat="server" ID="UPD_Btnbuscar" RenderMode="Inline">
            <ContentTemplate>
                <table style="width: ">
                    <tr>
                        <td class="Titulo">Procesos</td>
                    </tr>
                    <%--                    <tr>
                        <td align="center">
                            <asp:Button runat="server" ID="btnCargaCatalogos" Text="Carga Catalogos" CssClass="Boton" OnClick="btnCargaCatalogos_OnClick" />
                        </td>
                    </tr>--%>
                    <tr>
                        <td align="center">
                            <asp:ImageButton runat="server" ID="btnProcesaInfoImg" CssClass="" OnClick="btnProcesaInfoImg_Click" ImageUrl="~/App_Images/Procesar.jpg" BorderStyle="Outset" Height="100px" Width="100px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:ImageButton runat="server" ID="ImageButton1" CssClass="" OnClick="btnCalificar_Onclick" ImageUrl="~/App_Images/Clasificar.jpg" BorderStyle="Outset" Height="100px" Width="100px" />

                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <uc1:Mensaje runat="server" ID="Mensaje" />
</asp:Content>
