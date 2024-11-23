using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AIProducts.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace AIProducts.Web.Pages.Products;

public class CreateModalModel : AIProductsPageModel
{
    [BindProperty]
    public CreateProductViewModel Product { get; set; } = null!;

    public List<SelectListItem> ProductCategories { get; set; } = null!;

    private readonly IProductAppService _productAppService;

    public CreateModalModel(IProductAppService productAppService)
    {
        _productAppService = productAppService;
    }

    public async Task OnGetAsync()
    {
        Product = new CreateProductViewModel();

        var productCategoryLookup = await _productAppService.GetProductCategoryLookupAsync();
        ProductCategories = productCategoryLookup.Items
            .OrderBy(x => x.Name)
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();
        ProductCategories.Insert(0, new SelectListItem(string.Empty, null));
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _productAppService.CreateAsync(
            ObjectMapper.Map<CreateProductViewModel, CreateUpdateProductDto>(Product)
            );
        return NoContent();
    }

    public class CreateProductViewModel
    {

        public string? Name { get; set; }

        public string? Description { get; set; }

        public double Price { get; set; }

        public int StockQuantity { get; set; }

        public string? Photo { get; set; }

        public string? Notes { get; set; }

        [SelectItems(nameof(ProductCategories))]
        [DisplayName("ProductCategory")]
        public int? ProductCategoryId { get; set; }
    }
}
