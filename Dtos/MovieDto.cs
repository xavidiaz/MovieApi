namespace MovieApi.Dtos;

public record MovieDto(int Id, string Title, string Genre, string Director, int ReleaseYear, int DurationMinutes, double Rating, string? Description);
