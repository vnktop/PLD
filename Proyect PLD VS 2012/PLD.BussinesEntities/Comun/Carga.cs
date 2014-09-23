using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PLD.BussinesEntities.Comun
{
    [DataContract]
    public class Carga
    {
        public Carga()
        {
            intLogID = 0;
            vchDescripcion = string.Empty;
            vchParametros = string.Empty;
            sintNoError = 0;
            sintNoExito = 0;
            vchXMLError = string.Empty;
            vchUsuario = string.Empty;
            sdatFecha = DateTime.Now;
        }

        [DataMember]
        public int intLogID { get; set; }
        [DataMember]
        public short? sintNoError { get; set; }
        [DataMember]
        public string vchDescripcion { get; set; }
        [DataMember]
        public string vchParametros { get; set; }
        [DataMember]
        public short? sintNoExito { get; set; }
        [DataMember]
        public string vchXMLError { get; set; }
        [DataMember]
        public string vchUsuario { get; set; }
        [DataMember]
        public DateTime? sdatFecha { get; set; }
    }
}
