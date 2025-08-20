using System.ComponentModel.DataAnnotations;

namespace PD421_MVC_Shop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        public List<Product> Products { get; set; } = []; // Initialize to an empty collection
    }
}
