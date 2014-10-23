using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PLD.Web.UserControl.Cliente
{
    public partial class wucDomicilio : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargaCatalogos();
        }
        public void setDatos(ClienteService.DomicilioResponse item)
        {
            txtCP.Text = item.strCP;
            txtNoExt.Text = item.strNoExterior;
            txtNoInt.Text = item.strNoInterior;
            txtCalle.Text = item.strCalle;
            ddlEstado.SelectedValue = item.shEstado.ToString();
            ddlLocalidad.SelectedValue = item.shLocalidad.ToString();
        }
        public void CargaCatalogos()
        {
            Catalogos cat = new Catalogos();
            cat.getEstados(ref ddlEstado, true);

            cat.getLocalidad(ref ddlLocalidad, true);

        }
    }
}