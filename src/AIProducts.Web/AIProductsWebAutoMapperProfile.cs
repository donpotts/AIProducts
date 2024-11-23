using AIProducts.Products;
using AIProducts.ProductCategories;
using AutoMapper;

namespace AIProducts.Web;

public class AIProductsWebAutoMapperProfile : Profile
{
    public AIProductsWebAutoMapperProfile()
    {
        CreateMap<ProductDto, CreateUpdateProductDto>();
        CreateMap<ProductCategoryDto, CreateUpdateProductCategoryDto>();
        CreateMap<Pages.Products.CreateModalModel.CreateProductViewModel, CreateUpdateProductDto>();
        CreateMap<ProductDto, Pages.Products.EditModalModel.EditProductViewModel>();
        CreateMap<Pages.Products.EditModalModel.EditProductViewModel, CreateUpdateProductDto>();
    }
}
