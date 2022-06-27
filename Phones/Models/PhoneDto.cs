using System.ComponentModel.DataAnnotations.Schema;

namespace Phones.Models;

public class PhoneDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    [Column(TypeName = "decimal(4,2)")]
    public decimal Price { get; set; }
    public string BrandName { get; set; }
}
