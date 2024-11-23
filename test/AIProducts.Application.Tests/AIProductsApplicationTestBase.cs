using Volo.Abp.Modularity;

namespace AIProducts;

public abstract class AIProductsApplicationTestBase<TStartupModule> : AIProductsTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
