namespace Contracts;

public class EnchereFinished
{
    public bool ItemSold { get; set; }
    public string EnchereId { get; set; }
    public string Winner { get; set; }
    public string Seller { get; set; }
    public int? Amount { get; set; }
}
