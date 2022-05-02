using System.ComponentModel.DataAnnotations;

namespace Cqrs.ViewModels
{
    public class AddProduct
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public int Quantity { get; set; }
    }
}