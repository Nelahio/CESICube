using Contracts;
using MassTransit;
using MongoDB.Entities;
using RechercheService.Models;

namespace RechercheService;

public class EnchereFinishedConsumer : IConsumer<EnchereFinished>
{
    public async Task Consume(ConsumeContext<EnchereFinished> context)
    {
        var enchere = await DB.Find<Produit>().OneAsync(context.Message.EnchereId);

        if (context.Message.ItemSold)
        {
            enchere.Winner = context.Message.Winner;
            enchere.SoldAmount = (int)context.Message.Amount;
        }

        enchere.Statut = "Finished";

        await enchere.SaveAsync();
    }
}
