using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace backend.Models
{
    public partial class lndbContext : DbContext
    {
        public lndbContext()
        {
        }

        public lndbContext(DbContextOptions<lndbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbListaFofa> TbListaFofa { get; set; }
        public virtual DbSet<TbListaNegra> TbListaNegra { get; set; }
        public virtual DbSet<TbMemelation> TbMemelation { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conn = "server=localhost;user id=root;password=1234;database=lndb";
                optionsBuilder.UseMySql(conn, x => {
                    x.ServerVersion("8.0.20-mysql");
                    //x.EnableRetryOnFailure();
                });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbListaFofa>(entity =>
            {
                entity.HasKey(e => e.IdListaFofa)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsPorque)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NmFofura)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<TbListaNegra>(entity =>
            {
                entity.HasKey(e => e.IdListaNegra)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsFoto)
                    .HasDefaultValueSql("'user.png'")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.DsLocal)
                    .HasDefaultValueSql("'Outro'")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.DsMotivo)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NmPessoa)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<TbMemelation>(entity =>
            {
                entity.HasKey(e => e.IdMemelation)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsCategoria)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsHashtags)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ImgMeme)
                    .HasDefaultValueSql("'user.png'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmAutor)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
