using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movies_api.Models {
  public class Movie {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public string? title { get; set; }
    public string? poster { get; set; }
    public DateTime release_date { get; set; }

    public int rating { get; set; }
  }
}