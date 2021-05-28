using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Gestione.Core.Entities
{
    [DataContract]
    public class Ordine
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime DataOrdine { get; set; }
        [DataMember]
        public string CodiceOrdine { get; set; }
        [DataMember]
        public string CodiceProdotto { get; set; }
        [DataMember]
        public decimal Importo { get; set; }
        [DataMember]
        public Cliente Cliente { get; set; }

        //Per ogni prodotto ho una lista di clienti
        List<Cliente> listaClienti { get; set; }

    }
}
