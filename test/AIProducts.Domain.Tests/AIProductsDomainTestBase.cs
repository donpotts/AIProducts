using Volo.Abp.Modularity;

namespace AIProducts;

/* Inherit from this class for your domain layer tests. */
public abstract class AIProductsDomainTestBase<TStartupModule> : AIProductsTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
