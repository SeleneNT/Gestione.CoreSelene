using Gestione.Core.Entities;
using Gestione.Core.Repository;
using Gestione.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestione.EF.Repository
{
    public class EFOrdineRepository : IOrdineRepository
    {
        private GestioneContext ctx;

        //Aggiungo i costruttori 
        public EFOrdineRepository() : this(new GestioneContext())
        {

        }

        public EFOrdineRepository(GestioneContext ctx)
        {
            this.ctx = ctx;
        }



        public bool Add(Ordine newOrder)
        {
            try
            {
                ctx.Ordini.Add(newOrder);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Ordine orderToDelete)
        {
            try
            {
                //Prima lo devo trovare e poi lo cancello
                var ordine= ctx.Ordini.Find(orderToDelete.Id);

                if (ordine != null)
                    ctx.Ordini.Remove(ordine);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Ordine> Fetch()
        {
            try
            {
                return ctx.Ordini.ToList();
            }
            catch (Exception)
            {
                return new List<Ordine>();
            }
        }

        public Ordine GetById(int id)
        {
            try
            {
                var ordine = ctx.Ordini.Find(id);

                return ordine;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(Ordine orderToBeEdited)
        {
            try
            {
                ctx.Ordini.Update(orderToBeEdited);
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
