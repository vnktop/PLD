using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PLD.Web.Logs
{
    public partial class frmCarga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Session["User"] = "";
                    PLD.Web.ComunService.ComunContractClient wsComun = new ComunService.ComunContractClient();
                    grvCargas.DataSource = wsComun.getBitacoraCarga(DateTime.Parse("2014-09-01"), DateTime.Parse("2014-09-30"));
                    grvCargas.DataBind();

 
                }
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }



        protected void grvCargas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow row;
                row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                if (e.CommandName == "xml")
                {
                    string strXML = ((Label)(grvCargas.Rows[row.RowIndex].FindControl("lblXML"))).Text;
                }
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }
    }
}