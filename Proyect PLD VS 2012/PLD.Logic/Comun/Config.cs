using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PLD.BusinessEntities;
using PLD.BusinessEntities.Comun;
using PLD.DataAccess.Comun;

namespace PLD.Logic.Comun
{
    public class Config
    {
        #region Constructor DA

        private ConfigDA ConfDA;
        public Config()
        {
            ConfDA = new ConfigDA();
        }
        #endregion


        public List<TipoInusual> getConfigInusual()
        {
            List<TipoInusual> result = new List<TipoInusual>();
            try
            {
                result = ConfDA.getConfigInusual();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public ServiceResult setConfigInusual(ConfigInusual item)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = ConfDA.setConfigInusual(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public ServiceResult setDetTipoInusual(DetTipoInusual item)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = ConfDA.setDetTipoInusual(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }


    }

}
