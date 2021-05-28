using Gestione.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Gestione.Wcf
{
    [ServiceContract]
    public interface IGestioneService
    {
        //WCF per la gestione anagrafica clienti
        [OperationContract]
        List<Cliente> GetClients();

        [OperationContract]
        Cliente GetClientById(int id);

        [OperationContract]
        bool AddNewClient(Cliente newClient);

        [OperationContract]
        bool EditClient(Cliente clientToEdit);

        [OperationContract]
        bool DeleteClientById(int id);

      
    }
}
