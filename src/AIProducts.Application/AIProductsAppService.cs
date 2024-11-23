using AIProducts.Localization;
using Volo.Abp.Application.Services;

namespace AIProducts;

/* Inherit your application services from this class.
 */
public abstract class AIProductsAppService : ApplicationService
{
    protected AIProductsAppService()
    {
        LocalizationResource = typeof(AIProductsResource);
    }
}
