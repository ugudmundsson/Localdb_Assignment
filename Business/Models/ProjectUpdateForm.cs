namespace Business.Models;

public class ProjectUpdateForm()
{

    public int Id { get; set; }

    public string ProjectName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int CustomerId { get; set; }

    public int EmployeeId { get; set; }

    public int OrderId { get; set; }

    public int StatusId { get; set; }

    public Employee Employee { get; set; } = null!;

    public Order Order { get; set; } = null!;

    public Customer Customer { get; set; } = null!;

    public Status Status { get; set; } = null!;


}

