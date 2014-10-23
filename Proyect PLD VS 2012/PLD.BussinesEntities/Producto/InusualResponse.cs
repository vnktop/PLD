using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PLD.BusinessEntities.Producto
{
    [DataContract]
    public class InusualResponse
    {

        public InusualResponse()
        {
            intInusualID = 0;
            sintTipoInusual = 0;
            strTipoInusual = string.Empty;
            decMontoPesos = 0;
            decMontoDolar = 0;
            datFechaDeteccion = null;
            lstMovimientos = new List<MovimietoResponse>();
            strNombreCliente = string.Empty;
        }
        [DataMember]
        public int intInusualID { get; set; }
        [DataMember]
        public short? sintTipoInusual { get; set; }
        [DataMember]
        public string strTipoInusual { get; set; }
        [DataMember]
        public decimal? decMontoPesos { get; set; }
        [DataMember]
        public decimal? decMontoDolar { get; set; }
        [DataMember]
        public DateTime? datFechaDeteccion { get; set; }
        [DataMember]
        public string strNombreCliente { get; set; }
        [DataMember]
        public List<MovimietoResponse> lstMovimientos { get; set; }
    }


}
