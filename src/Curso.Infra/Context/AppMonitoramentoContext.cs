using Curso.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Curso.Infra.Context;

public class AppMonitoramentoContext : DbContext
{
    public AppMonitoramentoContext(DbContextOptions<AppMonitoramentoContext> options) : base(options)
    { }

    public DbSet<EstacionamentoModel> Estacionamentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppMonitoramentoContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
