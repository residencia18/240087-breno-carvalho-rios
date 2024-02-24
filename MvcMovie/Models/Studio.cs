namespace MvcMovie.Models;

public class Studio
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Country { get; set; }
    public required string Site { get; set; }
    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
