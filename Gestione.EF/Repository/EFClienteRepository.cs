using Gestione.Core.Entities;
using Gestione.Core.Repository;
using Gestione.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestione.EF.Repository
{
    public class EFClienteRepository : IClienteRepository
    {
        //Prima di tutto richiamo il mio Context di Gestione
        private GestioneContext ctx;

        //Aggiungo i costruttori 
        public EFClienteRepository() : this(new GestioneContext())
        {
                
        }

        public EFClienteRepository(GestioneContext ctx)
        {
            this.ctx= ctx;
        }



        public bool Add(Cliente newClient)
        {
            try
            {
                ctx.Clienti.Add(newClient);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Cliente clientToBeErased)
        {
            try
            {
                var cliente = ctx.Clienti.Find(clientToBeErased.Id);

                if (cliente != null)
                    ctx.Clienti.Remove(cliente);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Cliente> Fetch()
        {
            try
            {
                return ctx.Clienti.ToList();
            }
            catch (Exception)
            {
                return new List<Cliente>();
            }
        }

        public Cliente GetById(int id)
        {
            try
            {
                var cliente = ctx.Clienti.Include(c => c.listaOrdini)
                    .FirstOrDefault(c => c.Id == id);

                return cliente;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(Cliente clientToEdit)
        {
            try
            {
                ctx.Clienti.Update(clientToEdit);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
