using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PLD.BusinessEntities;
using PLD.BusinessEntities.Catalogo;
using PLD.BusinessEntities.Comun;
using PLD.DataAccess.Catalogo;

namespace PLD.Logic.Catalogos
{
    public class Catalogo
    {

        #region Constructor DA
        private CatalogoDA DA_Catalogo;

        public Catalogo()
        {
            DA_Catalogo = new CatalogoDA();
        }
        #endregion


        public ServiceResult setCatalogos(List<CatalogoRequest> request)
        {
            ServiceResult results = new ServiceResult();
            try
            {
                results = DA_Catalogo.setCatalogos(request);
            }
            catch (Exception e)
            {
                throw e;
            }
            return results;
        }

        public List<CatalogoResponse> getEstado()
        {
            List<CatalogoResponse> results = new List<CatalogoResponse>();
            try
            {
                results = DA_Catalogo.getEstado();
            }
            catch (Exception e)
            {
                throw e;
            }
            return results;
        }

        public List<CatalogoResponse> getLocalidad()
        {
            List<CatalogoResponse> results = new List<CatalogoResponse>();
            try
            {
                results = DA_Catalogo.getLocalidad();
            }
            catch (Exception e)
            {
                throw e;
            }
            return results;

        }

        public List<CatalogoResponse> getActividad()
        {
            List<CatalogoResponse> results = new List<CatalogoResponse>();
            try
            {
                results = DA_Catalogo.getActividad();
            }
            catch (Exception e)
            {
                throw e;
            }
            return results;
        }

        public List<CatalogoResponse> getNacionalidad()
        {
            List<CatalogoResponse> results = new List<CatalogoResponse>();
            try
            {
                results = DA_Catalogo.getNacionalidad();
            }
            catch (Exception e)
            {
                throw e;
            }
            return results;
        }

        public List<CatalogoResponse> getTipoPersona()
        {
            List<CatalogoResponse> results = new List<CatalogoResponse>();
            try
            {
                results = DA_Catalogo.getTipoPersona();
            }
            catch (Exception e)
            {
                throw e;
            }
            return results;
        }

        public List<CatalogoResponse> getRiesgo()
        {
            List<CatalogoResponse> results = new List<CatalogoResponse>();
            try
            {
                results = DA_Catalogo.getRiesgo();
            }
            catch (Exception e)
            {
                throw e;
            }
            return results;
        }

        public List<CatalogoResponse> getEstatusSeguimientoOp()
        {
            List<CatalogoResponse> results = new List<CatalogoResponse>();
            try
            {
                results = DA_Catalogo.getEstatusSeguimientoOp();
            }
            catch (Exception e)
            {
                throw e;
            }
            return results;
        }

        public List<CatalogoResponse> getProductos()
        {
            List<CatalogoResponse> results = new List<CatalogoResponse>();
            try
            {
                results = DA_Catalogo.getProductos();
            }
            catch (Exception e)
            {
                throw e;
            }
            return results;
        }

    }
}