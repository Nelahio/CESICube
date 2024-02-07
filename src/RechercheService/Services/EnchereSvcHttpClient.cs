using MongoDB.Entities;
using RechercheService.Models;

namespace RechercheService.Services;

public class EnchereSvcHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public EnchereSvcHttpClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<List<Produit>> GetProduitsForSearchDb()
    {
        var lastUpdated = await DB.Find<Produit, string>()
        .Sort(x => x.Descending(x => x.UpdatedAt))
        .Project(x => x.UpdatedAt.ToString())
        .ExecuteFirstAsync();

        return await _httpClient.GetFromJsonAsync<List<Produit>>(_configuration["EnchereServiceUrl"] + "/api/encheres?date=" + lastUpdated);
    }
}
