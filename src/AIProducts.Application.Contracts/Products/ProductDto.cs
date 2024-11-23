using System;
using Volo.Abp.Application.Dtos;
using AIProducts.ProductCategories;

namespace AIProducts.Products;

public class ProductDto : AuditedEntityDto<int>
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public double Price { get; set; }

    public int StockQuantity { get; set; }

    public string? Photo { get; set; }

    public string? Notes { get; set; }

    public ProductCategoryDto? ProductCategory { get; set; }
}
