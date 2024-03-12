using Contracts;
using MassTransit;
using MongoDB.Entities;

namespace OffreService;

public class EnchereCreatedConsumer : IConsumer<EnchereCreated>
{
    public async Task Consume(ConsumeContext<EnchereCreated> context)
    {
        var enchere = new Enchere
        {
            ID = context.Message.Id.ToString(),
            Seller = context.Message.Seller,
            AuctionEnd = context.Message.AuctionEnd,
            ReservePrice = context.Message.ReservePrice
        };

        await enchere.SaveAsync();
    }
}
