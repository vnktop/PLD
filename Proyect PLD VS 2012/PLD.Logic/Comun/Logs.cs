using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PLD.BusinessEntities;
using PLD.BusinessEntities.Comun;
using PLD.BussinesEntities.Comun;
using PLD.DataAccess.Comun;

namespace PLD.Logic.Comun
{
    public class Logs
    {

        #region Constructor DA

        private LogsDA LogDA;
        public Logs()
        {
            LogDA = new LogsDA();
        }
        #endregion


        public void setLogError(LogError error)
        {
            try
            {
                LogDA.setLogError(error);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }


        public ServiceResult setCargaInformacion()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = LogDA.setCargaInformacion();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public List<Carga> getBitacoraCarga(DateTime dttFechIni, DateTime dttFechFin)
        {
            List<Carga> result = new List<Carga>();
            try
            {
                result = LogDA.getBitacoraCarga(dttFechIni, dttFechFin);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

    }
}