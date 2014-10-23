<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucSeguimientoOp.ascx.cs" Inherits="PLD.Web.UserControl.Productos.wucSeguimientoOp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="~/UserControl/Comun/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc11" %>
<table>
    <tr>
        <td align="center" colspan="6">
            <asp:GridView runat="server" ID="grvSeguimiento" AllowPaging="true" Font-Size="7" EmptyDataText="Sin Detalle" AutoGenerateColumns="false" PageSize="2"
                OnRowCommand="grvSeguimiento_RowCommand" OnRowDataBound="grvSeguimiento_RowDataBound" OnPageIndexChanging="grvSeguimiento_PageIndexChanging">
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
                    <asp:BoundField DataField="strTipoInusual" HeaderText="Tipo Operacion" />
                    <asp:BoundField DataField="strNombre" HeaderText="Nombre Cli." ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="decMontoPesos" HeaderText="Monto Dolares" />
                    <asp:BoundField DataField="decMontoDolar" HeaderText="Monto Dolares" />
                    <asp:BoundField DataField="datFechaDeteccion" HeaderText="Fecha de Deteccion" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="strEstatusDescripcion" HeaderText="Estatus Operacion" />
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="MovimientosH" runat="server" Text="Detalle"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="imgBtnSeguimiento" CommandName="Seguimiento" BorderStyle="Outset"  ImageUrl="~/App_Images/editar.gif"></asp:ImageButton>
                            <asp:HiddenField ID="sintRelSeguimientoOperacionID" runat="server" Value='<%#Bind("sintRelSeguimientoOperacionID") %>'></asp:HiddenField>
                            <asp:HiddenField ID="intInusualID" runat="server" Value='<%#Bind("intInusualID") %>'></asp:HiddenField>
                            <asp:HiddenField ID="sintEstatusSeguimientoID" runat="server" Value='<%#Bind("sintEstatusSeguimientoID") %>'></asp:HiddenField>
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
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td></td>
    </tr>
</table>

<asp:Button ID="bttnShowPopup_Seguimiento" runat="server" Style="display: none;" />
<AjaxToolkit:ModalPopupExtender ID="mdlSeguimiento" runat="server" TargetControlID="bttnShowPopup_Seguimiento"
    PopupControlID="pnlPopup_Seguimiento" BackgroundCssClass="modalBackground">
</AjaxToolkit:ModalPopupExtender>
<asp:Panel ID="pnlPopup_Seguimiento" runat="server" Width="40%" HorizontalAlign="Center"
    Style="display: none;" Height="50%">
    <asp:Panel ID="pnlSeguimiento" runat="server" Width="100%" BackColor="LightGray" Height="80%">
        <table width="100%">
            <tr>
                <td class="Titulo">Detalle de la Operacoin (Movimientos)
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UPC_Seguimiento">
                        <ContentTemplate>
                            <asp:GridView runat="server" ID="grvDetalleInusuales" AllowPaging="false" Font-Size="7" EmptyDataText="Sin Detalle" AutoGenerateColumns="false">
                                <AlternatingRowStyle CssClass="alternatingrowstyle" />
                                <HeaderStyle CssClass="headerstyle" />
                                <RowStyle CssClass="rowstyle" />
                                <PagerStyle HorizontalAlign="Center" />
                                <Columns>
                                    <asp:BoundField DataField="vchReferencia" HeaderText="Referencia del Mvto." />
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
                <td>
                    <asp:UpdatePanel runat="server" ID="UPD_DetalleDesc" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td class="th">Estatus:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlEstatusOp" runat="server"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="th">Descripcion de la Operacion:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" runat="server" MaxLength="4000" Height="80" Width="300"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="th">Observaciones de la Operacion:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtObservaciones" TextMode="MultiLine" runat="server" MaxLength="4000" Height="80" Width="300"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Button runat="server" ID="btnGuardaDetalle" CssClass="Boton" OnClick="btnGuardaDetalle_Click" Text="Guardar" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:UpdatePanel runat="server" ID="UPD_Cancel">
                        <ContentTemplate>
                            <asp:Button ID="bttnCancelarSeguimientoOp" runat="server" Text="Cerrar" ToolTip="Cierra Consulta de Seguimiento"
                                CssClass="Boton" CausesValidation="false" OnClick="bttnCancelarSeguimiento_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Panel>

<uc11:Mensaje ID="Mensaje" runat="server" />


