using System.ComponentModel.DataAnnotations.Schema;

namespace Phones.Models
{
    public class UpdatePhoneDto
    {
        public string? Description { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal Price { get; set; }
    }
}
