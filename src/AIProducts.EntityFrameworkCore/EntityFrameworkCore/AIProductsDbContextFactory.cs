using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AIProducts.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class AIProductsDbContextFactory : IDesignTimeDbContextFactory<AIProductsDbContext>
{
    public AIProductsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        AIProductsEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<AIProductsDbContext>()
            .UseSqlite(configuration.GetConnectionString("Default"));
        
        return new AIProductsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../AIProducts.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
