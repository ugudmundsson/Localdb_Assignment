using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class EmployeesEntity
{
    [Key]
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    [ForeignKey(nameof(RoleId))]
    public int RoleId { get; set; }
    public RolesEntity RolesName { get; set; } = null!;

    public ICollection<ProjectEntity> Projects { get; set; } = [];

}
