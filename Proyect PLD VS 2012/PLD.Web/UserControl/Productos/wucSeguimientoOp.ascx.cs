using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PLD.Web.ClienteService;

namespace PLD.Web.UserControl.Productos
{
    public partial class wucSeguimientoOp : System.Web.UI.UserControl
    {

        ClienteContractClient WS_Cliente = new ClienteContractClient();

        private short sintRelSeguimientoOperacionID
        {
            get
            {
                if (ViewState["sintRelSeguimientoOperacionID"] == null)
                    return 0;
                else
                    return (short)ViewState["sintRelSeguimientoOperacionID"];
            }
            set { ViewState.Add("sintRelSeguimientoOperacionID", value); }
        }


        //private short sintRelSeguimientoOperacionID
        //{
        //    get
        //    {
        //        if (ViewState["sintRelSeguimientoOperacionID"] == null)
        //            return 0;
        //        else
        //            return (short)ViewState["sintRelSeguimientoOperacionID"];
        //    }
        //    set { ViewState.Add("sintRelSeguimientoOperacionID", value); }
        //}



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        public void setDatos(List<InusualSeguimientoResponse> item)
        {
            try
            {
                ViewState["lstSeg"] = item;
                grvSeguimiento.DataSource = item;
                grvSeguimiento.DataBind();
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }

        protected void grvSeguimiento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow row;
                row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                sintRelSeguimientoOperacionID = short.Parse(((HiddenField)(grvSeguimiento.Rows[row.RowIndex].FindControl("sintRelSeguimientoOperacionID"))).Value);
                short intInusualID = short.Parse(((HiddenField)(grvSeguimiento.Rows[row.RowIndex].FindControl("intInusualID"))).Value);

                short sintEstatusSeguimientoID = short.Parse(((HiddenField)(grvSeguimiento.Rows[row.RowIndex].FindControl("sintEstatusSeguimientoID"))).Value);
                if (e.CommandName == "Seguimiento")
                {

                    Catalogos cat = new Catalogos();
                    cat.getEstatusSeguimientoOp(ref ddlEstatusOp, true);


                    List<MovimietoResponse> Detalle_Response = WS_Cliente.getDetalleInusual(intInusualID).ToList();
                    grvDetalleInusuales.DataSource = Detalle_Response;
                    grvDetalleInusuales.DataBind();

                    txtDescripcion.Text = string.Empty;
                    txtObservaciones.Text = string.Empty;
                    ddlEstatusOp.SelectedValue = "1";


                    DetSeguimientoResponse DetSeg_Response = WS_Cliente.getDetalleSeguimiento(sintRelSeguimientoOperacionID, sintEstatusSeguimientoID);

                    txtDescripcion.Text = DetSeg_Response.vchDescripcion;
                    txtObservaciones.Text = DetSeg_Response.vchObservaciones;
                    ddlEstatusOp.SelectedValue = DetSeg_Response.sintEstatusSeguimientoID.ToString();

                    UPC_Seguimiento.Update();
                    mdlSeguimiento.Show();
                }
            }
            catch (Exception ex)
            {

            }
        }


        protected void grvSeguimiento_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                GridView gridView = (GridView)sender;

                if (e.Row.RowType == DataControlRowType.DataRow)
                {


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

        protected void bttnCancelarSeguimiento_Click(object sender, EventArgs e)
        {
            mdlSeguimiento.Hide();
        }

        protected void btnGuardaDetalle_Click(object sender, EventArgs e)
        {
            ServiceResult Result_SetSeguimiento = new ServiceResult();

            DetalleSeguimientoRequest Request_Seg = new DetalleSeguimientoRequest();
            Request_Seg.sintEstatusSeguimientoID = short.Parse(ddlEstatusOp.SelectedValue);
            Request_Seg.sintRelSeguimientoOperacionID = sintRelSeguimientoOperacionID;
            Request_Seg.strDescripcion = txtDescripcion.Text;
            Request_Seg.strObservaciones = txtObservaciones.Text;
            WS_Cliente.setDetalleSeguimiento(Request_Seg);
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
                    this.grvSeguimiento.AllowPaging = true;
                    this.grvSeguimiento.PageSize = int.Parse(dropDownList.SelectedValue);
                }
                else
                    this.grvSeguimiento.AllowPaging = false;
                setDatos((List<InusualSeguimientoResponse>)ViewState["lstSeg"]);
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
                    this.grvSeguimiento.PageIndex = numeroPagina - 1;
                else
                    this.grvSeguimiento.PageIndex = 0;
                setDatos((List<InusualSeguimientoResponse>)ViewState["lstSeg"]);
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
        protected void grvSeguimiento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    this.grvSeguimiento.PageIndex = e.NewPageIndex;
                    setDatos((List<InusualSeguimientoResponse>)ViewState["lstSeg"]);
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