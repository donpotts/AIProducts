using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AIProducts.Data;

/* This is used if database provider does't define
 * IAIProductsDbSchemaMigrator implementation.
 */
public class NullAIProductsDbSchemaMigrator : IAIProductsDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
