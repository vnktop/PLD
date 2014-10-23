using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PLD.BusinessEntities;
using PLD.BusinessEntities.Catalogo;
using PLD.BusinessEntities.Comun;
using PLD.BusinessEntities.Producto;
using PLD.BussinesEntities.Comun;
using PLD.Logic.Catalogos;
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

        public ServiceResult setCargaInformacion(string strUsuario)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = (new Logs()).setCargaInformacion(strUsuario);
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



        public ServiceResult setCatalogos(List<CatalogoRequest> request)
        {

            ServiceResult result = new ServiceResult();
            try
            {

                result = (new Catalogo()).setCatalogos(request);
            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ComunService.setCatalogos: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ComunService.setLogError: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;
        }

        public List<CatalogoResponse> getEstado()
        {
            List<CatalogoResponse> result = new List<CatalogoResponse>();
            try
            {

                result = (new Catalogo()).getEstado();
            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ComunService.getEstado: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ComunService.getEstado: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;
        }


        public List<CatalogoResponse> getLocalidad()
        {
            List<CatalogoResponse> result = new List<CatalogoResponse>();
            try
            {

                result = (new Catalogo()).getLocalidad();
            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ComunService.getLocalidad: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ComunService.getLocalidad: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;
        }

        public List<CatalogoResponse> getActividad()
        {
            List<CatalogoResponse> result = new List<CatalogoResponse>();
            try
            {

                result = (new Catalogo()).getActividad();
            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ComunService.getActividad: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ComunService.getActividad: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;
        }

        public List<CatalogoResponse> getNacionalidad()
        {
            List<CatalogoResponse> result = new List<CatalogoResponse>();
            try
            {

                result = (new Catalogo()).getNacionalidad();
            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ComunService.getNacionalidad: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ComunService.getActividad: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;
        }

        public List<CatalogoResponse> getTipoPersona()
        {
            List<CatalogoResponse> result = new List<CatalogoResponse>();
            try
            {

                result = (new Catalogo()).getTipoPersona();
            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ComunService.getTipoPersona: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ComunService.getActividad: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;
        }



        public List<CatalogoResponse> getRiesgo()
        {
            List<CatalogoResponse> result = new List<CatalogoResponse>();
            try
            {
                result = (new Catalogo()).getRiesgo();
            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ComunService.getRiesgo: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ClienteService.getRiesgo: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;
        }

        public List<CatalogoResponse> getEstatusSeguimientoOp()
        {
            List<CatalogoResponse> result = new List<CatalogoResponse>();
            try
            {
                result = (new Catalogo()).getEstatusSeguimientoOp();
            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ComunService.getEstatusSeguimientoOp: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ClienteService.getEstatusSeguimientoOp: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;
        }


        public List<TipoInusual> getConfigInusual()
        {
            List<TipoInusual> result = new List<TipoInusual>();
            try
            {
                result = (new Config()).getConfigInusual();
            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ComunService.getConfigInusual: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ClienteService.getConfigInusual: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;
        }


        public List<CatalogoResponse> getProductos()
        {
            List<CatalogoResponse> result = new List<CatalogoResponse>();
            try
            {
                result = (new Catalogo()).getProductos();
            }
            catch (Exception ex)
            {
#if(DEBUG)
                Console.WriteLine("Error en ComunService.getProductos: " + ex.Message);
#else
                    EventLogManager.LogErrorEntry("Error en ClienteService.getRiesgo: " + ex.Message);
                    //TODO: Codificar envío de notificación de error al EventLog
#endif
            }
            return result;
        }
    }
}
