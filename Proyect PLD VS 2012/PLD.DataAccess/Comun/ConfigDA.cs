using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PLD.BusinessEntities;
using PLD.BusinessEntities.Comun;
using PLD.DataAccess.Context;

namespace PLD.DataAccess.Comun
{
    public class ConfigDA
    {
        public List<TipoInusual> getConfigInusual()
        {
            List<TipoInusual> result = new List<TipoInusual>();
            try
            {
                using (ClientesDataContext dc = new ClientesDataContext(Helper.ConnectionString()))
                {
                    var lnqConfig = from a in dc.tbl_CAT_TipoInusual
                                    select new TipoInusual
                                    {
                                        lstDetTipoInusual = a.tbl_DET_TipoInisual.Select(item => new DetTipoInusual()
                                        {
                                            sintDetTipoInusualID = item.sintDetTipoInusualID,
                                            sintConfigInusualID = item.sintConfigInusualID,
                                            sintTipoInusualID = item.sintTipoInusual,
                                            sintTipoProductoID = item.sintTipoProductoID,
                                            entConfigInusual = new ConfigInusual()
                                            {
                                                sintConfigInusualID = item.tbl_CAT_ConfigInusual.sintConfigInusualID,
                                                blAgrupacion = item.tbl_CAT_ConfigInusual.bitAgrupacion,
                                                blSaldoMensual = item.tbl_CAT_ConfigInusual.bitSaldoMensual,
                                                blMontos = item.tbl_CAT_ConfigInusual.bitMontos,
                                                decMontoAgrupacion = item.tbl_CAT_ConfigInusual.decMontoAgrupacion,
                                                decMontoMayor = item.tbl_CAT_ConfigInusual.decMontoMayor,
                                                shDiasAgrupacion = item.tbl_CAT_ConfigInusual.sintDiasAgrupacion,
                                                shPorcSaldoMens = item.tbl_CAT_ConfigInusual.intPorcentajeSaldo,
                                            }
                                        }).ToList(),

                                        shTipoInusualID = a.sintTipoInusual,
                                        shTipoTipoReporte = a.sintTipoReporteID,
                                        strDescripcion = a.vchDescripcion,
                                        strNombre = a.vchNombre
                                    };
                    result.AddRange(lnqConfig);
                }
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
                using (ClientesDataContext dc = new ClientesDataContext(Helper.ConnectionString()))
                {
                    tbl_CAT_ConfigInusual tbl = new tbl_CAT_ConfigInusual()
                    {
                        sintConfigInusualID = item.sintConfigInusualID,
                        bitMontos = item.blMontos,
                        bitSaldoMensual = item.blSaldoMensual,
                        decMontoMayor = item.decMontoMayor,
                        sintDiasAgrupacion = item.shDiasAgrupacion,

                    };

                    dc.tbl_CAT_ConfigInusual.InsertOnSubmit(tbl);
                    dc.SubmitChanges();
                }

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
                using (ClientesDataContext dc = new ClientesDataContext(Helper.ConnectionString()))
                {
                    tbl_DET_TipoInisual tbl = new tbl_DET_TipoInisual()
                    {
                        sintDetTipoInusualID = item.sintDetTipoInusualID,
                        sintConfigInusualID = item.sintConfigInusualID,
                        sintTipoInusual = item.sintTipoInusualID,
                        sintTipoProductoID = item.sintTipoProductoID
                    };
                    dc.tbl_DET_TipoInisual.InsertOnSubmit(tbl);
                    dc.SubmitChanges();
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
