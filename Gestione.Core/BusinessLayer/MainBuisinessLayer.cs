using Gestione.Core.Entities;
using Gestione.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestione.Core.BusinessLayer
{
    public class MainBusinessLayer : IGestioneBL
    {
        //Dichiaro i Repository singolarmente
        private IClienteRepository clientRepo;
        private IOrdineRepository orderRepo;

        //Costruttore della classe
        public MainBusinessLayer(IClienteRepository clientRepo, IOrdineRepository orderRepo)
        {
            this.clientRepo = clientRepo;
            this.orderRepo = orderRepo;
        }


        //Implemento l'interfaccia con i metodi dichiarati. Fino a qui il Core è indipendente dall'implementazione
        //di un qualsiasi DAL

        #region CRUD del CLIENTE
        //CREATE
        public bool RegisterClient(Cliente newClient)
        {
            return clientRepo.Add(newClient);
        }
        //READ
        public Cliente FetchClientById(int id)
        {
            return clientRepo.GetById(id);
        }

        public List<Cliente> FetchClients()
        {
            return clientRepo.Fetch();
        }

        //UPDATE
        public bool UpdateClient(Cliente clientToEdit)
        {
            return clientRepo.Update(clientToEdit);
        }


        //DELETE
        public bool DeleteClient(Cliente clientToBeDeleted)
        {
            return clientRepo.Delete(clientToBeDeleted);
        }

        #endregion

        #region CRUD dell'Ordine 
        //READ
        public Ordine FetchOrderById(int id)
        {
            return orderRepo.GetById(id);
        }

        public List<Ordine> FetchOrders()
        {
            return orderRepo.Fetch();
        }

        //CREATE
        public bool RegisterOrder(Ordine newOrder)
        {
            return orderRepo.Add(newOrder);
        }

        //UPDATE
        public bool UpdateOrder(Ordine orderToEdit)
        {
            return orderRepo.Update(orderToEdit);
        }

        //DELETE
        public bool DeleteOrder(Ordine orderToBeDeleted)
        {
            return orderRepo.Delete(orderToBeDeleted);
        }

        #endregion
    }
}
