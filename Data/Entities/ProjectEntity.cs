using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public int Id { get; set; }

    public string ProjectName { get; set; } = null!;

    public string ProjectDescription { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime StartDate { get; set; }

    [NotMapped]
    public DateTime StartDateOnly => StartDate.Date;

    public DateTime EndDate { get; set; }
    
    [NotMapped]
    public DateTime EndDateOnly => EndDate.Date;

    [ForeignKey(nameof(EmployeeId))]
    public int EmployeeId { get; set; }
    public EmployeesEntity Employee { get; set; } = null!;


    [ForeignKey(nameof(OrderId))]
    public int OrderId { get; set; }
    public OrderEntity Order { get; set; } = null!;



    [ForeignKey(nameof(CustomerId))]
    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;


}
