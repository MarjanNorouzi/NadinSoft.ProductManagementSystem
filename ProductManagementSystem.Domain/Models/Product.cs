using ProductManagementSystem.Domain.Models.Common;

namespace ProductManagementSystem.Domain.Models;

public class Product : BaseEntity
{
    public string Name { get; set; } = default!;

    public DateTime ProduceDate { get; set; }

    public string ManufacturePhone { get; set; } = default!;

    public string ManufactureEmail { get; set; } = default!;

    public bool IsAvailable { get; set; }

    public int UserId { get; set; }

    public virtual ApplicationUser User { get; set; }
}
