<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmOperaciones.aspx.cs" Inherits="PLD.Web.Procesos.frmOperaciones" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>

<%@ Register Src="~/UserControl/Comun/Mensaje.ascx" TagPrefix="uc1" TagName="Mensaje" %>


<%@ Register Src="~/UserControl/Productos/wucMovInusuales.ascx" TagName="wucMovInusuales" TagPrefix="uc3" %>
<%@ Register Src="~/UserControl/Productos/wucSeguimientoOp.ascx" TagName="wucSeguimientoOp" TagPrefix="uc4" %>

<%@ Register Src="~/UserControl/Productos/wucReportes.ascx" TagName="wucReportes" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center; width: 100%;">

        <table>
            <tr>
                <td class="Titulo">OPERACIÓNES DETECTADAS / REPORTES
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td class="th">Fecha Inicio:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtFecInicioOp" CssClass="textbox" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td class="th">Fecha Fin:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtFechaFinOp" CssClass="textbox" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:UpdatePanel runat="server" ID="UPD_Busqueda" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Button runat="server" ID="btnBuscar" Text="Buscar" OnClick="btnBuscar_Click" CssClass="Boton" />   
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlfrmOperacion" runat="server" ScrollBars="Auto" BackColor="">
                        <AjaxToolkit:TabContainer ID="tabConteinerOP" runat="server" Visible="true">
                            <AjaxToolkit:TabPanel ID="tabDeteccion" runat="server" Height="90%" ScrollBars="Auto">
                                <HeaderTemplate>
                                    Deteccion
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel runat="server" ID="UPD_MovInusu" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <uc3:wucMovInusuales ID="wucMovInusuales" runat="server" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </AjaxToolkit:TabPanel>
                            <AjaxToolkit:TabPanel ID="tabSeguimiento" runat="server" Height="90%" ScrollBars="Auto">
                                <HeaderTemplate>
                                    Seguimiento
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel runat="server" ID="UPD_SegOp" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <uc4:wucSeguimientoOp ID="wucSeguimientoOp" runat="server" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel runat="server" ID="UPD_GenerarRep" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:Button runat="server" ID="btnGerneraRep" Text="Generar Reporte" CssClass="Boton" OnClick="btnGerneraRep_Click" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </AjaxToolkit:TabPanel>
                            <AjaxToolkit:TabPanel ID="tabRep" runat="server" Height="90%" ScrollBars="Auto">
                                <HeaderTemplate>
                                    Reportes
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel runat="server" ID="UPD_Reportes" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <uc2:wucReportes ID="wucReportes" runat="server" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </AjaxToolkit:TabPanel>
                            <AjaxToolkit:TabPanel ID="tabHist" runat="server" Height="90%" ScrollBars="Auto">
                                <HeaderTemplate>
                                    Historico
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td></td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </AjaxToolkit:TabPanel>
                        </AjaxToolkit:TabContainer>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtFecInicioOp').datepicker({ dateFormat: 'dd/mm/yy', showAnim: 'drop' });
                $('#txtFechaFinOp').datepicker({ dateFormat: 'dd/mm/yy', showAnim: 'drop' });

            }
        });

        $('#txtFecInicioOp').datepicker({ dateFormat: 'dd/mm/yy', showAnim: 'drop' });
        $('#txtFechaFinOp').datepicker({ dateFormat: 'dd/mm/yy', showAnim: 'drop' });


    </script>

    <uc1:Mensaje runat="server" ID="Mensaje" />
</asp:Content>
