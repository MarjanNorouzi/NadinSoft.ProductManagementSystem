using DanayanCrowd.Data.Entities.Common;

namespace Ordering.Domain.Models;

public class Product : BaseEntity
{
    public string Name { get; set; } = default!;

    public DateTime ProduceDate { get; set; }

    public string ManufacturePhone { get; set; } = default!;

    public string ManufactureEmail { get; set; } = default!;

    public bool IsAvailable { get; set; }
}
