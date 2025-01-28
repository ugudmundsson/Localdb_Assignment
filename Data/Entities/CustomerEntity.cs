using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Name { get; set; } = null!;


    [ForeignKey(nameof(ContactId))]
    public int ContactId { get; set; }
    public ContactEntity Contact { get; set; } = null!;
    

    public ICollection<ProjectEntity> Projects { get; set; } = [];


}
