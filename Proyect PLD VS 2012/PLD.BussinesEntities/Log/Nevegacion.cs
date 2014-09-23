using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PLD.BusinessEntities.Log
{
    [DataContract]
    public class Nevegacion
    {

        public Nevegacion()
        {
            strModulo = string.Empty;
            strAccion = null;
            strUsuario = string.Empty;
            dttFecha = DateTime.Now;
        }

        [DataMember]
        public string strModulo { get; set; }

        [DataMember]
        public string strAccion { get; set; }

        [DataMember]
        public string strUsuario { get; set; }

        [DataMember]
        public DateTime dttFecha { get; set; }

    }
}
