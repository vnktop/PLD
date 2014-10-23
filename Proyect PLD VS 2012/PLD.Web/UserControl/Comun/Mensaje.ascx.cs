using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Diagnostics;
using PLD.Web.ComunService;
using System.Net;

namespace PLD.UserControl.Comun
{
    public partial class Mensaje : System.Web.UI.UserControl
    {

      

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                }
            }
            catch (Exception ex)
            {
                setMensajeBD(ex.Message);
            }

        }
        /// <summary>
        /// Metodo que selecciona el tipo de mensaje a mostrar al usuario, ademas
        /// de que se inicializa el mensaje a mostrar
        /// </summary>
        /// <param name="mensaje">Establece el mensaje</param>
        /// <param name="sintTipo">1-Correcto,2-Error,3-Alerta,Default-Alerta</param>
        public void setMensaje(string mensaje, Int16 sintTipo /*1-Correcto,2-Error,3-Alerta*/)
        {
            try
            {
                this.lblMensaje.Text = mensaje;
                switch (sintTipo)
                {
                    case 1:
                        imgMensaje.ImageUrl = "~/App_Images/Correcto.png";
                        break;
                    case 2:
                        imgMensaje.ImageUrl = "~/App_Images/Error.png";
                        setMensajeBD(mensaje);
                        break;
                    case 3:
                        imgMensaje.ImageUrl = "~/App_Images/Alerta.png";
                        break;
                    default:
                        imgMensaje.ImageUrl = "~/App_Images/Alerta.png";
                        break;
                }
                mpeConfirmacion.Show();
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "alert('1');",true);
                //clsLogging.registrarError(ex.Message, st, Session["User"].ToString());
                //wucMensajeSisLog.setMensaje(ex.Message, 2);
            }
        }

        public void setMensajeBD(string strMsjErr)
        {
            try
            {
                PLD.Web.ComunService.ComunContractClient wsComun = new PLD.Web.ComunService.ComunContractClient();
                PLD.Web.ComunService.LogError log = new PLD.Web.ComunService.LogError();

                StackTrace st = new StackTrace(true);

                string strHostName = string.Empty;

                // Getting Ip address of local machine…
                // Local machine.                
                strHostName = Dns.GetHostName();

                // Then using host name, get the IP address list..
                IPAddress[] hostIPs = Dns.GetHostAddresses(strHostName);
                for (int i = 0; i < hostIPs.Length; i++)
                {
                    log.vchIP = hostIPs[i].ToString();
                }

                log.vchHostName = strHostName;
                log.datFechaError = DateTime.Now;
                log.vchMensaje = "Formulario: " + Server.HtmlEncode(Request.CurrentExecutionFilePath);
                log.vchStakeTrace = strMsjErr;
                log.vchUsuario = Session["User"].ToString();
                wsComun.setLogError(log);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //protected void btnCerrarConfirmacion_Click(object sender, EventArgs e)
        //{l
        //    try
        //    {
        //        mpeConfirmacion.Hide();
        //    }
        //    catch (Exception ex)
        //    {
        //        StackTrace st = new StackTrace(true);
        //        clsLogging.registrarError(ex.Message, st, Session["User"].ToString());
        //        //wucMensajeSisLog.setMensaje(ex.Message, 2);
        //    }
        //}
    }
}