using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using AIProducts.Localization;

namespace AIProducts.Web;

[Dependency(ReplaceServices = true)]
public class AIProductsBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<AIProductsResource> _localizer;

    public AIProductsBrandingProvider(IStringLocalizer<AIProductsResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
