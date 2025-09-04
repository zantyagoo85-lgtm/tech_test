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

    public async Task<ApiResponse<List<ProductDto>>> GetAllProductsAsync()
    {
        return await _httpClient.GetFromJsonAsync<ApiResponse<List<ProductDto>>>("api/Product/getAllProduct");
    }
}
