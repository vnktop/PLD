using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PLD.Web
{
    public class Catalogos
    {

        ComunService.ComunContractClient dc = new ComunService.ComunContractClient();

        public void getEstados(ref DropDownList ddl, bool bVacio)
        {
            try
            {
                ListItem lista = new ListItem();
                ddl.Items.Clear();
                if (bVacio)
                {
                    lista.Value = "0";
                    lista.Text = "[Seleccionar...]";
                    ddl.Items.Add(lista);
                }

                foreach (var a in this.dc.getEstado())
                {
                    lista = new ListItem();
                    lista.Value = a.strID.ToString();
                    lista.Text = a.strDescripcion;
                    ddl.Items.Add(lista);
                }

            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }


        public void getLocalidad(ref DropDownList ddl, bool bVacio)
        {
            try
            {
                ListItem lista = new ListItem();
                ddl.Items.Clear();
                if (bVacio)
                {
                    lista.Value = "0";
                    lista.Text = "[Seleccionar...]";
                    ddl.Items.Add(lista);
                }
                ComunService.CatalogoResponse[] lst = dc.getLocalidad();
                foreach (var a in lst)
                {
                    lista = new ListItem();
                    lista.Value = a.strID.ToString();
                    lista.Text = a.strDescripcion;
                    ddl.Items.Add(lista);
                }
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        public void getActividad(ref DropDownList ddl, bool bVacio)
        {
            try
            {
                ListItem lista = new ListItem();
                ddl.Items.Clear();
                if (bVacio)
                {
                    lista.Value = "0";
                    lista.Text = "[Seleccionar...]";
                    ddl.Items.Add(lista);
                }
                ComunService.CatalogoResponse[] lst = dc.getActividad();
                foreach (var a in lst)
                {
                    lista = new ListItem();
                    lista.Value = a.strID.ToString();
                    lista.Text = a.strDescripcion;
                    ddl.Items.Add(lista);
                }
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        public void getNacionalidad(ref DropDownList ddl, bool bVacio)
        {
            try
            {
                ListItem lista = new ListItem();
                ddl.Items.Clear();
                if (bVacio)
                {
                    lista.Value = "0";
                    lista.Text = "[Seleccionar...]";
                    ddl.Items.Add(lista);
                }
                ComunService.CatalogoResponse[] lst = dc.getNacionalidad();
                foreach (var a in lst)
                {
                    lista = new ListItem();
                    lista.Value = a.strID.ToString();
                    lista.Text = a.strDescripcion;
                    ddl.Items.Add(lista);
                }
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        public void getTipoPersona(ref DropDownList ddl, bool bVacio)
        {
            try
            {


                ListItem lista = new ListItem();
                ddl.Items.Clear();
                if (bVacio)
                {
                    lista.Value = "0";
                    lista.Text = "[Seleccionar...]";
                    ddl.Items.Add(lista);
                }

                ComunService.CatalogoResponse[] lst = dc.getTipoPersona();
                foreach (var a in lst)
                {
                    lista = new ListItem();
                    lista.Value = a.strID.ToString();
                    lista.Text = a.strDescripcion;
                    ddl.Items.Add(lista);
                }
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
        public void getRiesgo(ref DropDownList ddl, bool bVacio)
        {
            try
            {


                ListItem lista = new ListItem();
                ddl.Items.Clear();
                if (bVacio)
                {
                    lista.Value = "0";
                    lista.Text = "[Seleccionar...]";
                    ddl.Items.Add(lista);
                }

                ComunService.CatalogoResponse[] lst = dc.getRiesgo();
                foreach (var a in lst)
                {
                    lista = new ListItem();
                    lista.Value = a.strID.ToString();
                    lista.Text = a.strDescripcion;
                    ddl.Items.Add(lista);
                }
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }



        public void getEstatusSeguimientoOp(ref DropDownList ddl, bool bVacio)
        {
            try
            {


                ListItem lista = new ListItem();
                ddl.Items.Clear();
                if (bVacio)
                {
                    lista.Value = "0";
                    lista.Text = "[Seleccionar...]";
                    ddl.Items.Add(lista);
                }

                ComunService.CatalogoResponse[] lst = dc.getEstatusSeguimientoOp();
                foreach (var a in lst)
                {
                    lista = new ListItem();
                    lista.Value = a.strID.ToString();
                    lista.Text = a.strDescripcion;
                    ddl.Items.Add(lista);
                }
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }


        public void geProductos(ref DropDownList ddl, bool bVacio)
        {
            try
            {


                ListItem lista = new ListItem();
                ddl.Items.Clear();
                if (bVacio)
                {
                    lista.Value = "0";
                    lista.Text = "[Seleccionar...]";
                    ddl.Items.Add(lista);
                }

                ComunService.CatalogoResponse[] lst = dc.getProductos();
                foreach (var a in lst)
                {
                    lista = new ListItem();
                    lista.Value = a.strID.ToString();
                    lista.Text = a.strDescripcion;
                    ddl.Items.Add(lista);
                }
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }


    }
}