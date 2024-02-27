using Contracts;
using MassTransit;
using MongoDB.Entities;
using RechercheService.Models;

namespace RechercheService;

public class BidPlacedConsumer : IConsumer<BidPlaced>
{
    public async Task Consume(ConsumeContext<BidPlaced> context)
    {
        Console.WriteLine("--> Consuming bid placed");

        var enchere = await DB.Find<Produit>().OneAsync(context.Message.EnchereId);

        if (context.Message.BidStatus.Contains("Accepted")
        && context.Message.Amount > enchere.CurrentHighBid)
        {
            enchere.CurrentHighBid = context.Message.Amount;
            await enchere.SaveAsync();
        }
    }
}
