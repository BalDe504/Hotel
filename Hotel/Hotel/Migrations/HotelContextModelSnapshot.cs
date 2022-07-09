﻿// <auto-generated />
using System;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotel.Migrations
{
    [DbContext(typeof(HotelContext))]
    partial class HotelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Hotel.Models.Klienci", b =>
                {
                    b.Property<int>("IdKlienta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_klienta");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdKlienta"), 1L, 1);

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("imie");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("nazwisko");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasMaxLength(9)
                        .IsUnicode(false)
                        .HasColumnType("varchar(9)")
                        .HasColumnName("telefon");

                    b.HasKey("IdKlienta")
                        .HasName("PK__Klienci__EB1748C932F0DC53");

                    b.ToTable("Klienci", (string)null);
                });

            modelBuilder.Entity("Hotel.Models.Pobyty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataPrzyjazdu")
                        .HasColumnType("date")
                        .HasColumnName("data_przyjazdu");

                    b.Property<int>("IdKlienta")
                        .HasColumnType("int")
                        .HasColumnName("id_klienta");

                    b.Property<int>("IdPokoju")
                        .HasColumnType("int")
                        .HasColumnName("id_pokoju");

                    b.Property<bool>("ZakonczonyPobyt")
                        .HasColumnType("bit")
                        .HasColumnName("zakonczony_pobyt");

                    b.HasKey("Id");

                    b.HasIndex("IdKlienta");

                    b.HasIndex("IdPokoju");

                    b.ToTable("Pobyty", (string)null);
                });

            modelBuilder.Entity("Hotel.Models.Pokoje", b =>
                {
                    b.Property<int>("IdPokoju")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_pokoju");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPokoju"), 1L, 1);

                    b.Property<double>("Cena")
                        .HasColumnType("float")
                        .HasColumnName("cena");

                    b.Property<int>("IloscOsob")
                        .HasColumnType("int")
                        .HasColumnName("ilosc_osob");

                    b.Property<int>("NumerPokoju")
                        .HasColumnType("int")
                        .HasColumnName("numer_pokoju");

                    b.HasKey("IdPokoju")
                        .HasName("PK__Pokoje__77BD26A3E64A0FAF");

                    b.ToTable("Pokoje", (string)null);
                });

            modelBuilder.Entity("Hotel.Models.Uslugi", b =>
                {
                    b.Property<int>("IdUslugi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_uslugi");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUslugi"), 1L, 1);

                    b.Property<int>("Cena")
                        .HasColumnType("int")
                        .HasColumnName("cena");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("nazwa");

                    b.HasKey("IdUslugi")
                        .HasName("PK__Uslugi__9FD22D6B4F02AA6C");

                    b.ToTable("Uslugi", (string)null);
                });

            modelBuilder.Entity("Hotel.Models.WykupioneUslugi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdKlienta")
                        .HasColumnType("int")
                        .HasColumnName("id_klienta");

                    b.Property<int>("IdUslugi")
                        .HasColumnType("int")
                        .HasColumnName("id_uslugi");

                    b.HasKey("Id");

                    b.HasIndex("IdKlienta");

                    b.HasIndex("IdUslugi");

                    b.ToTable("WykupioneUslugi", (string)null);
                });

            modelBuilder.Entity("Hotel.Models.Pobyty", b =>
                {
                    b.HasOne("Hotel.Models.Klienci", "IdKlientaNavigation")
                        .WithMany("Pobyties")
                        .HasForeignKey("IdKlienta")
                        .IsRequired()
                        .HasConstraintName("FK__Pobyty__id_klien__286302EC");

                    b.HasOne("Hotel.Models.Pokoje", "IdPokojuNavigation")
                        .WithMany("Pobyties")
                        .HasForeignKey("IdPokoju")
                        .IsRequired()
                        .HasConstraintName("FK__Pobyty__id_pokoj__29572725");

                    b.Navigation("IdKlientaNavigation");

                    b.Navigation("IdPokojuNavigation");
                });

            modelBuilder.Entity("Hotel.Models.WykupioneUslugi", b =>
                {
                    b.HasOne("Hotel.Models.Klienci", "IdKlientaNavigation")
                        .WithMany("WykupioneUslugis")
                        .HasForeignKey("IdKlienta")
                        .IsRequired()
                        .HasConstraintName("FK__Wykupione__id_kl__2E1BDC42");

                    b.HasOne("Hotel.Models.Uslugi", "IdUslugiNavigation")
                        .WithMany("WykupioneUslugis")
                        .HasForeignKey("IdUslugi")
                        .IsRequired()
                        .HasConstraintName("FK__Wykupione__id_us__2F10007B");

                    b.Navigation("IdKlientaNavigation");

                    b.Navigation("IdUslugiNavigation");
                });

            modelBuilder.Entity("Hotel.Models.Klienci", b =>
                {
                    b.Navigation("Pobyties");

                    b.Navigation("WykupioneUslugis");
                });

            modelBuilder.Entity("Hotel.Models.Pokoje", b =>
                {
                    b.Navigation("Pobyties");
                });

            modelBuilder.Entity("Hotel.Models.Uslugi", b =>
                {
                    b.Navigation("WykupioneUslugis");
                });
#pragma warning restore 612, 618
        }
    }
}