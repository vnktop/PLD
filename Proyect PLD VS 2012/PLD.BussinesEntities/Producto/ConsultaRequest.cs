using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PLD.BusinessEntities.Producto
{
    [DataContract]
    public class ConsultaRequest
    {
        public ConsultaRequest()
        {
            shClienteID = 0;
            dttFechaInicio = null;
            dttFechaFin = null;
            strUsuario = string.Empty;
        }
        [DataMember]
        public short shClienteID { get; set; }
        [DataMember]
        public DateTime? dttFechaInicio { get; set; }
        [DataMember]
        public DateTime? dttFechaFin { get; set; }
        [DataMember]
        public string strUsuario { get; set; }

    }
}
