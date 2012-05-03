using System.ComponentModel.DataAnnotations;

namespace personal_website.Models
{
  public class News
  {
    [Required]
    public string Id    { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; }

    [Required]
    [StringLength(500)]
    [DataType(DataType.MultilineText)]
    public string Body  { get; set; }
  }
}