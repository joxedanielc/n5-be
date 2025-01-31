using Microsoft.EntityFrameworkCore;
using N5_BE.Domain.Entities;

namespace N5_BE.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<TipoPermisos> TipoPermisos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TipoPermisos>(entity =>
            {
                entity.ToTable("TipoPermisos");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.ToTable("Permisos");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd();
                entity.HasOne(p => p.TipoPermisos)
                      .WithMany(t => t.Permisos)
                      .HasForeignKey(p => p.TipoPermiso)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}