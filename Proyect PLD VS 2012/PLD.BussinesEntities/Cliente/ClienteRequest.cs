using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PLD.BusinessEntities.Cliente
{
    [DataContract]
    public class ClienteRequest
    {
        public ClienteRequest()
        {
            strNoCliente = string.Empty;
            strNombre = string.Empty;
            strRFC = string.Empty;
            strEstado = string.Empty;
            strMunicipio = string.Empty;
            strNoCuenta = string.Empty;
            shRiesgo = 0;
            shSeguimiento = 0;
        }
        [DataMember]
        public string strNoCliente { get; set; }
        [DataMember]
        public string strNombre { get; set; }
        [DataMember]
        public string strRFC { get; set; }
        [DataMember]
        public string strEstado { get; set; }
        [DataMember]
        public string strMunicipio { get; set; }
        [DataMember]
        public string strNoCuenta { get; set; }
        [DataMember]
        public short? shRiesgo { get; set; }
        [DataMember]
        public short? shSeguimiento { get; set; }
    }
}
