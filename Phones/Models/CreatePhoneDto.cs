using System.ComponentModel.DataAnnotations.Schema;
using Phones.Entities;

namespace Phones.Models
{
    public class CreatePhoneDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal Price { get; set; }
        public int BrandId { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }
    }
}
