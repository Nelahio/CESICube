namespace EnchereService.DTOs;

public class EnchereDto
{
    public Guid Id { get; set; }
    public int ReservePrice { get; set; } = 0;
    public string Seller { get; set; }
    public string Winner { get; set; }
    public int SoldAmount { get; set; }
    public int CurrentHighBid { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime AuctionEnd { get; set; }
    public string Statut { get; set; }
    public string Make { get; set; }
    public string ProductName { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public int? Size { get; set; }
    public string Comments { get; set; }
    public string ImageUrl { get; set; }
}
