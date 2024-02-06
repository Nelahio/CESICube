using MongoDB.Driver;
using MongoDB.Entities;
using RechercheService.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();

await DB.InitAsync("RechercheDb", MongoClientSettings
.FromConnectionString(builder.Configuration.GetConnectionString("MongoDbConnection")));

await DB.Index<Produit>()
.Key(x => x.Make, KeyType.Text)
.Key(x => x.ProductName, KeyType.Text)
.Key(x => x.Color, KeyType.Text)
.CreateAsync();

app.Run();
