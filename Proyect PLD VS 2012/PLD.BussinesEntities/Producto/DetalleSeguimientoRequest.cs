using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PLD.BusinessEntities.Producto
{
    [DataContract]
    public class DetalleSeguimientoRequest
    {
        public DetalleSeguimientoRequest()
        {
            sintSeguimientoID = 0;
            sintDetSeguimientoID = 0;
            sintEstatusSeguimientoID = 0;
            sintRelSeguimientoOperacionID = 0;
            strDescripcion = string.Empty;
            strObservaciones = string.Empty;
            dttFecha = null;
            strUsuario = string.Empty;
        }

        [DataMember]
        public short sintSeguimientoID = 0;
        [DataMember]
        public short sintDetSeguimientoID { get; set; }
        [DataMember]
        public short sintEstatusSeguimientoID { get; set; }
        [DataMember]
        public short sintRelSeguimientoOperacionID { get; set; }
        [DataMember]
        public string strDescripcion { get; set; }
        [DataMember]
        public string strObservaciones { get; set; }
        [DataMember]
        public DateTime? dttFecha { get; set; }
        [DataMember]
        public string strUsuario { get; set; }

    }
}
