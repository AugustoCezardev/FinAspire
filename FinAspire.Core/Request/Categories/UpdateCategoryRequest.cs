using System.ComponentModel.DataAnnotations;

namespace FinAspire.Core.Request.Categories;

public class UpdateCategoryRequest: BaseRequest
{
    [Required(ErrorMessage = "Id is required")]
    public long Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}