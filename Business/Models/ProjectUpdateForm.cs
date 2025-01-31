namespace Business.Models;

public record ProjectUpdateForm(int Id,
                                string ProjectName,
                                string Description,
                                string Status,
                                DateTime StartDate,
                                DateTime EndDate,
                                int CustomerId,
                                int EmployeeId,
                                int OrderId);

