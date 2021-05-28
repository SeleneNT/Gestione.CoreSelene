using Gestione.Core.Entities;
using Gestione.EF.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestione.EF.Context
{
    public class GestioneContext: DbContext
    {

        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Ordine> Ordini { get; set; }

        public GestioneContext() : base()
        {

        }

        public GestioneContext(DbContextOptions<GestioneContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                var connectionString = "Data Source =(localdb)\\MSSQLLocalDB; Initial Catalog =GestioneOrdini; Integrated Security = True; " +
                "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;User ID=sa;Password=123";
                options.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Cliente>(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration<Ordine>(new OrdineConfiguration());
        }
    }
}
