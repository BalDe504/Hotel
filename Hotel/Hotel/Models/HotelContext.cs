using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Hotel.Models
{
    public partial class HotelContext : DbContext
    {
        public HotelContext()
        {
        }

        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Klienci> Kliencis { get; set; } = null!;
        public virtual DbSet<Pobyty> Pobyties { get; set; } = null!;
        public virtual DbSet<Pokoje> Pokojes { get; set; } = null!;
        public virtual DbSet<Uslugi> Uslugis { get; set; } = null!;
        public virtual DbSet<WykupioneUslugi> WykupioneUslugis { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Database=Hotel;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klienci>(entity =>
            {
                entity.HasKey(e => e.IdKlienta)
                    .HasName("PK__Klienci__EB1748C932F0DC53");

                entity.ToTable("Klienci");

                entity.Property(e => e.IdKlienta).HasColumnName("id_klienta");

                entity.Property(e => e.Imie)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("imie");

                entity.Property(e => e.Nazwisko)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("nazwisko");

                entity.Property(e => e.Telefon)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("telefon");
            });

            modelBuilder.Entity<Pobyty>(entity =>
            {
                entity.ToTable("Pobyty");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataPrzyjazdu)
                    .HasColumnType("date")
                    .HasColumnName("data_przyjazdu");

                entity.Property(e => e.IdKlienta).HasColumnName("id_klienta");

                entity.Property(e => e.IdPokoju).HasColumnName("id_pokoju");

                entity.Property(e => e.ZakonczonyPobyt).HasColumnName("zakonczony_pobyt");

                entity.HasOne(d => d.IdKlientaNavigation)
                    .WithMany(p => p.Pobyties)
                    .HasForeignKey(d => d.IdKlienta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pobyty__id_klien__286302EC");

                entity.HasOne(d => d.IdPokojuNavigation)
                    .WithMany(p => p.Pobyties)
                    .HasForeignKey(d => d.IdPokoju)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pobyty__id_pokoj__29572725");
            });

            modelBuilder.Entity<Pokoje>(entity =>
            {
                entity.HasKey(e => e.IdPokoju)
                    .HasName("PK__Pokoje__77BD26A3E64A0FAF");

                entity.ToTable("Pokoje");

                entity.Property(e => e.IdPokoju).HasColumnName("id_pokoju");

                entity.Property(e => e.Cena).HasColumnName("cena");

                entity.Property(e => e.IloscOsob).HasColumnName("ilosc_osob");

                entity.Property(e => e.NumerPokoju).HasColumnName("numer_pokoju");
            });

            modelBuilder.Entity<Uslugi>(entity =>
            {
                entity.HasKey(e => e.IdUslugi)
                    .HasName("PK__Uslugi__9FD22D6B4F02AA6C");

                entity.ToTable("Uslugi");

                entity.Property(e => e.IdUslugi).HasColumnName("id_uslugi");

                entity.Property(e => e.Cena).HasColumnName("cena");

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nazwa");
            });

            modelBuilder.Entity<WykupioneUslugi>(entity =>
            {
                entity.ToTable("WykupioneUslugi");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdKlienta).HasColumnName("id_klienta");

                entity.Property(e => e.IdUslugi).HasColumnName("id_uslugi");

                entity.HasOne(d => d.IdKlientaNavigation)
                    .WithMany(p => p.WykupioneUslugis)
                    .HasForeignKey(d => d.IdKlienta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Wykupione__id_kl__2E1BDC42");

                entity.HasOne(d => d.IdUslugiNavigation)
                    .WithMany(p => p.WykupioneUslugis)
                    .HasForeignKey(d => d.IdUslugi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Wykupione__id_us__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
