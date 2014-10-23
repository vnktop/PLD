using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PLD.Web.ComunService;
namespace PLD.Web.Procesos
{
    public partial class frmConfig : System.Web.UI.Page
    {
        ComunContractClient WS_Comun = new ComunContractClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    TipoInusual[] lsConfInusu = WS_Comun.getConfigInusual();

                    ViewState["lsConfInusu"] = lsConfInusu;
                    grvCatInusual.DataSource = lsConfInusu;
                    grvCatInusual.DataBind();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void grvCatInusual_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow row;
                row = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                if (e.CommandName == "Ir")
                {
                    short? sintTipoInusualID = short.Parse(row.Cells[0].Text);
                    List<DetTipoInusual> lst = new List<DetTipoInusual>();
                    var lstDe = ((TipoInusual[])ViewState["lsConfInusu"]).Select(a => a.lstDetTipoInusual.Where(b => b.sintTipoInusualID == sintTipoInusualID)).ToList();
                    DetTipoInusual dtTipoInusu;
                    foreach (var item in lstDe)
                    {
                        dtTipoInusu = new DetTipoInusual();
                        dtTipoInusu = item.FirstOrDefault();
                        if (dtTipoInusu != null)
                            lst.Add(dtTipoInusu);
                    }
                    hdnSintInusualID.Value = sintTipoInusualID.ToString();
                    grvDetTipoInusual.DataSource = lst;
                    grvDetTipoInusual.DataBind();
                    UPD_grvDetTipoInusual.Update();

                }
                else if (e.CommandName == "IrDetalleConfig")
                {
                    short sintConfigInusualID = short.Parse(((HiddenField)row.FindControl("sintConfigInusualID")).Value);

                    var entConfig = ((TipoInusual[])ViewState["lsConfInusu"]).Select(a => a.lstDetTipoInusual.Where(b => b.sintConfigInusualID == sintConfigInusualID).Select(c => c.entConfigInusual)).FirstOrDefault();

                    rdBtnAgrupacion.SelectedValue = entConfig.FirstOrDefault().blAgrupacion == true ? "1" : "0";
                    rdBtnListSaldoMensual.SelectedValue = entConfig.FirstOrDefault().blSaldoMensual == true ? "1" : "0";
                    rdBtnMontos.SelectedValue = entConfig.FirstOrDefault().blMontos == true ? "1" : "0";
                    txtMontoPermitido.Text = entConfig.FirstOrDefault().decMontoMayor.Value.ToString();
                    txtPorcentajeSaldoMens.Text = entConfig.FirstOrDefault().shPorcSaldoMens.Value.ToString();
                    hdnConfigID.Value = entConfig.FirstOrDefault().sintConfigInusualID.ToString();

                    UPD_Config.Update();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnGuardaConfig_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigInusual config = new ConfigInusual();
                config.sintConfigInusualID = short.Parse(hdnConfigID.Value);
                config.blAgrupacion = rdBtnAgrupacion.SelectedValue == "0" ? false : true;
                config.blSaldoMensual = rdBtnListSaldoMensual.SelectedValue == "0" ? false : true;
                config.blMontos = rdBtnMontos.SelectedValue == "0" ? false : true;
                config.decMontoMayor = decimal.Parse(txtMontoPermitido.Text);
                short shPorc;
                short.TryParse(txtPorcentajeSaldoMens.Text, out shPorc);
                config.shPorcSaldoMens = shPorc;

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAgregaDetInusual_Click(object sender, EventArgs e)
        {
            try
            {
                Catalogos cat = new Catalogos();
                cat.geProductos(ref ddlTipoProducto, true);

                var entConfig = ((TipoInusual[])ViewState["lsConfInusu"]).Select(a => a.lstDetTipoInusual.Where(b => b.sintConfigInusualID == b.sintConfigInusualID).Select(c => c.entConfigInusual));

                List<ConfigInusual> lst = new List<ConfigInusual>();
                foreach (var item in entConfig)
                {
                    if (item.Count() > 0)
                        lst.Add(item.FirstOrDefault());
                }
                grvConfig.DataSource = lst;
                grvConfig.DataBind();
            }
            catch (Exception ex)
            {

            }

        }

        protected void btnGuardarDetInusual_Click(object sender, EventArgs e)
        {
            short shInusual;
            short.TryParse(hdnSintInusualID.Value, out shInusual);
            DetTipoInusual det = new DetTipoInusual();
            det.sintTipoInusualID = shInusual;
            det.sintTipoProductoID = short.Parse(ddlTipoProducto.SelectedValue);

            foreach (GridViewRow item in grvConfig.Rows)
            {
                CheckBox chk = (CheckBox)item.FindControl("chkUsar");
                if (chk.Checked)
                    det.sintConfigInusualID = short.Parse(item.Cells[0].Text);
            }

        }
    }
}