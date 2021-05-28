using Gestione.Core.BusinessLayer;
using Gestione.Core.Entities;
using Gestione.Core.Repository;
using Gestione.EF.Context;
using Gestione.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestione.EFClient
{
    public class Helper
    {
        //La UI dei clienti parla con il WCF mentre la UI degli ordini parla
        //con l'API quindi devo rimandare il servizio

        var clientRepo = new EFClienteRepository();
        var orderRepo = new EFOrdineRepository();

        GestioneService layer = new GestioneService(clientRepo, orderRepo);
        OrdineController api = new OrdineController(clientRepo, orderRepo)
       

        #region Cliente

        public void CreaCliente()
        {
            //CodiceCliente-Nome-Cognome
            //Chiedere i dati
            Console.WriteLine("\nInserire Nome");
            string nome = Console.ReadLine();
            Console.WriteLine("\nInserire Cognome");
            string cognome = Console.ReadLine();
            Console.WriteLine("\nInserire Codice Cliente");
            string codiceCliente = Console.ReadLine();

            //Creo un nuovo Cliente
            Cliente c = new Cliente()
            {
                Nome = nome,
                Cognome = cognome,
                CodiceCliente = codiceCliente
            };

    
            bool confirm = layer.AddNewClient(c);
            if (confirm)
                Console.WriteLine("Cliente registrato con successo");
        }

        public void ModificaCliente()
        {
            //TODO da implementare
            Console.WriteLine("Azione da implementare");
        }

        public void VisualizzaClienti()
        {
            List<Cliente> listaClienti = layer.GetClients();
            Console.WriteLine($"\nElenco dei clienti:");
            foreach (var c in listaClienti)
            {
                Console.WriteLine($"[Id Cliente] {c.Id}\n" +
                                  $"[Codice Cliente] {c.CodiceCliente}\n" +
                                  $"[Nominativo] {c.Cognome} {c.Nome}");
            }
        }

        public void CancellaCliente()
        {
            Console.WriteLine("\nInserisci ID del cliente da cancellare");
            int.TryParse(Console.ReadLine(), out int idToErase);
           
            bool confirm = layer.DeleteClientById(idToErase);
            if (confirm)
                Console.WriteLine("Utente cancellato con successo");
        }

        public void ElencoOrdinePerCliente()
        {
            Console.WriteLine("\nInserisci ID del cliente interessato");
            int.TryParse(Console.ReadLine(), out int idClient);
            Cliente c = layer.GetClientById(idClient);
            Console.WriteLine($"\nElenco ordini del cliente con Id: {idClient}");
            foreach (var o in c.listaOrdini)
            {
                Console.WriteLine($"[Id Ordine] {o.Id}\n" +
                                  $"[Codice Prodotto] {o.CodiceProdotto}\n" +
                                  $"[Codice Ordine] {o.CodiceOrdine}\n" +
                                  $"[Importo] {o.Importo}");
            }
        }

        public Cliente RecuperoCliente(int id)
        {
            return Cliente c = layer.GetClientById(id);
        }

        #endregion



        #region ORDINE
        
        public void CreaOrdine()
        {
            //ID-DataOrdine-CodiceOrdine-CodiceProdotto-Importo-Cliente
            //Chiedere i dati
            Console.WriteLine("\nInserire l'ID dell'Ordine");
            int.TryParse(Console.ReadLine(), out int idOrdine);
            Console.WriteLine("\nInserire Data dell'Ordine");
            DateTime.TryParse(Console.ReadLine(), out DateTime date);
            Console.WriteLine("\nInserire Codice Ordine");
            string codiceOrdine = Console.ReadLine();
            Console.WriteLine("\nInserire Codice Prodotto");
            string codiceProdotto = Console.ReadLine();
            Console.WriteLine("\nInserire l'ID dell'Ordine");
            decimal.TryParse(Console.ReadLine(), out decimal importo);
            Console.WriteLine("\nInserire l'ID del Cliente");
            int.TryParse(Console.ReadLine(), out int idCliente);

            //Creo un nuovo Ordine
            Ordine o = new Ordine()
            {
                Id = idOrdine,
                DataOrdine = date,
                CodiceOrdine = codiceOrdine,
                CodiceProdotto = codiceProdotto,
                Importo = importo,
                Cliente = layer.FetchClientById(idClient)
            };

            //La UI parla con il BusinessLayer. E' poi il BL a indirizzare in base al DAL
            bool confirm = api.Post(o);
            if (confirm)
                Console.WriteLine("Ordine registrato con successo");
        }

        public void ModificaOrdine()
        {
            //TODO da implementare
            Console.WriteLine("Azione da implementare");
        }

        public void VisualizzaOrdini()
        {
            //ID-DataOrdine-CodiceOrdine-CodiceProdotto-Importo-Cliente
            List<Ordine> listaOrdini = api.Get();

            //Dovrebbe restituirmeli in JSON ma non mi fa testare quindi 
            //probabilmente non lo richiamo come {c.Id} ma come c[0]

            Console.WriteLine($"\nElenco degli Ordini:");
            foreach (var c in listaOrdini)
            {
                Console.WriteLine($"[Id Ordine] {c.Id}\n" +
                                  $"[Data Ordine] {c.DataOrdine}\n" +
                                  $"[Codice Ordine] {c.CodiceOrdine}\n" +
                                  $"[Codice Prodotto] {c.CodiceProdotto}\n" +
                                  $"[Importo] {c.Importo}\n" +
                                  $"[ID Cliente associato] {c.Cliente.Id}\n" ;
            }
        }

        public Ordine RecuperaOrdine(int id)
        {
            return Ordine o = api.Get(id);
        }

        public void CancellaOrdine()
        {
            Console.WriteLine("\nInserisci ID dell'Ordine da cancellare");
            int.TryParse(Console.ReadLine(), out int idToErase);
            Ordine orderToErase = RecuperaOrdine(idToErase);
            bool confirm = api.Delete(orderToErase);
            if (confirm)
                Console.WriteLine("Ordine cancellato con successo");
        }

        public void DettagliOrdine()
        {
            Ordine o = api.Get(id);
            Console.WriteLine($"[Id Ordine] {o.Id}\n" +
                              $"[Codice Prodotto] {o.CodiceProdotto}\n" +
                              $"[Codice Ordine] {o.CodiceOrdine}\n" +
                              $"[Importo] {o.Importo}");

        }

        public void ReportPerAnno()
        {
            //TODO: IMPLEMENTATA SOLO QUI E NON ANCORA IN TUTTE LE PARTI!
            //NON lanciare

            //Specificare numero di ordini e importo totale ordini
            Console.WriteLine("Inserire l'anno desiderato");
            int.TryParse(Console.ReadLine(), out int annoReport); 

            //mi faccio restituire una lista di ordini col filtro per anno
            List<Ordine> listaOrdini = api.Get(annoReport);
            foreach (var o in listaOrdini)
            {
                Console.WriteLine($"Report:\n" +
                    $"Numero totale di Ordini: {listaOrdini.Count}\n" +
                    $"Guadagno totale: {listaOrdini.Sum(o.Importo)}");
            }
        }

        #endregion
    }
}
