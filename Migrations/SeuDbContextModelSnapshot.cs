﻿// <auto-generated />
using System;
using ApiTransacoesBancarias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiTransacoesBancarias.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ApiTransacoesBancarias.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Categoria")
                        .HasColumnType("text")
                        .HasColumnName("Categoria");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DataHora");

                    b.Property<string>("ModoTransacao")
                        .HasColumnType("text")
                        .HasColumnName("ModoTransacao");

                    b.Property<string>("NotaObservacao")
                        .HasColumnType("text")
                        .HasColumnName("NotaObservacao");

                    b.Property<string>("TipoTransacao")
                        .HasColumnType("text")
                        .HasColumnName("TipoTransacao");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.ToTable("transacoes", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
