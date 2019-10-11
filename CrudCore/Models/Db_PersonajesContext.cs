using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrudCore.Models
{
    public interface ID_Personajes { }

    public partial class Db_PersonajesContext : DbContext, ID_Personajes
    {
        public Db_PersonajesContext()
        {
        }

        public Db_PersonajesContext(DbContextOptions<Db_PersonajesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbPersonajes> TbPersonajes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Db_Personajes;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbPersonajes>(entity =>
            {
                entity.HasKey(e => e.IdPersonaje)
                    .HasName("Pk_personaje");

                entity.ToTable("Tb_Personajes", "Comics");

                entity.Property(e => e.IdPersonaje).HasColumnName("id_personaje");

                entity.Property(e => e.EdadPersonaje).HasColumnName("edad_personaje");

                entity.Property(e => e.EditorialPersonaje)
                    .IsRequired()
                    .HasColumnName("editorial_personaje")
                    .HasMaxLength(15);

                entity.Property(e => e.FechaPersonaje)
                    .HasColumnName("fecha_personaje")
                    .HasColumnType("date");

                entity.Property(e => e.NombrePersonaje)
                    .IsRequired()
                    .HasColumnName("nombre_personaje")
                    .HasMaxLength(60);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
