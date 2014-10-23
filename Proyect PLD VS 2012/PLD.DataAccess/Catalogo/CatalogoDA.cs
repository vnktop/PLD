using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PLD.BusinessEntities;
using PLD.BusinessEntities.Catalogo;
using PLD.BusinessEntities.Comun;
using PLD.DataAccess.Context;

namespace PLD.DataAccess.Catalogo
{
    public class CatalogoDA
    {
        public ServiceResult setCatalogos(List<CatalogoRequest> request)
        {
            ServiceResult result = new ServiceResult();
            try
            {

                using (CatalogosDataContext dc = new CatalogosDataContext(Helper.ConnectionString()))
                {
                    foreach (var item in request)
                    {
                        switch (item.vchCodigo)
                        {
                            case "Estado":

                                var lnqEstado = from a in dc.tbl_CAT_Estado where a.vchClave == item.vchClave select a;

                                if (lnqEstado != null)
                                    if (lnqEstado.Count() > 0)
                                    {
                                        lnqEstado.First().vchDescripcion = item.vchDescripcion;
                                    }
                                    else
                                    {
                                        tbl_CAT_Estado tbl = new tbl_CAT_Estado();
                                        tbl.vchDescripcion = item.vchDescripcion;
                                        tbl.vchClave = item.vchClave;
                                        dc.tbl_CAT_Estado.InsertOnSubmit(tbl);
                                    }
                                break;
                            case "Localidad":

                                var lnqLocalidad = from a in dc.tbl_CAT_Localidades where a.vchClave == item.vchClave select a;

                                if (lnqLocalidad != null)
                                    if (lnqLocalidad.Count() > 0)
                                    {
                                        lnqLocalidad.First().vchDescripcion = item.vchDescripcion;
                                    }
                                    else
                                    {
                                        var lnqEstadoID = from a in dc.tbl_CAT_Estado where a.vchClave == item.vchClaveRel select new { a.sintEstadoID };

                                        if (lnqEstadoID != null)
                                        {
                                            tbl_CAT_Localidades tbl = new tbl_CAT_Localidades();
                                            tbl.vchDescripcion = item.vchDescripcion;
                                            tbl.sintEstadoID = lnqEstadoID.Count() > 0 ?(short?)short.Parse(lnqEstadoID.ToString()) : null;
                                            tbl.vchClave = item.vchClave;
                                            dc.tbl_CAT_Localidades.InsertOnSubmit(tbl);
                                        }
                                        else
                                        {
                                            using (ComunDataContext dComun = new ComunDataContext(Helper.ConnectionString()))
                                            {

                                            }
                                        }

                                    }
                                break;
                            case "Actividad":

                                var lnqActividad = from a in dc.tbl_CAT_Actividad where a.vchClave == item.vchClave select a;

                                if (lnqActividad != null)
                                    if (lnqActividad.Count() > 0)
                                    {
                                        lnqActividad.First().vchDescripcion = item.vchDescripcion;
                                        lnqActividad.First().sintPuntaje = item.shPuntaje;
                                    }
                                    else
                                    {
                                        tbl_CAT_Actividad tbl = new tbl_CAT_Actividad();
                                        tbl.vchDescripcion = item.vchDescripcion;
                                        tbl.vchClave = item.vchClave;
                                        tbl.sintPuntaje = item.shPuntaje;
                                        dc.tbl_CAT_Actividad.InsertOnSubmit(tbl);
                                    }
                                break;
                            case "Moneda":

                                var lnqMoneda = from a in dc.tbl_CAT_Moneda where a.vchClave == item.vchClave select a;

                                if (lnqMoneda != null)
                                    if (lnqMoneda.Count() > 0)
                                    {
                                        lnqMoneda.First().vchDescripcion = item.vchDescripcion;
                                    }
                                    else
                                    {
                                        tbl_CAT_Moneda tbl = new tbl_CAT_Moneda();
                                        tbl.vchDescripcion = item.vchDescripcion;
                                        tbl.vchClave = item.vchClave;
                                        dc.tbl_CAT_Moneda.InsertOnSubmit(tbl);
                                    }
                                break;
                            case "Nacionalidad":

                                var lnqNacion = from a in dc.tbl_CAT_Nacionalidad where a.vchClave == item.vchClave select a;

                                if (lnqNacion != null)
                                    if (lnqNacion.Count() > 0)
                                    {
                                        lnqNacion.First().vchDescripcion = item.vchDescripcion;
                                    }
                                    else
                                    {
                                        tbl_CAT_Nacionalidad tbl = new tbl_CAT_Nacionalidad();
                                        tbl.vchDescripcion = item.vchDescripcion;
                                        tbl.vchClave = item.vchClave;
                                        dc.tbl_CAT_Nacionalidad.InsertOnSubmit(tbl);
                                    }
                                break;
                            case "TipoDomicilio":

                                var lnqTipDom = from a in dc.tbl_CAT_TipoDomicilio where a.vchClave == item.vchClave select a;

                                if (lnqTipDom != null)
                                    if (lnqTipDom.Count() > 0)
                                    {
                                        lnqTipDom.First().vchDescripcion = item.vchDescripcion;
                                    }
                                    else
                                    {
                                        tbl_CAT_TipoDomicilio tbl = new tbl_CAT_TipoDomicilio();
                                        tbl.vchDescripcion = item.vchDescripcion;
                                        tbl.vchClave = item.vchClave;
                                        dc.tbl_CAT_TipoDomicilio.InsertOnSubmit(tbl);
                                    }
                                break;
                            case "TipoPersona":

                                var lnqTipPer = from a in dc.tbl_CAT_TipoPersona where a.vchClave == item.vchClave select a;

                                if (lnqTipPer != null)
                                    if (lnqTipPer.Count() > 0)
                                    {
                                        lnqTipPer.First().vchDescripcion = item.vchDescripcion;
                                    }
                                    else
                                    {
                                        tbl_CAT_TipoPersona tbl = new tbl_CAT_TipoPersona();
                                        tbl.vchDescripcion = item.vchDescripcion;
                                        tbl.vchClave = item.vchClave;
                                        dc.tbl_CAT_TipoPersona.InsertOnSubmit(tbl);
                                    }
                                break;
                            default:
                                break;
                        }
                    }

                    dc.SubmitChanges();
                }

                result.ServiceOk = true;
                result.ErrorMessage = "Se cargaron los Catalogos con Exito";
                return result;
            }
            catch (Exception ex)
            {
                result.ServiceOk = false;
                result.ErrorMessage = ex.Message;
                throw new Exception(ex.Message);
            }
        }

        public List<CatalogoResponse> getEstado()
        {
            try
            {
                List<CatalogoResponse> result = new List<CatalogoResponse>();
                using (CatalogosDataContext dc = new CatalogosDataContext(Helper.ConnectionString()))
                {
                    var lnqCat = from a in dc.tbl_CAT_Estado
                                 select new CatalogoResponse
                                 {
                                     strID = a.sintEstadoID.ToString(),
                                     strDescripcion = a.vchDescripcion
                                 };
                    result.AddRange(lnqCat);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CatalogoResponse> getLocalidad()
        {
            try
            {
                List<CatalogoResponse> result = new List<CatalogoResponse>();
                using (CatalogosDataContext dc = new CatalogosDataContext(Helper.ConnectionString()))
                {
                    var lnqCat = from a in dc.tbl_CAT_Localidades
                                 select new CatalogoResponse
                                 {
                                     strID = a.sintLocalidadID.ToString(),
                                     strDescripcion = a.vchDescripcion
                                 };
                    result.AddRange(lnqCat);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CatalogoResponse> getActividad()
        {
            try
            {
                List<CatalogoResponse> result = new List<CatalogoResponse>();
                using (CatalogosDataContext dc = new CatalogosDataContext(Helper.ConnectionString()))
                {
                    var lnqCat = from a in dc.tbl_CAT_Actividad
                                 select new CatalogoResponse
                                 {
                                     strID = a.sintActividadID.ToString(),
                                     strDescripcion = a.vchDescripcion
                                 };
                    result.AddRange(lnqCat);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CatalogoResponse> getNacionalidad()
        {
            try
            {
                List<CatalogoResponse> result = new List<CatalogoResponse>();
                using (CatalogosDataContext dc = new CatalogosDataContext(Helper.ConnectionString()))
                {
                    var lnqCat = from a in dc.tbl_CAT_Nacionalidad
                                 select new CatalogoResponse
                                 {
                                     strID = a.sintNacionalidadID.ToString(),
                                     strDescripcion = a.vchDescripcion
                                 };
                    result.AddRange(lnqCat);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CatalogoResponse> getTipoPersona()
        {
            try
            {
                List<CatalogoResponse> result = new List<CatalogoResponse>();
                using (CatalogosDataContext dc = new CatalogosDataContext(Helper.ConnectionString()))
                {
                    var lnqCat = from a in dc.tbl_CAT_TipoPersona
                                 select new CatalogoResponse
                                 {
                                     strID = a.sintTipoPersonaID.ToString(),
                                     strDescripcion = a.vchDescripcion
                                 };
                    result.AddRange(lnqCat);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CatalogoResponse> getRiesgo()
        {
            try
            {
                List<CatalogoResponse> result = new List<CatalogoResponse>();
                using (ClientesDataContext dc = new ClientesDataContext(Helper.ConnectionString()))
                {
                    var lnqCat = from a in dc.tbl_CAT_RiesgoCliente
                                 select new CatalogoResponse
                                 {
                                     strID = a.sintRiesgoClienteID.ToString(),
                                     strDescripcion = a.vchDescripcion
                                 };
                    result.AddRange(lnqCat);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CatalogoResponse> getEstatusSeguimientoOp()
        {
            try
            {
                List<CatalogoResponse> result = new List<CatalogoResponse>();
                using (CatalogosDataContext dc = new CatalogosDataContext(Helper.ConnectionString()))
                {
                    var lnqCat = from a in dc.tbl_CAT_EstuausSeguimiento
                                 select new CatalogoResponse
                                 {
                                     strID = a.sintEstatusSeguimientoID.ToString(),
                                     strDescripcion = a.vchDescripcion
                                 };
                    result.AddRange(lnqCat);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CatalogoResponse> getProductos()
        {
            try
            {
                List<CatalogoResponse> result = new List<CatalogoResponse>();
                using (CatalogosDataContext dc = new CatalogosDataContext(Helper.ConnectionString()))
                {
                    var lnqCat = from a in dc.tbl_CAT_TipoProducto
                                 select new CatalogoResponse
                                 {
                                     strID = a.sintTipoProductoID.ToString(),
                                     strDescripcion = a.vchDescripcion
                                 };
                    result.AddRange(lnqCat);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
