using System;
using AIProducts.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace AIProducts.ProductCategories;

public class ProductCategoryAppService :
    CrudAppService<
        ProductCategory, //The ProductCategory entity
        ProductCategoryDto, //Used to show product categories
        int, //Primary key of the product category entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateProductCategoryDto>, //Used to create/update a product category
    IProductCategoryAppService //implement the IProductCategoryAppService
{
    public ProductCategoryAppService(IRepository<ProductCategory, int> repository)
        : base(repository)
    {
        GetPolicyName = AIProductsPermissions.ProductCategories.Default;
        GetListPolicyName = AIProductsPermissions.ProductCategories.Default;
        CreatePolicyName = AIProductsPermissions.ProductCategories.Create;
        UpdatePolicyName = AIProductsPermissions.ProductCategories.Edit;
        DeletePolicyName = AIProductsPermissions.ProductCategories.Delete;
    }
}
