using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;

public class DummyImage
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int DummyId { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string ImageUrl { get; set; }

    [ForeignKey("DummyId")]
    public virtual Dummy Dummy { get; set; }
}
