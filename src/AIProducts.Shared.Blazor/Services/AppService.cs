using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Principal;
using System.Text.Json.Serialization;
using System.Web;
using AIProducts.Shared.Blazor.Authentication;
using AIProducts.Shared.Blazor.Models;
using AIProducts.Shared.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using MudBlazor;

namespace AIProducts.Shared.Blazor.Services;

public class AppService
{
    private readonly HttpClient httpClient;
    private readonly JwtAuthenticationStateProvider authenticationStateProvider;

    public AppService(
        HttpClient httpClient,
        AuthenticationStateProvider authenticationStateProvider)
    {
        this.httpClient = httpClient;
        this.authenticationStateProvider
            = authenticationStateProvider as JwtAuthenticationStateProvider
                ?? throw new InvalidOperationException();
    }

    private static async Task HandleResponseErrorsAsync(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode
            && response.StatusCode != HttpStatusCode.Unauthorized
            && response.StatusCode != HttpStatusCode.NotFound)
        {
            string? message = await response.Content.ReadFromJsonAsync<string>();
            throw new Exception(message);
        }

        response.EnsureSuccessStatusCode();
    }

    public async Task RegisterUserAsync(User registerModel)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Post, "api/identity/users");
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(registerModel);

        HttpResponseMessage response = await httpClient.SendAsync(request);// ("/api/Users", registerModel);

        await HandleResponseErrorsAsync(response);
    }

    public async Task AccountRegisterAsync(string userName, string emailAddress, string password, string appName)
    {
        HttpRequestMessage request = new(HttpMethod.Post, "api/account/register");
        request.Content = JsonContent.Create(new { userName, emailAddress, password, appName });
        HttpResponseMessage response = await httpClient.SendAsync(request);
        await HandleResponseErrorsAsync(response);
    }

    public async Task ChangePasswordAsync(string userName, string currentPassword, string newPassword)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Post, $"api/account/my-profile/change-password");
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(new { currentPassword, newPassword });

        var response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);
    }

    public async Task<PagedResultDto<User>> ListUsersAsync(string orderby, int skip, int? top)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        Uri uri = new(httpClient.BaseAddress, "api/identity/users");
        uri = GetUri(uri, top, skip, orderby);

        HttpRequestMessage request = new(HttpMethod.Get, uri);
        request.Headers.Add("Authorization", $"Bearer {token}");

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);

        return await response.Content.ReadFromJsonAsync<PagedResultDto<User>>();
    }

    public async Task<User?> GetUserByIdAsync(string id)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Get, $"api/identity/users/{id}");
        request.Headers.Add("Authorization", $"Bearer {token}");

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);

        return await response.Content.ReadFromJsonAsync<User>();
    }

    public async Task<RoleItemsDto<RoleItems>> GetRolesByUserIdAsync(string id)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Get, $"api/identity/users/{id}/roles");
        request.Headers.Add("Authorization", $"Bearer {token}");

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);

        return await response.Content.ReadFromJsonAsync<RoleItemsDto<RoleItems>>();
    }

    public async Task<RoleItems> GetRoleByIdAsync(string id)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Get, $"api/identity/roles/{id}");
        request.Headers.Add("Authorization", $"Bearer {token}");

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);

        return await response.Content.ReadFromJsonAsync<RoleItems>();
    }

    public async Task<RoleItemsDto<RoleItems>> GetAllRolesAsync()
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Get, $"api/identity/roles/all");
        request.Headers.Add("Authorization", $"Bearer {token}");

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);

        return await response.Content.ReadFromJsonAsync<RoleItemsDto<RoleItems>>();
    }

    public async Task<RoleItemsDto<RoleItems>> ListRolesAsync(string orderby, int skip, int? top)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        Uri uri = new(httpClient.BaseAddress, "api/identity/roles");
        uri = GetUri(uri, top, skip, orderby);

        HttpRequestMessage request = new(HttpMethod.Get, uri);
        request.Headers.Add("Authorization", $"Bearer {token}");

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);

        return await response.Content.ReadFromJsonAsync<RoleItemsDto<RoleItems>>();
    }

    public class RoleNames
    {
        public List<string> roleNames { get; set; }
    }

    public async Task ModifyRolesAsync(string key, IEnumerable<string> roleNames)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Put, $"api/identity/users/{key}/roles");
        request.Headers.Add("Authorization", $"Bearer {token}");

        RoleNames roles = new RoleNames
        {
            roleNames = roleNames.ToList()
        };

        request.Content = JsonContent.Create(roles);

        var response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);
    }

    public async Task ModifyPermissionsAsync(string providerName, string providerKey, List<object> permissions)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Put, $"api/permission-management/permissions?providerName={providerName}&providerKey={providerKey}");
        request.Headers.Add("Authorization", $"Bearer {token}");

        var content = new { permissions = permissions };

        request.Content = JsonContent.Create(content);

        var response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);
    }

    public async Task<PermissionsDto> GetPermissionsAsync(string providerName, string providerKey)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");
        HttpRequestMessage request = new(HttpMethod.Get, $"api/permission-management/permissions?providerName={providerName}&providerKey={providerKey}");

        request.Headers.Add("Authorization", $"Bearer {token}");

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);

        return await response.Content.ReadFromJsonAsync<PermissionsDto>();
    }


    public async Task UpdateUserAsync(string id, User data)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Put, $"api/identity/users/{id}");
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(data);

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);
    }

    public async Task DeleteUserAsync(string id)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Delete, $"api/identity/users/{id}");
        request.Headers.Add("Authorization", $"Bearer {token}");

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);
    }

    public async Task AddRoleAsync(RoleItems roleModel)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Post, "api/identity/roles");
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(roleModel);

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);
    }

    public async Task UpdateRoleAsync(string id, RoleItems data)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Put, $"api/identity/roles/{id}");
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(data);

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);
    }

    public async Task DeleteRoleAsync(string id)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Delete, $"api/identity/roles/{id}");
        request.Headers.Add("Authorization", $"Bearer {token}");

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);
    }

    public Uri GetUri(Uri uri, int? top = null, int? skip = null, string orderby = null)
    {
        UriBuilder uriBuilder = new UriBuilder(uri);
        NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(uriBuilder.Query);

        if (top.HasValue)
        {
            nameValueCollection["MaxResultCount"] = $"{top}";
        }

        if (skip.HasValue)
        {
            nameValueCollection["SkipCount"] = $"{skip}";
        }

        if (!string.IsNullOrEmpty(orderby))
        {
            nameValueCollection["Sorting"] = orderby ?? "";
        }

        uriBuilder.Query = nameValueCollection.ToString();
        return uriBuilder.Uri;
    }

        
    public async Task<PagedResultDto<Product>> ListProductsAsync(string orderby, int skip, int? top)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        Uri uri = new(httpClient.BaseAddress, "api/app/product");
        uri = GetUri(uri, top, skip, orderby);

        HttpRequestMessage request = new(HttpMethod.Get, uri);
        request.Headers.Add("Authorization", $"Bearer {token}");

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);

        return await response.Content.ReadFromJsonAsync<PagedResultDto<Product>>();
    }
        
    public async Task<Product[]?> ListProductAsync()
    {
        string token = authenticationStateProvider.Token
           ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Get, "/api/product");
        request.Headers.Authorization = new("Bearer", token);

        var response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);

        return await response.Content.ReadFromJsonAsync<Product[]>();
    }

    public async Task<Product?> GetProductByIdAsync(long id)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Get, $"api/app/product/{id}");
        request.Headers.Add("Authorization", $"Bearer {token}");

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);

        return await response.Content.ReadFromJsonAsync<Product>();
    }

    public async Task UpdateProductAsync(long id, Product data)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Put, $"api/app/product/{id}");
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(data);

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);
    }

    public async Task<Product?> InsertProductAsync(Product data)
    {
        data.Id = 0;
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Post, "api/app/product");
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(data);

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);

        return await response.Content.ReadFromJsonAsync<Product>();
    }

    public async Task DeleteProductAsync(long id)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Delete, $"api/app/product/{id}");
        request.Headers.Add("Authorization", $"Bearer {token}");

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);
    }

        
    public async Task<PagedResultDto<ProductCategory>> ListProductCategoriesAsync(string orderby, int skip, int? top)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        Uri uri = new(httpClient.BaseAddress, "api/app/product-category");
        uri = GetUri(uri, top, skip, orderby);

        HttpRequestMessage request = new(HttpMethod.Get, uri);
        request.Headers.Add("Authorization", $"Bearer {token}");

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);

        return await response.Content.ReadFromJsonAsync<PagedResultDto<ProductCategory>>();
    }
        
    public async Task<ProductCategory[]?> ListProductCategoryAsync()
    {
        string token = authenticationStateProvider.Token
           ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Get, "/api/product-category");
        request.Headers.Authorization = new("Bearer", token);

        var response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);

        return await response.Content.ReadFromJsonAsync<ProductCategory[]>();
    }

    public async Task<ProductCategory?> GetProductCategoryByIdAsync(long id)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Get, $"api/app/product-category/{id}");
        request.Headers.Add("Authorization", $"Bearer {token}");

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);

        return await response.Content.ReadFromJsonAsync<ProductCategory>();
    }

    public async Task UpdateProductCategoryAsync(long id, ProductCategory data)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Put, $"api/app/product-category/{id}");
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(data);

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);
    }

    public async Task<ProductCategory?> InsertProductCategoryAsync(ProductCategory data)
    {
        data.Id = 0;
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Post, "api/app/product-category");
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(data);

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);

        return await response.Content.ReadFromJsonAsync<ProductCategory>();
    }

    public async Task DeleteProductCategoryAsync(long id)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Delete, $"api/app/product-category/{id}");
        request.Headers.Add("Authorization", $"Bearer {token}");

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);
    }

    
    
    public async Task<string?> UploadImageAsync(Stream stream, int bufferSize, string contentType)
    {
        string token = authenticationStateProvider.Token
           ?? throw new Exception("Not authorized");

        MultipartFormDataContent content = [];
        StreamContent fileContent = new(stream, bufferSize);
        fileContent.Headers.ContentType = new(contentType);
        content.Add(fileContent, "image", "image");

        HttpRequestMessage request = new(HttpMethod.Post, $"/api/image");
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = content;

        var response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);

        return await response.Content.ReadFromJsonAsync<string>();
    }

    public async Task<string?> UploadImageAsync(IBrowserFile image)
    {
        using var stream = image.OpenReadStream(image.Size);

        return await UploadImageAsync(stream, Convert.ToInt32(image.Size), image.ContentType);
    }
}
