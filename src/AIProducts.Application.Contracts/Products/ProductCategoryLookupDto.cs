using System;
using Volo.Abp.Application.Dtos;

namespace AIProducts.Products;

public class ProductCategoryLookupDto : EntityDto<int>
{
	public string? Name { get; set; }
}
