using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PLD.BusinessEntities.Comun
{
    [DataContract]
    public class CatalogoResponse
    {
        public CatalogoResponse()
        {
        }
        [DataMember]
        public string strID { get; set; }
        [DataMember]
        public string strDescripcion { get; set; }

    }
}
