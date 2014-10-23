using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PLD.BusinessEntities;
using PLD.BusinessEntities.Cliente;
using PLD.BusinessEntities.Producto;
using PLD.Logic.Cliente;
using PLD.Logic.Producto;

namespace PLD.Services
{
    public class ClienteService : IClienteContract
    {



        public List<ClienteResponse> lstClientes(ClienteRequest request)
        {
            List<ClienteResponse> result = new List<ClienteResponse>();
            try
            {
                result = (new Cliente()).lstClientes(request);

            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ClienteService.lstClientes: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ComunService.setLogError: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;
        }

        public DatosGralesResponse getDatosCliente(short shClienteID)
        {
            DatosGralesResponse result = new DatosGralesResponse();
            try
            {
                result = (new Cliente()).getDatosCliente(shClienteID);

            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ClienteService.getDatosCliente: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ClienteService.getDatosCliente: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;
        }


        public CalificacionResponse getCalificacionCliente(short shClienteID)
        {
            CalificacionResponse result = new CalificacionResponse();
            try
            {
                result = (new Cliente()).getCalificacionCliente(shClienteID);

            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ClienteService.getCalificacionCliente: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ClienteService.getCalificacionCliente: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;
        }

        public ServiceResult setCalificaCliente(short shClienteID, string strUsuario)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = (new Cliente()).setCalificaCliente(shClienteID, strUsuario);

            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ClienteService.setCalificaCliente: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ClienteService.getCalificacionCliente: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;

        }


        public List<CalificacionResponse> getCalificacionClienteHistorico(short shClienteID)
        {
            List<CalificacionResponse> result = new List<CalificacionResponse>();
            try
            {
                result = (new Cliente()).getCalificacionClienteHistorico(shClienteID);

            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ClienteService.getCalificacionClienteHistorico: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ClienteService.getCalificacionClienteHistorico: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;
        }


        public List<ProductoResponse> getProductosCliente(short sintClienteID)
        {
            List<ProductoResponse> result = new List<ProductoResponse>();
            try
            {
                result = (new Producto()).getProductosCliente(sintClienteID);

            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ClienteService.getProductosCliente: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ClienteService.getProductosCliente: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;
        }



        public List<MovimietoResponse> getMvtosProducto(short sintProductoID)
        {
            List<MovimietoResponse> result = new List<MovimietoResponse>();
            try
            {
                result = (new Producto()).getMvtosProducto(sintProductoID);

            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ClienteService.getMvtosProducto: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ClienteService.getProductosCliente: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;

        }


        public List<InusualResponse> getInusuales(ConsultaRequest request)
        {
            List<InusualResponse> result = new List<InusualResponse>();
            try
            {
                result = (new Producto()).getInusuales(request);

            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ClienteService.getInusuales: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ClienteService.getInusuales: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;

        }
        public List<MovimietoResponse> getDetalleInusual(int intInusualID)
        {
            List<MovimietoResponse> result = new List<MovimietoResponse>();
            try
            {
                result = (new Producto()).getDetalleInusual(intInusualID);

            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ClienteService.getDetalleInusual: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ClienteService.getInusuales: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;

        }

        public ServiceResult setInusualSeguimiento(string strInusualesIDs, string strUsuario)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = (new Producto()).setInusualSeguimiento(strInusualesIDs, strUsuario);

            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ClienteService.setInusualSeguimiento: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ClienteService.setInusualSeguimiento: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;

        }


        public List<InusualSeguimientoResponse> getInusualSeguimiento(ConsultaRequest request)
        {
            List<InusualSeguimientoResponse> result = new List<InusualSeguimientoResponse>();
            try
            {
                result = (new Producto()).getInusualSeguimiento(request);

            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ClienteService.getInusualSeguimiento: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ClienteService.setInusualSeguimiento: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;

        }


        public ServiceResult setDetalleSeguimiento(DetalleSeguimientoRequest request)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = (new Producto()).setDetalleSeguimiento(request);
            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ClientService.setDetalleSeguimiento: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ClienteService.setDetalleSeguimiento: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;
        }


        public DetSeguimientoResponse getDetalleSeguimiento(short sintRelSeguimientoOperacionID, short sintEstatusSeguimientoID)
        {
            DetSeguimientoResponse result = new DetSeguimientoResponse();
            try
            {
                result = (new Producto()).getDetalleSeguimiento(sintRelSeguimientoOperacionID, sintEstatusSeguimientoID);
            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ComunService.getDetalleSeguimiento: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ClienteService.getEstatusSeguimientoOp: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;
        }

        public List<ReporteResponse> getReportes(ConsultaRequest request)
        {
            List<ReporteResponse> result = new List<ReporteResponse>();
            try
            {
                result = (new Producto()).getReportes(request);
            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ComunService.getReportes: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ClienteService.getEstatusSeguimientoOp: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;
        }


        public ServiceResult setAgrupaReporte()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = (new Producto()).setAgrupaReporte();
            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ComunService.setAgrupaReporte: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ClienteService.setAgrupaReporte: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;
        }



        public ServiceResult setGeneraReporte(short shReporteID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = (new Producto()).setGeneraReporte(shReporteID);
            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ComunService.setGeneraReporte: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ClienteService.setGeneraReporte: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;
        }

        public List<MovimietoResponse> getMovimientosReporte(short shReporteID)
        {

            List<MovimietoResponse> result = new List<MovimietoResponse>();
            try
            {
                result = (new Producto()).getMovimientosReporte(shReporteID);
            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ComunService.getMovimientosReporte: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ClienteService.getMovimientosReporte: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;

        }

    }
}
