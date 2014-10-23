using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PLD.BusinessEntities;
using PLD.BusinessEntities.Cliente;
using PLD.DataAccess.Context;

namespace PLD.DataAccess.Cliente
{
    public class ClienteDA
    {
        /// <summary>
        /// Obtiene lista de Clientes
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<ClienteResponse> lstClientes(ClienteRequest request)
        {
            try
            {

                using (ClientesDataContext dc = new ClientesDataContext(Helper.ConnectionString()))
                {
                    List<ClienteResponse> result = new List<ClienteResponse>();

                    var lnqClientes = from a in dc.stp_getClientes(request.strNoCliente, request.strNombre, request.strRFC, request.strEstado, request.strMunicipio, request.strNoCuenta, request.shRiesgo, request.shSeguimiento)
                                      select new ClienteResponse
                                      {
                                          shCalificacion = (short)a.shCalificacion,
                                          shClienteID = a.shClienteID,
                                          shRiesgo = (short)a.shRiesgo,
                                          strNoCliente = a.strNoCliente,
                                          strNombre = a.strNombre,
                                          strRFC = a.strRFC
                                      };
                    result.AddRange(lnqClientes);

                    return result;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene los datos del cliente 
        /// </summary>
        /// <param name="shClienteID"></param>
        /// <returns></returns>
        public DatosGralesResponse getDatosCliente(short shClienteID)
        {
            try
            {
                DatosGralesResponse response = new DatosGralesResponse();
                using (ClientesDataContext dc = new ClientesDataContext(Helper.ConnectionString()))
                {
                    List<DomicilioResponse> lstDom = new List<DomicilioResponse>();

                    var lnqCliente = from a in dc.tbl_MST_Cliente
                                     where a.sintClienteID == shClienteID
                                     select
                                         new DatosGralesResponse
                                         {

                                             sinClienteID = a.sintClienteID,
                                             sintActividadID = a.sintActividadID,
                                             sintNacionalidadID = a.sintNacionalidadID,
                                             sintTipoPersonaID = a.sintTipoPersonaID,
                                             vchApMaterno = a.vchApMaterno,
                                             vchApPaterno = a.vchApPaterno,
                                             vchCURP = a.vchCURP,
                                             vchNoCliente = a.vchNoCliente,
                                             vchNombre = a.vchNombre,
                                             vchRazonSocial = a.vchRazonSocial,
                                             vchRFC = a.vchRFC,
                                             vchTelefono = a.vchTelefono,
                                             dtFechaNac = a.dtFechaNac.Value,
                                             lstDomicilio = a.tbl_MST_Domicilio.Select(item => new DomicilioResponse()
                                                                                        {
                                                                                            shEstado = item.sintEstadoID,
                                                                                            shLocalidad = item.sintLocalidadID,
                                                                                            strCalle = item.vchCalle,
                                                                                            strCP = item.vchCP,
                                                                                            strNoExterior = item.vchNumExt,
                                                                                            strNoInterior = item.vchNumInt

                                                                                        }).ToList(),
                                         };

                    response = lnqCliente.First();


                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ServiceResult setCalificaCliente(short shClienteID, string strUsuario)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (ClientesDataContext dc = new ClientesDataContext(Helper.ConnectionString()))
                {
                    short? shRespuesta = 0;
                    string strRerspuesta = string.Empty;

                    dc.stp_CalificaCliente(shClienteID, strUsuario, ref shRespuesta, ref strRerspuesta);

                    result.ErrorMessage = strRerspuesta;
                    result.ServiceOk = shRespuesta == 0 ? true : false;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public CalificacionResponse getCalificacionCliente(short shClienteID)
        {
            CalificacionResponse result = new CalificacionResponse();
            try
            {
                using (ClientesDataContext dc = new ClientesDataContext(Helper.ConnectionString()))
                {
                    var lnqCalificacion = from a in dc.tbl_MST_Calificacion
                                          where a.sintClienteID == shClienteID
                                          select new CalificacionResponse
                                          {
                                              sintCalificacionID = a.sintCalificacionID,
                                              dttFechaCalif = a.datFechaCalificacion,
                                              sintClienteID = a.sintClienteID,
                                              sintPuntaje = a.sintPuntaje,
                                              sintRiesgoClienteID = a.sintRiesgoClienteID,
                                              sintTipoCalificacionID = a.sintTipoCalificacionID,
                                              strRiesgoCliente = a.tbl_CAT_RiesgoCliente.vchDescripcion,
                                              strTipoCalificacion = a.tbl_CAT_TipoCalificacion.vchDescripcion,
                                              vchUsuario = a.vchUsuario,

                                              listaFactores = a.tbl_DET_Calificacion.Select(item => new DetCalificacion()
                                              {
                                                  sintFactoresID = item.sintFactoresID,
                                                  sintPuntosFactor = item.sintPuntosFactor,
                                                  strDescripcionFactor = item.tbl_CAT_FactoresCalificacion.vchNombre

                                              }).ToList(),
                                          };
                    result = lnqCalificacion.OrderByDescending(a => a.sintCalificacionID).First();
                }
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CalificacionResponse> getCalificacionClienteHistorico(short shClienteID)
        {
            List<CalificacionResponse> result = new List<CalificacionResponse>();
            try
            {
                using (ClientesDataContext dc = new ClientesDataContext(Helper.ConnectionString()))
                {
                    var lnqCalificacion = from a in dc.tbl_MST_Calificacion
                                          where a.sintClienteID == shClienteID
                                          select new CalificacionResponse
                                          {
                                              sintCalificacionID = a.sintCalificacionID,
                                              dttFechaCalif = a.datFechaCalificacion,
                                              sintClienteID = a.sintClienteID,
                                              sintPuntaje = a.sintPuntaje,
                                              sintRiesgoClienteID = a.sintRiesgoClienteID,
                                              sintTipoCalificacionID = a.sintTipoCalificacionID,
                                              strRiesgoCliente = a.tbl_CAT_RiesgoCliente.vchDescripcion,
                                              strTipoCalificacion = a.tbl_CAT_TipoCalificacion.vchDescripcion,
                                              vchUsuario = a.vchUsuario,

                                              listaFactores = a.tbl_DET_Calificacion.Select(item => new DetCalificacion()
                                              {
                                                  sintFactoresID = item.sintFactoresID,
                                                  sintPuntosFactor = item.sintPuntosFactor,
                                                  strDescripcionFactor = item.tbl_CAT_FactoresCalificacion.vchNombre

                                              }).ToList(),
                                          };
                    result = lnqCalificacion.OrderByDescending(a => a.sintCalificacionID).ToList();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
