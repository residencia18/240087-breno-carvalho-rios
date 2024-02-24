using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class NewMovieInputModel
{
    public string? Title { get; set; }

    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    public decimal Price { get; set; }
    public int StudioId { get; set; }
    public ICollection<int> Artists { get; set; } = new List<int>();
}
