using System.ComponentModel.DataAnnotations;

namespace FinAspire.Core.Request.Categories;

public class DeleteCategoryRequest: BaseRequest
{
    [Required(ErrorMessage = "Id is required")]
    public long Id { get; set; }
}