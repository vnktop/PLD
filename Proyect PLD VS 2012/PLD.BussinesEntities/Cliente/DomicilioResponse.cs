using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PLD.BusinessEntities.Cliente
{
    [DataContract]
    public class DomicilioResponse
    {
        public DomicilioResponse()
        {
            shEstado = 0;
            shLocalidad = 0;
            strCalle = string.Empty;
            strNoExterior = string.Empty;
            strNoInterior = string.Empty;
            strCP = string.Empty;

        }
        [DataMember]
        public short? shEstado { get; set; }
        [DataMember]
        public short? shLocalidad { get; set; }
        [DataMember]
        public string strCalle { get; set; }
        [DataMember]
        public string strNoExterior { get; set; }
        [DataMember]
        public string strNoInterior { get; set; }
        [DataMember]
        public string strCP { get; set; }

    }
}
