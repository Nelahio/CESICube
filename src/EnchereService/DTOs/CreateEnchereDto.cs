using System.ComponentModel.DataAnnotations;

namespace EnchereService.DTOs;

public class CreateEnchereDto
{
    [Required]
    public string Make { get; set; }
    [Required]
    public string ProductName { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public string Color { get; set; }
    [Required]
    public int? Size { get; set; }
    [Required]
    public string Comments { get; set; }
    [Required]
    public string ImageUrl { get; set; }
    [Required]
    public int ReservePrice { get; set; }
    [Required]
    public DateTime AuctionEnd { get; set; }
}
