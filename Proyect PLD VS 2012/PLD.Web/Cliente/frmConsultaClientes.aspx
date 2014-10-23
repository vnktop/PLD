<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmConsultaClientes.aspx.cs" Inherits="PLD.Web.Cliente.frmConsultaClientes" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="~/UserControl/Comun/Mensaje.ascx" TagPrefix="uc1" TagName="Mensaje" %>
<%@ Register Src="~/UserControl/Cliente/wucCalificacion.ascx" TagName="wucCalificacion" TagPrefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center; width: 100%;">
        <table style="width: 60%;">
            <tr>
                <td class="Titulo">Busqueda / Calificación
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table border="1">
                        <tr>
                            <td class="th">No Cliente:
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtNoCliente" CssClass="textbox"></asp:TextBox>
                            </td>
                            <td class="th">RFC:
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtRFC" CssClass="textbox"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="th">No Cuenta/Crédito:
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtNoCta" CssClass="textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="th">Nombre:
                            </td>
                            <td align="left" colspan="3">
                                <asp:TextBox runat="server" ID="txtNombre" Width="300px" CssClass="textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="th">Riesgo:
                            </td>
                            <td align="left" >
                                <asp:DropDownList ID="ddlRiesgo" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
<%--                        <tr>
                            <td class="th">Seguimiento:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSeguimiento" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>--%>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:UpdatePanel runat="server" ID="UPD_Btnbuscar" RenderMode="Inline">
                        <ContentTemplate>
                            <asp:Button runat="server" ID="btnBuscar" Text="Buscar" CssClass="Boton" OnClick="btnBuscar_Onclick" />

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="UPD_Clientes" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="grvClientes" runat="Server" AutoGenerateColumns="false" OnRowCommand="grvClientes_RowCommand"
                                EmptyDataText="No se encontraron datos" Width="45%" ShowFooter="false"
                                HeaderStyle-Wrap="false" RowStyle-Wrap="false" ShowHeader="true" OnRowDataBound="grvClientes_RowDataBound"
                                PageSize="10" AllowPaging="true" OnPageIndexChanging="grvClientes_PageIndexChanging">
                                <AlternatingRowStyle CssClass="alternatingrowstyle" />
                                <HeaderStyle CssClass="headerstyle" />
                                <RowStyle CssClass="rowstyle" />
                                <PagerStyle HorizontalAlign="Center" />
                                <PagerStyle CssClass="pagerstyle" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="Cliente" runat="server" Text="ID"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="shClienteID" runat="server" CssClass="letra" Text='<%#Bind("shClienteID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="ClienteNo" runat="server" Text="No. de Cliente"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="strNoCliente" runat="server" CssClass="letra" Text='<%#Bind("strNoCliente") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="RFC" runat="server" Text="RFC"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="strRFC" runat="server" CssClass="letra" Text='<%#Bind("strRFC") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="Nombre" runat="server" Text="Nombre"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="strNombre" runat="server" CssClass="letra" Text='<%#Bind("strNombre") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="Calificacion" runat="server" Text="Calificación"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="shCalificacion" runat="server" CssClass="letra" Text='<%#Bind("shCalificacion") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="CalificacionH" runat="server" Text="Riesgo"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgButton" CommandName="Calificacion" BorderStyle="Outset" />
                                            <asp:HiddenField ID="hdnRiesgo" runat="server" Value='<%#Bind("shRiesgo") %>'></asp:HiddenField>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="IrH" runat="server" Text="Ir"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnDetalle" CommandName="Ir" runat="server" ImageUrl="../App_Images/arrow_right.png" BorderStyle="Outset"></asp:ImageButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>

                                <PagerTemplate>
                                    <asp:Label ID="lblTemplate" runat="server" Text="Muestra Filas:" />
                                    <asp:DropDownList ID="ddlBandeja" runat="server" AutoPostBack="true" CausesValidation="false"
                                        OnSelectedIndexChanged="ddlBandejaNoPago_SelectedIndexChanged" Enabled="true" Height="17px" Font-Size="Smaller">
                                        <asp:ListItem Value="10" />
                                        <asp:ListItem Value="20" />
                                        <asp:ListItem Value="30" />
                                        <asp:ListItem Value="40" />
                                    </asp:DropDownList>
                                    &nbsp; Página
                                 <asp:TextBox ID="txtBandeja" runat="server" AutoPostBack="true" OnTextChanged="txtBandejaNoPago_TextChanged" Width="30" Font-Size="Smaller">
                                 </asp:TextBox>de<asp:Label ID="lblBandeja_TotalNumDePag" runat="server" />
                                    &nbsp;
                                <asp:Button ID="bttnBandeja_1" runat="server" CommandName="Page" CausesValidation="false" ToolTip="Página Anterior" CommandArgument="Prev" CssClass="previous" Height="17px" />
                                    <asp:Button ID="bttnBandeja_2" runat="server" CommandName="Page" CausesValidation="false" Height="17px"
                                        ToolTip="Página Siguiente" CommandArgument="Next" CssClass="next" />
                                </PagerTemplate>
                            </asp:GridView>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>

    <asp:Button ID="bttnShowPopup_Calificacion" runat="server" Style="display: none;" />
    <AjaxToolkit:ModalPopupExtender ID="mdlCalificacion" runat="server" TargetControlID="bttnShowPopup_Calificacion"
        PopupControlID="pnlPopup_Calificacion" BackgroundCssClass="modalBackground" CancelControlID="bttnCancelar">
    </AjaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlPopup_Calificacion" runat="server" Width="60%" HorizontalAlign="Center"
        Style="display: none;" Height="50%">
        <asp:Panel ID="pnlCalificacion" runat="server" Width="100%" BackColor="White" Height="80%">
            <table width="100%">
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UPC_Calificacion">
                            <ContentTemplate>
                                <uc2:wucCalificacion ID="wucCalificacion" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="bttnCancelar" runat="server" Text="Cerrar" ToolTip="Cierra Consulta de Calificacion"
                            CssClass="Boton" CausesValidation="false" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>
    <uc1:Mensaje runat="server" ID="Mensaje" />
</asp:Content>
