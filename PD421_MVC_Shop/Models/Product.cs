using System.ComponentModel.DataAnnotations;

namespace PD421_MVC_Shop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        public string? Description { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public string? Image { get; set; }

        [Range(0, int.MaxValue)]
        public int Count { get; set; }

        // Navigation property to Category
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
