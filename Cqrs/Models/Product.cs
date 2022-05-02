using System.ComponentModel.DataAnnotations;

namespace Cqrs.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public int Quantity { get; set; }
    }
}