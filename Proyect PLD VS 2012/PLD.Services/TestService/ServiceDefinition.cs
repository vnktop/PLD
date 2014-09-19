using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PLD.BussinesEntities;
using PLD.Logic;

namespace PLD.Services
{
    public class ServiceDefinition : IServiceContract
    {
        public List<BE_Test> listar_Test()
        {
            List<BE_Test> results = null;
            try
            {
                results = (new L_Test()).listar_Test();
            }
            catch (Exception ex)
            {               
                throw ex;
            }
            return results;
        }
    }
}
