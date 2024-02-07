using System.Text.Json;
using MongoDB.Driver;
using MongoDB.Entities;
using RechercheService.Models;
using RechercheService.Services;

namespace RechercheService.Data;

public class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {

        await DB.InitAsync("RechercheDb", MongoClientSettings
        .FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));

        await DB.Index<Produit>()
        .Key(x => x.Make, KeyType.Text)
        .Key(x => x.ProductName, KeyType.Text)
        .Key(x => x.Color, KeyType.Text)
        .CreateAsync();

        var count = await DB.CountAsync<Produit>();

        using var scope = app.Services.CreateScope();

        var httpClient = scope.ServiceProvider.GetRequiredService<EnchereSvcHttpClient>();

        var produits = await httpClient.GetProduitsForSearchDb();

        Console.WriteLine(produits.Count + " retournés du service enchere");

        if (produits.Count > 0) await DB.SaveAsync(produits);
    }
}
