using System.Reflection;
using FinAspire.Infra.Data;
using FinAspire.Infra.Repositories.Categories;
using FinAspire.Infra.Repositories.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinAspire.Infra;

public static class DependencyInjection
{
    public static IServiceCollection ImplementPersistence(
        this IServiceCollection servicesCollection, IConfiguration configuration)
    {
        servicesCollection.AddDbContext<AppDbContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("DefaultConnection"),
            c => c.MigrationsAssembly(Assembly.GetExecutingAssembly())));

        servicesCollection.AddScoped<ICategoryRepository, CategoryRepository>();
        servicesCollection.AddScoped<ITransactionRepository, TransactionRepository>();
        
        return servicesCollection;
            
    }
}