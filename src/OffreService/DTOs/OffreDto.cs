namespace OffreService;

public class OffreDto
{
    public string Id { get; set; }
    public string AuctionId { get; set; }
    public string Bidder { get; set; }
    public DateTime BidTime { get; set; }
    public int Amount { get; set; }
    public string StatutOffre { get; set; }
}
