namespace EnchereService.DTOs;

public class UpdateEnchereDto
{
    public string Make { get; set; }
    public string ProductName { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public int? Size { get; set; }
    public string Comments { get; set; }
}
