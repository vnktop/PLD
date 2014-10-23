using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PLD.Web.UserControl.Productos
{
    public partial class wucMovInusuales : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public void setDatos(List<ClienteService.InusualResponse> item)
        {

            ViewState["lsInusual"] = item;
            grvInusuales.DataSource = item;
            grvInusuales.DataBind();
        }

        protected void grvInusuales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow row;
                row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                short shProductoID = short.Parse(((HiddenField)(grvInusuales.Rows[row.RowIndex].FindControl("intInusualID"))).Value);
                if (e.CommandName == "Ir")
                {

                    List<ClienteService.MovimietoResponse> resp = new ClienteService.ClienteContractClient().getDetalleInusual(shProductoID).ToList();

                    grvDetalleInusu.DataSource = resp;
                    grvDetalleInusu.DataBind();
                    UPC_Inusuales.Update();
                    mdlInusuales.Show();
                }
            }
            catch (Exception ex)
            {

            }
        }


        protected void grvInusuales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                GridView gridView = (GridView)sender;

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    CheckBox chK = (CheckBox)e.Row.FindControl("chkSeleccion");


                    HiddenField hdn = (HiddenField)e.Row.FindControl("sintTipoInusual");

                    if (hdn.Value == "2")
                    {
                        chK.Checked = true;
                        chK.Enabled = false;
                    }
                    //if (hdnRiesgo.Value == "0")
                    //    imgButton.ImageUrl = "~/App_Images/exclamation.png";
                    //else
                    //    if (hdnRiesgo.Value == "1")
                    //    {
                    //        imgButton.ImageUrl = "~/App_Images/Verde.jpg";
                    //        imgButton.Height = 20;
                    //    }
                    //    else
                    //    {
                    //        imgButton.ImageUrl = "~/App_Images/Rojo.jpg";
                    //        imgButton.Height = 20;
                    //    }
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
            mdlInusuales.Hide();
        }

        protected void btnParaReporte_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteService.ClienteContractClient Client_WS = new ClienteService.ClienteContractClient();
                ClienteService.ServiceResult result = new ClienteService.ServiceResult();
                string strInusual = string.Empty;
                foreach (GridViewRow item in grvInusuales.Rows)
                {
                    CheckBox chk = (CheckBox)item.FindControl("chkSeleccion");
                    if (chk.Checked)
                        strInusual += "|" + ((HiddenField)item.FindControl("intInusualID")).Value;
                }
                result = Client_WS.setInusualSeguimiento(strInusual, Session["User"].ToString());

                Mensaje.setMensaje(result.ErrorMessage, (result.ServiceOk == true ? (short)1 : (short)3));
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }

        }

        public Button btnAvanzaReporte { get { return btnParaReporte; } }



        #region Region para el paginado de los grids

        /// <summary>
        /// Evento que realiza el cambio del tamaño del numero de registros
        /// que seran mostradas en pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlBandeja_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList dropDownList = (DropDownList)sender;
                if (int.Parse(dropDownList.SelectedValue) != 0)
                {
                    this.grvInusuales.AllowPaging = true;
                    this.grvInusuales.PageSize = int.Parse(dropDownList.SelectedValue);
                }
                else
                    this.grvInusuales.AllowPaging = false;
                setDatos((List<ClienteService.InusualResponse>)ViewState["lsInusual"]);
            }
            catch (Exception ex)
            {
                //Mensaje.setMensaje(ex.Message, 2);
            }
        }

        /// <summary>
        /// Evento que registra el cambio del numero de acceso a la pagina a consultar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtBandeja_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtBandejaAvaluosGoToPage = (TextBox)sender;
                int numeroPagina;
                if (int.TryParse(txtBandejaAvaluosGoToPage.Text.Trim(), out numeroPagina))
                    this.grvInusuales.PageIndex = numeroPagina - 1;
                else
                    this.grvInusuales.PageIndex = 0;
                setDatos((List<ClienteService.InusualResponse>)ViewState["lsInusual"]);
            }
            catch (Exception ex)
            {
                //Mensaje.setMensaje(ex.Message, 2);
            }
        }




        /// <summary>
        /// Evento que realiza el paginado de la consulta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvInusuales_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    this.grvInusuales.PageIndex = e.NewPageIndex;
                    setDatos((List<ClienteService.InusualResponse>)ViewState["lsInusual"]);
                }
            }
            catch (Exception ex)
            {
                //  Mensaje.setMensaje(ex.Message, 2);
            }
        }

        #endregion

    }
}