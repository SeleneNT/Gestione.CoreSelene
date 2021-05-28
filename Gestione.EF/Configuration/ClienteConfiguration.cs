using Gestione.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestione.EF.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
               .HasKey(c => c.Id);
            builder
                .Property(c => c.Nome)
                .HasMaxLength(200)
                .IsRequired();
            builder
                .Property(c => c.Nome)
                .HasMaxLength(200)
                .IsRequired();
            builder
                .Property(c => c.CodiceCliente)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}