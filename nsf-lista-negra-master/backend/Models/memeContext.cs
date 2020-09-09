using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace backend.Models
{
    public partial class memeContext : DbContext
    {
        public memeContext()
        {
        }

        public memeContext(DbContextOptions<memeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbComentario> TbComentario { get; set; }
        public virtual DbSet<TbMemelation> TbMemelation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySql("server=localhost;user id=root;password=1234;database=meme", x => x.ServerVersion("5.7.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbComentario>(entity =>
            {
                entity.HasKey(e => e.IdComentario)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdMemelation)
                    .HasName("id_memelation");

                entity.Property(e => e.DsComentario)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.IdMemelationNavigation)
                    .WithMany(p => p.TbComentario)
                    .HasForeignKey(d => d.IdMemelation)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_comentario_ibfk_1");
            });

            modelBuilder.Entity<TbMemelation>(entity =>
            {
                entity.HasKey(e => e.IdMemelation)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsCategoria)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.DsHashtags)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ImgMeme)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NmAutor)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.QtdCurtidas).HasDefaultValueSql("'0'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
