using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public  class ContactEntity
{

    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string FirstName { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string LastName { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string Email { get; set; } = null!;

    [Column(TypeName = "nvarchar(20)")]
    public string? PhoneNumber { get; set; }

    public ICollection<CustomerEntity> Customer { get; set; } = [];

}
