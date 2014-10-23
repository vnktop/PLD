using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PLD.BusinessEntities.Catalogo
{
    [DataContract]
    public class CatalogoRequest
    {
        public CatalogoRequest()
        {
            vchCodigo = string.Empty;
            vchClave = string.Empty;
            vchClaveRel = string.Empty;
            vchDescripcion = string.Empty;
            shPuntaje = 0;
        }

        [DataMember]
        public string vchCodigo { get; set; }
        [DataMember]
        public string vchClave { get; set; }
        [DataMember]
        public string vchClaveRel { get; set; }
        [DataMember]
        public string vchDescripcion { get; set; }
        [DataMember]
        public short shPuntaje { get; set; }
    }
}
