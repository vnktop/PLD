<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucMovInusuales.ascx.cs" Inherits="PLD.Web.UserControl.Productos.wucMovInusuales" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="~/UserControl/Comun/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<table>
    <tr>
        <td align="center" colspan="6">
            <asp:GridView runat="server" ID="grvInusuales" AllowPaging="true" PageSize="2" Font-Size="7" EmptyDataText="Sin Detalle" AutoGenerateColumns="false"
                OnRowCommand="grvInusuales_RowCommand" OnRowDataBound="grvInusuales_RowDataBound" OnPageIndexChanging="grvInusuales_PageIndexChanging">
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
                    <asp:BoundField DataField="strNombreCliente" HeaderText="Cliente" />
                    <asp:BoundField DataField="strTipoInusual" HeaderText="Tipo Operacion" />
                    <asp:BoundField DataField="decMontoPesos" HeaderText="Monto Pesos" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="decMontoDolar" HeaderText="Monto Dolares" />
                    <asp:BoundField DataField="datFechaDeteccion" HeaderText="Fecha de Deteccion"  DataFormatString="{0:dd/MM/yyyy}"  />
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="MovimientosH" runat="server" Text="Mvtos"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkSeleccion" BorderStyle="Outset"></asp:CheckBox>
                            <asp:HiddenField ID="sintTipoInusual" runat="server" Value='<%#Bind("sintTipoInusual") %>'></asp:HiddenField>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="MovimientosH" runat="server" Text="Mvtos"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="btnDetalle" CommandName="Ir" runat="server" ImageUrl="~/App_Images/detalle.png" BorderStyle="Outset"></asp:ImageButton>
                            <asp:HiddenField ID="intInusualID" runat="server" Value='<%#Bind("intInusualID") %>'></asp:HiddenField>
                        </ItemTemplate>
                    </asp:TemplateField>
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
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button runat="server" ID="btnParaReporte" OnClick="btnParaReporte_Click" CssClass="Boton" Text="Dar Seguimiento"  />
        </td>
    </tr>
</table>

<asp:Button ID="bttnShowPopup_Inusuales" runat="server" Style="display: none;" />
<AjaxToolkit:ModalPopupExtender ID="mdlInusuales" runat="server" TargetControlID="bttnShowPopup_Inusuales"
    PopupControlID="pnlPopup_Inusuales" BackgroundCssClass="modalBackground">
</AjaxToolkit:ModalPopupExtender>
<asp:Panel ID="pnlPopup_Inusuales" runat="server" Width="40%" HorizontalAlign="Center"
    Style="display: none;" Height="50%">
    <asp:Panel ID="pnlInusuales" runat="server" Width="100%" BackColor="LightGray" Height="80%">
        <table width="100%">
            <tr>
                <td class="Titulo">Detalle de la Operacoin (Movimientos)
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UPC_Inusuales">
                        <ContentTemplate>
                            <asp:GridView runat="server" ID="grvDetalleInusu" AllowPaging="false" Font-Size="7" EmptyDataText="Sin Detalle" AutoGenerateColumns="false">
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
                                    <asp:BoundField DataField="vchReferencia" HeaderText="Regerencia del Mvto." />
                                    <asp:BoundField DataField="strNoCuenta" HeaderText="No Cred/Prod" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="decMonto" HeaderText="Monto" />
                                    <asp:BoundField DataField="dtFechaOperacion" HeaderText="Fecha de Operacion" />
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:UpdatePanel runat="server" ID="UPD_Cancel">
                        <ContentTemplate>
                            <asp:Button ID="bttnCancelarInusuales" runat="server" Text="Cerrar" ToolTip="Cierra Consulta de Inusuales"
                                CssClass="Boton" CausesValidation="false" OnClick="bttnCancelar_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Panel>
<uc1:Mensaje ID="Mensaje" runat="server" />

