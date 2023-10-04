﻿// <auto-generated />
using System;
using DataLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    [Migration("20231003073644_init1")]
    partial class init1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityLayer.Concreate.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("EntityLayer.Concreate.TrenIstasyon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IstasyonAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IstasyonAdresi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IstasyonKonumu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TrenIstasyonlar");
                });

            modelBuilder.Entity("EntityLayer.Concreate.TrenSefer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("KalısSaati")
                        .HasColumnType("datetime2");

                    b.Property<int>("TrenKalkisIstasyonId")
                        .HasColumnType("int");

                    b.Property<int>("TrenVarisIstasyonId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VarisSaati")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TrenKalkisIstasyonId");

                    b.HasIndex("TrenVarisIstasyonId");

                    b.ToTable("TrenSeferler");
                });

            modelBuilder.Entity("EntityLayer.Concreate.TrenSefer", b =>
                {
                    b.HasOne("EntityLayer.Concreate.TrenIstasyon", "TrenKalkisIstasyon")
                        .WithMany("KalkısIstasyonlar")
                        .HasForeignKey("TrenKalkisIstasyonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concreate.TrenIstasyon", "TrenVarisIstasyon")
                        .WithMany("VarisIstasyonlar")
                        .HasForeignKey("TrenVarisIstasyonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("TrenKalkisIstasyon");

                    b.Navigation("TrenVarisIstasyon");
                });

            modelBuilder.Entity("EntityLayer.Concreate.TrenIstasyon", b =>
                {
                    b.Navigation("KalkısIstasyonlar");

                    b.Navigation("VarisIstasyonlar");
                });
#pragma warning restore 612, 618
        }
    }
}
