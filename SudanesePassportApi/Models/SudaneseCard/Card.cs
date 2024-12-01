using System.ComponentModel.DataAnnotations;

namespace SudanesePassportApi.Models.SudaneseCard;

public class Card
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public required string Name { get; set; }
    [Required]
    public required string NationalId { get; set; }
}
