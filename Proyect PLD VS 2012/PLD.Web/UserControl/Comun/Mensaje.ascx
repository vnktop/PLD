<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Mensaje.ascx.cs" Inherits="PLD.UserControl.Comun.Mensaje" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:HiddenField runat="server" ID="hidModal" />

<ajaxToolkit:ModalPopupExtender ID="mpeConfirmacion" runat="server" TargetControlID="hidModal"
    PopupControlID="pnlPopup_ClientesNuevos" CancelControlID="btnCerrarConfirmacion"
    BackgroundCssClass="modalBackground" DropShadow="false" Drag="false" />
<asp:Panel ID="pnlPopup_ClientesNuevos" runat="server" Style="display: none">
    <asp:Panel ID="pnlConfirmacion" runat="server">
        <table width="50%" style="height: 25%;" class="Tabla" >
            <tr>
                <td style="text-align: center;" class="Titulo" >Mensaje del Sistema
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr style="margin-left: 15px; margin-right: 15px;">
                <td style="vertical-align: middle;">
                    <asp:UpdatePanel runat="server" ID="upaeMensaje">
                        <ContentTemplate>
                            <asp:Panel ID="Panel1" runat="server" GroupingText="Mensaje:" Style="vertical-align: middle;">
                                <table>
                                    <tr>
                                        <td align="center">
                                            <asp:Image runat="server" ID="imgMensaje" ImageUrl="~/App_Images/correcto.gif" Width="40%"
                                                Height="30%" />
                                        </td>
                                        <td align="left" style="vertical-align: central;" width="100%" style="height: 150px;">

                                            <asp:Label ID="lblMensaje" Text="" runat="server" ForeColor="WindowFrame" Font-Size="Small">
                                            </asp:Label>

                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <%--<asp:UpdatePanel runat="server" ID="updCerrar">
                        <ContentTemplate>
                            <asp:Button ID="btnCerrarConfirmacion" runat="server" Text="Cerrar" CssClass="Boton"
                                CausesValidation="false" OnClick="btnCerrarConfirmacion_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>--%>
                    <asp:Button ID="btnCerrarConfirmacion" runat="server" Text="Cerrar"   CssClass="Boton"
                        CausesValidation="false" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Panel>
