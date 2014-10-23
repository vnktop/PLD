using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PLD.Web.ComunService;

namespace PLD.Web.Procesos
{
    public partial class frmProcesos : System.Web.UI.Page
    {

        PLD.Web.ClienteService.ClienteContractClient Client_WS = new PLD.Web.ClienteService.ClienteContractClient();
        ComunContractClient Comun_WS = new ComunContractClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalificar_Onclick(object sender, ImageClickEventArgs e)
        {
            try
            {
                PLD.Web.ClienteService.ServiceResult result = Client_WS.setCalificaCliente(0, Session["User"].ToString());
                Mensaje.setMensaje(result.ErrorMessage, (short)(result.ServiceOk == true ? 1 : 3));
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }


        protected void btnCargaCatalogos_OnClick(object sender, EventArgs e)
        {
            try
            {

                ServiceResult result = new ServiceResult();

                List<CatalogoRequest> request = new List<CatalogoRequest>();

                CatalogoRequest catalogo;
                int counter = 0;
                string line;

                System.IO.StreamReader file = new System.IO.StreamReader("C:\\Prueba\\Catalogos.txt");

                while ((line = file.ReadLine()) != null)
                {
                    catalogo = new CatalogoRequest();

                    string[] arrDatos = line.Split('|');


                    catalogo.vchCodigo = arrDatos[0];
                    catalogo.vchClave = arrDatos[1];
                    catalogo.vchDescripcion = arrDatos[2];
                    catalogo.vchClaveRel = arrDatos.Count() == 4 ? arrDatos[3] : "";
                    catalogo.shPuntaje = arrDatos.Count() == 5 ? short.Parse(arrDatos[4].ToString()) : (short)0;


                    counter++;
                    request.Add(catalogo);
                }

                file.Close();

                result = Comun_WS.setCatalogos(request.ToArray());

                Mensaje.setMensaje(result.ErrorMessage, 3);
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }



        protected void btnProcesaInfoImg_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ServiceResult result = Comun_WS.setCargaInformacion(Session["User"].ToString());
                Mensaje.setMensaje(result.ErrorMessage, result.ServiceOk == true ? (short)1 : (short)3);
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }
    }
}