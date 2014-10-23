<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucCalificacion.ascx.cs" Inherits="PLD.Web.UserControl.Cliente.wucCalificacion" %>
<table border="1">
    <tr>
        <td align="center" colspan="6" class="Titulo">CALIFICACIÓN
        </td>
    </tr>
    <tr>
        <td colspan="6">
            <asp:Panel ID="pnlNoCalif" runat="server" Visible="false" BackColor="YellowGreen" Width="100%" HorizontalAlign="Center">
               <strong><p style="color:red;"> EL CLIENTE NO TIENE CALIFICACIÓN</p></strong>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td class="th">Cliente
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtCliente" CssClass="textbox"></asp:TextBox>
        </td>

        <td class="th">Fecha de Calificación
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtFechaCalificacion" CssClass="textbox"></asp:TextBox>
        </td>
        <td class="th">Tipo de Calificacion
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtCalificacion" CssClass="textbox"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="th">Puntos
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtPuntos" CssClass="textbox"></asp:TextBox>
        </td>
        <td class="th">Riesgo del Cliente
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtRiesgoCliente" CssClass="textbox"></asp:TextBox>

        </td>
        <td class="th">Usuario
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtUsuario" CssClass="textbox"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="6" style="background-color: gray;">
            <strong><p style="color:white;">FACTORES</p></strong>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="6">
            <asp:GridView runat="server" ID="grvCalificacionDetalle" AllowPaging="false" Font-Size="7" EmptyDataText="Sin Detalle" AutoGenerateColumns="false">
                <AlternatingRowStyle CssClass="alternatingrowstyle" />
                <HeaderStyle CssClass="headerstyle" />
                <RowStyle CssClass="rowstyle" />
                <PagerStyle HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundField DataField="sintFactoresID" HeaderText="Factor ID" />
                    <asp:BoundField DataField="strDescripcionFactor" HeaderText="Descripcion" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="sintPuntosFactor" HeaderText="Puntos" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
