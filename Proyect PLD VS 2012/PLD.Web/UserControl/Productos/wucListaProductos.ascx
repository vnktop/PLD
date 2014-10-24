<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucListaProductos.ascx.cs" Inherits="PLD.Web.UserControl.Productos.wucListaProductos" %>


<table>
    <tr>
        <td class="Titulo">Productos</td>
    </tr>
    <tr>
        <td align="center" colspan="6">
            <asp:GridView runat="server" ID="grvProductos" AllowPaging="true" Font-Size="7" EmptyDataText="Sin Detalle" AutoGenerateColumns="false" ShowFooter="true" PageSize="2"
                OnRowCommand="grvProductos_RowCommand" OnRowDataBound="grvProductos_RowDataBound" OnPageIndexChanging="grvProductos_PageIndexChanging">                
                <AlternatingRowStyle CssClass="alternatingrowstyle" />
                <HeaderStyle CssClass="headerstyle" />
                <RowStyle CssClass="rowstyle" />
                <PagerStyle HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundField DataField="vhcNoCuenta" HeaderText="No Producto" />
                    <asp:BoundField DataField="sdatFechaAlta" HeaderText="Fecha Alta" ItemStyle-HorizontalAlign="Left" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="vchCodSucursal" HeaderText="Sucursal" />
                    <asp:BoundField DataField="decMontoInicial" HeaderText="Monto Inicial" />
                    <asp:BoundField DataField="decSaldoMensual" HeaderText="Operador" />
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="MovimientosH" runat="server" Text="Mvtos"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="btnDetalle" CommandName="Ir" runat="server" ImageUrl="~/App_Images/detalle.png" BorderStyle="Outset"></asp:ImageButton>
                            <asp:HiddenField ID="intProductoID" runat="server" Value='<%#Bind("intProductoID") %>'></asp:HiddenField>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerTemplate>
                    <asp:Label ID="lblTemplate" runat="server" Text="Muestra Filas:" />
                    <asp:DropDownList ID="ddlBandeja" runat="server" AutoPostBack="true" CausesValidation="false"
                        OnSelectedIndexChanged="ddlBandejaPr_SelectedIndexChanged" Enabled="true" Height="17px" Font-Size="Smaller">
                        <asp:ListItem Value="10" />
                        <asp:ListItem Value="20" />
                        <asp:ListItem Value="30" />
                        <asp:ListItem Value="40" />
                    </asp:DropDownList>
                    &nbsp; Página
                                 <asp:TextBox ID="txtBandeja" runat="server" AutoPostBack="true" OnTextChanged="txtBandejaPr_TextChanged" Width="30" Font-Size="Smaller">
                                 </asp:TextBox>de<asp:Label ID="lblBandeja_TotalNumDePag" runat="server" />
                    &nbsp;
                                <asp:Button ID="bttnBandeja_1" runat="server" CommandName="Page" CausesValidation="false" ToolTip="Página Anterior" CommandArgument="Prev" CssClass="previous" Height="17px" />
                    <asp:Button ID="bttnBandeja_2" runat="server" CommandName="Page" CausesValidation="false" Height="17px"
                        ToolTip="Página Siguiente" CommandArgument="Next" CssClass="next" />
                </PagerTemplate>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="Titulo">Movimientos</td>
    </tr>
    <tr>
        <td align="center" colspan="6">
            <asp:UpdatePanel runat="server" ID="UPD_Mvts" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="pnlMovimientos" runat="server" Height="300px" ScrollBars="Vertical">
                        <asp:GridView runat="server" ID="grvMovimientos" AllowPaging="true" Font-Size="7" EmptyDataText="Sin Detalle" AutoGenerateColumns="false" PageSize="5"
                            OnRowCommand="grvMovimientos_RowCommand" OnRowDataBound="grvMovimientos_RowDataBound" OnPageIndexChanging="grvMovimientos_PageIndexChanging">
                            <AlternatingRowStyle CssClass="alternatingrowstyle" />
                            <HeaderStyle CssClass="headerstyle" />
                            <RowStyle CssClass="rowstyle" />
                            <PagerStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%# Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex")) + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="intProductoID" HeaderText="No Producto" />
                                <asp:BoundField DataField="strNoCuenta" HeaderText="Clave Producto" />
                                <asp:BoundField DataField="sintTipoOperacionID" HeaderText="Tipo Op" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="vchReferencia" HeaderText="Referencia" />
                                <asp:BoundField DataField="decMonto" HeaderText="Monto" />
                                <asp:BoundField DataField="dtFechaOperacion" HeaderText="Fecha Op" />
                            </Columns>
                            <PagerTemplate>
                                <asp:Label ID="lblTemplate" runat="server" Text="Muestra Filas:" />
                                <asp:DropDownList ID="ddlBandeja" runat="server" AutoPostBack="true" CausesValidation="false"
                                    OnSelectedIndexChanged="ddlBandeja_SelectedIndexChanged" Enabled="true" Height="17px" Font-Size="Smaller">
                                    <asp:ListItem Value="10" />
                                    <asp:ListItem Value="20" />
                                    <asp:ListItem Value="30" />
                                    <asp:ListItem Value="40" />
                                </asp:DropDownList>
                                &nbsp; Página
                                 <asp:TextBox ID="txtBandeja" runat="server" AutoPostBack="true" OnTextChanged="txtBandeja_TextChanged" Width="30" Font-Size="Smaller">
                                 </asp:TextBox>de<asp:Label ID="lblBandeja_TotalNumDePag" runat="server" />
                                &nbsp;
                                <asp:Button ID="bttnBandeja_1" runat="server" CommandName="Page" CausesValidation="false" ToolTip="Página Anterior" CommandArgument="Prev" CssClass="previous" Height="17px" />
                                <asp:Button ID="bttnBandeja_2" runat="server" CommandName="Page" CausesValidation="false" Height="17px"
                                    ToolTip="Página Siguiente" CommandArgument="Next" CssClass="next" />
                            </PagerTemplate>
                        </asp:GridView>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
