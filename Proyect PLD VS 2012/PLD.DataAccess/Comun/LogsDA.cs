using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PLD.BusinessEntities;
using PLD.BusinessEntities.Comun;
using PLD.BussinesEntities.Comun;
using PLD.DataAccess.Context;

namespace PLD.DataAccess.Comun
{
    public class LogsDA
    {
        /// <summary>
        /// Inserta entidad LogError, esto para llevar el control de todos los errores de la aplicacion
        /// </summary>
        /// <param name="error">LogError</param>
        public void setLogError(LogError error)
        {
            try
            {
                using (ComunDataContext dc = new ComunDataContext(Helper.ConnectionString()))
                {
                    tbl_LOG_Error tbl = new tbl_LOG_Error();

                    tbl.datFechaError = error.datFechaError;
                    tbl.vchMensaje = error.vchMensaje;
                    tbl.vchUsuario = error.vchUsuario;
                    tbl.vchIP = error.vchIP;
                    tbl.vchParametros = error.vchParametros;
                    tbl.vchStakeTrace = error.vchStakeTrace;
                    tbl.vchHostName = error.vchHostName;
                    dc.tbl_LOG_Error.InsertOnSubmit(tbl);
                    dc.SubmitChanges();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void setNavegacion(BusinessEntities.Log.Nevegacion navegacion)
        {
            try
            {
                using (ComunDataContext dc = new ComunDataContext(Helper.ConnectionString()))
                {

                }
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
                using (ComunDataContext dc = new ComunDataContext(Helper.ConnectionString()))
                {
                    string strMensaje = "";
                    short? shError = 0;
                    dc.stp_CargaInformacion(ref strMensaje, ref shError);
                    result.ServiceOk = shError == 0 ? true : false;
                    result.ErrorMessage = strMensaje;
                }
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
                using (ComunDataContext dc = new ComunDataContext(Helper.ConnectionString()))
                {
                    var lnqCarga = from a in dc.tbl_LOG_Carga
                                   where a.sdatFecha >= dttFechIni && a.sdatFecha <= dttFechFin
                                   select new Carga
                                   {
                                       intLogID = a.intLogID,
                                       sdatFecha = a.sdatFecha,
                                       sintNoError = a.sintNoError,
                                       sintNoExito = a.sintNoExito,
                                       vchDescripcion = a.vchDescripcion,
                                       vchParametros = a.vchParametros,
                                       vchUsuario = a.vchUsuario,
                                       vchXMLError = a.vchXMLError
                                   };

                    result.AddRange(lnqCarga);
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
