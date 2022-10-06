using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ECF_auto_ecole.Models
{
    public partial class ECF_AELContext : DbContext
    {
        public ECF_AELContext()
        {
        }

        public ECF_AELContext(DbContextOptions<ECF_AELContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calendrier> Calendriers { get; set; } = null!;
        public virtual DbSet<Eleve> Eleves { get; set; } = null!;
        public virtual DbSet<Lecon> Lecons { get; set; } = null!;
        public virtual DbSet<Modele> Modeles { get; set; } = null!;
        public virtual DbSet<Moniteur> Moniteurs { get; set; } = null!;
        public virtual DbSet<Vehicule> Vehicules { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-VRSB5G3\\MYDB;Database=ECF_AEL;User Id=sa;Password=kazuma77;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Eleve>(entity =>
            {
                entity.Property(e => e.IdÉlève).ValueGeneratedNever();
            });

            modelBuilder.Entity<Lecon>(entity =>
            {
                entity.HasKey(e => new { e.ModèleVéhicule, e.DateHeure, e.IdÉlève, e.IdMoniteur });

                entity.HasOne(d => d.DateHeureNavigation)
                    .WithMany(p => p.Lecons)
                    .HasForeignKey(d => d.DateHeure)
                    .HasConstraintName("FK_lecon_calendrier");

                entity.HasOne(d => d.IdMoniteurNavigation)
                    .WithMany(p => p.Lecons)
                    .HasForeignKey(d => d.IdMoniteur)
                    .HasConstraintName("FK_lecon_moniteur");

                entity.HasOne(d => d.IdÉlèveNavigation)
                    .WithMany(p => p.Lecons)
                    .HasForeignKey(d => d.IdÉlève)
                    .HasConstraintName("FK_lecon_eleve");

                entity.HasOne(d => d.ModèleVéhiculeNavigation)
                    .WithMany(p => p.Lecons)
                    .HasForeignKey(d => d.ModèleVéhicule)
                    .HasConstraintName("FK_lecon_modele");
            });

            modelBuilder.Entity<Modele>(entity =>
            {
                entity.Property(e => e.Année).IsFixedLength();
            });

            modelBuilder.Entity<Moniteur>(entity =>
            {
                entity.Property(e => e.IdMoniteur).ValueGeneratedNever();
            });

            modelBuilder.Entity<Vehicule>(entity =>
            {
                entity.HasOne(d => d.ModèleVéhiculeNavigation)
                    .WithMany(p => p.Vehicules)
                    .HasForeignKey(d => d.ModèleVéhicule)
                    .HasConstraintName("FK_Vehicule_Modele");
            });
            base.OnModelCreating(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
