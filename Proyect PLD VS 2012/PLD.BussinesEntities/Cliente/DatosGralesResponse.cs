using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PLD.BusinessEntities.Cliente
{
    [DataContract]
    public class DatosGralesResponse
    {
        public DatosGralesResponse()
        {
            sinClienteID = 0;
            sintNacionalidadID = 0;
            sintTipoPersonaID = 0;
            sintActividadID = 0;
            vchNoCliente = string.Empty;
            vchNombre = string.Empty;
            vchApPaterno = string.Empty;
            vchApMaterno = string.Empty;
            vchRazonSocial = string.Empty;
            vchRFC = string.Empty;
            vchCURP = string.Empty;
            vchTelefono = string.Empty;
            dtFechaNac = null;
        }
        [DataMember]
        public short sinClienteID{ get; set; }
        [DataMember]
        public short? sintNacionalidadID { get; set; }
        [DataMember]
        public short? sintTipoPersonaID { get; set; }
        [DataMember]
        public short? sintActividadID { get; set; }
        [DataMember]
        public string vchNoCliente { get; set; }
        [DataMember]
        public string vchNombre { get; set; }
        [DataMember]
        public string vchApPaterno { get; set; }
        [DataMember]
        public string vchApMaterno { get; set; }
        [DataMember]
        public string vchRazonSocial { get; set; }
        [DataMember]
        public string vchRFC { get; set; }
        [DataMember]
        public string vchCURP { get; set; }
        [DataMember]
        public DateTime? dtFechaNac { get; set; }
        [DataMember]
        public string vchTelefono { get; set; }
        [DataMember]
        public List<DomicilioResponse> lstDomicilio { get; set; }
    }
}
