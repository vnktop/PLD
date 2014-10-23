using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PLD.BusinessEntities;
using PLD.BusinessEntities.Producto;
using PLD.DataAccess.Context;

namespace PLD.DataAccess
{
    public class ProductoDA
    {


        public List<ProductoResponse> getProductosCliente(short sintClienteID)
        {

            List<ProductoResponse> result = new List<ProductoResponse>();
            try
            {
                using (ClientesDataContext dc = new ClientesDataContext(Helper.ConnectionString()))
                {
                    var lnqProductos = from a in dc.tbl_MST_Producto
                                       where a.sintClienteID == sintClienteID
                                       select new ProductoResponse
                                       {
                                           decMontoInicial = a.decMontoInicial,
                                           decSaldoMensual = a.decSaldoMensual,
                                           intProductoID = a.intProductoID,
                                           sdatFechaAlta = a.sdatFechaAlta,
                                           sdatFechaFin = a.sdatFechaFin,
                                           sintClienteID = a.sintClienteID,
                                           sintMonedaID = a.sintMonedaID,
                                           sintTipoProductoID = a.sintTipoProductoID,
                                           vchCodOperador = a.vchCodOperador,
                                           vchCodOperadorAutiliza = a.vchCodOperadorAutiliza,
                                           vchCodSucursal = a.vchCodSucursal,
                                           vhcNoCuenta = a.vhcNoCuenta,
                                       };
                    result.AddRange(lnqProductos);
                }

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<MovimietoResponse> getMvtosProducto(short sintProductoID)
        {

            List<MovimietoResponse> result = new List<MovimietoResponse>();
            try
            {
                using (ClientesDataContext dc = new ClientesDataContext(Helper.ConnectionString()))
                {
                    var lnqProductos = from a in dc.tbl_DET_ProductoMovimiento
                                       where a.tbl_MST_Producto.intProductoID == sintProductoID
                                       select new MovimietoResponse
                                       {
                                           decMonto = a.decMonto,
                                           dtFechaOperacion = a.dtFechaOperacion,
                                           intProductoID = a.intProductoID,
                                           strNoCuenta = a.tbl_MST_Producto.vhcNoCuenta,
                                           intMovimientoID = a.intMovimientoID,
                                           sintMonedaID = a.sintMonedaID,
                                           sintTipoOperacionID = a.sintTipoOperacionID,
                                           vchReferencia = a.vchReferencia,
                                       };
                    result.AddRange(lnqProductos);
                }

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<InusualResponse> getInusuales(ConsultaRequest request)
        {
            List<InusualResponse> result = new List<InusualResponse>();
            try
            {
                using (ClientesDataContext dc = new ClientesDataContext(Helper.ConnectionString()))
                {

                    var lnqInusuales = from a in dc.stp_getInusuales(request.shClienteID, request.dttFechaInicio, request.dttFechaFin)
                                       select
                                           new InusualResponse
                                           {
                                               intInusualID = a.intInusualID,
                                               decMontoPesos = a.decMontoPesos,
                                               sintTipoInusual = a.sintTipoInusual,
                                               strTipoInusual = a.vchNombre,
                                               decMontoDolar = a.decMontoDolar,
                                               datFechaDeteccion = a.datFechaDeteccion,
                                               strNombreCliente = a.vchNombreCliente
                                           };
                    result.AddRange(lnqInusuales);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<MovimietoResponse> getDetalleInusual(int intInusualID)
        {
            List<MovimietoResponse> response = new List<MovimietoResponse>();
            try
            {
                using (ClientesDataContext dc = new ClientesDataContext(Helper.ConnectionString()))
                {
                    var lnqDetalle = from a in dc.tbl_DET_Inusual
                                     join b in dc.tbl_DET_ProductoMovimiento on a.intMovimientoID equals b.intMovimientoID
                                     where a.intInusualID == intInusualID
                                     select new MovimietoResponse
                                     {
                                         decMonto = b.decMonto,
                                         dtFechaOperacion = b.dtFechaOperacion,
                                         intMovimientoID = b.intMovimientoID,
                                         sintMonedaID = b.sintMonedaID,
                                         sintTipoOperacionID = b.sintTipoOperacionID,
                                         strNoCuenta = b.tbl_MST_Producto.vhcNoCuenta,
                                         vchReferencia = b.vchReferencia
                                     };

                    response.AddRange(lnqDetalle);

                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public ServiceResult setInusualSeguimiento(string strInusualesIDs, string strUsuario)
        {
            try
            {
                ServiceResult result = new ServiceResult();
                //using (TransactionScope trans = new TransactionScope())
                //{
                using (ClientesDataContext dc = new ClientesDataContext(Helper.ConnectionString()))
                {

                    dc.stp_setInusualSeguimiento(strInusualesIDs, 1, false, strUsuario);
                }
                // }
                result.ServiceOk = true;
                result.ErrorMessage = "Se completo la transaccion";
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public List<InusualSeguimientoResponse> getInusualSeguimiento(ConsultaRequest request)
        {
            List<InusualSeguimientoResponse> response = new List<InusualSeguimientoResponse>();
            try
            {
                using (ClientesDataContext dc = new ClientesDataContext(Helper.ConnectionString()))
                {
                    var lnqDetalle = from a in dc.stp_getInusualAvance(request.shClienteID, request.dttFechaInicio, request.dttFechaFin)
                                     select new InusualSeguimientoResponse
                                     {
                                         strNombre = a.Nombre,
                                         strTipoInusual = a.TipoInusual,
                                         datFechaDeteccion = a.datFechaDeteccion,
                                         decMontoDolar = a.decMontoDolar,
                                         decMontoPesos = a.decMontoPesos,
                                         intInusualID = a.intInusualID,
                                         sintEstatusSeguimientoID = a.sintEstatusSeguimientoID,
                                         sintRelSeguimientoOperacionID = a.sintRelSeguimientoOperacionID,
                                         sintTipoInusual = a.sintTipoInusual,
                                         strEstatusDescripcion = a.EstatusDescripcion,
                                     };

                    response.AddRange(lnqDetalle);

                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public ServiceResult setDetalleSeguimiento(DetalleSeguimientoRequest request)
        {
            ServiceResult response = new ServiceResult();
            try
            {
                using (ClientesDataContext dc = new ClientesDataContext(Helper.ConnectionString()))
                {


                    var lnq_DetSeg = from a in dc.tbl_DET_Seguimiento
                                     where a.sintRelSeguimientoOperacionlID == request.sintRelSeguimientoOperacionID &&
                                     a.sintEstatusSeguimientoID == request.sintEstatusSeguimientoID
                                     select a;



                    if (lnq_DetSeg.Count() > 0)
                    {
                        lnq_DetSeg.First().sintEstatusSeguimientoID = request.sintEstatusSeguimientoID;
                        lnq_DetSeg.First().vchDescripcion = request.strDescripcion;
                        lnq_DetSeg.First().vchObservaciones = request.strObservaciones;
                        lnq_DetSeg.First().sdatFecha = DateTime.Now;
                        lnq_DetSeg.First().vchUsuario = request.strUsuario;
                    }
                    else
                    {
                        var lnq_Seg = from a in dc.tbl_REL_SeguimientoOperacion
                                      where a.sintRelSeguimientoOperacionID == request.sintRelSeguimientoOperacionID
                                      select a;

                        lnq_Seg.First().sintEstatusSeguimientoID = request.sintEstatusSeguimientoID;

                        tbl_DET_Seguimiento tbl_Seg = new tbl_DET_Seguimiento();

                        tbl_Seg.sintEstatusSeguimientoID = request.sintEstatusSeguimientoID;
                        tbl_Seg.sintRelSeguimientoOperacionlID = request.sintRelSeguimientoOperacionID;
                        tbl_Seg.vchDescripcion = request.strDescripcion;
                        tbl_Seg.vchObservaciones = request.strObservaciones;
                        tbl_Seg.sdatFecha = DateTime.Now;
                        tbl_Seg.vchUsuario = request.strUsuario;
                        dc.tbl_DET_Seguimiento.InsertOnSubmit(tbl_Seg);
                    }
                    dc.SubmitChanges();
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DetSeguimientoResponse getDetalleSeguimiento(short sintRelSeguimientoOperacionID, short sintEstatusSeguimientoID)
        {
            try
            {
                DetSeguimientoResponse result = new DetSeguimientoResponse();

                using (ClientesDataContext dc = new ClientesDataContext(Helper.ConnectionString()))
                {

                    var lnq_DetSeg = from a in dc.tbl_DET_Seguimiento
                                     where a.sintRelSeguimientoOperacionlID == sintRelSeguimientoOperacionID && a.sintEstatusSeguimientoID == sintEstatusSeguimientoID
                                     select new DetSeguimientoResponse
                                     {
                                         sdatFecha = a.sdatFecha,
                                         sintDetSeguimientoID = a.sintDetSeguimientoID,
                                         sintEstatusSeguimientoID = a.sintEstatusSeguimientoID,
                                         sintRelSeguimientoOperacionlID = a.sintRelSeguimientoOperacionlID,
                                         vchDescripcion = a.vchDescripcion,
                                         vchObservaciones = a.vchObservaciones,
                                     };
                    result = lnq_DetSeg.FirstOrDefault();
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<ReporteResponse> getReportes(ConsultaRequest request)
        {
            try
            {
                List<ReporteResponse> result = new List<ReporteResponse>();

                using (ClientesDataContext dc = new ClientesDataContext(Helper.ConnectionString()))
                {
                    var lnq_Rep = from a in dc.tbl_MST_Reportes
                                  where a.sdatFechaReporte >= request.dttFechaInicio && a.sdatFechaReporte <= request.dttFechaFin
                                  select new ReporteResponse
                                  {
                                      bitReportado = a.bitReportado,
                                      sdatFechaReporte = a.sdatFechaReporte,
                                      sintReporteID = a.sintReporteID,
                                      sintTipoReporteID = a.sintTipoReporteID,
                                      strTipoReporte = a.tbl_CAT_TipoReporte.vchDescripcion,
                                      detReporte = a.tbl_DET_Reporte.Select(item => new DetReporte()
                                      {
                                          sintRelSeguimientoOperacionID = item.sintRelSeguimientoOperacionID,
                                          sintReporteID = item.sintReporteID

                                      }).FirstOrDefault(),
                                  };

                    result.AddRange(lnq_Rep.OrderByDescending(x => x.sintReporteID));
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ServiceResult setAgrupaReporte()
        {

            ServiceResult result = new ServiceResult();

            try
            {
                using (ClientesDataContext dc = new ClientesDataContext(Helper.ConnectionString()))
                {
                    dc.stp_AgrupaReporte();
                    result.ErrorMessage = "Se actualizaron.";
                    result.ServiceOk = true;
                }
            }
            catch (Exception ex)
            {
                result.ServiceOk = false;
                result.ErrorMessage = ex.Message;
                throw new Exception(ex.Message);
            }
            return result;
        }



        public ServiceResult setGeneraReporte(short shReporteID)
        {

            ServiceResult result = new ServiceResult();

            try
            {
                using (ClientesDataContext dc = new ClientesDataContext(Helper.ConnectionString()))
                {


                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<MovimietoResponse> getMovimientosReporte(short shReporteID)
        {

            List<MovimietoResponse> result = new List<MovimietoResponse>();

            try
            {
                using (ClientesDataContext dc = new ClientesDataContext(Helper.ConnectionString()))
                {

                    var lnqMovRpt = from a in dc.stp_getDetalleMovRpt(shReporteID)
                                    select new MovimietoResponse
                                    {
                                        decMonto=a.decMonto,
                                        dtFechaOperacion = a.dtFechaOperacion,
                                        intMovimientoID = a.intMovimientoID,
                                        intProductoID = a.intProductoID,
                                        sintMonedaID = a.sintMonedaID,
                                        sintTipoOperacionID = a.sintTipoOperacionID,
                                        strMoneda = a.strTipoMoneda,
                                        strNoCuenta = a.vhcNoCuenta,
                                        strTipoOperacion = a.vchTipoOperacion,
                                        vchReferencia = a.vchReferencia,
                                        strNombreCliente = a.vchNombreCliente
                                    };

                    result.AddRange(lnqMovRpt);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

    }
}
