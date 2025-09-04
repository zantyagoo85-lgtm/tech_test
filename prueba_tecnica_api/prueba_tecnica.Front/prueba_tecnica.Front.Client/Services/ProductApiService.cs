using System.Net.Http.Json;
using prueba_tecnica.Application.DTOs.Common;
using prueba_tecnica.Application.DTOs;

public class ProductApiService
{
    private readonly HttpClient _httpClient;

    public ProductApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResponse<List<ProductDto>>?> GetAllProductsAsync()
    {
        return await _httpClient.GetFromJsonAsync<ApiResponse<List<ProductDto>>>("api/Product/getAllProduct");
    }

    public async Task<ApiResponse<ProductDto>?> GetProductById(int? id)
    {
        return await _httpClient.GetFromJsonAsync<ApiResponse<ProductDto>>($"api/Product/getProductById?id={id}");
    }

    public async Task<ApiResponse<ProductDto>?> DeleteProductAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Product/deleteProductById?id={id}");
        return await response.Content.ReadFromJsonAsync<ApiResponse<ProductDto>>();
    }

    public async Task<ApiResponse<ProductDto>?> CreateProductAsync(ProductDto product)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Product/registerProduct", product);
        return await response.Content.ReadFromJsonAsync<ApiResponse<ProductDto>>();
    }

    public async Task<ApiResponse<ProductDto>?> UpdateProductAsync(ProductDto product)
    {
        var response = await _httpClient.PutAsJsonAsync("api/Product/updateProductById", product);
        return await response.Content.ReadFromJsonAsync<ApiResponse<ProductDto>>();
    }
}
