using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PLD.Web.ClienteService;
namespace PLD.Web.Procesos
{
    public partial class frmOperaciones : System.Web.UI.Page
    {

        ClienteContractClient Cliente_WS = new ClienteContractClient();
        List<InusualResponse> Inus_Response = new List<InusualResponse>();
        ConsultaRequest Inusu_Request = new ConsultaRequest();
        List<InusualSeguimientoResponse> Inusu_Seg_Req = new List<InusualSeguimientoResponse>();


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {



                    Inusu_Request.dttFechaInicio = DateTime.Now.AddMonths(-1);
                    Inusu_Request.dttFechaFin = DateTime.Now;

                    Inus_Response = Cliente_WS.getInusuales(Inusu_Request).ToList();
                    wucMovInusuales.setDatos(Inus_Response);

                    Inusu_Seg_Req = Cliente_WS.getInusualSeguimiento(Inusu_Request).ToList();
                    wucSeguimientoOp.setDatos(Inusu_Seg_Req);


                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {


            string strFechIni = "";
            string strFechFin = "";
            try
            {
                strFechIni = txtFecInicioOp.Text.Split('/')[2].ToString() + "-" + txtFecInicioOp.Text.Split('/')[1].ToString() + "-" + txtFecInicioOp.Text.Split('/')[0].ToString();
                DateTime.Parse(strFechIni);
            }
            catch (Exception)
            {
                strFechIni = DateTime.Now.AddMonths(-1).ToString();
            }

            try
            {
                strFechFin = txtFechaFinOp.Text.Split('/')[2].ToString() + "-" + txtFechaFinOp.Text.Split('/')[1].ToString() + "-" + txtFechaFinOp.Text.Split('/')[0].ToString();
                DateTime.Parse(strFechFin);
            }
            catch (Exception)
            {
                strFechFin = DateTime.Now.ToString();
            }



            Inusu_Request.dttFechaInicio = DateTime.Parse(strFechIni);//DateTime.Now.AddMonths(-1);
            Inusu_Request.dttFechaFin = DateTime.Parse(strFechFin); ;

            Inus_Response = Cliente_WS.getInusuales(Inusu_Request).ToList();
            wucMovInusuales.setDatos(Inus_Response);

            Inusu_Seg_Req = Cliente_WS.getInusualSeguimiento(Inusu_Request).ToList();
            wucSeguimientoOp.setDatos(Inusu_Seg_Req);

            UPD_MovInusu.Update();
            UPD_SegOp.Update();
            UPD_Reportes.Update();

        }

        protected void btnGerneraRep_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceResult result = new ServiceResult();
                result = Cliente_WS.setAgrupaReporte();
                Mensaje.setMensaje(result.ErrorMessage, result.ServiceOk == true ? (short)1 : (short)3);
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }

        }
    }
}