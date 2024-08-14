using Microsoft.AspNetCore.Identity;

namespace ProductManagementSystem.Domain.Models;

public class ApplicationUser : IdentityUser<int>
{
    public virtual ICollection<Product> Products { get; } = [];
}
