﻿// <auto-generated />
using System;
using Ma.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ma.API.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231214212532_test")]
    partial class test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ma.API.Entities.Lawsuit.Lawsuit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AdversePartId")
                        .HasColumnType("integer");

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FinalDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("IndicatedById")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("InitialDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LawsuitClientPosition")
                        .HasColumnType("integer");

                    b.Property<string>("LawsuitCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LawsuitType")
                        .HasColumnType("integer");

                    b.Property<string>("Observation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ResponsibleLawyerId")
                        .HasColumnType("integer");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AdversePartId");

                    b.HasIndex("ClientId");

                    b.HasIndex("IndicatedById");

                    b.HasIndex("ResponsibleLawyerId");

                    b.ToTable("Lawsuits");
                });

            modelBuilder.Entity("Ma.API.Entities.Lawyer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Oab")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Lawyer");
                });

            modelBuilder.Entity("Ma.API.Entities.Registry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<int?>("LawyerResponsibleId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("LawyerResponsibleId");

                    b.ToTable("Registry");
                });

            modelBuilder.Entity("Ma.API.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Ma.API.Entities.Lawsuit.Lawsuit", b =>
                {
                    b.HasOne("Ma.API.Entities.Registry", "AdversePart")
                        .WithMany()
                        .HasForeignKey("AdversePartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ma.API.Entities.Registry", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ma.API.Entities.Registry", "IndicatedBy")
                        .WithMany()
                        .HasForeignKey("IndicatedById");

                    b.HasOne("Ma.API.Entities.Lawyer", "ResponsibleLawyer")
                        .WithMany()
                        .HasForeignKey("ResponsibleLawyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdversePart");

                    b.Navigation("Client");

                    b.Navigation("IndicatedBy");

                    b.Navigation("ResponsibleLawyer");
                });

            modelBuilder.Entity("Ma.API.Entities.Lawyer", b =>
                {
                    b.HasOne("Ma.API.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ma.API.Entities.Registry", b =>
                {
                    b.HasOne("Ma.API.Entities.Lawyer", "LawyerResponsible")
                        .WithMany()
                        .HasForeignKey("LawyerResponsibleId");

                    b.Navigation("LawyerResponsible");
                });
#pragma warning restore 612, 618
        }
    }
}
