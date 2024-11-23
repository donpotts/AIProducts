using Microsoft.AspNetCore.Builder;
using AIProducts;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<AIProductsWebTestModule>();

public partial class Program
{
}
