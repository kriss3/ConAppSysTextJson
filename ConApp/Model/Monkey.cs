
namespace ConApp.Model;
public record Monkey
{
    public string? Name { get; init; }
    public string? Location { get; init; }
    public string? Details { get; init; }
    public string? Image { get; init; }
    public int? Population { get; init; }
    public float? Latitude { get; init; }
    public float? Longitude { get; init; }
}
