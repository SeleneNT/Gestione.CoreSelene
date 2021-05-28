using Gestione.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestione.EF.Configuration
{
    public class OrdineConfiguration : IEntityTypeConfiguration<Ordine>
    {
        public void Configure(EntityTypeBuilder<Ordine> builder)
        {
            builder
               .HasKey(o => o.Id);
            builder
                .Property(o => o.DataOrdine)
                .IsRequired();
            builder
                .Property(o => o.CodiceOrdine)
                .HasMaxLength(10)
                .IsRequired();
            builder
                .Property(o => o.CodiceProdotto)
                .HasMaxLength(10)
                .IsRequired();
            builder
                .Property(o => o.Importo)
                .IsRequired();
            builder
                 .HasOne(o => o.Cliente)
                 .WithMany(c=>c.listaOrdini)
                 .HasForeignKey(o => o.Id);
        }
    }
}