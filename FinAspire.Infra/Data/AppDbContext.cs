using System.Reflection;
using FinAspire.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FinAspire.Infra.Data;

public class AppDbContext : DbContext
{
    public DbSet<Transaction> Transactions { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}