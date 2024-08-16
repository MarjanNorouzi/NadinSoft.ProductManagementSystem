namespace ProductManagementSystem.Application.Common.Interfaces;

public interface IUserContext
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}
