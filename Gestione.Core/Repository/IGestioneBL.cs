using Gestione.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestione.Core.Repository
{
    public interface IGestioneBL
    {
        //Specifico le operazioni di CRUD a cui ha accesso il BL
        #region Cliente
        List<Cliente> FetchClients();
        Cliente FetchClientById(int id);
        bool RegisterClient(Cliente newClient);
        bool UpdateClient(Cliente clientToEdit);
        bool DeleteClient(Cliente clientToBeDeleted);

        #endregion

        #region Ordine
        List<Ordine> FetchOrders();
        Ordine FetchOrderById(int id);
        bool RegisterOrder(Ordine newOrder);
        bool UpdateOrder(Ordine orderToEdit);
        bool DeleteOrder(Ordine orderToBeDeleted);

        #endregion

    }
}
