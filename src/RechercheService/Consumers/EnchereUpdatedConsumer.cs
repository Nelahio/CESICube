using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using RechercheService.Models;

namespace RechercheService;

public class EnchereUpdatedConsumer : IConsumer<EnchereUpdated>
{
    private readonly IMapper _mapper;

    public EnchereUpdatedConsumer(IMapper _mapper)
    {
        this._mapper = _mapper;
    }

    public async Task Consume(ConsumeContext<EnchereUpdated> context)
    {
        Console.WriteLine("--> Consumin enchere updated : " + context.Message.Id);

        var produit = _mapper.Map<Produit>(context.Message);

        var result = await DB.Update<Produit>()
        .Match(a => a.ID == context.Message.Id)
        .ModifyOnly(x => new
        {
            x.Color,
            x.Make,
            x.ProductName,
            x.Year,
            x.Size
        }, produit)
        .ExecuteAsync();

        if (!result.IsAcknowledged)
            throw new MessageException(typeof(EnchereUpdated), "Erreur lors de la mise à jour dans mongodb");
    }
}
