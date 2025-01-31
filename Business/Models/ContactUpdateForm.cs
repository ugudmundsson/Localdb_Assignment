namespace Business.Models;

public record ContactUpdateForm(int Id, string FirstName, string LastName, string Email, string? PhoneNumber);

