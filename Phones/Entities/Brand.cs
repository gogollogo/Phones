using System.ComponentModel.DataAnnotations;

namespace Phones.Entities;

public class Brand
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual Phone Phones { get; set; }
}
