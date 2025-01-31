namespace Business.Models;

public record Project(int Id,
                      string ProjectName, 
                      string Description, 
                      string Status, 
                      DateTime Startdate, 
                      DateTime Enddate, 
                      int CustomId,
                      int EmployeeId,
                      int OrderId);

