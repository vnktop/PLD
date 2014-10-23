<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmConfig.aspx.cs" Inherits="PLD.Web.Procesos.frmConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td class="th">Tipo de Operaciones a detectar
            </td>
            <td>
                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UPC_CatInusuales">
                    <ContentTemplate>
                        <asp:GridView runat="server" ID="grvCatInusual" AllowPaging="false" Font-Size="7" EmptyDataText="Sin Detalle" AutoGenerateColumns="false" OnRowCommand="grvCatInusual_RowCommand">
                            <AlternatingRowStyle CssClass="alternatingrowstyle" />
                            <HeaderStyle CssClass="headerstyle" />
                            <RowStyle CssClass="rowstyle" />
                            <PagerStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="shTipoInusualID" HeaderText="Tipo de Inusual" />
                                <asp:BoundField DataField="shTipoTipoReporte" HeaderText="Tipo de Reporte" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="strNombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="strDescripcion" HeaderText="Descripcion" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblDetInusu" runat="server" Text="Detalle"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnDetalle" CommandName="Ir" runat="server" ImageUrl="~/App_Images/detalle.png" BorderStyle="Outset"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="th">Detalle
            </td>
            <td>
                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UPD_grvDetTipoInusual">
                    <ContentTemplate>
                        <asp:HiddenField ID="hdnSintInusualID" runat="server" />
                        <asp:GridView runat="server" ID="grvDetTipoInusual" AllowPaging="false" Font-Size="7" EmptyDataText="Sin Detalle" AutoGenerateColumns="false" OnRowCommand="grvCatInusual_RowCommand">
                            <AlternatingRowStyle CssClass="alternatingrowstyle" />
                            <HeaderStyle CssClass="headerstyle" />
                            <RowStyle CssClass="rowstyle" />
                            <PagerStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="sintDetTipoInusualID" HeaderText="Nombre" />
                                <asp:BoundField DataField="sintTipoInusualID" HeaderText="Tipo de Inusual" />
                                <asp:BoundField DataField="sintTipoProductoID" HeaderText="Producto" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="sintConfigInusualID" HeaderText="Configuracion" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblDetInusu" runat="server" Text="Detalle"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnDetDetalleCong" CommandName="IrDetalleConfig" runat="server" ImageUrl="~/App_Images/detalle.png" BorderStyle="Outset"></asp:ImageButton>
                                        <asp:HiddenField ID="sintConfigInusualID" runat="server" Value='<%#Bind("sintConfigInusualID") %>'></asp:HiddenField>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel runat="server" ID="UPD_AddDetInusual">
                    <ContentTemplate>
                         <asp:Button runat="server" ID="btnAgregaDetInusual" CssClass="Boton" OnClick="btnAgregaDetInusual_Click" Text="Nuevo Producto" />
                        <table>
                            <tr>
                               
                                <td class="th">Producto
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTipoProducto" runat="server"></asp:DropDownList>
                                </td>
                                <td class="th">Configuraciones
                                </td>
                                <td>
                                    <asp:GridView runat="server" ID="grvConfig" AllowPaging="false" Font-Size="7" EmptyDataText="Sin Detalle" AutoGenerateColumns="false" OnRowCommand="grvCatInusual_RowCommand">
                                        <AlternatingRowStyle CssClass="alternatingrowstyle" />
                                        <HeaderStyle CssClass="headerstyle" />
                                        <RowStyle CssClass="rowstyle" />
                                        <PagerStyle HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:BoundField DataField="sintConfigInusualID" HeaderText="Nombre" />
                                            <asp:BoundField DataField="blSaldoMensual" HeaderText="Tipo de Inusual" />
                                            <asp:BoundField DataField="shPorcSaldoMens" HeaderText="Producto" ItemStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="decMontoMayor" HeaderText="Configuracion" />
                                            <asp:BoundField DataField="blMontos" HeaderText="Configuracion" />
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblDetInusu" runat="server" Text="Detalle"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDetDetalleCong" CommandName="IrDetalleConfig" runat="server" ImageUrl="~/App_Images/detalle.png" BorderStyle="Outset"></asp:ImageButton>
                                                    <asp:HiddenField ID="sintConfigInusualID" runat="server" Value='<%#Bind("sintConfigInusualID") %>'></asp:HiddenField>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblDetInusu" runat="server" Text="Usar"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox runat="server" ID="chkUsar" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                         <asp:Button runat="server" ID="btnGuardarDetInusual" CssClass="Boton" OnClick="btnGuardarDetInusual_Click" Text="Guardar Producto" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="Titulo" colspan="2">Configuraciones
            </td>
        </tr>
    </table>

    <asp:UpdatePanel runat="server" ID="UPD_Config" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:HiddenField runat="server" ID="hdnConfigID" />
            <table>
                <tr>

                    <td class="th">Aplica Saldo Mensual</td>
                    <td>
                        <asp:RadioButtonList ID="rdBtnListSaldoMensual" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Si" Value="1" />
                            <asp:ListItem Text="No" Value="0" />
                        </asp:RadioButtonList></td>
                    <td class="th">Porcentaje arriba del saldo mensual
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPorcentajeSaldoMens" Width="20px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="th">Aplica Montos</td>
                    <td>
                        <asp:RadioButtonList ID="rdBtnMontos" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Si" Value="1" />
                            <asp:ListItem Text="No" Value="0" />
                        </asp:RadioButtonList></td>
                    <td class="th">Monto Maximo Permitido
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtMontoPermitido" Width="60px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="th">Aplica Agrupacion de Operaciones</td>
                    <td>
                        <asp:RadioButtonList ID="rdBtnAgrupacion" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Si" Value="1" />
                            <asp:ListItem Text="No" Value="0" />
                        </asp:RadioButtonList></td>
                    <td class="th">Monto Maximo por Agrupacion
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtMontoMaximoAgrup" Width="60px"></asp:TextBox>
                    </td>
                    <td class="th">Dias para generar Agrupacion
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDiasGenerarAgrupacion" Width="30px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnGuardaConfig" runat="server" CssClass="Boton" OnClick="btnGuardaConfig_Click" Text="Guarda Configuracion" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
