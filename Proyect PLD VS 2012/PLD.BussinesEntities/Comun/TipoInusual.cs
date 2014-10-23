using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PLD.BusinessEntities.Comun
{

    [DataContract]
    public class TipoInusual
    {

        public TipoInusual()
        {
            shTipoInusualID = 0;
            shTipoTipoReporte = 0;
            strNombre = string.Empty;
            strDescripcion = string.Empty;
            lstDetTipoInusual = new List<DetTipoInusual>();

        }
        [DataMember]
        public short shTipoInusualID { get; set; }
        [DataMember]
        public short? shTipoTipoReporte { get; set; }
        [DataMember]
        public string strNombre { get; set; }
        [DataMember]
        public string strDescripcion { get; set; }
        [DataMember]
        public List<DetTipoInusual> lstDetTipoInusual { get; set; }

    }

    [DataContract]
    public class DetTipoInusual
    {
        public DetTipoInusual()
        {
            sintDetTipoInusualID = 0;
            sintTipoInusualID = 0;
            sintTipoProductoID = 0;
            sintConfigInusualID = 0;
            entConfigInusual = new ConfigInusual();
        }
        [DataMember]
        public short sintDetTipoInusualID { get; set; }
        [DataMember]
        public short? sintTipoInusualID { get; set; }
        [DataMember]
        public short? sintTipoProductoID { get; set; }
        [DataMember]
        public short? sintConfigInusualID { get; set; }
        [DataMember]
        public ConfigInusual entConfigInusual { get; set; }
    }

    [DataContract]
    public class ConfigInusual
    {
        public ConfigInusual()
        {
            sintConfigInusualID = 0;
            blSaldoMensual = false;
            shPorcSaldoMens = 0;
            decMontoMayor = 0;
            blMontos = false;
            blAgrupacion = false;
            shDiasAgrupacion = 0;
            decMontoAgrupacion = 0;
        }
        [DataMember]
        public short sintConfigInusualID { get; set; }
        [DataMember]
        public bool? blSaldoMensual { get; set; }
        [DataMember]
        public short? shPorcSaldoMens { get; set; }
        [DataMember]
        public bool? blMontos { get; set; }
        [DataMember]
        public decimal? decMontoMayor { get; set; }
        [DataMember]
        public bool? blAgrupacion { get; set; }
        [DataMember]
        public short? shDiasAgrupacion { get; set; }
        [DataMember]
        public decimal? decMontoAgrupacion { get; set; }
    }
}
