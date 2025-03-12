using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vehiculos.Models;

namespace Vehiculos.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }
    public DbSet<ClientesModels> Clientes { get; set; }
    public DbSet<AlquileresModels> Alquileres { get; set; }
    public DbSet<VehiculosModels> Vehiculos { get; set; }

}
