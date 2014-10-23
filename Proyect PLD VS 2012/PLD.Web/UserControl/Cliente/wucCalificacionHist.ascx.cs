using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PLD.Web.UserControl.Cliente
{
    public partial class wucCalificacionHist : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void setDatos(List<ClienteService.CalificacionResponse> response)
        {
            ViewState["lstCalificaciones"] = response;
            grvCalificacionHist.DataSource = response;
            grvCalificacionHist.DataBind();
        }


        protected void grvCalificacionHist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow row;
                row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string sintCalificacionID = ((HiddenField)(grvCalificacionHist.Rows[row.RowIndex].FindControl("hdnsintCalificacionID"))).Value;
                if (e.CommandName == "Ir")
                {

                    ClienteService.CalificacionResponse resp = ((List<ClienteService.CalificacionResponse>)ViewState["lstCalificaciones"]).Where(a => a.sintCalificacionID == short.Parse(sintCalificacionID)).First();

                    wucCalificacion.setDatos(resp);
                    mdlCalificacion.Show();
                    //UPC_Calificacion.Update();
                }
            }
            catch (Exception ex)
            {

            }
        }


        protected void grvCalificacionHist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                GridView gridView = (GridView)sender;

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    HiddenField hdnRiesgo = (HiddenField)e.Row.FindControl("hdnRiesgo");
                    Image imgButton = (Image)e.Row.FindControl("imgRiesgo");
                    if (hdnRiesgo.Value == "0")
                        imgButton.ImageUrl = "~/App_Images/exclamation.png";
                    else
                        if (hdnRiesgo.Value == "1")
                        {
                            imgButton.ImageUrl = "~/App_Images/Verde.jpg";
                            imgButton.Height = 20;
                        }
                        else
                        {
                            imgButton.ImageUrl = "~/App_Images/Rojo.jpg";
                            imgButton.Height = 20;
                        }
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

        protected void bttnCancelar_Click(object sender, EventArgs e)
        {
            mdlCalificacion.Hide();
        }


    }
}