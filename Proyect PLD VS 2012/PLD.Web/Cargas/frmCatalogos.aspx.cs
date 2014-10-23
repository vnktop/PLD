using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PLD.Web.Cargas
{
    public partial class frmCatalogos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCargaCatalogos_OnClick(object sender, EventArgs e)
        {
            try
            {
                ComunService.ComunContractClient wsComun = new ComunService.ComunContractClient();
                ComunService.ServiceResult result = new ComunService.ServiceResult();

                List<ComunService.CatalogoRequest> request = new List<ComunService.CatalogoRequest>();

                ComunService.CatalogoRequest catalogo;
                int counter = 0;
                string line;

                System.IO.StreamReader file = new System.IO.StreamReader("C:\\Prueba\\Catalogos.txt");

                while ((line = file.ReadLine()) != null)
                {
                    catalogo = new ComunService.CatalogoRequest();

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

                result = wsComun.setCatalogos(request.ToArray());

                Mensaje.setMensaje(result.ErrorMessage, 3);
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }
    }
}