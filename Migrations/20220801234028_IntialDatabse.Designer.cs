﻿// <auto-generated />
using System.Collections.Generic;
using FaktureAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FaktureAPI.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220801234028_IntialDatabse")]
    partial class IntialDatabse
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FaktureAPI.Models.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("Banka")
                        .HasColumnType("text[]");

                    b.Property<string>("BrojPoste")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Drzava")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MB")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Mjesto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Pbr")
                        .HasColumnType("text");

                    b.Property<string>("Swift")
                        .HasColumnType("text");

                    b.Property<bool>("Tip")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Partners");
                });
#pragma warning restore 612, 618
        }
    }
}
