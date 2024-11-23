using AIProducts.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AIProducts.Permissions;

public class AIProductsPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var aIProductsGroup = context.AddGroup(AIProductsPermissions.GroupName, L("Permission:AIProducts"));

        var productsPermission = aIProductsGroup.AddPermission(AIProductsPermissions.Products.Default, L("Permission:Products"));
        productsPermission.AddChild(AIProductsPermissions.Products.Create, L("Permission:Products.Create"));
        productsPermission.AddChild(AIProductsPermissions.Products.Edit, L("Permission:Products.Edit"));
        productsPermission.AddChild(AIProductsPermissions.Products.Delete, L("Permission:Products.Delete"));
        var productCategoriesPermission = aIProductsGroup.AddPermission(AIProductsPermissions.ProductCategories.Default, L("Permission:ProductCategories"));
        productCategoriesPermission.AddChild(AIProductsPermissions.ProductCategories.Create, L("Permission:ProductCategories.Create"));
        productCategoriesPermission.AddChild(AIProductsPermissions.ProductCategories.Edit, L("Permission:ProductCategories.Edit"));
        productCategoriesPermission.AddChild(AIProductsPermissions.ProductCategories.Delete, L("Permission:ProductCategories.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AIProductsResource>(name);
    }
}
