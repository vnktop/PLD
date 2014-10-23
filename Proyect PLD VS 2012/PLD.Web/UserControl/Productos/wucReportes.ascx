<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucReportes.ascx.cs" Inherits="PLD.Web.UserControl.Productos.wucReportes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="~/UserControl/Comun/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>

<table>
    <tr>
        <td align="center" colspan="6">
            <asp:GridView runat="server" ID="grvReportes" AllowPaging="false" Font-Size="7" EmptyDataText="Sin Detalle" AutoGenerateColumns="false"
                OnRowCommand="grvReportes_RowCommand" OnRowDataBound="grvReportes_RowDataBound">
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
                    <asp:BoundField DataField="sintReporteID" HeaderText="Reporte ID" />
                    <asp:BoundField DataField="strTipoReporte" HeaderText="Tipo Reporte" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="sdatFechaReporte" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="bitReportado" HeaderText="Estatus Rpt" />
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblDtalleReporte" runat="server" Text="Detalle"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="imgRptDet" CommandName="RptDet" BorderStyle="Outset" ToolTip="Detalle del Reporte" ImageUrl="~/App_Images/detalle.png"></asp:ImageButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblGenReporte" runat="server" Text="Generar Rpt"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="imgGenerar" CommandName="Rpt" BorderStyle="Outset" ImageUrl="~/App_Images/txt_red.jpg" Height="20px"></asp:ImageButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td></td>
    </tr>
</table>

<asp:Button ID="bttnShowPopup_MovRpt" runat="server" Style="display: none;" />
<AjaxToolkit:ModalPopupExtender ID="mdlMovRpt" runat="server" TargetControlID="bttnShowPopup_MovRpt"
    PopupControlID="pnlPopup_MovRpt" BackgroundCssClass="modalBackground">
</AjaxToolkit:ModalPopupExtender>
<asp:Panel ID="pnlPopup_MovRpt" runat="server" Width="40%" HorizontalAlign="Center"
    Style="display: none;" Height="50%">
    <asp:Panel ID="pnlMovRpt" runat="server" Width="100%" BackColor="LightGray" Height="80%">
        <table width="100%">
            <tr>
                <td class="Titulo">Detalle del Reporte (Movimientos)
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel runat="server" ID="UPD_Mvts" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel ID="pnlMovimientos" runat="server" Height="300px" ScrollBars="Vertical">
                                <asp:GridView runat="server" ID="grvMovimientos" AllowPaging="true" Font-Size="7" EmptyDataText="Sin Detalle" AutoGenerateColumns="false" PageSize="5">
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
                                        <asp:BoundField DataField="strNoCuenta" HeaderText="Clave Producto" />
                                        <asp:BoundField DataField="strTipoOperacion" HeaderText="Tipo Op" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="vchReferencia" HeaderText="Referencia" />
                                        <asp:BoundField DataField="decMonto" HeaderText="Monto" />
                                        <asp:BoundField DataField="dtFechaOperacion" HeaderText="Fecha Op" DataFormatString="{0:dd/MM/yyyy}" />
                                    </Columns>
                                    <%--                                    <PagerTemplate>
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
                                    </PagerTemplate>--%>
                                </asp:GridView>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:UpdatePanel runat="server" ID="UPD_Cancel">
                        <ContentTemplate>
                            <asp:Button ID="bttnCancelarMovRpt" runat="server" Text="Cerrar" ToolTip="Cierra Consulta de MovRpt"
                                CssClass="Boton" CausesValidation="false" OnClick="bttnCancelarMovRpt_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Panel>
<uc1:Mensaje ID="Mensaje" runat="server" />

