using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PLD.BusinessEntities;
using PLD.BusinessEntities.Comun;
using PLD.BussinesEntities.Comun;
using PLD.Logic.Comun;
using PLD.Services;

namespace PLD.Services
{
    public class ComunService : IComunContract
    {


        public void setLogError(LogError error)
        {

            try
            {
                (new Logs()).setLogError(error);
            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ComunService.setLogError: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ComunService.setLogError: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
        }

        public ServiceResult setCargaInformacion()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = (new Logs()).setCargaInformacion();
            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ComunService.setLogError: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ComunService.setLogError: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;
        }


        public List<Carga> getBitacoraCarga(DateTime dttFechIni, DateTime dttFechFin)
        {
            List<Carga> result = new List<Carga>();
            try
            {
                result = (new Logs()).getBitacoraCarga(dttFechIni, dttFechFin);
            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ComunService.getBitacoraCarga: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ComunService.setLogError: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;
        }


    }
}
