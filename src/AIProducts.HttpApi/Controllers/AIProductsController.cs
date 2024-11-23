using AIProducts.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AIProducts.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AIProductsController : AbpControllerBase
{
    protected AIProductsController()
    {
        LocalizationResource = typeof(AIProductsResource);
    }
}
