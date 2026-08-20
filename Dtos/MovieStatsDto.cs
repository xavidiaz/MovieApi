namespace MovieApi.Dtos;

public record MovieStatsDto(int TotalMovies, double AverageRating, int AverageDurationMinutes, int OldestReleaseYear);
