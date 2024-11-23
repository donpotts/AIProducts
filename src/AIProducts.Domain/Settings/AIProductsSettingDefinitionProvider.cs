using Volo.Abp.Settings;

namespace AIProducts.Settings;

public class AIProductsSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AIProductsSettings.MySetting1));
    }
}
