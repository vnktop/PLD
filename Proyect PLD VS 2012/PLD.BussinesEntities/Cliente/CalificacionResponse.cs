using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PLD.BusinessEntities.Cliente
{
    [DataContract]
    public class CalificacionResponse
    {
        public CalificacionResponse()
        {
            sintCalificacionID = 0;
            sintClienteID = 0;
            sintRiesgoClienteID = 0;
            strRiesgoCliente = string.Empty;
            sintPuntaje = 0;
            sintTipoCalificacionID = 0;
            strTipoCalificacion = String.Empty;
            vchUsuario = String.Empty;
            dttFechaCalif = DateTime.MinValue;
        }


        [DataMember]
        public short sintCalificacionID { get; set; }
        [DataMember]
        public short? sintClienteID { get; set; }
        [DataMember]
        public short? sintRiesgoClienteID { get; set; }
        [DataMember]
        public string strRiesgoCliente { get; set; }
        [DataMember]
        public short? sintPuntaje { get; set; }
        [DataMember]
        public short? sintTipoCalificacionID { get; set; }
        [DataMember]
        public string strTipoCalificacion { get; set; }
        [DataMember]
        public DateTime? dttFechaCalif { get; set; }
        [DataMember]
        public string vchUsuario { get; set; }
        [DataMember]
        public List<DetCalificacion> listaFactores { get; set; }
    }

    [DataContract]
    public class DetCalificacion
    {
        public DetCalificacion()
        {
            sintFactoresID = 0;
            strDescripcionFactor = string.Empty;
            sintPuntosFactor = 0;
        }
        [DataMember]
        public short? sintFactoresID { get; set; }
        [DataMember]
        public string strDescripcionFactor { get; set; }
        [DataMember]
        public short? sintPuntosFactor { get; set; }
    }
}

