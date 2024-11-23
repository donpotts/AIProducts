using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AIProducts.Data;
using Volo.Abp.DependencyInjection;

namespace AIProducts.EntityFrameworkCore;

public class EntityFrameworkCoreAIProductsDbSchemaMigrator
    : IAIProductsDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAIProductsDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the AIProductsDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AIProductsDbContext>()
            .Database
            .MigrateAsync();
    }
}
