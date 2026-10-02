using Microsoft.EntityFrameworkCore;
using TallerMecanico.Models;

namespace TallerMecanico.Data;

public class TallerDbContext : DbContext
{
    public TallerDbContext(DbContextOptions<TallerDbContext> options) : base(options)
    {
    }

    public DbSet<TipoServicio> TipoServicios { get; set; } = null!;
    public DbSet<Cliente> Clientes { get; set; } = null!;
    public DbSet<Vehiculo> Vehiculos { get; set; } = null!;
    public DbSet<OrdenServicio> OrdenesServicio { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure decimal precision if not inferred
        modelBuilder.Entity<TipoServicio>().Property(t => t.PrecioBase).HasColumnType("decimal(10,2)");
        modelBuilder.Entity<OrdenServicio>().Property(o => o.CostoEstimado).HasColumnType("decimal(10,2)");

        // Configure relations (EF can infer these from conventions but explicit mapping is clearer)
        modelBuilder.Entity<Cliente>()
            .HasMany(c => c.Vehiculos)
            .WithOne(v => v.Cliente)
            .HasForeignKey(v => v.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Vehiculo>()
            .HasMany(v => v.OrdenesServicio)
            .WithOne(o => o.Vehiculo)
            .HasForeignKey(o => o.VehiculoId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TipoServicio>()
            .HasMany(t => t.OrdenesServicio)
            .WithOne(o => o.TipoServicio)
            .HasForeignKey(o => o.TipoServicioId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
