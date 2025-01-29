using Microsoft.AspNetCore.Identity;

namespace FinAspire.Infra.Models;

public class User : IdentityUser<long>
{
    public List<IdentityRole<long>>? Roles { get; set; }
}