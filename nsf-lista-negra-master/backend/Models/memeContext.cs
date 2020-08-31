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
        public virtual DbSet<TbUsuario> TbUsuario { get; set; }

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

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("id_usuario");

                entity.Property(e => e.DsComentario)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.IdMemelationNavigation)
                    .WithMany(p => p.TbComentario)
                    .HasForeignKey(d => d.IdMemelation)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_comentario_ibfk_1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TbComentario)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_comentario_ibfk_2");
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
            });

            modelBuilder.Entity<TbUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsSenha)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NmUsuario)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
