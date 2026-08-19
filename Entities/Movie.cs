using System.ComponentModel.DataAnnotations;

namespace MovieApi.Entities;

public class Movie
{
    public int Id { get; set; }

    [Required, StringLength(200)]
    public required string Title { get; set; }

    [Required, StringLength(200)]
    public required string Genre { get; set; }

    [Required, StringLength(100)]
    public required string Director { get; set; }

    [Range(1888, 2100)]
    public int ReleaseYear { get; set; }

    [Range(1, int.MaxValue)]
    public int DurationMinutes { get; set; }

    [Range(0, 10)]
    public double Rating { get; set; }

    public string? Description { get; set; }

}
