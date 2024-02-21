using Contracts;
using MassTransit;
using MongoDB.Entities;
using RechercheService.Models;

namespace RechercheService.Consumers;

public class EnchereDeletedConsumer : IConsumer<EnchereDeleted>
{
    public async Task Consume(ConsumeContext<EnchereDeleted> context)
    {
        Console.WriteLine("--> Consuming EnchereDeleted : " + context.Message.Id);

        var result = await DB.DeleteAsync<Produit>(context.Message.Id);

        if (!result.IsAcknowledged)
            throw new MessageException(typeof(EnchereDeleted), "Erreur lors de la suppression de l'enchère");
    }
}
