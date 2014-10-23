using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PLD.Web.UserControl.Cliente
{
    public partial class wucDatosCliente : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void HideControls(bool Fisica)
        {
            txtApMaterno.Visible = Fisica;
            txtApPaterno.Visible = Fisica;
            txtCURP.Visible = Fisica;
            lblCurp.Visible = Fisica;
            lblApPaterno.Visible = Fisica;
            lblApMaterno.Visible = Fisica;
            lblFechNac.Text = Fisica ? "Fecha de Nacimiento" : "Fecha de Constitucion:";
            txtNombre.Width = Fisica ? 150 : 300;
            ScriptManager.RegisterStartupScript(this, GetType(), "Hide", "javascript:Oculta(" + (Fisica ? "1" : "0") + ");", true);
        }

        public void setDatos(ClienteService.DatosGralesResponse datos)
        {
            CargaCatalogos();

            HideControls(datos.sintTipoPersonaID == 1 ? true : false);
            txtApMaterno.Text = datos.vchApMaterno;
            txtApPaterno.Text = datos.vchApPaterno;
            txtCURP.Text = datos.vchCURP;
            txtFechNac.Text = datos.dtFechaNac.ToString();
            txtNoCliente.Text = datos.vchNoCliente;
            txtNombre.Text = datos.sintTipoPersonaID == 1 ? datos.vchNombre : datos.vchRazonSocial;
            txtRFC.Text = datos.vchRFC;
            txtTelefono.Text = datos.vchTelefono;
            try
            {
                ddlActividad.SelectedValue = datos.sintActividadID.ToString();
                ddlNacionalidad.SelectedValue = datos.sintNacionalidadID.ToString();
                ddlTipoPersona.SelectedValue = datos.sintTipoPersonaID.ToString();
            }
            catch { }
        }

        public void CargaCatalogos()
        {

            Catalogos cat = new Catalogos();

            cat.getActividad(ref ddlActividad, true);
            cat.getNacionalidad(ref ddlNacionalidad, true);
            cat.getTipoPersona(ref ddlTipoPersona, true);
        }
    }
}