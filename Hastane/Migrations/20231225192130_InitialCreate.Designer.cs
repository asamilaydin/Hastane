﻿// <auto-generated />
using System;
using Hastane.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hastane.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231225192130_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Hastane.Entities.AnaBilimDali", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("AnaBilimDallari");
                });

            modelBuilder.Entity("Hastane.Entities.CalısmaSaat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<TimeSpan>("BaslangıcSaat")
                        .HasColumnType("interval");

                    b.Property<TimeSpan>("BitisSaat")
                        .HasColumnType("interval");

                    b.Property<Guid>("DoktorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Gun")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.ToTable("CalismaSaatleri");
                });

            modelBuilder.Entity("Hastane.Entities.Doktor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("PoliklinikId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PoliklinikId");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("Hastane.Entities.Poliklinik", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AnaBilimDaliId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("AnaBilimDaliId");

                    b.ToTable("Poliklinikler");
                });

            modelBuilder.Entity("Hastane.Entities.Randevu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("DoktorId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("DoktorId1")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("RandevuTarihi")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId1");

                    b.HasIndex("UserId");

                    b.ToTable("Randevular");
                });

            modelBuilder.Entity("Hastane.Entities.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Locked")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Hastane.Entities.CalısmaSaat", b =>
                {
                    b.HasOne("Hastane.Entities.Doktor", null)
                        .WithMany("CalısmaSaatleri")
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hastane.Entities.Doktor", b =>
                {
                    b.HasOne("Hastane.Entities.Poliklinik", null)
                        .WithMany("Doktorlar")
                        .HasForeignKey("PoliklinikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hastane.Entities.Poliklinik", b =>
                {
                    b.HasOne("Hastane.Entities.AnaBilimDali", null)
                        .WithMany("Poliklinikler")
                        .HasForeignKey("AnaBilimDaliId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hastane.Entities.Randevu", b =>
                {
                    b.HasOne("Hastane.Entities.Doktor", null)
                        .WithMany("Randevular")
                        .HasForeignKey("DoktorId1");

                    b.HasOne("Hastane.Entities.User", null)
                        .WithMany("Randevular")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hastane.Entities.AnaBilimDali", b =>
                {
                    b.Navigation("Poliklinikler");
                });

            modelBuilder.Entity("Hastane.Entities.Doktor", b =>
                {
                    b.Navigation("CalısmaSaatleri");

                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("Hastane.Entities.Poliklinik", b =>
                {
                    b.Navigation("Doktorlar");
                });

            modelBuilder.Entity("Hastane.Entities.User", b =>
                {
                    b.Navigation("Randevular");
                });
#pragma warning restore 612, 618
        }
    }
}