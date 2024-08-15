using Microsoft.AspNetCore.Identity;

namespace ProductManagementSystem.Domain.Models;

public class ApplicationUser(string userName) : IdentityUser<int>(userName)
{
    public virtual ICollection<Product> Products { get; } = [];
}
