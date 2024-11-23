using System.Threading.Tasks;

namespace AIProducts.Data;

public interface IAIProductsDbSchemaMigrator
{
    Task MigrateAsync();
}
