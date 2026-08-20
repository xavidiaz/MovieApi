namespace MovieApi.Dtos;

public record CreateMovieDto(string Title, string Genre, string Director, int ReleaseYear, int DurationMinutes, double Rating, string? Description);
