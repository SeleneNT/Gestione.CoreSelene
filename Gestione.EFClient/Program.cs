using Gestione.Core.BusinessLayer;
using Gestione.Core.Entities;
using Gestione.EF.Context;
using Gestione.EF.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gestione.EFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****Sistema Gestione Ordini****");

            do
            {
                Console.WriteLine("\nSezione CLIENTI Sezionare l'opzione:");

                Console.WriteLine("1.Crea nuovo Cliente");
                Console.WriteLine("2.Modifica Cliente");
                Console.WriteLine("3.Visualizza tutti i Clienti");
                Console.WriteLine("4.Cancella un Cliente");
                Console.WriteLine("5.Stampa elenco Ordini");

                Console.WriteLine("\nSezione ORDINI");
                Console.WriteLine("Sezionare l'opzione:");

                Console.WriteLine("6.Registra Ordine");
                Console.WriteLine("7.Modifica Ordine");
                Console.WriteLine("8.Visualizza tutti gli Ordini");
                Console.WriteLine("9.Cancella un Ordine");

                Console.WriteLine("\n@.Stampa dettagli Ordine");
                Console.WriteLine("#.Visualizza Report Ordine per Anno");

                Console.WriteLine("0.Esci");

                switch(Console.ReadKey().KeyChar)
                {
                    case '1':
                        Helper.CreaCliente();
                        break;
                    case '2':
                        Helper.ModificaCliente();
                        break;
                    case '3':
                        Helper.VisualizzaClienti();
                        break;
                    case '4':
                        Helper.CancellaCliente();
                        break;
                    case '5':
                        Helper.ElencoOrdinePerCliente();
                        break;
                    case '6':
                        Helper.CreaOrdine();
                        break;
                    case '7':
                        Helper.ModificaOrdine();
                        break;
                    case '8':
                        Helper.VisualizzaOrdini();
                        break;
                    case '9':
                        Helper.CancellaOrdine();
                        break;
                    case '@':
                        Helper.DettagliOrdine();
                        break;
                    case '#':
                        Helper.ReportPerAnno();
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            } while (true);
        }


    }
}
