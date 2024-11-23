using System.Threading.Tasks;
using AIProducts.Localization;
using AIProducts.MultiTenancy;
using AIProducts.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace AIProducts.Web.Menus;

public class AIProductsMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<AIProductsResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                AIProductsMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        context.Menu.AddItem(
            new ApplicationMenuItem(
                "AIProducts",
                l["Menu:AIProducts"],
                icon: "fa fa-database")
            .AddItem(
                new ApplicationMenuItem(
                    "AIProducts.Products",
                    l["Menu:Products"],
                    url: "/Products"
                ).RequirePermissions(AIProductsPermissions.Products.Default) // Check the permission!
            )
            .AddItem(
                new ApplicationMenuItem(
                    "AIProducts.ProductCategories",
                    l["Menu:ProductCategories"],
                    url: "/ProductCategories"
                ).RequirePermissions(AIProductsPermissions.ProductCategories.Default) // Check the permission!
            )
        );

        return Task.CompletedTask;
    }
}
