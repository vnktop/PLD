using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PLD.BusinessEntities.Producto
{
    [DataContract] 
    public class InusualesRequest
    {
        public InusualesRequest()
        {
            shClienteID = 0;
            dttFechaInicio = null;
            dttFechaFin = null;
        }
        [DataMember]
        public short shClienteID { get; set; }
        [DataMember]
        public DateTime? dttFechaInicio { get; set; }
        [DataMember]
        public DateTime? dttFechaFin { get; set; }

    }
}
