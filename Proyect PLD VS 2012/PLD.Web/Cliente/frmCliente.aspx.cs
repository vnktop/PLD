using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PLD.Web.ClienteService;

namespace PLD.Web.Cliente
{
    public partial class frmCliente : System.Web.UI.Page
    {
        ClienteContractClient Cliente_WS = new ClienteContractClient();
        CalificacionResponse Calif_Response = new CalificacionResponse();
        List<ProductoResponse> Product_Response = new List<ProductoResponse>();
        List<InusualResponse> Inus_Response = new List<InusualResponse>();
        ConsultaRequest Inusu_Request = new ConsultaRequest();
        List<InusualSeguimientoResponse> Inusu_Seg_Req = new List<InusualSeguimientoResponse>();



        private short shClienteID
        {
            get
            {
                if (ViewState["shClienteID"] == null)
                    return 0;
                else
                    return (short)ViewState["shClienteID"];
            }
            set { ViewState.Add("shClienteID", value); }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["intClienteID"] != null)
                        shClienteID = short.Parse(Request.QueryString["intClienteID"].ToString());

                    DatosGralesResponse response = new DatosGralesResponse();
                    response = Cliente_WS.getDatosCliente(shClienteID);
                    wucDatosCliente.setDatos(response);

                    if (response.lstDomicilio.Count() > 0)
                        wucDomicilio.setDatos(response.lstDomicilio.First());

                    Calif_Response = Cliente_WS.getCalificacionCliente(shClienteID);

                    if (Calif_Response.sintRiesgoClienteID == 0)
                        imgBtnRiesgoCliente.ImageUrl = "../App_Images/exclamation.png";
                    else
                        if (Calif_Response.sintRiesgoClienteID == 1)
                        {

                            imgBtnRiesgoCliente.ImageUrl = "../App_Images/Verde.jpg";
                        }
                        else
                        {
                            imgBtnRiesgoCliente.ImageUrl = "../App_Images/Rojo.jpg";
                        }



                    wucCalificacionHist.setDatos(Cliente_WS.getCalificacionClienteHistorico(shClienteID).ToList());


                    Product_Response = Cliente_WS.getProductosCliente(shClienteID).ToList();
                    wucListaProductos.setDatos(Product_Response);


                    Inusu_Request.shClienteID = shClienteID;
                    Inus_Response = Cliente_WS.getInusuales(Inusu_Request).ToList();
                    wucMovInusuales.setDatos(Inus_Response);

                    Inusu_Request.shClienteID = shClienteID;
                    Inusu_Seg_Req = Cliente_WS.getInusualSeguimiento(Inusu_Request).ToList();
                    wucSeguimientoOp.setDatos(Inusu_Seg_Req);
                    wucMovInusuales.btnAvanzaReporte.OnClientClick = "CambiaTab();";


                }
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }


        }

        protected void imgBtnRiesgoCliente_OnClick(object sender, EventArgs e)
        {
            try
            {
                Calif_Response = Cliente_WS.getCalificacionCliente(shClienteID);
                wucCalificacion.setDatos(Calif_Response);
                mdlCalificacion.Show();
                UPC_Calificacion.Update();

            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegresar_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("frmConsultaClientes.aspx");
        }

        protected void btnFiltraInfCli_Click(object sender, EventArgs e)
        {
            try
            {

                string strFechIni = "";
                string strFechFin = "";
                try
                {
                    strFechIni = txtFechIni.Text.Split('/')[2].ToString() + "-" + txtFechIni.Text.Split('/')[1].ToString() + "-" + txtFechIni.Text.Split('/')[0].ToString();
                    DateTime.Parse(strFechIni);
                }
                catch (Exception)
                {
                    strFechIni = DateTime.Now.AddMonths(-1).ToString();
                }

                try
                {
                    strFechFin = txtFechFin.Text.Split('/')[2].ToString() + "-" + txtFechFin.Text.Split('/')[1].ToString() + "-" + txtFechFin.Text.Split('/')[0].ToString();
                    DateTime.Parse(strFechFin);
                }
                catch (Exception)
                {
                    strFechFin = DateTime.Now.ToString();
                }


                Product_Response = Cliente_WS.getProductosCliente(shClienteID).ToList();
                wucListaProductos.setDatos(Product_Response);

                wucListaProductos.FiltrarMovimientos(DateTime.Parse(strFechIni), DateTime.Parse(strFechFin));

                Inusu_Request.shClienteID = shClienteID;
                Inusu_Request.dttFechaInicio = DateTime.Parse(strFechIni);
                Inusu_Request.dttFechaFin = DateTime.Parse(strFechFin);

                Inus_Response = Cliente_WS.getInusuales(Inusu_Request).ToList();
                wucMovInusuales.setDatos(Inus_Response);

                Inusu_Seg_Req = Cliente_WS.getInusualSeguimiento(Inusu_Request).ToList();
                wucSeguimientoOp.setDatos(Inusu_Seg_Req);

                UPD_HistEval.Update();
                UPD_Cuentas.Update();
                UPD_MovInusu.Update();
                UPD_SegOp.Update();
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }


        }
    }
}