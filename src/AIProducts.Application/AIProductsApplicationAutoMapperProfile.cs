using AIProducts.Products;
using AIProducts.ProductCategories;
using AutoMapper;

namespace AIProducts;

public class AIProductsApplicationAutoMapperProfile : Profile
{
    public AIProductsApplicationAutoMapperProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<CreateUpdateProductDto, Product>();
        CreateMap<ProductCategory, ProductCategoryDto>();
        CreateMap<CreateUpdateProductCategoryDto, ProductCategory>();
        CreateMap<ProductCategory, AIProducts.Products.ProductCategoryLookupDto>();
    }
}
