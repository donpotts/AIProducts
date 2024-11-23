using Xunit;

namespace AIProducts.EntityFrameworkCore;

[CollectionDefinition(AIProductsTestConsts.CollectionDefinitionName)]
public class AIProductsEntityFrameworkCoreCollection : ICollectionFixture<AIProductsEntityFrameworkCoreFixture>
{

}
