using AIProducts.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AIProducts.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AIProductsEntityFrameworkCoreModule),
    typeof(AIProductsApplicationContractsModule)
)]
public class AIProductsDbMigratorModule : AbpModule
{
}
