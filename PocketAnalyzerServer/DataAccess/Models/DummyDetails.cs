using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class DummyDetails
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Value { get; set; }
}
