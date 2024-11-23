using AIProducts.Samples;
using Xunit;

namespace AIProducts.EntityFrameworkCore.Applications;

[Collection(AIProductsTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AIProductsEntityFrameworkCoreTestModule>
{

}
