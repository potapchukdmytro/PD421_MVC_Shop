using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PD421_MVC_Shop.ViewModels.Product
{
    public class CreateProductVM
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        public string? Description { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Count { get; set; }
        public int CategoryId { get; set; }
        public IFormFile? Image { get; set; }
        public IEnumerable<Models.Category> Categories { get; set; } = [];
    }
}
