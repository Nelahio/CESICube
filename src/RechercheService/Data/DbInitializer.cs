using System.Text.Json;
using MongoDB.Driver;
using MongoDB.Entities;
using RechercheService.Models;

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

        if (count == 0)
        {
            Console.WriteLine("Pas de données - en attente des données");
            var produitData = await File.ReadAllTextAsync("Data/encheres.json");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var produits = JsonSerializer.Deserialize<List<Produit>>(produitData, options);

            await DB.SaveAsync(produits);
        }
    }
}
