using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PLD.Web.Cliente
{
    public partial class frmConsultaClientes : System.Web.UI.Page
    {

        ClienteService.ClienteContractClient Client_WS = new ClienteService.ClienteContractClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    Catalogos Cat_CS = new Catalogos();
                    Cat_CS.getRiesgo(ref ddlRiesgo, true);

                }
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }


        protected void btnBuscar_Onclick(object sender, EventArgs e)
        {
            try
            {

                ClienteService.ClienteRequest request = new ClienteService.ClienteRequest();

                request.strNoCliente = txtNoCliente.Text;
                request.strNoCuenta = txtNoCta.Text;
                request.shRiesgo = short.Parse(ddlRiesgo.SelectedValue);
                //request.strSeguimiento = ddlSeguimiento.SelectedValue;
                ClienteService.ClienteResponse[] lst = Client_WS.lstClientes(request);
                grvClientes.DataSource = lst;
                grvClientes.DataBind();
                UPD_Clientes.Update();
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }



        private void CargaGrid(bool carga)
        {
            try
            {
                grvClientes.DataSource = ViewState["lstClientes"];
                grvClientes.DataBind();
                UPD_Clientes.Update();
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }

        protected void grvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow row;
                row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string strClienteID = ((Label)(grvClientes.Rows[row.RowIndex].FindControl("shClienteID"))).Text;
                if (e.CommandName == "Calificacion")
                {
                    ClienteService.CalificacionResponse calif = new ClienteService.CalificacionResponse();
                    calif = Client_WS.getCalificacionCliente(short.Parse(strClienteID));
                    wucCalificacion.setDatos(calif);
                    mdlCalificacion.Show();
                    UPC_Calificacion.Update();
                }
                else
                    if (e.CommandName == "Ir")
                    {
                        Response.Redirect("frmCliente.aspx?intClienteID=" + strClienteID + "");
                    }
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }


        protected void grvClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                GridView gridView = (GridView)sender;

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    HiddenField hdnRiesgo = (HiddenField)e.Row.FindControl("hdnRiesgo");
                    ImageButton imgButton = (ImageButton)e.Row.FindControl("imgButton");
                    if (hdnRiesgo.Value == "0")
                        imgButton.ImageUrl = "../App_Images/exclamation.png";
                    else
                        if (hdnRiesgo.Value == "1")
                        {
                            imgButton.ImageUrl = "../App_Images/Verde.jpg";
                            imgButton.Height = 20;
                        }
                        else
                        {
                            imgButton.ImageUrl = "../App_Images/Rojo.jpg";
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
                    this.grvClientes.AllowPaging = true;
                    this.grvClientes.PageSize = int.Parse(dropDownList.SelectedValue);
                }
                else
                    this.grvClientes.AllowPaging = false;
                UPD_Clientes.Update();
                //btnBuscar_Click(sender, e);
                CargaGrid(true);
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }

        /// <summary>
        /// Evento que realiza el cambio del tamaño del numero de registros
        /// que seran mostradas en pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlBandejaNoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList dropDownList = (DropDownList)sender;
                if (int.Parse(dropDownList.SelectedValue) != 0)
                {
                    this.grvClientes.AllowPaging = true;
                    this.grvClientes.PageSize = int.Parse(dropDownList.SelectedValue);
                }
                else
                    this.grvClientes.AllowPaging = false;
                UPD_Clientes.Update();
                //btnBuscar_Click(sender, e);
                CargaGrid(false);
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
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
                    this.grvClientes.PageIndex = numeroPagina - 1;
                else
                    this.grvClientes.PageIndex = 0;
                //btnBuscar_Click(sender, e);
                CargaGrid(true);
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }


        /// <summary>
        /// Evento que registra el cambio del numero de acceso a la pagina a consultar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtBandejaNoPago_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtBandejaAvaluosGoToPage = (TextBox)sender;
                int numeroPagina;
                if (int.TryParse(txtBandejaAvaluosGoToPage.Text.Trim(), out numeroPagina))
                    this.grvClientes.PageIndex = numeroPagina - 1;
                else
                    this.grvClientes.PageIndex = 0;

                //btnBuscar_Click(sender, e);
                CargaGrid(false);
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }

        /// <summary>
        /// Evento que realiza el paginado de la consulta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    this.grvClientes.PageIndex = e.NewPageIndex;
                    //btnBuscar_Click(sender, e);
                    CargaGrid(true);
                }
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }

        #endregion
    }
}