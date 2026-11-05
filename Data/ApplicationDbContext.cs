using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection;
using OficinaEF.Models;
namespace OficinaEF.Data;

public class ApplicationDbContext : IdentityDbContext
{
    private readonly IDataProtector _protetor;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
        IDataProtectionProvider provider) : base(options)
    {
        _protetor = provider.CreateProtector("Cpf.OficinaEF");
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Equipamento> Equipamentos { get; set; }
    public DbSet<Agendamento> Agendamentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var protetor = _protetor;
        modelBuilder.Entity<Cliente>().Property(c => c.Cpf)
            .HasConversion(
                valor => protetor.Protect(valor),
                valor => protetor.Unprotect(valor));
    }
}

