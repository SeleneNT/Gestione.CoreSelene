﻿// <auto-generated />
using System;
using Gestione.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gestione.EF.Migrations
{
    [DbContext(typeof(GestioneContext))]
    [Migration("20210528093919_PrimaMigrazione")]
    partial class PrimaMigrazione
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gestione.Core.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodiceCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Cognome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Clienti");
                });

            modelBuilder.Entity("Gestione.Core.Entities.Ordine", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("CodiceOrdine")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("CodiceProdotto")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<DateTime>("DataOrdine")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Importo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Ordini");
                });

            modelBuilder.Entity("Gestione.Core.Entities.Ordine", b =>
                {
                    b.HasOne("Gestione.Core.Entities.Cliente", "Cliente")
                        .WithMany("listaOrdini")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}