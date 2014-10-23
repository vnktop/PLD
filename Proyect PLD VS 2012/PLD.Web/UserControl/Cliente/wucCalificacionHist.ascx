<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucCalificacionHist.ascx.cs" Inherits="PLD.Web.UserControl.Cliente.wucCalificacionHist" %>
<%@ Register Src="wucCalificacion.ascx" TagName="wucCalificacion" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>

<table>
    <tr>
        <td align="center" colspan="6">
            <asp:GridView runat="server" ID="grvCalificacionHist" AllowPaging="false" Font-Size="7" EmptyDataText="Sin Detalle" AutoGenerateColumns="false"
                OnRowCommand="grvCalificacionHist_RowCommand" OnRowDataBound="grvCalificacionHist_RowDataBound">
                <AlternatingRowStyle CssClass="alternatingrowstyle" />
                <HeaderStyle CssClass="headerstyle" />
                <RowStyle CssClass="rowstyle" />
                <PagerStyle HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundField DataField="strRiesgoCliente" HeaderText="Riesgo Cliente" />
                    <asp:BoundField DataField="sintPuntaje" HeaderText="Puntos" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="strTipoCalificacion" HeaderText="Calificacion" />

                      <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="CalificacionH" runat="server" Text="Riesgo"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Image runat="server" ID="imgRiesgo" CommandName="Riesgo" />
                                            <asp:HiddenField ID="hdnRiesgo" runat="server" Value='<%#Bind("sintRiesgoClienteID") %>'></asp:HiddenField>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                    <asp:BoundField DataField="dttFechaCalif" HeaderText="Fech. Calif." ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="vchUsuario" HeaderText="Usuario Proceso" />
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="IrH" runat="server" Text="Detalle"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="btnDetalle" CommandName="Ir" runat="server" ImageUrl="~/App_Images/arrow_right.png" BorderStyle="Outset"></asp:ImageButton>
                            <asp:HiddenField ID="hdnsintCalificacionID" runat="server" Value='<%#Bind("sintCalificacionID") %>'></asp:HiddenField>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </td>
    </tr>
</table>


<asp:Button ID="bttnShowPopup_Calificacion" runat="server" Style="display: none;" />
<AjaxToolkit:ModalPopupExtender ID="mdlCalificacion" runat="server" TargetControlID="bttnShowPopup_Calificacion"
    PopupControlID="pnlPopup_Calificacion" BackgroundCssClass="modalBackground">
</AjaxToolkit:ModalPopupExtender>
<asp:Panel ID="pnlPopup_Calificacion" runat="server" Width="60%" HorizontalAlign="Center"
    Style="display: none;" Height="50%">
    <asp:Panel ID="pnlCalificacion" runat="server" Width="100%" BackColor="White" Height="80%">
        <asp:UpdatePanel ID="UPDCalif" runat="server">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <uc1:wucCalificacion ID="wucCalificacion" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="bttnCancelar" runat="server" Text="Cerrar" ToolTip="Cierra Consulta de Calificacion"
                                CssClass="Boton" CausesValidation="false" OnClick="bttnCancelar_Click" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Panel>
