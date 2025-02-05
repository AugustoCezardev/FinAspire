namespace FinAspire.Core.Models.Account;

public class User
{
    public string Email { get; set; } = String.Empty;
    public Dictionary<string, string> Claims { get; set; } = [];
}