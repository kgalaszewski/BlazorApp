using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class DummyDetails
{
    [Key]
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string Name { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string Value { get; set; }
}
