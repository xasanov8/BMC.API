﻿// <auto-generated />
using System;
using BMC.Infrostructure.References;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BMC.Infrostructure.Migrations
{
    [DbContext(typeof(BMCProjDbContext))]
    partial class BMCProjDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BMC.Domain.Entities.Models.AboutWorker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("EndTime")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RestoranId")
                        .HasColumnType("uuid");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StartTime")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("AboutWorkers");
                });

            modelBuilder.Entity("BMC.Domain.Entities.Models.ClientModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TableNumber")
                        .HasColumnType("integer");

                    b.Property<Guid?>("WorkerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("ClientModels");
                });

            modelBuilder.Entity("BMC.Domain.Entities.Models.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ClientModelId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<Guid>("RestoranId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ClientModelId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("BMC.Domain.Entities.Models.Restoran", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Restorans");
                });

            modelBuilder.Entity("BMC.Domain.Entities.Models.Worker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("RestoranId")
                        .HasColumnType("uuid");

                    b.Property<double>("Salary")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Worker");
                });

            modelBuilder.Entity("BMC.Domain.Entities.Models.ClientModel", b =>
                {
                    b.HasOne("BMC.Domain.Entities.Models.Worker", null)
                        .WithMany("Clients")
                        .HasForeignKey("WorkerId");
                });

            modelBuilder.Entity("BMC.Domain.Entities.Models.Menu", b =>
                {
                    b.HasOne("BMC.Domain.Entities.Models.ClientModel", null)
                        .WithMany("Menus")
                        .HasForeignKey("ClientModelId");
                });

            modelBuilder.Entity("BMC.Domain.Entities.Models.ClientModel", b =>
                {
                    b.Navigation("Menus");
                });

            modelBuilder.Entity("BMC.Domain.Entities.Models.Worker", b =>
                {
                    b.Navigation("Clients");
                });
#pragma warning restore 612, 618
        }
    }
}
