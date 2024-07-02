using Microsoft.EntityFrameworkCore;
using NetCorePlantillas.Models;

public class CartaSolicitudContext : DbContext
{
    public CartaSolicitudContext(DbContextOptions<CartaSolicitudContext> options) : base(options)
    {
    }

    public DbSet<Plantilla> Plantillas { get; set; }
    // Agregar DbSet para otras entidades si es necesario

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración adicional del modelo, como relaciones entre entidades
    }
}