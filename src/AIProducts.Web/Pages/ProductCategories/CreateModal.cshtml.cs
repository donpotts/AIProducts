using System.Threading.Tasks;
using AIProducts.ProductCategories;
using Microsoft.AspNetCore.Mvc;

namespace AIProducts.Web.Pages.ProductCategories;

public class CreateModalModel : AIProductsPageModel
{
    [BindProperty]
    public CreateUpdateProductCategoryDto ProductCategory { get; set; } = null!;

    private readonly IProductCategoryAppService _productCategoryAppService;

    public CreateModalModel(IProductCategoryAppService productCategoryAppService)
    {
        _productCategoryAppService = productCategoryAppService;
    }

    public void OnGet()
    {
        ProductCategory = new CreateUpdateProductCategoryDto();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _productCategoryAppService.CreateAsync(ProductCategory);
        return NoContent();
    }
}
