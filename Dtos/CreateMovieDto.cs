using System.ComponentModel.DataAnnotations;

namespace MovieApi.Dtos;

public record CreateMovieDto(
    [Required, StringLength(200)] string Title,
    [Required, StringLength(50)] string Genre,
    [Required, StringLength(100)] string Director,
    [Range(1888, 2100)] int ReleaseYear,
    [Range(1, 600)] int DurationMinutes,
    [Range(0, 10)] double Rating,
    [StringLength(1000)] string? Description
);
