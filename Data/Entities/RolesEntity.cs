
using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class RolesEntity
{
    [Key]
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public ICollection<EmployeesEntity> Employees { get; set; } = [];
}
