using ProductManagementSystem.Application.Common.Interfaces;

namespace ProductManagementSystem.Application.Securities;

public class UserContext : IUserContext
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
