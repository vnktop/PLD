using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PLD.BusinessEntities.Producto
{
    [DataContract]
    public class ProductoResponse
    {
        public ProductoResponse()
        {
            intProductoID = 0;
            sintClienteID = 0;
            vchCliente = string.Empty;
            sintTipoProductoID = 0;
            vchTipoProducto = string.Empty;
            sintMonedaID = 0;
            vchMoneda = string.Empty;
            vhcNoCuenta = string.Empty;
            sdatFechaAlta = null;
            sdatFechaFin = null;
            vchCodSucursal = string.Empty;
            vchCodOperador = string.Empty;
            vchCodOperadorAutiliza = string.Empty;
            decMontoInicial = 0m;
            decSaldoMensual = 0m;
        }

        [DataMember]
        public int intProductoID { get; set; }
        [DataMember]
        public short? sintClienteID { get; set; }
        [DataMember]
        public string vchCliente { get; set; }
        [DataMember]
        public short? sintTipoProductoID { get; set; }
        [DataMember]
        public string vchTipoProducto { get; set; }
        [DataMember]
        public short? sintMonedaID { get; set; }
        [DataMember]
        public string vchMoneda { get; set; }
        [DataMember]
        public string vhcNoCuenta { get; set; }
        [DataMember]
        public DateTime? sdatFechaAlta { get; set; }
        [DataMember]
        public DateTime? sdatFechaFin { get; set; }
        [DataMember]
        public string vchCodSucursal { get; set; }
        [DataMember]
        public string vchCodOperador { get; set; }
        [DataMember]
        public string vchCodOperadorAutiliza { get; set; }
        [DataMember]
        public decimal? decMontoInicial { get; set; }
        [DataMember]
        public decimal? decSaldoMensual { get; set; }

    }
}
