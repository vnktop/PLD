using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PLD.Web.ClienteService;

namespace PLD.Web.UserControl.Productos
{
    public partial class wucReportes : System.Web.UI.UserControl
    {

        ClienteContractClient WS_Cliente = new ClienteContractClient();



        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ConsultaRequest request = new ConsultaRequest();
                    request.dttFechaInicio = DateTime.Now.AddYears(-1);
                    request.dttFechaFin = DateTime.Now;
                    ReporteResponse[] response = WS_Cliente.getReportes(request);
                    grvReportes.DataSource = response;
                    grvReportes.DataBind();
                }
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }



        protected void grvReportes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow row;
                row = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                short sintReporte = 0;
                short.TryParse(grvReportes.Rows[row.RowIndex].Cells[1].Text, out sintReporte);

                if (e.CommandName == "RptDet")
                {
                    MovimietoResponse[] lstMov = WS_Cliente.getMovimientosReporte(sintReporte);
                    grvMovimientos.DataSource = lstMov;
                    grvMovimientos.DataBind();
                    mdlMovRpt.Show();
                    UPD_Mvts.Update();
                }
                else
                    if (e.CommandName == "Rpt")
                    {
                        WS_Cliente.setGeneraReporte(sintReporte);
                    }
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }


        protected void grvReportes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                GridView gridView = (GridView)sender;

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    if (e.Row.Cells[4].Text == "0")
                    {
                        e.Row.Cells[4].Text = "Pendiente";
                    }
                    else
                        e.Row.Cells[4].Text = "Generado";
                }

                if (e.Row.RowType == DataControlRowType.Pager)
                {
                    Label lblTotalNumDePaginas = (Label)e.Row.FindControl("lblBandeja_TotalNumDePag");
                    lblTotalNumDePaginas.Text = gridView.PageCount.ToString();
                    TextBox txtIrAlaPagina = (TextBox)e.Row.FindControl("txtBandeja");
                    //txtIrAlaPagina.Text = "0";
                    txtIrAlaPagina.Text = (gridView.PageIndex + 1).ToString();
                    DropDownList ddlTamPagina = (DropDownList)e.Row.FindControl("ddlBandeja");
                    ddlTamPagina.SelectedValue = gridView.PageSize.ToString();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void bttnCancelarMovRpt_Click(object sender, EventArgs e)
        {
            mdlMovRpt.Hide();
        }


    }
}