using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PLD.BusinessEntities.Producto
{
    [DataContract]
    public class ReporteResponse
    {
        public ReporteResponse()
        {
            sintReporteID = 0;
            sintTipoReporteID = 0;
            strTipoReporte = string.Empty;
            sdatFechaReporte = null;
            byReporte = null;
            bitReportado = null;
            detReporte = new DetReporte();
        }
        [DataMember]
        public short sintReporteID { get; set; }
        [DataMember]
        public short? sintTipoReporteID { get; set; }
        [DataMember]
        public string strTipoReporte { get; set; }
        [DataMember]
        public DateTime? sdatFechaReporte { get; set; }
        [DataMember]
        public  byte[] byReporte { get; set; }
        [DataMember]
        public Nullable<byte> bitReportado { get; set; }
        [DataMember]
        public DetReporte detReporte { get; set; }
    }

    [DataContract]
    public class DetReporte
    {
        public DetReporte()
        {
            sintReporteID = 0;
            sintRelSeguimientoOperacionID = 0;
        }
        [DataMember]
        public short? sintReporteID { get; set; }
        [DataMember]
        public short? sintRelSeguimientoOperacionID { get; set; }
    }

}
