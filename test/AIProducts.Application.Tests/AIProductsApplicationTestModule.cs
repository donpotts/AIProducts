using Volo.Abp.Modularity;

namespace AIProducts;

[DependsOn(
    typeof(AIProductsApplicationModule),
    typeof(AIProductsDomainTestModule)
)]
public class AIProductsApplicationTestModule : AbpModule
{

}
