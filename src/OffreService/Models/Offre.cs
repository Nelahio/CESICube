using MongoDB.Entities;

namespace OffreService;

public class Offre : Entity
{
    public string AuctionId { get; set; }
    public string Bidder { get; set; }
    public DateTime BidTime { get; set; } = DateTime.UtcNow;
    public int Amount { get; set; }
    public StatutOffre StatutOffre { get; set; }
}
