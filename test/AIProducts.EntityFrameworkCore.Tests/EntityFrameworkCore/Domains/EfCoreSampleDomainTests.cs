using AIProducts.Samples;
using Xunit;

namespace AIProducts.EntityFrameworkCore.Domains;

[Collection(AIProductsTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AIProductsEntityFrameworkCoreTestModule>
{

}
