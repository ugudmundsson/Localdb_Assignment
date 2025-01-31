using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class OrderEntity
{
    [Key]
    public int Id { get; set; }

    public string OrderName { get; set; } = null!;

    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
