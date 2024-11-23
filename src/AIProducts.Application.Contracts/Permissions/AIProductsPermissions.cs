namespace AIProducts.Permissions;

public static class AIProductsPermissions
{
    public const string GroupName = "AIProducts";

    public static class Products
    {
        public const string Default = GroupName + ".Products";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class ProductCategories
    {
        public const string Default = GroupName + ".ProductCategories";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
