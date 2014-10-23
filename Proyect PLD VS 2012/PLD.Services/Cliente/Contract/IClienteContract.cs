using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using PLD.BusinessEntities;
using PLD.BusinessEntities.Cliente;
using PLD.BusinessEntities.Producto;

namespace PLD.Services
{
    [ServiceContract]
    interface IClienteContract
    {
        [OperationContract]
        List<ClienteResponse> lstClientes(ClienteRequest request);
        [OperationContract]
        DatosGralesResponse getDatosCliente(short shClienteID);
        [OperationContract]
        CalificacionResponse getCalificacionCliente(short shClienteID);
        [OperationContract]
        ServiceResult setCalificaCliente(short shClienteID, string strUsuario);
        [OperationContract]
        List<CalificacionResponse> getCalificacionClienteHistorico(short shClienteID);
        [OperationContract]
        List<ProductoResponse> getProductosCliente(short sintClienteID);
        [OperationContract]
        List<MovimietoResponse> getMvtosProducto(short sintProductoID);
        [OperationContract]
        List<InusualResponse> getInusuales(ConsultaRequest request);
        [OperationContract]
        List<MovimietoResponse> getDetalleInusual(int intInusualID);
        [OperationContract]
        ServiceResult setInusualSeguimiento(string strInusualesIDs, string strUsuario);
        [OperationContract]
        List<InusualSeguimientoResponse> getInusualSeguimiento(ConsultaRequest request);
        [OperationContract]
        ServiceResult setDetalleSeguimiento(DetalleSeguimientoRequest request);
        [OperationContract]
        DetSeguimientoResponse getDetalleSeguimiento(short sintRelSeguimientoOperacionID, short sintEstatusSeguimientoID);
        [OperationContract]
        List<ReporteResponse> getReportes(ConsultaRequest request);
        [OperationContract]
        ServiceResult setAgrupaReporte();
        [OperationContract]
        ServiceResult setGeneraReporte(short shReporteID);
        [OperationContract]
        List<MovimietoResponse> getMovimientosReporte(short shReporteID);
    }
}
