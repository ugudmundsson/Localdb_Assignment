namespace Business.Dtos;

public class EmployeesRegistrationForm
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int RoleId { get; set; }
}