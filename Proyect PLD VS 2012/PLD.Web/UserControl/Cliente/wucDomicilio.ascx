<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucDomicilio.ascx.cs" Inherits="PLD.Web.UserControl.Cliente.wucDomicilio" %>
<table>
    <tr>
        <td class="th">Estado:</td>
        <td align="left">
            <asp:DropDownList runat="server" ID="ddlEstado" CssClass="textbox" />
        </td>
        <td class="th">Localidad:</td>
        <td align="left">
            <asp:DropDownList runat="server" ID="ddlLocalidad" CssClass="textbox" />
        </td>
    </tr>
    <tr>
        <td class="th">Calle:
        </td>
        <td colspan="4" align="left">
            <asp:TextBox runat="server" ID="txtCalle" CssClass="textbox" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>

        <td class="th">No ext:
        </td>
        <td align="left">
            <asp:TextBox runat="server" ID="txtNoExt" CssClass="textbox"></asp:TextBox>
        </td>
        <td class="th">No int.
        </td>
        <td align="left">
            <asp:TextBox runat="server" ID="txtNoInt" CssClass="textbox"></asp:TextBox>
        </td>
        <td class="th">CP
        </td>
        <td align="left">
            <asp:TextBox runat="server" ID="txtCP" CssClass="textbox" Width="80px"></asp:TextBox>
        </td>
    </tr>
</table>
