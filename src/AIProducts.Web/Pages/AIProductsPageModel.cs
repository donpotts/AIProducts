using AIProducts.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AIProducts.Web.Pages;

public abstract class AIProductsPageModel : AbpPageModel
{
    protected AIProductsPageModel()
    {
        LocalizationResourceType = typeof(AIProductsResource);
    }
}
