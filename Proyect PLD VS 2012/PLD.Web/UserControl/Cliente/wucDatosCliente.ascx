<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucDatosCliente.ascx.cs" Inherits="PLD.Web.UserControl.Cliente.wucDatosCliente" %>
<table>
    <tr>
        <td class="th">Numero de Cliente:
        </td>
        <td align="left">
            <asp:TextBox runat="server" ID="txtNoCliente" CssClass="textbox" Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="th" id="tdNombre">Nombre:
        </td>
        <td align="left">
            <asp:TextBox runat="server" ID="txtNombre" CssClass="textbox"></asp:TextBox>
        </td>
        <td class="th" id="tdPaterno">
            <asp:Label runat="server" ID="lblApPaterno" Text="Ap. Paterno:" />
        </td>
        <td align="left">
            <asp:TextBox runat="server" ID="txtApPaterno" CssClass="textbox"></asp:TextBox>

        </td>
        <td class="th" id="tdMaterno">
            <asp:Label runat="server" ID="lblApMaterno" Text="Ap. Materno:" />
        </td>
        <td align="left">
            <asp:TextBox runat="server" ID="txtApMaterno" CssClass="textbox"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="th">Tipo Persona:</td>
        <td align="left">
            <asp:DropDownList runat="server" ID="ddlTipoPersona" CssClass="textbox" />
        </td>
        <td class="th" align="left">RFC:</td>
        <td>
            <asp:TextBox runat="server" ID="txtRFC" CssClass="textbox"></asp:TextBox>
        </td>
        <td class="th" id="tdCurp">
            <asp:Label runat="server" ID="lblCurp" Text="CURP:" /></td>
        <td align="left">
            <asp:TextBox runat="server" ID="txtCURP" CssClass="textbox"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="th">Actividad:</td>
        <td align="left">
            <asp:DropDownList runat="server" ID="ddlActividad" CssClass="textbox" Width="300px" />
        </td>
        <td class="th">Nacionalidad:</td>
        <td align="left">
            <asp:DropDownList runat="server" ID="ddlNacionalidad" CssClass="textbox" />
        </td>
        <td class="th">
            <asp:Label runat="server" ID="lblFechNac" Text="Fecha de Nacimiento:"></asp:Label>
        </td>
        <td align="left">
            <asp:TextBox runat="server" ID="txtFechNac" CssClass="textbox"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="th">Teléfono:</td>
        <td align="left">
            <asp:TextBox runat="server" ID="txtTelefono" CssClass="textbox"></asp:TextBox>
        </td>
    </tr>
</table>

<script language="javascript" type="text/javascript">
    function Oculta(Fisica) {       
        document.getElementById('tdPaterno').style.visibility = Fisica == 1 ? '' : 'hidden';
        document.getElementById('tdMaterno').style.visibility = Fisica == 1 ? '' : 'hidden';
        document.getElementById('tdCURP').style.visibility = Fisica == 1 ? '' : 'hidden';

     //   document.getElementById('tdNombre').style = Fisica == true ? '' : 'colspan=3';

    }
</script>
