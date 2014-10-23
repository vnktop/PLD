using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PLD.BusinessEntities;
using PLD.BusinessEntities.Cliente;
using PLD.BusinessEntities.Producto;
using PLD.DataAccess.Cliente;

namespace PLD.Logic.Cliente
{
    public class Cliente
    {
        #region Constructor DA
        private ClienteDA Cliente_DA;

        public Cliente()
        {
            Cliente_DA = new ClienteDA();
        }

        #endregion


        public List<ClienteResponse> lstClientes(ClienteRequest request)
        {
            List<ClienteResponse> result;
            try
            {
                result = Cliente_DA.lstClientes(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public DatosGralesResponse getDatosCliente(short shClienteID)
        {
            DatosGralesResponse result;
            try
            {
                result = Cliente_DA.getDatosCliente(shClienteID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public ServiceResult setCalificaCliente(short shClienteID, string strUsuario)
        {
            ServiceResult result;
            try
            {
                result = Cliente_DA.setCalificaCliente(shClienteID, strUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }


        public CalificacionResponse getCalificacionCliente(short shClienteID)
        {
            CalificacionResponse result;
            try
            {
                result = Cliente_DA.getCalificacionCliente(shClienteID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<CalificacionResponse> getCalificacionClienteHistorico(short shClienteID)
        {
            List<CalificacionResponse> result;
            try
            {
                result = Cliente_DA.getCalificacionClienteHistorico(shClienteID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

       
    }



}
