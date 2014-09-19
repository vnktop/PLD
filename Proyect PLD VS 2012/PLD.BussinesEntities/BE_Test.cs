using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PLD.BussinesEntities
{
    [DataContract]
    public class BE_Test
    {
        //Se agreaga script en dbMaster, Soprte/dbTest.sql, para integraación de capas como modelo
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }
}
