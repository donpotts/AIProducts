using Volo.Abp.Modularity;

namespace AIProducts;

[DependsOn(
    typeof(AIProductsDomainModule),
    typeof(AIProductsTestBaseModule)
)]
public class AIProductsDomainTestModule : AbpModule
{

}
