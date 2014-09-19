using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using PLD.BussinesEntities;

namespace PLD.Services
{
    [ServiceContract]
    interface IServiceContract
    {
        [OperationContract]
        List<BE_Test> listar_Test();
    }
}
