using Gestione.Core.BusinessLayer;
using Gestione.Core.Entities;
using Gestione.Core.Repository;
using Gestione.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Gestione.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class GestioneService : IGestioneService
    {
        IGestioneBL layer;
        public GestioneService()
        {
            var bookRepo = new EFClienteRepository();
            var loanRepo = new EFOrdineRepository();

            layer = new MainBusinessLayer(bookRepo, loanRepo);
        }
        
        //Implementazione dei servizi visibili dal WCF
        public bool AddNewClient(Cliente newClient)
        {
            try
            {
                return layer.RegisterClient(newClient);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteClientById(int id)
        {
            try
            {
                //Riuso direttamente il metodo implementato qui così da non
                //Richiamare una volta in più il layer, ma avrei potuto anche richiamare il 
                //metodo var cliente= layer.etchClientById

                var cliente = GetClientById(id);
                return layer.DeleteClient(cliente);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditClient(Cliente clientToEdit)
        {
            try
            {
                return layer.UpdateClient(clientToEdit);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Cliente GetClientById(int id)
        {
            try
            {
                return layer.FetchClientById(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Cliente> GetClients()
        {
            try
            {
                return layer.FetchClients().ToList();
            }
            catch (Exception)
            {
                return new List<Cliente>();
            }
        }
    }
}
