using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PLD.DataAccess;
using PLD.BusinessEntities;
using PLD.BusinessEntities.Producto;

namespace PLD.Logic.Producto
{
    public class Producto
    {

        #region Constructor DA
        private ProductoDA Producto_DA;

        public Producto()
        {
            Producto_DA = new ProductoDA();
        }

        #endregion

        public List<ProductoResponse> getProductosCliente(short sintClienteID)
        {
            List<ProductoResponse> result;
            try
            {
                result = Producto_DA.getProductosCliente(sintClienteID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }


        public List<MovimietoResponse> getMvtosProducto(short sintProductoID)
        {
            List<MovimietoResponse> result;
            try
            {
                result = Producto_DA.getMvtosProducto(sintProductoID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public List<InusualResponse> getInusuales(ConsultaRequest request)
        {
            List<InusualResponse> result;
            try
            {
                result = Producto_DA.getInusuales(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<MovimietoResponse> getDetalleInusual(int intInusualID)
        {

            List<MovimietoResponse> result;
            try
            {
                result = Producto_DA.getDetalleInusual(intInusualID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public ServiceResult setInusualSeguimiento(string strInusualesIDs, string strUsuario)
        {
            ServiceResult result;
            try
            {
                result = Producto_DA.setInusualSeguimiento(strInusualesIDs, strUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<InusualSeguimientoResponse> getInusualSeguimiento(ConsultaRequest request)
        {

            List<InusualSeguimientoResponse> result;
            try
            {
                result = Producto_DA.getInusualSeguimiento(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }


        public ServiceResult setDetalleSeguimiento(DetalleSeguimientoRequest request)
        {
            ServiceResult result;
            try
            {
                result = Producto_DA.setDetalleSeguimiento(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public DetSeguimientoResponse getDetalleSeguimiento(short sintRelSeguimientoOperacionID, short sintEstatusSeguimientoID)
        {
            DetSeguimientoResponse result;
            try
            {
                result = Producto_DA.getDetalleSeguimiento(sintRelSeguimientoOperacionID, sintEstatusSeguimientoID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<ReporteResponse> getReportes(ConsultaRequest request)
        {
            List<ReporteResponse> result;
            try
            {
                result = Producto_DA.getReportes(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public ServiceResult setAgrupaReporte()
        {
            ServiceResult result;
            try
            {
                result = Producto_DA.setAgrupaReporte();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public ServiceResult setGeneraReporte(short shReporteID)
        {
            ServiceResult result;
            try
            {
                result = Producto_DA.setGeneraReporte(shReporteID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<MovimietoResponse> getMovimientosReporte(short shReporteID)
        {
            List<MovimietoResponse> result;
            try
            {
                result = Producto_DA.getMovimientosReporte(shReporteID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

    }
}

