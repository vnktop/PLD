
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PLD.BusinessEntities.Cliente
{
    [DataContract]
    public class ClienteResponse
    {
        public ClienteResponse()
        {
            shClienteID = 0;
            strNoCliente = string.Empty;
            strRFC = string.Empty;
            strNombre = string.Empty;
            shCalificacion = 0;
            shRiesgo = 0;
        }

        [DataMember]
        public short shClienteID { get; set; }
        [DataMember]
        public string strNoCliente { get; set; }
        [DataMember]
        public string strRFC { get; set; }
        [DataMember]
        public string strNombre { get; set; }
        [DataMember]
        public short shCalificacion { get; set; }
        [DataMember]
        public short shRiesgo { get; set; }
    }
}
