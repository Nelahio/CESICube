using Contracts;
using EnchereService.Data;
using EnchereService.Entities;
using MassTransit;
using Microsoft.VisualBasic;

namespace EnchereService;

public class EnchereFinishedConsumer : IConsumer<EnchereFinished>
{
    private readonly EnchereDbContext _dbContext;

    public EnchereFinishedConsumer(EnchereDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Consume(ConsumeContext<EnchereFinished> context)
    {
        Console.WriteLine("--> Consuming enchere finished");

        var enchere = await _dbContext.Encheres.FindAsync(context.Message.EnchereId);

        if (context.Message.ItemSold)
        {
            enchere.Winner = context.Message.Winner;
            enchere.SoldAmount = context.Message.Amount;
        }

        enchere.Statut = enchere.SoldAmount > enchere.ReservePrice
        ? Statut.Finish : Statut.ReserveNotMet;

        await _dbContext.SaveChangesAsync();
    }
}
