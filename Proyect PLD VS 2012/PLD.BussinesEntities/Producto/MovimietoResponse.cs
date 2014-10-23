using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PLD.BusinessEntities.Producto
{
    [DataContract]
    public class MovimietoResponse
    {
        public MovimietoResponse()
        {
            intMovimientoID = 0;
            intProductoID = 0;
            strNoCuenta = string.Empty;
            sintTipoOperacionID = 0;
            strTipoOperacion = string.Empty;
            vchReferencia = string.Empty;
            sintMonedaID = 0;
            strMoneda = string.Empty;
            decMonto = 0m;
            dtFechaOperacion = null;
            strNombreCliente = string.Empty;
        }
        [DataMember]
        public int intMovimientoID { get; set; }
        [DataMember]
        public int? intProductoID { get; set; }
        [DataMember]
        public string strNoCuenta { get; set; }
        [DataMember]
        public short? sintTipoOperacionID { get; set; }
        [DataMember]
        public string strTipoOperacion { get; set; }
        [DataMember]
        public string vchReferencia { get; set; }
        [DataMember]
        public short? sintMonedaID { get; set; }
        [DataMember]
        public string strMoneda { get; set; }
        [DataMember]
        public decimal? decMonto { get; set; }
        [DataMember]
        public DateTime? dtFechaOperacion { get; set; }
        [DataMember]
        public string strNombreCliente { get; set; }
        

    }
}
