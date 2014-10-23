using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PLD.BusinessEntities.Producto
{
    [DataContract]
    public class InusualSeguimientoResponse
    {
        public InusualSeguimientoResponse()
        {
            intInusualID = 0;
            strTipoInusual = string.Empty;
            strNombre = string.Empty;
            sintTipoInusual = 0;
            decMontoPesos = 0m;
            decMontoDolar = 0m;
            datFechaDeteccion = null;
            sintRelSeguimientoOperacionID = 0;
            sintEstatusSeguimientoID = 0;
            strEstatusDescripcion = string.Empty;
        }
        [DataMember]
        public int intInusualID { get; set; }
        [DataMember]
        public string strTipoInusual { get; set; }
        [DataMember]
        public string strNombre { get; set; }
        [DataMember]
        public short? sintTipoInusual { get; set; }
        [DataMember]
        public decimal? decMontoPesos { get; set; }
        [DataMember]
        public decimal? decMontoDolar { get; set; }
        [DataMember]
        public DateTime? datFechaDeteccion { get; set; }
        [DataMember]
        public short? sintRelSeguimientoOperacionID { get; set; }
        [DataMember]
        public short? sintEstatusSeguimientoID { get; set; }
        [DataMember]
        public string strEstatusDescripcion { get; set; }
    }
}
