<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="frmCarga.aspx.cs" Inherits="PLD.Web.Logs.frmCarga" %>

<%@ Register Src="~/UserControl/Comun/Mensaje.ascx" TagPrefix="uc1" TagName="Mensaje" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table width="100%">
        <tr>

            <td align="center">

                <table width="50%" class="curvedEdges">
                    <tr>
                        <td colspan="4" class="Titulo">Motor de Busqueda
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="th">Fecha Inicial:
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtFechIni" ClientIDMode="Static" CssClass="textbox" />
                        </td>

                        <td class="th">Fecha Final:
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtFechFin" ClientIDMode="Static" CssClass="textbox" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>

            <td style="vertical-align: central;" align="center" colspan="2">
                <asp:UpdatePanel runat="server" ID="updBtnBusca">
                    <ContentTemplate>
                        <asp:Button ID="bntConsulta" runat="server" Text="Buscar" CssClass="Boton" OnClick="btnBuscar" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>

        </tr>
        <tr>
            <td align="center">
                <div class="Titulo" style="width: 50%;">Historal de Cargas</div>

            </td>
        </tr>
        <tr>
            <td style="vertical-align: central;" align="center" colspan="2">
                <asp:UpdatePanel ID="UPD_Cargas" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="grvCargas" runat="Server" AutoGenerateColumns="false" OnRowCommand="grvCargas_RowCommand"
                            EmptyDataText="No se encontraron datos" Width="45%" ShowFooter="false"
                            HeaderStyle-Wrap="false" RowStyle-Wrap="false" ShowHeader="true" OnRowDataBound="grvCarga_RowDataBound"
                            PageSize="10" AllowPaging="true" OnPageIndexChanging="grvCargas_PageIndexChanging">
                            <AlternatingRowStyle CssClass="alternatingrowstyle" />
                            <HeaderStyle CssClass="headerstyle" />
                            <RowStyle CssClass="rowstyle" />
                            <PagerStyle HorizontalAlign="Center" />
                            <PagerStyle CssClass="pagerstyle" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="intLogIDT" runat="server" Text="Carga No."></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="intLogID" runat="server" CssClass="letra" Text='<%#Bind("intLogID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="FechaT" runat="server" Text="Fecha de Carga"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="sFecha" runat="server" CssClass="letra" Text='<%#Bind("sdatFecha") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblErrorC" runat="server" Text="Con Error"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblError" runat="server" CssClass="letra" Text='<%#Bind("sintNoError") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblExitoC" runat="server" Text="Exitosos"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblExito" runat="server" CssClass="letra" Text='<%#Bind("sintNoExito") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblDescC" runat="server" Text="Descripcion"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesc" runat="server" CssClass="letra" Text='<%#Bind("vchDescripcion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblUsuC" runat="server" Text="Usuario"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblUsu" runat="server" CssClass="letra" Text='<%#Bind("vchUsuario") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblXmlC" runat="server" Text="Errores"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblXML" Visible="false" runat="server" CssClass="letra" Text='<%#Bind("vchXMLError") %>'></asp:Label>
                                        <asp:ImageButton runat="server" ID="btnXML" CommandName="xml" ImageUrl="../App_Images/exclamation.png" ImageAlign="Middle" />
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

    <asp:Button ID="bttnShowPopup_Errores" runat="server" Style="display: none;" />
    <AjaxToolkit:ModalPopupExtender ID="mdlErrores" runat="server" TargetControlID="bttnShowPopup_Errores"
        PopupControlID="pnlPopup_Errores" BackgroundCssClass="modalBackground" CancelControlID="bttnCancelar">
    </AjaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlPopup_Errores" runat="server" Width="90%" HorizontalAlign="Center"
        Style="display: none;" Height="80%">

        <asp:Panel ID="pnlErrores" runat="server" Width="100%" BackColor="White" Height="80%">
            <table Width="100%" >
                <tr>
                    <td class="Titulo">
                        <center>
                                   Errores en la carga
                                </center>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:UpdatePanel ID="udpErrores" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Button ID="btnExportaGrid" OnClick="btnExportaGrid_OnClick" runat="server" Text="Exporta Excel" CssClass="Boton" />
                                <asp:Panel ID="pnlClientes" runat="server" BackColor="" ScrollBars="Auto">
                                    <AjaxToolkit:TabContainer ID="tabConteinerError" runat="server">
                                        <AjaxToolkit:TabPanel ID="tabClientes" runat="server" Height="90%" ScrollBars="Auto">
                                            <HeaderTemplate>
                                                Clientes
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <asp:GridView runat="server" ID="grvClientes" AllowPaging="false" Font-Size="7" EmptyDataText="Carga sin errores">
                                                    <AlternatingRowStyle CssClass="alternatingrowstyle" />
                                                    <HeaderStyle CssClass="headerstyle" />
                                                    <RowStyle CssClass="rowstyle" />
                                                    <PagerStyle HorizontalAlign="Center" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </AjaxToolkit:TabPanel>

                                        <AjaxToolkit:TabPanel ID="tabDomicilios" runat="server" Height="90%" ScrollBars="Auto">
                                            <HeaderTemplate>
                                                Domicilios
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <asp:GridView runat="server" ID="grvDomicilios" AllowPaging="false" Font-Size="7" EmptyDataText="Carga sin errores" ShowHeaderWhenEmpty="true">
                                                    <AlternatingRowStyle CssClass="alternatingrowstyle" />
                                                    <HeaderStyle CssClass="headerstyle" />
                                                    <RowStyle CssClass="rowstyle" />
                                                    <PagerStyle HorizontalAlign="Center" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </AjaxToolkit:TabPanel>

                                        <AjaxToolkit:TabPanel ID="tabProductos" runat="server" Height="90%" ScrollBars="Auto">
                                            <HeaderTemplate>
                                                Productos
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <asp:GridView runat="server" ID="grvProductos" AllowPaging="false" Font-Size="7" EmptyDataText="Carga sin errores">
                                                    <AlternatingRowStyle CssClass="alternatingrowstyle" />
                                                    <HeaderStyle CssClass="headerstyle" />
                                                    <RowStyle CssClass="rowstyle" />
                                                    <PagerStyle HorizontalAlign="Center" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </AjaxToolkit:TabPanel>
                                        <AjaxToolkit:TabPanel ID="tabMovimientos" runat="server" Height="90%" ScrollBars="Auto">
                                            <HeaderTemplate>
                                                Movimientos
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <asp:GridView runat="server" ID="grvMovimientos" AllowPaging="false" Font-Size="7" EmptyDataText="Carga sin errores">
                                                    <AlternatingRowStyle CssClass="alternatingrowstyle" />
                                                    <HeaderStyle CssClass="headerstyle" />
                                                    <RowStyle CssClass="rowstyle" />
                                                    <PagerStyle HorizontalAlign="Center" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </AjaxToolkit:TabPanel>
                                    </AjaxToolkit:TabContainer>
                                </asp:Panel>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnExportaGrid" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="bttnCancelar" runat="server" Text="Cancelar" ToolTip="Cierra el modal para la cancelación de la contraseña."
                            CssClass="Boton" CausesValidation="false" />
                    </td>
                </tr>
            </table>
        </asp:Panel>

    </asp:Panel>

    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtFechIni').datepicker({ dateFormat: 'dd/mm/yy', showAnim: 'drop' });
                $('#txtFechFin').datepicker({ dateFormat: 'dd/mm/yy', showAnim: 'drop' });

            }
        });

        $('#txtFechIni').datepicker({ dateFormat: 'dd/mm/yy', showAnim: 'drop' });
        $('#txtFechFin').datepicker({ dateFormat: 'dd/mm/yy', showAnim: 'drop' });


    </script>
    <uc1:Mensaje runat="server" ID="Mensaje" />
</asp:Content>
