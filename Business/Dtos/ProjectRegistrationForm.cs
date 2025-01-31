namespace Business.Dtos;

public class ProjectRegistrationForm

{
    public string ProjectName { get; set; } = null!;

    public string ProjectDescription { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int EmployeeId { get; set; }

    public int CustomerId { get; set; }

    public int OrderId { get; set; }


}
