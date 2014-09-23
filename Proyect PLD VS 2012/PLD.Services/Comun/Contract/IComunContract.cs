using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using PLD.BusinessEntities;
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
        ServiceResult setCargaInformacion();
        [OperationContract]
        List<Carga> getBitacoraCarga(DateTime dttFechIni, DateTime dttFechFin);

    }
}
