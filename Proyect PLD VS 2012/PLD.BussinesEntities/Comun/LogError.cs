using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PLD.BusinessEntities.Comun
{
    [DataContract]
    public class LogError
    {


        public LogError()
        {
            vchMensaje = string.Empty;
            vchHostName = null;
            vchIP = string.Empty;
            vchStakeTrace = string.Empty;
            vchParametros = string.Empty;
            datFechaError = DateTime.Now;
            vchUsuario = string.Empty;
        }

        [DataMember]
        public string vchMensaje { get; set; }
        [DataMember]
        public string vchHostName { get; set; }
        [DataMember]
        public string vchIP { get; set; }
        [DataMember]
        public string vchStakeTrace { get; set; }
        [DataMember]
        public string vchParametros { get; set; }
        [DataMember]
        public DateTime datFechaError { get; set; }
        [DataMember]
        public string vchUsuario { get; set; }

    }
}
