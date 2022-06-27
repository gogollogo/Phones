

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phones.Entities;

public class Phone
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    [Column(TypeName = "decimal(4,2)")]
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public int BrandId { get; set; }
    [ForeignKey("BrandId")]
    public virtual Brand Brand { get; set; }

}
