using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using PLD.BusinessEntities;
using PLD.BusinessEntities.Catalogo;
using PLD.BusinessEntities.Comun;
using PLD.BussinesEntities.Comun;

namespace PLD.Services
{
    [ServiceContract]
    interface IComunContract
    {

        [OperationContract]
        void setLogError(LogError error);
        [OperationContract]
        ServiceResult setCargaInformacion(string strUsuario);
        [OperationContract]
        List<Carga> getBitacoraCarga(DateTime dttFechIni, DateTime dttFechFin);
        [OperationContract]
        ServiceResult setCatalogos(List<CatalogoRequest> request);
        [OperationContract]
        List<CatalogoResponse> getEstado();
        [OperationContract]
        List<CatalogoResponse> getLocalidad();
        [OperationContract]
        List<CatalogoResponse> getActividad();
        [OperationContract]
        List<CatalogoResponse> getNacionalidad();
        [OperationContract]
        List<CatalogoResponse> getTipoPersona();
        [OperationContract]
        List<CatalogoResponse> getRiesgo();
        [OperationContract]
        List<CatalogoResponse> getEstatusSeguimientoOp();
        [OperationContract]
        List<TipoInusual> getConfigInusual();
        [OperationContract]
        List<CatalogoResponse> getProductos();
    }
}
