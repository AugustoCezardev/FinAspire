using System.ComponentModel.DataAnnotations;

namespace FinAspire.Core.Request.Account;

public class RegisterRequest: BaseRequest
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email is invalid")]
    public string Email { get; set; } = String.Empty;
    
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = String.Empty;
}