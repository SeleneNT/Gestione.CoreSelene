using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Gestione.Core.Entities
{
    [DataContract]
    public class Cliente
    {
        [DataMember]
        public int Id { get;set; }
        [DataMember]
        public string CodiceCliente { get;set; }
        [DataMember]
        public string Nome { get;set; }
        [DataMember]
        public string Cognome { get;set; }
      
        //Ad ogni cliente è associata una lista di ordini
        public List<Ordine> listaOrdini { get; set;} 
    }
}
