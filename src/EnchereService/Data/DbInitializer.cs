
using EnchereService.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnchereService.Data;

public class DbInitializer
{
	public static void InitDb(WebApplication app)
	{
		using var scope = app.Services.CreateScope();

		SeedData(scope.ServiceProvider.GetService<EnchereDbContext>());
	}

	private static void SeedData(EnchereDbContext context)
	{
		context.Database.Migrate();
		if (context.Encheres.Any())
		{
			Console.WriteLine("Données déjà présentes - pas besoin d'en ajouter");
			return;
		}

		var encheres = new List<Enchere>(){
            //encheres

            // 1 Parfum Lolita Lempicka Sweet
 		new Enchere
			{
				Id = Guid.Parse("afbee524-5972-4075-8800-7d1f9d7b0a0c"),
				Statut = Statut.Live,
				ReservePrice = 300,
				Seller = "bob",
				AuctionEnd = DateTime.UtcNow.AddDays(10),
				Produit = new Produit
				{
					Make = "Lolita Lempicka",
					ProductName = "Sweet",
					Color = "Crystal Red",
					Year = 2020,
					Size = 50,
					Comments = "Eau de parfum 50ml",
					ImageUrl = "https://cdn.pixabay.com/photo/2017/03/14/11/36/perfume-2142792_1280.jpg"
				}
			},

// 2 Dior J'adore
new Enchere
{
	Id = Guid.Parse("c8c3ec17-01bf-49db-82aa-1ef80b833a9f"),
	Statut = Statut.Live,
	ReservePrice = 500,
	Seller = "alice",
	AuctionEnd = DateTime.UtcNow.AddDays(60),
	Produit = new Produit
	{
		Make = "Dior",
		ProductName = "J'adore",
		Color = "Crystal Amber",
		Year = 2020,
		Size = 50,
		Comments = "Eau de parfum 50ml",
		ImageUrl = "https://cdn.pixabay.com/photo/2017/03/14/11/36/perfume-2142792_1280.jpg"
	}
},

// 3 Nina Ricci Nina Rouge
new Enchere
{
	Id = Guid.Parse("bbab4d5a-8565-48b1-9450-5ac2a5c4a654"),
	Statut = Statut.Live,
	Seller = "bob",
	AuctionEnd = DateTime.UtcNow.AddDays(4),
	Produit = new Produit
	{
		Make = "Nina Ricci",
		ProductName = "Nina Rouge",
		Color = "Red",
		Year = 2020,
		Size = 50,
		Comments = "Eau de parfum 50ml",
		ImageUrl = "https://cdn.pixabay.com/photo/2017/03/14/11/36/perfume-2142792_1280.jpg"
	}
},

// 4 Nina Ricci Illusion
new Enchere
{
	Id = Guid.Parse("155225c1-4448-4066-9886-6786536e05ea"),
	Statut = Statut.ReserveNotMet,
	ReservePrice = 200,
	Seller = "bob",
	AuctionEnd = DateTime.UtcNow.AddDays(4),
	Produit = new Produit
	{
		Make = "Nina Ricci",
		ProductName = "Illusion",
		Color = "Crystal Pink",
		Year = 2020,
		Size = 30,
		Comments = "Eau de parfum 30ml",
		ImageUrl = "https://cdn.pixabay.com/photo/2017/03/14/11/36/perfume-2142792_1280.jpg"
	}
},

// 5 Nina Ricci L'air du temps
new Enchere
{
	Id = Guid.Parse("466e4744-4dc5-4987-aae0-b621acfc5e39"),
	Statut = Statut.Live,
	ReservePrice = 200,
	Seller = "alice",
	AuctionEnd = DateTime.UtcNow.AddDays(30),
	Produit = new Produit
	{
		Make = "Nina Ricci",
		ProductName = "L'air du temps",
		Color = "Crystal Yellow",
		Year = 2020,
		Size = 100,
		Comments = "Eau de parfum 100ml",
		ImageUrl = "https://cdn.pixabay.com/photo/2017/03/14/11/36/perfume-2142792_1280.jpg"
	}
},

// 6 Nina Ricci Nina Nature
new Enchere
{
	Id = Guid.Parse("dc1e4071-d19d-459b-b848-b5c3cd3d151f"),
	Statut = Statut.Live,
	ReservePrice = 200,
	Seller = "bob",
	AuctionEnd = DateTime.UtcNow.AddDays(45),
	Produit = new Produit
	{
		Make = "Nina Ricci",
		ProductName = "Nina Nature",
		Color = "Matte Water Green",
		Year = 2020,
		Size = 50,
		Comments = "Eau de parfum 50ml",
		ImageUrl = "https://cdn.pixabay.com/photo/2017/03/14/11/36/perfume-2142792_1280.jpg"
	}
},

// 7 Dior Miss Dior
new Enchere
{
	Id = Guid.Parse("47111973-d176-4feb-848d-0ea22641c31a"),
	Statut = Statut.Live,
	ReservePrice = 200,
	Seller = "bob",
	AuctionEnd = DateTime.UtcNow.AddDays(45),
	Produit = new Produit
	{
		Make = "Nina Ricci",
		ProductName = "Nina Nature",
		Color = "Matte Water Green",
		Year = 2020,
		Size = 50,
		Comments = "Eau de parfum 50ml",
		ImageUrl = "https://cdn.pixabay.com/photo/2017/03/14/11/36/perfume-2142792_1280.jpg"
	}
},

// 8 Dior Sauvage
new Enchere
{
	Id = Guid.Parse("6a5011a1-fe1f-47df-9a32-b5346b289391"),
	Statut = Statut.Live,
	Seller = "bob",
	AuctionEnd = DateTime.UtcNow.AddDays(19),
	Produit = new Produit
	{
		Make = "Dior",
		ProductName = "Sauvage",
		Color = "Crystal Blue",
		Year = 2020,
		Size = 50,
		Comments = "Eau de parfum 50ml",
		ImageUrl = "https://cdn.pixabay.com/photo/2017/03/14/11/36/perfume-2142792_1280.jpg"
	}
},

// 9 Dior Hypnotic Poison
new Enchere
{
	Id = Guid.Parse("40490065-dac7-46b6-acc4-df507e0d6570"),
	Statut = Statut.Live,
	ReservePrice = 400,
	Seller = "tom",
	AuctionEnd = DateTime.UtcNow.AddDays(20),
	Produit = new Produit
	{
		Make = "Dior",
		ProductName = "Hypnotic Poison",
		Color = "Crystal Red Purple",
		Year = 2020,
		Size = 50,
		Comments = "Eau de parfum 50ml",
		ImageUrl = "https://cdn.pixabay.com/photo/2017/03/14/11/36/perfume-2142792_1280.jpg"
	}
},

// 10 Dolce & Gabbana The One
new Enchere
{
	Id = Guid.Parse("3659ac24-29dd-407a-81f5-ecfe6f924b9b"),
	Statut = Statut.Live,
	ReservePrice = 100,
	Seller = "bob",
	AuctionEnd = DateTime.UtcNow.AddDays(48),
	Produit = new Produit
	{
		Make = "Dolce & Gabbana",
		ProductName = "The One",
		Color = "Crystal Amber Yellow",
		Year = 2020,
		Size = 50,
		Comments = "Eau de parfum 50ml",
		ImageUrl = "https://cdn.pixabay.com/photo/2017/03/14/11/36/perfume-2142792_1280.jpg"
	}
}


		};

		context.AddRange(encheres);
		context.SaveChanges();
	}
}
