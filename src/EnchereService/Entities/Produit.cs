namespace EnchereService.Entities;

public class Produit
{
    public Guid Id { get; set; }
    public string Make { get; set; }
    public string ProductName { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public int? Size { get; set; }
    public string Comments { get; set; }
    public string ImageUrl { get; set; }

    //nav properties
    public Enchere Enchere { get; set; }
    public Guid EnchereId { get; set; }
}
