using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PLD.Web.ClienteService;

namespace PLD.Web.UserControl.Productos
{
    public partial class wucListaProductos : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void setDatos(List<ProductoResponse> item)
        {
            ViewState["lstProductos"] = item;
            grvProductos.DataSource = item;
            grvProductos.DataBind();
        }

        public void FiltrarMovimientos(DateTime? dttIni, DateTime? dttFin)
        {
            try
            {
               List<MovimietoResponse> lstMovi = (List<MovimietoResponse>)ViewState["lstMovimi"];
               lstMovi = lstMovi.Where(a => a.dtFechaOperacion >= dttIni && a.dtFechaOperacion <= dttFin).ToList();
               CargaGridMov(lstMovi);
            }
            catch (Exception)
            {                
                throw;
            }
        
        }

        protected void grvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow row;
                row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                short shProductoID = short.Parse(((HiddenField)(grvProductos.Rows[row.RowIndex].FindControl("intProductoID"))).Value);
                if (e.CommandName == "Ir")
                {
                    List<MovimietoResponse> resp = new ClienteContractClient().getMvtosProducto(shProductoID).ToList();
                    CargaGridMov(resp);

                }
            }
            catch (Exception ex)
            {

            }
        }

        public void CargaGridMov(List<MovimietoResponse> resp)
        {
            ViewState["lstMovimi"] = resp;
            grvMovimientos.DataSource = resp;
            grvMovimientos.DataBind();
            UPD_Mvts.Update();

        }

        protected void grvProductos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                GridView gridView = (GridView)sender;

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    //HiddenField hdnRiesgo = (HiddenField)e.Row.FindControl("hdnRiesgo");
                    //Image imgButton = (Image)e.Row.FindControl("imgRiesgo");
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

        protected void grvMovimientos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow row;
                row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                //string sintCalificacionID = ((HiddenField)(grvCalificacionHist.Rows[row.RowIndex].FindControl("hdnsintCalificacionID"))).Value;
                //if (e.CommandName == "Ir")
                //{

                //    CalificacionResponse resp = ((List<CalificacionResponse>)ViewState["lstCalificaciones"]).Where(a => a.sintCalificacionID == short.Parse(sintCalificacionID)).First();

                //    wucCalificacion.setDatos(resp);
                //    mdlCalificacion.Show();
                //UPC_Calificacion.Update();
                // }
            }
            catch (Exception ex)
            {

            }
        }


        protected void grvMovimientos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                GridView gridView = (GridView)sender;

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    //HiddenField hdnRiesgo = (HiddenField)e.Row.FindControl("hdnRiesgo");
                    //Image imgButton = (Image)e.Row.FindControl("imgRiesgo");
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
                    this.grvMovimientos.AllowPaging = true;
                    this.grvMovimientos.PageSize = int.Parse(dropDownList.SelectedValue);
                }
                else
                    this.grvMovimientos.AllowPaging = false;
                CargaGridMov((List<MovimietoResponse>)ViewState["lstMovimi"]);
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
                    this.grvMovimientos.PageIndex = numeroPagina - 1;
                else
                    this.grvMovimientos.PageIndex = 0;
                CargaGridMov((List<MovimietoResponse>)ViewState["lstMovimi"]);
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
        protected void grvMovimientos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    this.grvMovimientos.PageIndex = e.NewPageIndex;
                    CargaGridMov((List<MovimietoResponse>)ViewState["lstMovimi"]);
                }
            }
            catch (Exception ex)
            {
                //  Mensaje.setMensaje(ex.Message, 2);
            }
        }




        /// <summary>
        /// Evento que realiza el cambio del tamaño del numero de registros
        /// que seran mostradas en pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlBandejaPr_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList dropDownList = (DropDownList)sender;
                if (int.Parse(dropDownList.SelectedValue) != 0)
                {
                    this.grvMovimientos.AllowPaging = true;
                    this.grvMovimientos.PageSize = int.Parse(dropDownList.SelectedValue);
                }
                else
                    this.grvMovimientos.AllowPaging = false;
                setDatos((List<ProductoResponse>)ViewState["lstProductos"]);
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
        protected void txtBandejaPr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtBandejaAvaluosGoToPage = (TextBox)sender;
                int numeroPagina;
                if (int.TryParse(txtBandejaAvaluosGoToPage.Text.Trim(), out numeroPagina))
                    this.grvMovimientos.PageIndex = numeroPagina - 1;
                else
                    this.grvMovimientos.PageIndex = 0;
                setDatos((List<ProductoResponse>)ViewState["lstProductos"]);
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
        protected void grvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    this.grvProductos.PageIndex = e.NewPageIndex;
                    setDatos((List<ProductoResponse>)ViewState["lstProductos"]);
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