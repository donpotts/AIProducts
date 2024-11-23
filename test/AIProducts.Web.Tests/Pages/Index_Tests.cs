using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace AIProducts.Pages;

[Collection(AIProductsTestConsts.CollectionDefinitionName)]
public class Index_Tests : AIProductsWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
