using System.ComponentModel.DataAnnotations;

namespace FinAspire.Core.Request.Categories;

public class CreateCategoryRequest: BaseRequest
{
    [Required(ErrorMessage = "Title is required")]
    [MaxLength(80, ErrorMessage = "Title must be less than 80 characters")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; } = string.Empty;
}