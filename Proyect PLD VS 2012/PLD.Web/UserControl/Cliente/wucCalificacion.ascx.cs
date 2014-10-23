using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PLD.Web.UserControl.Cliente
{
    public partial class wucCalificacion : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void setDatos(ClienteService.CalificacionResponse item)
        {
            try
            {
                pnlNoCalif.Visible = item.sintCalificacionID == 0 ? true : false;
                txtCalificacion.Text = item.strTipoCalificacion;
                txtCliente.Text = item.sintClienteID.ToString();
                txtFechaCalificacion.Text = item.dttFechaCalif.ToString();
                txtPuntos.Text = item.sintPuntaje.ToString();
                txtRiesgoCliente.Text = item.strRiesgoCliente;
                txtUsuario.Text = item.vchUsuario;
                grvCalificacionDetalle.DataSource = item.listaFactores;
                grvCalificacionDetalle.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}