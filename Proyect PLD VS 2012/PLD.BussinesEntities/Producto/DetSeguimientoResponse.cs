using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PLD.BusinessEntities.Producto
{
    [DataContract]
    public class DetSeguimientoResponse
    {
        public DetSeguimientoResponse()
        {

        }
        [DataMember]
        public short sintDetSeguimientoID { get; set; }
        [DataMember]
        public System.Nullable<short> sintRelSeguimientoOperacionlID { get; set; }
        [DataMember]
        public System.Nullable<short> sintEstatusSeguimientoID { get; set; }
        [DataMember]
        public string vchObservaciones { get; set; }
        [DataMember]
        public string vchDescripcion { get; set; }
        [DataMember]
        public System.Nullable<System.DateTime> sdatFecha { get; set; }

    }
}
