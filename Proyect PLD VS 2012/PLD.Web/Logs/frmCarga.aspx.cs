using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

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



                }
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }

        protected void btnBuscar(object sender, EventArgs e)
        {
            try
            {

                string strFechIni = "";
                string strFechFin = "";

                try
                {
                    strFechIni = txtFechIni.Text.Split('/')[2].ToString() + "-" + txtFechIni.Text.Split('/')[1].ToString() + "-" + txtFechIni.Text.Split('/')[0].ToString();
                    DateTime.Parse(strFechIni);
                }
                catch (Exception)
                {
                    strFechIni = DateTime.Now.ToString();
                }

                try
                {
                    strFechFin = txtFechFin.Text.Split('/')[2].ToString() + "-" + txtFechFin.Text.Split('/')[1].ToString() + "-" + txtFechFin.Text.Split('/')[0].ToString();
                    DateTime.Parse(strFechFin);
                }
                catch (Exception)
                {
                    strFechFin = DateTime.Now.ToString();
                }



                Session["User"] = "";
                PLD.Web.ComunService.ComunContractClient wsComun = new ComunService.ComunContractClient();
                ViewState["BitacoraCarga"] = wsComun.getBitacoraCarga(DateTime.Parse(strFechIni), DateTime.Parse(strFechFin));
                grvCargas.DataSource = ViewState["BitacoraCarga"];
                grvCargas.DataBind();
                UPD_Cargas.Update();
            }
            catch (Exception ex)
            {

                Mensaje.setMensaje(ex.Message, 2);
            }
        }

        private void CargaGrid(bool carga)
        {
            try
            {
                grvCargas.DataSource = ViewState["BitacoraCarga"];
                grvCargas.DataBind();
                UPD_Cargas.Update();

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



                    XDocument xmlDoc = XDocument.Parse(strXML);


                    DataSet dataSet = new DataSet(xmlDoc.Root.Name.ToString());

                    Console.WriteLine(xmlDoc);

                    //Recorre los nodos de la raiz (Root) 
                    //El metodo Nodes() devuelve una coleccion de objetos XNode 
                    Console.WriteLine("\nNodos de la raiz:");
                    foreach (var n in xmlDoc.Root.Nodes())
                    {

                        XDocument xmlT = XDocument.Parse(n.ToString());
                        DataTable dataTable = new DataTable(xmlT.Root.Name.ToString());
                        bool blAgregaT = false;
                        foreach (var item in xmlT.Root.Nodes())
                        {
                            XDocument xmlC = XDocument.Parse(item.ToString());
                            dataTable.Columns.Add(xmlC.Root.Name.ToString(), typeof(string));
                            blAgregaT = true;
                        }

                        if (blAgregaT)
                            dataSet.Tables.Add(dataTable);
                    }
                    System.IO.StringReader xmlSR = new System.IO.StringReader(strXML);

                    dataSet.ReadXml(xmlSR, XmlReadMode.IgnoreSchema);

                    grvClientes.DataSource = dataSet.Tables.Count >= 1 ? dataSet.Tables[0] : new DataTable();
                    grvClientes.DataBind();
                    grvDomicilios.DataSource = dataSet.Tables.Count >= 2 ? dataSet.Tables[1] : new DataTable();
                    grvDomicilios.DataBind();
                    grvProductos.DataSource = dataSet.Tables.Count >= 3 ? dataSet.Tables[2] : new DataTable();
                    grvProductos.DataBind();
                    grvMovimientos.DataSource = dataSet.Tables.Count >= 4 ? dataSet.Tables[3] : new DataTable();
                    grvMovimientos.DataBind();

                    ViewState["dsErrores"] = dataSet;
                    udpErrores.Update();
                    mdlErrores.Show();
                }
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }



        protected void btnExportaGrid_OnClick(object sender, EventArgs e)
        {
            try
            {
                //ExcelHelper.ToExcel((DataSet)ViewState["dsErrores"], @"Ejemplo.xls", Page.Response);

                btnExport_Click(null, null);
                //ExportToExcel(grvClientes);
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }

        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            DataSet dataSet = (DataSet)ViewState["dsErrores"];
            // Create two DataTable instances.
            try
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook xlWorkbook = ExcelApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);

                // Loop over DataTables in DataSet.
                DataTableCollection collection = dataSet.Tables;

                ExcelApp.Caption = "ErroresCarga";

                for (int i = collection.Count; i > 0; i--)
                {
                    Microsoft.Office.Interop.Excel.Sheets xlSheets = null;
                    Microsoft.Office.Interop.Excel.Worksheet xlWorksheet = null;
                    //Create Excel Sheets
                    xlSheets = ExcelApp.Sheets;
                    xlWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)xlSheets.Add(xlSheets[1],
                                   Type.Missing, Type.Missing, Type.Missing);


                    System.Data.DataTable table = collection[i - 1];
                    xlWorksheet.Name = table.TableName;

                    for (int j = 1; j < table.Columns.Count + 1; j++)
                    {
                        ExcelApp.Cells[1, j] = table.Columns[j - 1].ColumnName;
                    }


                    // Storing Each row and column value to excel sheet
                    for (int k = 0; k < table.Rows.Count; k++)
                    {
                        for (int l = 0; l < table.Columns.Count; l++)
                        {

                            ExcelApp.Cells[k + 2, l + 1] =
                            table.Rows[k].ItemArray[l].ToString();
                        }
                    }

                    //Obtiene Rangos 
                    Microsoft.Office.Interop.Excel.Range c1 = xlWorksheet.Cells[1, 1];
                    Microsoft.Office.Interop.Excel.Range c2 = xlWorksheet.Cells[1, table.Columns.Count];
                    Microsoft.Office.Interop.Excel.Range rt = xlWorksheet.Cells[table.Rows.Count+1, table.Columns.Count];
                    //Formato Color , Borde 
                    xlWorksheet.get_Range(c1, c2).Font.Bold = true;
                    xlWorksheet.get_Range(c1, rt).Borders.Color = BorderStyle.Double;
                    xlWorksheet.get_Range(c1, c2).Cells.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

                    ExcelApp.Columns.AutoFit();
                }

                ((Microsoft.Office.Interop.Excel.Worksheet)ExcelApp.ActiveWorkbook.Sheets[ExcelApp.ActiveWorkbook.Sheets.Count]).Delete();
                ExcelApp.Visible = true;

                mdlErrores.Show();
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }



        protected void ExportToExcel(GridView grv)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + grv.ID + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                grv.AllowPaging = false;


                grv.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in grv.HeaderRow.Cells)
                {
                    cell.BackColor = grv.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grv.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grv.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grv.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grv.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }


        protected void grvCarga_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                GridView gridView = (GridView)sender;

                if (e.Row.RowType == DataControlRowType.Pager)
                {
                    Label lblTotalNumDePaginas = (Label)e.Row.FindControl("lblBandeja_TotalNumDePag");
                    lblTotalNumDePaginas.Text = gridView.PageCount.ToString();
                    TextBox txtIrAlaPagina = (TextBox)e.Row.FindControl("txtBandeja");
                    //txtIrAlaPagina.Text = "0";
                    txtIrAlaPagina.Text = (gridView.PageIndex + 1).ToString();
                    DropDownList ddlTamPagina = (DropDownList)e.Row.FindControl("ddlBandeja");
                    ddlTamPagina.SelectedValue = gridView.PageSize.ToString();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        #region Region para el paginado de los grids
        /// <summary>
        /// Evento que realiza el cambio del tamaño del numero de registros
        /// que seran mostradas en pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlBandeja_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList dropDownList = (DropDownList)sender;
                if (int.Parse(dropDownList.SelectedValue) != 0)
                {
                    this.grvCargas.AllowPaging = true;
                    this.grvCargas.PageSize = int.Parse(dropDownList.SelectedValue);
                }
                else
                    this.grvCargas.AllowPaging = false;
                UPD_Cargas.Update();
                //btnBuscar_Click(sender, e);
                CargaGrid(true);
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }

        /// <summary>
        /// Evento que realiza el cambio del tamaño del numero de registros
        /// que seran mostradas en pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlBandejaNoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList dropDownList = (DropDownList)sender;
                if (int.Parse(dropDownList.SelectedValue) != 0)
                {
                    this.grvCargas.AllowPaging = true;
                    this.grvCargas.PageSize = int.Parse(dropDownList.SelectedValue);
                }
                else
                    this.grvCargas.AllowPaging = false;
                UPD_Cargas.Update();
                //btnBuscar_Click(sender, e);
                CargaGrid(false);
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }

        /// <summary>
        /// Evento que registra el cambio del numero de acceso a la pagina a consultar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtBandeja_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtBandejaAvaluosGoToPage = (TextBox)sender;
                int numeroPagina;
                if (int.TryParse(txtBandejaAvaluosGoToPage.Text.Trim(), out numeroPagina))
                    this.grvCargas.PageIndex = numeroPagina - 1;
                else
                    this.grvCargas.PageIndex = 0;
                //btnBuscar_Click(sender, e);
                CargaGrid(true);
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }


        /// <summary>
        /// Evento que registra el cambio del numero de acceso a la pagina a consultar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtBandejaNoPago_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtBandejaAvaluosGoToPage = (TextBox)sender;
                int numeroPagina;
                if (int.TryParse(txtBandejaAvaluosGoToPage.Text.Trim(), out numeroPagina))
                    this.grvCargas.PageIndex = numeroPagina - 1;
                else
                    this.grvCargas.PageIndex = 0;

                //btnBuscar_Click(sender, e);
                CargaGrid(false);
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }

        /// <summary>
        /// Evento que realiza el paginado de la consulta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvCargas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    this.grvCargas.PageIndex = e.NewPageIndex;
                    //btnBuscar_Click(sender, e);
                    CargaGrid(true);
                }
            }
            catch (Exception ex)
            {
                Mensaje.setMensaje(ex.Message, 2);
            }
        }

        #endregion
    }


}

