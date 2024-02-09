using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using RechercheService.Models;

namespace RechercheService;

public class EnchereCreatedConsumer : IConsumer<EnchereCreated>
{
    private readonly IMapper _mapper;

    public EnchereCreatedConsumer(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task Consume(ConsumeContext<EnchereCreated> context)
    {
        Console.WriteLine("--> Consuming enchere created : " + context.Message.Id);

        var produit = _mapper.Map<Produit>(context.Message);

        if (produit.ProductName == "Foo") throw new ArgumentException("Impossible de vendre un produit avec le nom Foo");

        await produit.SaveAsync();
    }
}
