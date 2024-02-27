using System.Text;
using Contracts;
using EnchereService.Data;
using MassTransit;

namespace EnchereService;

public class BidPlacedConsumer : IConsumer<BidPlaced>
{
    private readonly EnchereDbContext _dbContext;

    public BidPlacedConsumer(EnchereDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Consume(ConsumeContext<BidPlaced> context)
    {
        Console.WriteLine("--> Consume bid placed");

        var enchere = await _dbContext.Encheres.FindAsync(context.Message.EnchereId);

        if (enchere.CurrentHighBid == null
        || context.Message.BidStatus.Contains("Accepted")
        && context.Message.Amount > enchere.CurrentHighBid)
        {
            enchere.CurrentHighBid = context.Message.Amount;
            await _dbContext.SaveChangesAsync();
        }
    }
}
