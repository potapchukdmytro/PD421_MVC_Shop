using System.ComponentModel.DataAnnotations;

namespace PD421_MVC_Shop.ViewModels.Category
{
    public class UpdateCategoryVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Вкажіть ім'я")]
        [MaxLength(50, ErrorMessage = "Максимально довжина 50 символів")]
        public string? Name { get; set; }
        public string? UniqueNameError { get; set; }
    }
}
