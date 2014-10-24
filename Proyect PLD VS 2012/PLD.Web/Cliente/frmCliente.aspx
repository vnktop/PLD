<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmCliente.aspx.cs" Inherits="PLD.Web.Cliente.frmCliente" %>

<%@ Register Src="~/UserControl/Comun/Mensaje.ascx" TagPrefix="uc1" TagName="Mensaje" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="../UserControl/Cliente/wucDatosCliente.ascx" TagName="wucDatosCliente" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/Cliente/wucDomicilio.ascx" TagName="wucDomicilio" TagPrefix="uc3" %>
<%@ Register Src="~/UserControl/Cliente/wucCalificacion.ascx" TagName="wucCalificacion" TagPrefix="uc2" %>
<%@ Register Src="~/UserControl/Cliente/wucCalificacionHist.ascx" TagName="wucCalificacionHist" TagPrefix="uc4" %>

<%@ Register Src="~/UserControl/Productos/wucListaProductos.ascx" TagName="wucListaProductos" TagPrefix="uc5" %>

<%@ Register Src="~/UserControl/Productos/wucMovInusuales.ascx" TagName="wucMovInusuales" TagPrefix="uc6" %>

<%@ Register Src="~/UserControl/Productos/wucSeguimientoOp.ascx" TagName="wucSeguimientoOp" TagPrefix="uc7" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script language="javascript" type="text/javascript">
            function CambiaTab() {
                //$find('tabBeneficiario').set_activeTabIndex(1);
                 // cambio
                // if ($find('tabContenedor').get_activeTabIndex() > 0) {
                var ctrl = $find('ContentPlaceHolder1_tabConteinerCliente');
                ctrl.set_activeTab(ctrl.get_tabs()[4]);
                //}
              
            }
    </script>


    <div style="text-align: center; width: 100%;">

        <table>
            <tr>
                <td colspan="3"></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <table width="50%" class="curvedEdges">
                        <tr>
                            <td colspan="4" class="Titulo">Filtrar infirmacion
                            &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="th">Fecha Inicial:
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtFechIni" ClientIDMode="Static" CssClass="textbox" Width="100px" />
                            </td>

                            <td class="th">Fecha Final:
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtFechFin" ClientIDMode="Static" CssClass="textbox" Width="100px" />
                            </td>
                        </tr>

                        <tr>
                            <td align="center" colspan="4">
                                <asp:UpdatePanel runat="server" ID="UPD_BtnFiltraInfCli">
                                    <ContentTemplate>
                                        <asp:Button runat="server" ID="btnFiltraInfCli" OnClick="btnFiltraInfCli_Click" Text="Filtrar" CssClass="Boton" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="" align="right" style="vertical-align: middle;">
                    <asp:UpdatePanel runat="server" ID="UPD_ImgRiesgoCli" RenderMode="Inline">
                        <ContentTemplate>
                            <table border="1">
                                <tr>
                                    <td class="th">Riesgo Actual
                                    </td>
                                    <td>
                                        <asp:ImageButton runat="server" ID="imgBtnRiesgoCliente" OnClick="imgBtnRiesgoCliente_OnClick" BorderStyle="Outset" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Panel ID="pnlClientes" runat="server" BackColor="" ScrollBars="Auto">
                        <AjaxToolkit:TabContainer ID="tabConteinerCliente" runat="server" >
                            <AjaxToolkit:TabPanel ID="tabClientes" runat="server" Height="90%" ScrollBars="Auto">
                                <HeaderTemplate>
                                    Datos Generales
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Panel runat="server" ID="pnlDatosCliente" GroupingText="Datos Generales">
                                                    <uc2:wucDatosCliente ID="wucDatosCliente" runat="server" />
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel runat="server" ID="pnlDomicilio" GroupingText="Domicilio">
                                                    <uc3:wucDomicilio ID="wucDomicilio" runat="server" />
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </AjaxToolkit:TabPanel>
                            <AjaxToolkit:TabPanel ID="tabCalificacion" runat="server" Height="90%" ScrollBars="Auto">
                                <HeaderTemplate>
                                    Calificación
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UPD_HistEval">
                                        <ContentTemplate>
                                            <uc4:wucCalificacionHist ID="wucCalificacionHist" runat="server" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                            </AjaxToolkit:TabPanel>
                            <AjaxToolkit:TabPanel ID="tabProductos" runat="server" Height="90%" ScrollBars="Auto">
                                <HeaderTemplate>
                                    Productos
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UPD_Cuentas">
                                        <ContentTemplate>
                                            <uc5:wucListaProductos ID="wucListaProductos" runat="server" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                            </AjaxToolkit:TabPanel>
                            <AjaxToolkit:TabPanel ID="tabOpDetectadas" runat="server" Height="90%" ScrollBars="Auto">
                                <HeaderTemplate>
                                    Operaciones Detectadas
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UPD_MovInusu">
                                        <ContentTemplate>
                                            <uc6:wucMovInusuales ID="wucMovInusuales" runat="server" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                            </AjaxToolkit:TabPanel>
                            <AjaxToolkit:TabPanel ID="tabSegOp" runat="server" Height="90%" ScrollBars="Auto">
                                <HeaderTemplate>
                                    Seguimiento de Operaciones
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UPD_SegOp">
                                        <ContentTemplate>
                                            <uc7:wucSeguimientoOp ID="wucSeguimientoOp" runat="server" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                            </AjaxToolkit:TabPanel>
                        </AjaxToolkit:TabContainer>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server" ID="btnRegresar" Text="Regresar" OnClick="btnRegresar_OnClick" CssClass="Boton" />

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

</asp:Content>
